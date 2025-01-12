

using Business.Dtos;

namespace Business.Utilities;

public class PrintContactDetails
{
    /// <summary>
    /// Prints the details of a contact.
    /// </summary>
    /// <param name="contact">The contact being printed.</param>
    public static void Print(ContactDto contact)
    {
        Console.WriteLine($"ID: {contact.Id}");
        Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
        Console.WriteLine($"Email: {contact.Email}");
        Console.WriteLine($"Phonenumber: {contact.PhoneNumber}");
        Console.WriteLine($"Address: {contact.StreetAddress} {contact.StreetNumber}");
        Console.WriteLine($"Postal Code: {contact.PostalCode}");
        Console.WriteLine($"City: {contact.City}");
        Console.WriteLine();
    }
}
