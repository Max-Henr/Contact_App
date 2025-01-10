using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class ContactService(IFileService fileService) : IContactService
{
    private readonly IFileService _fileService = fileService;

    //Tagit hjälp av chatgpt för denna rad kod
    public List<ContactRegForm> Contacts { get; private set; } = (List<ContactRegForm>)fileService.GetContactList().ToList() ?? new List<ContactRegForm>();

    public void CreateContact(ContactRegForm regForm)
    {   
        Contacts.Add(regForm);
        _fileService.SaveContactToList(Contacts);
    }

    public bool RemoveContactFromList(ContactRegForm contactRegForm)
    {
        if (!string.IsNullOrWhiteSpace(contactRegForm.Id))
        {
            var exisitingContact = Contacts.FirstOrDefault(x => x.Id == contactRegForm.Id);
            if (exisitingContact != null)
            {
                Contacts.Remove(exisitingContact);
                _fileService.SaveContactToList(Contacts);
                return true;
            }
        }
        return false;
    }

    public bool EditContact(ContactRegForm updatedContact)
    {
        if (!string.IsNullOrWhiteSpace(updatedContact.Id))
        {
            var existingContact = Contacts.FirstOrDefault(x => x.Id == updatedContact.Id);
            if (existingContact != null)
            {
                // Update properties of the existing contact
                existingContact.FirstName = updatedContact.FirstName;
                existingContact.LastName = updatedContact.LastName;
                existingContact.Email = updatedContact.Email;
                existingContact.Phone = updatedContact.Phone;
                existingContact.Address = updatedContact.Address;
                existingContact.PostalCode = updatedContact.PostalCode;
                existingContact.City = updatedContact.City;

                // Save updated list to file
                _fileService.SaveContactToList(Contacts);
                return true;
            }
        }
        return false;
    }
    public IEnumerable<ContactRegForm> GetAllContacts()
    {
        return _fileService.GetContactList();
    }
}
