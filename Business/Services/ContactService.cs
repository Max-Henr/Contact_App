using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class ContactService(IFileService fileService) : IContactService
{
    private readonly IFileService _fileService = fileService;
    private List<ContactRegForm> _contacts = new();

    public void CreateContact(ContactRegForm regForm)
    {   
        _contacts.Add(regForm);
        _fileService.SaveContactToList(_contacts);
    }

    public IEnumerable<ContactRegForm> GetAllContacts()
    {
        return _fileService.GetContactList();
    }
}
