
namespace Business.Utilities;

/// <summary>
/// Errormessages for the validation of the contact registration form.
/// </summary>

public static class ErrorMessages
{
    public const string Required = "This field is required.";
    public const string InvalidName = "This field can only contain letters, spaces and hyphens. (For example: \"Anders\", \"Anna-Karin\")";
    public const string InvalidEmail = "Invalid email address. Example format: name@domain.com";
    public const string InvalidPhoneNumber = "Please enter a Swedish phonenumber";
    public const string InvalidAddress = "This field can only contain letters and spaces.";
    public const string InvalidStreetNumber = "This field can only contain numbers and letters. Please enter without spaces";
    public const string InvalidPostalCode = "Please enter five numbers without spaces.";
}
