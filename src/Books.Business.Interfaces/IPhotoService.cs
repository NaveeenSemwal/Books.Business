using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Books.Business.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

        Task<DeletionResult> DeletePhotoAsync(string PublicId);
    }
}
