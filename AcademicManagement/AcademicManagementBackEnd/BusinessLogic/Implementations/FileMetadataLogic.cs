using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.IO;

using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace BusinessLogic.Implementations
{
    public class FileMetadataLogic : BaseLogic, IFileMetadataLogic
    {
        private IGradeLogic _gradeLogic;


        public FileMetadataLogic(IRepository repository, IGradeLogic gradeLogic)
            : base(repository)
        {
            _gradeLogic = gradeLogic;
        }

        public async Task<FileMetadataDto> UploadFiles(Guid courseId, IFormFile file, bool IsExcel, string id)
        {
            var isPost = false;
            var course = _repository.GetByFilter<Course>(x => x.Id == courseId);

            if (course == null)
                isPost = true;

            // full path to file in temp location
            FileMetadataDto result = null;

            if (file.Length > 0)
            {
                var filePath = Path.GetTempFileName();

                // copy files to temp location for checking
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // check if files valid
                if (CheckFileValid(filePath))
                {
                    // create folder if it doesn't exists
                    if (!Directory.Exists("../../AcademicManagementFrontEnd/src/assets/files/" + courseId.ToString() + "/"))
                    {
                        Directory.CreateDirectory("../../AcademicManagementFrontEnd/src/assets/files/" + courseId.ToString() + "/");
                    }

                    var path = "../../AcademicManagementFrontEnd/src/assets/files/" + courseId.ToString() + "/";
                    // download files to server folder
                    using (var stream = new FileStream(path + file.FileName, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var guid = isPost ? Guid.NewGuid() : courseId;

                    // create metadatas
                    result = new FileMetadataDto
                    { 
                        CourseId = guid,
                        Path = path,
                        FileName = file.FileName
                    };

                    if (IsExcel)
                    {
                        ImportDataFromExcel(path + file.FileName,courseId, id);
                    }

                    // delete temp files after processing
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                }

            }

            return result;
        }

        public async void ImportDataFromExcel(string path, Guid courseId, string id)
        {


            var existingfile = new FileInfo(path);
            // open and read the xlsx file.
            using (var package = new ExcelPackage(existingfile))
            {
                // get the work book in the file
                var workbook = package.Workbook;
                if (workbook != null)
                {

                    // get the first worksheet
                    var currentworksheet = workbook.Worksheets.First();

                    // read some data
                    int colcount = currentworksheet.Dimension.End.Column;  //get column count
                    int rowcount = currentworksheet.Dimension.End.Row;     //get row count


                    for(var row=2; row< rowcount; row++)
                    {
                        for(var column=2; column<colcount; column++)
                        {
                            var usercode = currentworksheet.Cells[row,1].Value.ToString().Trim();
                            var category = currentworksheet.Cells[1, column].Value.ToString().Trim();
                            var value = currentworksheet.Cells[row, column].Value.ToString().Trim();

                            var studPotentialUser = _repository.GetByFilter<PotentialUser>(x => x.UserCode == usercode);
                            var profPotentialUser = _repository.GetByFilter<PotentialUser>(x => x.UserCode == id);

                            var student = _repository.GetByFilter<Student>(x => x.PotentialUserId == studPotentialUser.Id);
                            var prof = _repository.GetByFilter<Professor>(x => x.PotentialUserId == profPotentialUser.Id);
                            var categoryId = _repository.GetByFilter<GradeCategory>(x => x.Name.ToLower() == category.ToLower()).Id;
                            var grade = new GradeDto
                            {
                                CourseId = courseId,
                                StudentId = student.Id,
                                ProfId = prof.Id,
                                CategoryId = categoryId,
                                Value = Int32.Parse(value)
                            };

                            _gradeLogic.Add(grade);
                        }
                    }
                          
                }
            }
        }



        public bool CheckFileValid(string filePath)
        {
            if (filePath == null)
                return false;

            byte[] BMP = { 66, 77 };
            byte[] DOC = { 208, 207, 17, 224, 161, 177, 26, 225 };
            byte[] JPG = { 255, 216, 255 };
            byte[] PDF = { 37, 80, 68, 70, 45 };
            byte[] PNG = { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82 };
            byte[] RAR = { 82, 97, 114, 33, 26, 7, 0 };
            byte[] ZIP_DOCX = { 80, 75, 3, 4 };

            FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);
            byte[] file = null;
            file = reader.ReadBytes(32);
            reader.Close();
            stream.Close();

            if (file.Take(2).SequenceEqual(BMP))
            {
                return true;
            }
            else if (file.Take(8).SequenceEqual(DOC))
            {
                return true;
            }
            else if (file.Take(3).SequenceEqual(JPG))
            {
                return true;
            }
            else if (file.Take(5).SequenceEqual(PDF))
            {
                return true;
            }
            else if (file.Take(16).SequenceEqual(PNG))
            {
                return true;
            }
            else if (file.Take(7).SequenceEqual(RAR))
            {
                return true;
            }
            else if (file.Take(4).SequenceEqual(ZIP_DOCX))
            {
                return true;
            }

            return false;
        }

        public FileMetadata Create(FileMetadataDto fileMetadataDto)
        {
            var newFileMetadata = new FileMetadata
            {
                Id = Guid.NewGuid(),
                CourseId = fileMetadataDto.CourseId,
                Path = fileMetadataDto.Path,
                FileName = fileMetadataDto.FileName
            };

            _repository.Insert(newFileMetadata);
            _repository.Save();

            return newFileMetadata;
        }

        public FileMetadata Update(FileMetadataDto fileMetadataDto, Guid id)
        {
            var file = _repository.GetByFilter<FileMetadata>(c => c.Id == id);


            if (file == null)
                return null;

            file.CourseId = fileMetadataDto.CourseId;
            file.Path = fileMetadataDto.Path;

            _repository.Update(file);
            _repository.Save();

            return file;
        }

        public FileMetadata Delete(Guid id)
        {
            var file = _repository.GetByFilter<FileMetadata>(f => f.Id == id);

            _repository.Delete(file);
            _repository.Save();

            if (File.Exists(file.Path + file.FileName))
            {
                File.Delete(file.Path + file.FileName);
            }

            return file;
        }

        public FileMetadataDto GetById(Guid id)
        {
            var file = _repository.GetByFilter<FileMetadata>(f => f.Id == id);

            var fileDto = new FileMetadataDto
            {
                CourseId = file.CourseId,
                Path = file.Path,
                FileName = file.FileName
            };

            return fileDto;
        }

        public ICollection<FileMetadataDto> GetByCourseId(Guid courseEntityId)
        {
            List<FileMetadataDto> fileDtos = new List<FileMetadataDto>();

            var files = _repository.GetAll<FileMetadata>();

            foreach (var file in files)
            {
                if (file.CourseId == courseEntityId)
                {
                    var fileDto = new FileMetadataDto
                    {
                        CourseId = file.CourseId,
                        Path = file.Path,
                        FileName = file.FileName
                    };

                    fileDtos.Add(fileDto);
                }
            }

            return fileDtos;
        }

        public ICollection<FileMetadataDto> GetAll()
        {
            List<FileMetadataDto> fileDtos = new List<FileMetadataDto>();

            var files = _repository.GetAll<FileMetadata>();

            foreach (var file in files)
            {
                var fileDto = new FileMetadataDto
                {
                    CourseId = file.CourseId,
                    Path = file.Path,
                    FileName = file.FileName
                };

                fileDtos.Add(fileDto);
            }

            return fileDtos;
        }

        public FileStreamResult GetFile(Guid id, ControllerBase controller)
        {
            var metadata = GetById(id);

            if (metadata == null)
                return null;

            Stream stream = new FileStream(metadata.Path + metadata.FileName, FileMode.Open);

            if (stream == null)
                return null;

            return controller.File(stream, "application/octet-stream", metadata.FileName);
        }
    }
}
