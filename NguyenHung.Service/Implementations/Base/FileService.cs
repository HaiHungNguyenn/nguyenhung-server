using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NguyenHung.Common.Attributes;
using NguyenHung.Common.Helpers;
using NguyenHung.Common.Settings;
using NguyenHung.Service.Interfaces.Base;

namespace NguyenHung.Service.Implementations.Base;
[ServiceRegister]
public class FileService : IFileService
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly IConfiguration _configuration;

    private readonly AzureSetting _azureSetting;

    public FileService(IConfiguration configuration)
    {
        _configuration = configuration;
        var connectionString = configuration.GetConnectionString("AzureConnectionString") ?? throw new Exception("Missing Azure connection string");
        _azureSetting = new AzureSetting { AzureBlobStorage = connectionString };
        _blobServiceClient = new BlobServiceClient(_azureSetting.AzureBlobStorage);
    }

    public async Task<string> UploadFile(IFormFile file)
    {
        var containerInstance = _blobServiceClient.GetBlobContainerClient(_azureSetting.BlobContainer);
        var blobInstance =
            containerInstance.GetBlobClient(StringInterpolationHelper.GenerateUniqueFileName(file.FileName,10));
        await blobInstance.UploadAsync(file.OpenReadStream());
        return blobInstance.Uri.ToString();
    }

    public async Task<Stream> GetFile(string fileName)
    {
        var containerInstance = _blobServiceClient.GetBlobContainerClient(_azureSetting.BlobContainer);
        var blobInstance = containerInstance.GetBlobClient(StringInterpolationHelper.GenerateUniqueFileName(fileName,10));
        var downloadResult = await blobInstance.DownloadAsync();
        return downloadResult.Value.Content;
    }

    public async Task<ICollection<string>> GetUrlAfterUploadingFile(List<IFormFile> files)
    {
        var listUrl = new List<string>();
        var containerInstance = _blobServiceClient.GetBlobContainerClient(_azureSetting.BlobContainer);
        
        foreach (var file in files)
        {
            var blobInstance = containerInstance.GetBlobClient(StringInterpolationHelper.GenerateUniqueFileName(file.FileName,10));
            await blobInstance.UploadAsync(file.OpenReadStream());
            listUrl.Add(blobInstance.Uri.ToString());
        }
        return listUrl;
    }
}