using Microsoft.AspNetCore.Http;

namespace NguyenHung.Service.Interfaces.Base;

public interface IFileService
{
    Task<string> UploadFile(IFormFile file);
    Task<Stream> GetFile(string fileName);
    Task<ICollection<string>> GetUrlAfterUploadingFile(List<IFormFile> files);
}