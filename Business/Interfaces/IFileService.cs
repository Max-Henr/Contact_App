using Business.Models;

namespace Business.Interfaces;

public interface IFileService
{
    public bool SaveContactToList(List<ContactRegForm> list);

    public IEnumerable<ContactRegForm> GetContactList();
}
