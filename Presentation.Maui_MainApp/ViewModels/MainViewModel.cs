using System.Collections.ObjectModel;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Business.Factories;

namespace Presentation.Maui_MainApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IContactService _contactService;

    [ObservableProperty]
    private ContactRegForm _registrationForm;
    public MainViewModel(IContactService contactService)
    {
        _contactService = contactService;
        UpdateContactList();

        _registrationForm = ContactFactory.Create();
    }


    [ObservableProperty]
    private ObservableCollection<ContactRegForm> _contactList = [];

    [ObservableProperty]
    private ContactRegForm _selectedContact;

    [RelayCommand]
    public async Task NavigateToAddContact()
    {
        try
        {
            await Shell.Current.GoToAsync(nameof(AddContactPage));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Navigation failed: {ex.Message}");
        }
    }

    [RelayCommand]
    public async Task NavigateToViewContacts()
    {
        try
        {
            await Shell.Current.GoToAsync(nameof(ViewContactsPage));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Navigation failed: {ex.Message}");
        }
    }

    [RelayCommand]

    public void AddContactToList()
    {
        if(RegistrationForm != null && !string.IsNullOrWhiteSpace(RegistrationForm.FirstName))
        {
            _contactService.CreateContact(RegistrationForm);
            UpdateContactList();
            RegistrationForm = new();
        }
    }
    [RelayCommand]

    public void RemoveContactFromList(ContactRegForm contactRegForm)
    {
        if(contactRegForm != null)
        {
            var result = _contactService.RemoveContactFromList(contactRegForm);
            if (result)
            {
                ContactList.Remove(contactRegForm);
            }
        }
    }

    [RelayCommand]
    public void EditContact(ContactRegForm contact)
    {
        if (contact != null)
        {
            // Set the selected contact to RegistrationForm for editing
            RegistrationForm = new ContactRegForm
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                Phone = contact.Phone,
                Address = contact.Address,
                PostalCode = contact.PostalCode,
                City = contact.City
            };

            // Set SelectedContact to indicate which contact is being edited
            SelectedContact = contact;
        }
    }
    [RelayCommand]
    public void SaveEditedContact()
    {
        if (SelectedContact != null)
        {
            _contactService.EditContact(RegistrationForm);
            UpdateContactList();
            SelectedContact = null; // Clear selection after editing
        }
    }

    public void UpdateContactList()
    {
        ContactList = new ObservableCollection<ContactRegForm>(_contactService.GetAllContacts());
    }
   
}
