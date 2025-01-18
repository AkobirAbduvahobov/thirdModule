using System.IO.Compression;

namespace WebFileManagement.StorageBroker.Services;

public class LocalStorageBrokerService : IStorageBrokerService
{
    private string _dataPath;
    public LocalStorageBrokerService()
    {
        _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "data");

        if (!Directory.Exists(_dataPath))
        {
            Directory.CreateDirectory(_dataPath);
        }
    }

    public void CreateDirectory(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath); 
        ValidateDirectoryPath(directoryPath);
        Directory.CreateDirectory(directoryPath);
    }

    public void DeleteDirectory(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);

        if(!Directory.Exists(directoryPath))
        {
            throw new Exception("Directory not fount to delete");
        }

        Directory.Delete(directoryPath, true);
    }

    public void DeleteFile(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);

        if (!File.Exists(filePath))
        {
            throw new Exception("File not fount to delete");
        }

        File.Delete(filePath);
    }

    public Stream DownloadFile(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);

        if(!File.Exists(filePath))
        {
            throw new Exception("File not found to download");
        }

        var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        
        return stream;
    }

    public Stream DownloadFolderAsZip(string directoryPath)
    {
        if(Path.GetExtension(directoryPath) != string.Empty)
        {
            throw new Exception("DirectoryPath is not directory");
        }

        directoryPath = Path.Combine(_dataPath, directoryPath);  
        if (!Directory.Exists(directoryPath))
        {
            throw new Exception("Directory not found to download");
        }

        var zipPath = directoryPath + ".zip";

        ZipFile.CreateFromDirectory(directoryPath, zipPath);

        var stream = new FileStream(zipPath, FileMode.Open, FileAccess.Read);

        return stream;
    }

    public List<string> GetAllFilesAndDirectories(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath); 

        var parentPath = Directory.GetParent(directoryPath);

        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Parent folder path not found");
        }

        var allFilesAndFolders = Directory.GetFileSystemEntries(directoryPath).ToList();

        allFilesAndFolders = allFilesAndFolders.Select(p => p.Remove(0, directoryPath.Length + 1)).ToList();

        return allFilesAndFolders;
    }

    public void UploadFile(string filePath, Stream stream)
    {
        filePath = Path.Combine(_dataPath, filePath);
        var parentPath = Directory.GetParent(filePath);

        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Parent folder path not found");
        }

        using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            stream.CopyTo(fileStream);
        }
    }

    private void ValidateDirectoryPath(string directoryPath)
    {
        if (Directory.Exists(directoryPath))
        {
            throw new Exception("Folder has already created");
        }

        var parentPath = Directory.GetParent(directoryPath);

        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Parent folder path not found");
        }
    }
}
