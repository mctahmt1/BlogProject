using BlogProject.Entity.DTOs.Images;
using BlogProject.Entity.Enums;
using Microsoft.AspNetCore.Http;

namespace BlogProject.Service.Helpers.Images
{
    public interface IImageHelper
    {
        Task<ImageUploadedDto> Upload(string name, IFormFile imageFile,ImageType imageType, string folderName = null);
        void Delete(string imageName);
    }
}
