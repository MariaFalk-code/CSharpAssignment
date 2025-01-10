

using Business.Interfaces;
using Business.Messages;

namespace Presentation_ContactList_ConsoleApp.Dialogs;

public class MenuDialogs (IContactService contactService)
{
    private readonly IContactService _contactService = contactService;

    public void RunMainMeny()
    {
        while (true)
        {
            Console.Clear();
            var option = ShowMainMenu();

            if (!string.IsNullOrEmpty(option) && )
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

        private string ShowMainMenu()
    {
        Console.WriteLine("---Welcome to the Contact List App!---");
        Console.WriteLine();
        Console.WriteLine("Please select an option by entering the corresponding number:");
        Console.WriteLine(---------------------------------);
        Console.WriteLine("1. Add a contact");
        Console.WriteLine("2. Update a contact");
        Console.WriteLine("3. Delete a contact");
        Console.WriteLine("4. View a contact");
        Console.WriteLine("5. View all contacts");
        Console.WriteLine("6. Exit App");
        Console.WriteLine(---------------------------------);
        var option = Console.ReadLine();
    }
        
        private void MenuOptionSelector(string option)
    {
        switch (option)
        {
            case "1":
                AddContact();
                break;
            case "2":
                UpdateContact();
                break;
            case "3":
                DeleteContact();
                break;
            case "4":
                ViewContacts();
                break;
            case "5":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
}
