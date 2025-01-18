using Microsoft.AspNetCore.Mvc;
using WebFileManagement.Service.Services;

namespace WebFileManagement.Server.Controllers;

[Route("api/storage")]
[ApiController]
public class StorageController : ControllerBase
{
    private readonly IStorageService _storageService;

    public StorageController(IStorageService storageService)
    {
        _storageService = storageService;
    }

    [HttpPost("uploadFile")]
    public void UploadFile(IFormFile file, string? directoryPath)
    {
        directoryPath = directoryPath ?? string.Empty;
        directoryPath = Path.Combine(directoryPath, file.FileName);

        using (var stream = file.OpenReadStream())
        {
            _storageService.UploadFile(directoryPath, stream);
        }
    }

    [HttpPost("uploadFiles")]
    public void UploadFiles(List<IFormFile> files, string? directoryPath)
    {
        directoryPath = directoryPath ?? string.Empty;
        var mainPath = directoryPath;
        if (files == null || files.Count == 0)
        {
            throw new Exception("files is empty or null");
        }

        foreach (var file in files)
        {
            directoryPath = Path.Combine(mainPath, file.FileName);

            using (var stream = file.OpenReadStream())
            {
                _storageService.UploadFile(directoryPath, stream);
            }
        }
    }

    [HttpPost("createFolder")]
    public void CreateFolder(string folderPath)
    {
        _storageService.CreateDirectory(folderPath);
    }

    [HttpGet("getAll")]
    public List<string> GetAllInFolderPath(string? directoryPath)
    {
        directoryPath = directoryPath ?? string.Empty;
        var all = _storageService.GetAllFilesAndDirectories(directoryPath);
        return all;
    }

    [HttpGet("downloadFile")]
    public FileStreamResult DownloadFile(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new Exception("Error");
        }

        var fileName = Path.GetFileName(filePath);

        var stream = _storageService.DownloadFile(filePath);


        var res = new FileStreamResult(stream, "application/octet-stream")
        {
            FileDownloadName = fileName,
        };

        return res;
    }

    [HttpGet("downloadFolderAsZip")]
    public FileStreamResult DownloadFolderAsZip(string directoryPath)
    {
        if (string.IsNullOrEmpty(directoryPath))
        {
            throw new Exception("Error");
        }

        var directoryName = Path.GetFileName(directoryPath);

        var stream = _storageService.DownloadFolderAsZip(directoryPath);

        try
        {
            var res = new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = directoryName + ".zip",
            };

            return res;
        }
        finally
        {
            //_storageService.DeleteFile(directoryPath + ".zip");
        }
    }

    [HttpDelete("deleteFile")]
    public void DeleteFile(string filePath)
    {
        _storageService.DeleteFile(filePath);
    }

    [HttpDelete("deleteDirectory")]
    public void DeleteDirectory(string directoryPath)
    {
        _storageService.DeleteDirectory(directoryPath);
    }
}
