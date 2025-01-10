using Business.Factories;
using Business.Interfaces;

namespace Presentation.Console_MainApp.Dialogs;

public class MenuDialog(IContactService contactService) : IMenuDialog
{
    private readonly IContactService _contactService = contactService;

    bool isRunning = true;
    public void Main()
    {
        do
        {

            Console.WriteLine("---------Contact App----------");
            Console.WriteLine("1. Add Contact:");
            Console.WriteLine("2. Show Contacts:");
            Console.WriteLine("Q. Close Contacts:");
            Console.WriteLine("------------------------------");
            Console.Write("Your Choice: ");
            string option = Console.ReadLine()!;
            switch (option.ToLower())
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    ShowContacts();
                    break;
                case "q":
                    Close();
                    break;
                default:
                    Console.WriteLine("Choose a valid option!");
                    break;
            }

        }while (isRunning);
    }
    public void AddContact()
    {
        var contact = ContactFactory.Create();

        Console.Write("Enter your first name: ");
        contact.FirstName = Console.ReadLine()!;

        Console.Write("Enter your last name: ");
        contact.LastName = Console.ReadLine()!;

        Console.Write("Enter your email: ");
        contact.Email = Console.ReadLine()!;

        Console.Write("Enter your phone number: ");
        contact.Phone = Console.ReadLine()!;

        Console.Write("Enter your address: ");
        contact.Address = Console.ReadLine()!;

        Console.Write("Enter your postal code: ");
        contact.PostalCode = Console.ReadLine()!;

        Console.Write("Enter your city: ");
        contact.City = Console.ReadLine()!;

        _contactService.CreateContact(contact);
    }

    public void ShowContacts()
    {
        var contacts = _contactService.GetAllContacts();
        if(contacts.Count() == 0)
        {
            Console.WriteLine("No contacts found!");
            return;
        }
        foreach (var contact in contacts) {
            Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"PhoneNumber: {contact.Phone}");
            Console.WriteLine($"Address: {contact.Address}, {contact.PostalCode}, {contact.City}");
        }
        Console.Write("Press any key to continue: ");
        Console.ReadKey();
    }
    public void Close()
    {
        Console.Write("Do you want to close the app (y/n): ");
        string closeApp = Console.ReadLine()!;
        if (closeApp.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            isRunning = false;
        }
        
    }
}
