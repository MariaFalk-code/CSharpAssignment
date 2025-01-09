﻿
namespace Business.Utilities;

/// <summary>
/// Errormessages concerning the Contact List application.
/// </summary>

public static class ErrorMessages
{
    //Error messages concerning validation of the contact registration form.
    public const string Required = "This field is required.";
    public const string InvalidName = "This field can only contain letters, spaces and hyphens. (For example: \"Anders\", \"Anna-Karin\")";
    public const string InvalidEmail = "Invalid email address. Example format: name@domain.com";
    public const string InvalidPhoneNumber = "Please enter a Swedish phonenumber";
    public const string InvalidAddress = "This field can only contain letters and spaces.";
    public const string InvalidStreetNumber = "This field can only contain numbers and letters. Please enter without spaces";
    public const string InvalidPostalCode = "Please enter five numbers without spaces.";

    //Error messages concerning the contact list.
    public const string ContactNotFound = "Contact not found.";
    public const string ContactAlreadyExists = "Contact already exists.";
    public const string ContactNotAdded = "Failed to add contact.";
    public const string ContactNotUpdated = "Failed to update contact.";
    public const string ContactNotDeleted = "Failed to delete contact.";
    public const string ContactsNotRetrieved = "Failed to retrieve contacts.";

    //Error messages concerning ArgumentExceptions.
    public const string NullFormException = "The form cannot be null.";
}
