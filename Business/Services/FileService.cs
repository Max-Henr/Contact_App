using Business.Interfaces;

namespace Business.Services;

public class FileService : IFileService
{

    private readonly string _filePath;
    private readonly string _directoryPath;

    public FileService(string fileName = "Contacts.json", string directoryPath = "Data")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
    }

    public bool SaveContactToList()
    {
        try
        {
            if(!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);
        }
        catch 
        {

        }
    }
    public string GetContactList()
    {
        throw new NotImplementedException();
    }

}
