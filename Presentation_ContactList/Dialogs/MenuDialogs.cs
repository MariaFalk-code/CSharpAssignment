

using Business.Dtos;
using Business.Interfaces;
using Business.Messages;
using Business.Models;
using Business.Utilities;

namespace Presentation_ContactList_ConsoleApp.Dialogs;

public class MenuDialogs(IContactService contactService)
{
    private readonly IContactService _contactService = contactService;
    /// <summary>
    /// Runs the main menu of the application.
    /// </summary>
    public void RunMainMenu()
    {
        var validOptions = new HashSet<string> { "1", "2", "3", "4", "5", "6" };

        while (true)
        {
            Console.Clear();
            var option = ShowMainMenu();

            if (!string.IsNullOrEmpty(option) && validOptions.Contains(option))
            {
                HandleMenuOption(option);
            }
            else
            {
                Console.WriteLine(ErrorMessages.InvalidOption);
                WaitForUserInput();
            }
        }
    }
    /// <summary>
    /// Displays the main menu of the application.
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Handles the menu option selected by the user.
    /// </summary>
    /// <param name="option"></param>
    private void HandleMenuOption(string option)
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

    /// <summary>
    /// Adds a contact to the contact list, based on sanitized and validated user input.
    /// </summary>
    private void AddContact()
    {
        Console.Clear();
        var contactRegForm = new ContactRegistrationForm();

        Console.WriteLine("Please enter the following information to register a new contact:");
        contactRegForm.FirstName = PromptAndValidate.Prompt("First Name: ", contactRegForm, nameof(contactRegForm.FirstName));
        contactRegForm.LastName = PromptAndValidate.Prompt("Last Name: ", contactRegForm, nameof(contactRegForm.LastName));
        contactRegForm.Email = PromptAndValidate.Prompt("Email: ", contactRegForm, nameof(contactRegForm.Email));
        contactRegForm.PhoneNumber = PromptAndValidate.Prompt("Phone Number: ", contactRegForm, nameof(contactRegForm.PhoneNumber));
        contactRegForm.StreetAddress = PromptAndValidate.Prompt("Street Adress (name only) ", contactRegForm, nameof(contactRegForm.StreetAddress));
        contactRegForm.StreetNumber = PromptAndValidate.Prompt("Street Number: ", contactRegForm, nameof(contactRegForm.StreetNumber));
        contactRegForm.PostalCode = PromptAndValidate.Prompt("Postal Code: ", contactRegForm, nameof(contactRegForm.PostalCode));
        contactRegForm.City = PromptAndValidate.Prompt("City: ", contactRegForm, nameof(contactRegForm.City));

        var result = _contactService.CreateAndAddContact(contactRegForm);

        Console.Clear();
        if (!result.IsSuccess || result.Data == null)
        {
            Console.WriteLine(ErrorMessages.ContactNotAdded);
            WaitForUserInput();
            return;
        }
        Console.WriteLine(result.Message);
        Console.WriteLine();
        Console.WriteLine("---New contact:---");
        Console.WriteLine();
        PrintContactDetails.Print(result.Data!);
        WaitForUserInput();
    }

    /// <summary>
    /// Displays the details of a contact based on the ID entered by the user.
    /// </summary>
    private void ViewContact()
    {
        var result = GetContactById("view");

        Console.Clear();

        if (!result.IsSuccess || result.Data == null)
        {
            Console.WriteLine(ErrorMessages.ContactNotFound);
            WaitForUserInput();
            return;
        }

        Console.WriteLine(result.Message);
        Console.WriteLine();
        Console.WriteLine("---Contact Details---");
        Console.WriteLine();
        PrintContactDetails.Print(result.Data!);
        WaitForUserInput();
    }

