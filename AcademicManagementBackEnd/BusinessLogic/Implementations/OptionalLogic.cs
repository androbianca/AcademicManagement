using DataAccess.Abstractions;
using Entities;
using Microsoft.AspNetCore.Http;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Implementations
{
    public class OptionalLogic : BaseLogic, IOptionalLogic
    {

        public OptionalLogic(IRepository repository)
            : base(repository)
        {
        }


        public async Task<Optional> UploadFiles(IFormFile file, string googleForm, string year)
        {
            var optionalId = Guid.NewGuid();
            var path = "";
            // full path to file in temp location

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
                    if (!Directory.Exists("../../AcademicManagementFrontEnd/src/assets/files/" + optionalId.ToString() + "/"))
                    {
                        Directory.CreateDirectory("../../AcademicManagementFrontEnd/src/assets/files/" + optionalId.ToString() + "/");
                    }

                    path = "../../AcademicManagementFrontEnd/src/assets/files/" + optionalId.ToString() + "/";
                    // download files to server folder
                    using (var stream = new FileStream(path + file.FileName, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // create metadatas



                    // delete temp files after processing
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                }

            }
            var result = new Optional
            {
                Id = optionalId,
                Path = path,
                FileName = file.FileName,
                GoogleForm = googleForm,
                Year = Int32.Parse(year),

            };
            Create(result);


            return result;
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

        public void Create(Optional optional)
        {
            _repository.Insert(optional);
            _repository.Save();

        }

        public Optional Delete(Guid id)
        {
            var item = _repository.GetByFilter<Optional>(x => x.Id == id);
            _repository.Delete(item);
            _repository.Save();

            return item;

        }

        public ICollection<OptionalDto> GetAll()
        {
           var optionalDtos = new List<OptionalDto>();

            var optionals = _repository.GetAll<Optional>();

            foreach (var optional in optionals)
            {

                var optionalDto = new OptionalDto
                {
                    Path = optional.Path,
                    Filename = optional.FileName,
                    GoogleForm = optional.GoogleForm,
                    Id = optional.Id,
                    Year = optional.Year

                };

                optionalDtos.Add(optionalDto);
            }
            return optionalDtos;

        }

    }

}
