using Business.Models;

namespace Business.Interfaces;

public interface IContactService
{
    public void CreateContact(ContactRegForm regForm);

    public IEnumerable<ContactRegForm> GetAllContacts();
}
