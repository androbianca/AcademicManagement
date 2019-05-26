using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstractions
{
    public interface IFileMetadataLogic
    {
        Task<FileMetadataDto> UploadFiles(Guid courseId, IFormFile file, bool isExcel, string id);

        FileMetadata Create(FileMetadataDto fileMetadataDto);

        FileMetadata Update(FileMetadataDto fileMetadataDto, Guid fileEntityId);

        FileMetadata Delete(Guid fileEntityId);

        FileMetadataDto GetById(Guid fileEntityId);

        ICollection<FileMetadataDto> GetByCourseId(Guid courseEntityId);

        ICollection<FileMetadataDto> GetAll();

        bool CheckFileValid(string filePath);

        FileStreamResult GetFile(Guid fileEntityId, ControllerBase controller);
    }
}