    /// <summary>
    /// Updates the details of a contact fetched by the ID entered by the user.
    /// </summary>
    private void UpdateContact()
    {
        var result = GetContactById("update");

        if (!result.IsSuccess || result.Data == null) return;

        var existingDto = result.Data;

        Console.Clear();
        var contactRegForm = new ContactRegistrationForm();

        Console.WriteLine("Please enter the updated information for the contact:");
        contactRegForm.FirstName = PromptAndValidate.Prompt("First Name: ", contactRegForm, nameof(contactRegForm.FirstName));
        contactRegForm.LastName = PromptAndValidate.Prompt("Last Name: ", contactRegForm, nameof(contactRegForm.LastName));
        contactRegForm.Email = PromptAndValidate.Prompt("Email: ", contactRegForm, nameof(contactRegForm.Email));
        contactRegForm.PhoneNumber = PromptAndValidate.Prompt("Phone Number: ", contactRegForm, nameof(contactRegForm.PhoneNumber));
        contactRegForm.StreetAddress = PromptAndValidate.Prompt("Street Adress (name only) ", contactRegForm, nameof(contactRegForm.StreetAddress));
        contactRegForm.StreetNumber = PromptAndValidate.Prompt("Street Number: ", contactRegForm, nameof(contactRegForm.StreetNumber));
        contactRegForm.PostalCode = PromptAndValidate.Prompt("Postal Code: ", contactRegForm, nameof(contactRegForm.PostalCode));
        contactRegForm.City = PromptAndValidate.Prompt("City: ", contactRegForm, nameof(contactRegForm.City));

        var updatedResult = _contactService.UpdateContact(existingDto, contactRegForm);
        Console.Clear();

        if (!updatedResult.IsSuccess)
        {
            Console.WriteLine(result.Message);
            WaitForUserInput();
            return;
        }
        
        Console.WriteLine(updatedResult.Message);
        Console.WriteLine();
        Console.WriteLine("---Updated contact:---");
        Console.WriteLine();
        PrintContactDetails.Print(result.Data!);
        WaitForUserInput();
    }

    /// <summary>
    /// Deletes a contact from the contact list based on the ID entered by the user.
    /// </summary>
    private void DeleteContact()
    {
        var result = GetContactById("delete");

        if (!result.IsSuccess || result.Data == null) return;

        var deleteResult = _contactService.DeleteContact(result.Data.Id);

        Console.Clear();
        if (!deleteResult.IsSuccess)
        {
            Console.WriteLine(ErrorMessages.ContactNotDeleted);
            WaitForUserInput();
            return;
        }
        Console.WriteLine(deleteResult.Message);
        Console.WriteLine();
        Console.WriteLine("---Deleted contact:---");
        Console.WriteLine();
        PrintContactDetails.Print(result.Data!);
        WaitForUserInput();
    }
    /// <summary>
    /// Displays all contacts in the contact list. ChatGPTo generated this method as I was falling asleep. It calls the ShowAllContacts method,
    /// makes sure the result is not null or empty and then loops through the data to print each contact.
    /// </summary>
    private void ViewAllContacts()
    {
        var result = _contactService.ShowAllContacts();

        if (!result.IsSuccess || result.Data == null || !result.Data.Any())
        {
            Console.Clear();
            Console.WriteLine(result.Message ?? ErrorMessages.ContactsEmpty);
            WaitForUserInput();
            return;
        }

        Console.Clear();
        Console.WriteLine(result.Message);
        Console.WriteLine();
        Console.WriteLine("---All contacts:---");
        Console.WriteLine();
        foreach (var contact in result.Data)
        {
            {
                PrintContactDetails.Print(contact);
            }
        }
        WaitForUserInput();
    }
    /// <summary>
    /// Helper method, waits for user input before continuing.
    /// </summary>
    /// <param name="message">A message to the user.</param>
    private void WaitForUserInput(string message = "Press any key to return to the main menu.")
    {
        Console.WriteLine();
        Console.WriteLine(message);
        Console.ReadKey();
    }
    /// <summary>
    /// Helper method, suggested by GhatGpt4o for cleaning up the code. Slightly modified by me. Gets a contact by ID and returns the result.
    /// </summary>
    /// <param name="promptMessage"></param>
    /// <returns></returns>
    private Result<ContactDto> GetContactById(string promptAction)
    {
        Console.Clear();
        Console.WriteLine(($"Please enter the ID of the contact you want to {promptAction}: "));
        var contactId = Console.ReadLine()!.Trim();

        if (string.IsNullOrWhiteSpace(contactId))
        {
            Console.WriteLine(ErrorMessages.InvalidId);
            Console.ReadKey();
            return Result<ContactDto>.Failure(ErrorMessages.InvalidId);
        }

        var result = _contactService.GetContact(contactId);

        if (!result.IsSuccess || result.Data == null)
        {
            Console.WriteLine(ErrorMessages.ContactNotFound);
            WaitForUserInput();
            return Result<ContactDto>.Failure(ErrorMessages.ContactNotFound);
        }

        return result;
    }
}
