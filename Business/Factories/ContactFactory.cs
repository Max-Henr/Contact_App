using Business.Helpers;
using Business.Models;

namespace Business.Factories;

public static class ContactFactory
{
    public static ContactRegForm Create()
    {
        return new ContactRegForm
        {
            Id = IdGenerator.GenerateUniqueId()
        };
    }
}
