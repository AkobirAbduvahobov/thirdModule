
using WebFileManagement.StorageBroker.Services;

namespace WebFileManagement.Service.Services;

public class StorageService : IStorageService
{
    private readonly IStorageBrokerService _storageBrokerService;

    public StorageService(IStorageBrokerService storageBrokerService)
    {
        _storageBrokerService = storageBrokerService;
    }

    public void CreateDirectory(string directoryPath)
    {
        _storageBrokerService.CreateDirectory(directoryPath);
    }

    public void DeleteDirectory(string directoryPath)
    {
        _storageBrokerService.DeleteDirectory(directoryPath);
    }

    public void DeleteFile(string filePath)
    {
        _storageBrokerService.DeleteFile(filePath); 
    }

    public Stream DownloadFile(string filePath)
    {
        return _storageBrokerService.DownloadFile(filePath);
    }

    public Stream DownloadFolderAsZip(string directoryPath)
    {
        return _storageBrokerService.DownloadFolderAsZip(directoryPath);
    }

    public List<string> GetAllFilesAndDirectories(string directoryPath)
    {
        var filesAndDirectories = _storageBrokerService.GetAllFilesAndDirectories(directoryPath);

        return filesAndDirectories;
    }

    public void UploadFile(string filePath, Stream stream)
    {
        _storageBrokerService.UploadFile(filePath, stream);
    }

    
}
