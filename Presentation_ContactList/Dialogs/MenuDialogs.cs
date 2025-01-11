


using Business.Factories;
using Business.Interfaces;
using Business.Messages;
using Business.Utilities;

namespace Presentation_ContactList_ConsoleApp.Dialogs;

public class MenuDialogs(IContactService contactService)
{
    private readonly IContactService _contactService = contactService;

    public void RunMainMenu()
    {
        var validOptions = new HashSet<string> { "1", "2", "3", "4", "5", "6" };

        while (true)
        {
            Console.Clear();
            var option = ShowMainMenu();

            if (!string.IsNullOrEmpty(option) && validOptions.Contains(option))
            {
                MenuOptionSelector(option);
            }
            else
            {
                Console.WriteLine(ErrorMessages.InvalidOption);
                Console.ReadKey();
            }
        }
    }
    private static string ShowMainMenu()
    {
        Console.WriteLine("---Welcome to the Contact List App!---");
        Console.WriteLine();
        Console.WriteLine("Please select an option by entering the corresponding number:");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1. Add a contact");
        Console.WriteLine("2. View a contact by id");
        Console.WriteLine("3. Update a contact");
        Console.WriteLine("4. Delete a contact");
        Console.WriteLine("5. View all contacts");
        Console.WriteLine("6. Exit App");
        Console.WriteLine("---------------------------------");
        var option = Console.ReadLine()!;

        return option;
    }

    private void MenuOptionSelector(string option)
    {
        switch (option)
        {
            case "1":
                AddContact();
                break;
            case "2":
                ViewContact();
                break;
            case "3":
                UpdateContact();
                break;
            case "4":
                DeleteContact();
                break;
            case "5":
                ViewAllContacts();
                break;
            case "6":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine(ErrorMessages.InvalidOption);
                break;
        }
    }

    private void AddContact()
    {
        Console.Clear();
        var contactRegForm = ContactFactory.CreateRegistrationForm();

        Console.WriteLine("Please enter the following information to register a new contact:");
        contactRegForm.FirstName = PromptAndValidate.Prompt("First Name: ", contactRegForm, nameof(contactRegForm.FirstName));
        contactRegForm.LastName = PromptAndValidate.Prompt("Last Name: ", contactRegForm, nameof(contactRegForm.LastName));
        contactRegForm.Email = PromptAndValidate.Prompt("Email: ", contactRegForm, nameof(contactRegForm.Email));
        contactRegForm.PhoneNumber = PromptAndValidate.Prompt("Phone Number: ", contactRegForm, nameof(contactRegForm.PhoneNumber));
        contactRegForm.StreetAddress = PromptAndValidate.Prompt("Street Adress (name only) ", contactRegForm, nameof(contactRegForm.StreetAddress));
        contactRegForm.StreetNumber = PromptAndValidate.Prompt("Street Number: ", contactRegForm, nameof(contactRegForm.StreetNumber));
        contactRegForm.PostalCode = PromptAndValidate.Prompt("Postal Code: ", contactRegForm, nameof(contactRegForm.PostalCode));
        contactRegForm.City = PromptAndValidate.Prompt("City: ", contactRegForm, nameof(contactRegForm.City));

        var contactDto = ContactFactory.Create(contactRegForm);
        var result = _contactService.AddContact(contactDto);
        Console.WriteLine(result.Message);
    }

    private void ViewContact()
    {
        Console.Clear();
        Console.WriteLine("Please enter the ID of the contact you want to view: ");
        var contactId = Console.ReadLine()!.Trim();
        if (string.IsNullOrWhiteSpace(contactId))
        {
            Console.WriteLine(ErrorMessages.InvalidId);
            Console.ReadKey();
            return;
        }
        var contactDto = _contactService.ShowContact(contactId);
        if (contactDto == null)
        {
            Console.WriteLine(ErrorMessages.ContactNotFound);
            Console.ReadKey();
            return;
        }
        Console.WriteLine(contactDto);
        Console.ReadKey();
    }

    private void UpdateContact()
    {
        Console.Clear();
        Console.WriteLine("Please enter the ID of the contact you want to update: ");

        var contactId = Console.ReadLine()!.Trim();

        if (string.IsNullOrWhiteSpace(contactId))
        {
            Console.WriteLine(ErrorMessages.InvalidId);
            Console.ReadKey();
            return;
        }

        var contactDto = _contactService.ShowContact(contactId);
        if (contactDto == null)
        {
            Console.WriteLine(ErrorMessages.ContactNotFound);
            Console.ReadKey();
            return;
        }

        Console.Clear();
        var contactRegForm = ContactFactory.CreateRegistrationForm();
       
        Console.WriteLine("Please enter the updated information for the contact:");
        contactRegForm.FirstName = PromptAndValidate.Prompt("First Name: ", contactRegForm, nameof(contactRegForm.FirstName));
        contactRegForm.LastName = PromptAndValidate.Prompt("Last Name: ", contactRegForm, nameof(contactRegForm.LastName));
        contactRegForm.Email = PromptAndValidate.Prompt("Email: ", contactRegForm, nameof(contactRegForm.Email));
        contactRegForm.PhoneNumber = PromptAndValidate.Prompt("Phone Number: ", contactRegForm, nameof(contactRegForm.PhoneNumber));
        contactRegForm.StreetAddress = PromptAndValidate.Prompt("Street Adress (name only) ", contactRegForm, nameof(contactRegForm.StreetAddress));
        contactRegForm.StreetNumber = PromptAndValidate.Prompt("Street Number: ", contactRegForm, nameof(contactRegForm.StreetNumber));
        contactRegForm.PostalCode = PromptAndValidate.Prompt("Postal Code: ", contactRegForm, nameof(contactRegForm.PostalCode));
        contactRegForm.City = PromptAndValidate.Prompt("City: ", contactRegForm, nameof(contactRegForm.City));

        var result = _contactService.UpdateContact(contactId, contactRegForm);

        Console.WriteLine(result.IsSuccess ? $"Success: {result.Message}" : $"Error: {result.Message}");
        Console.ReadKey();
    }
    private void DeleteContact()
    {
        Console.Clear();
        Console.WriteLine("Please enter the ID of the contact you want to delete: ");

        var contactId = Console.ReadLine()!.Trim();

        if (string.IsNullOrWhiteSpace(contactId))
        {
            Console.WriteLine(ErrorMessages.InvalidId);
            Console.ReadKey();
            return;
        }

        var contactDto = _contactService.ShowContact(contactId);
        if (contactDto == null)
        {
            Console.WriteLine(ErrorMessages.ContactNotFound);
            Console.ReadKey();
            return;
        }
        var result = _contactService.DeleteContact(contactId);

        Console.WriteLine(result.IsSuccess ? $"Success: {result.Message}" : $"Error: {result.Message}");
        Console.ReadKey();
    }
    /// <summary>
    /// Displays all contacts in the contact list. ChatGPTo generated this method as I was falling asleep. It calls the ShowAllContacts method,
    /// makes sure the result is not null or empty and then loops through the data to print each contact.
    /// </summary>
    private void ViewAllContacts()
    {
        Console.Clear();
        var result = _contactService.ShowAllContacts();

        if (!result.IsSuccess || result.Data == null || !result.Data.Any())
        {
            Console.WriteLine(result.Message ?? ErrorMessages.ContactsEmpty);
            Console.ReadKey();
            return;
        }

        foreach (var contact in result.Data)
        {
            Console.WriteLine(contact);
        }

        Console.ReadKey();
    }

}
