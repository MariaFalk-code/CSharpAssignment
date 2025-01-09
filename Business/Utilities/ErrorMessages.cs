
namespace Business.Utilities;

/// <summary>
/// Errormessages for the validation of the contact registration form.
/// </summary>

public static class ErrorMessages
{
    public const string Required = "This field is required.";
    public const string NameField = "This field can only contain letters, spaces and hyphens. (For example: \"Anders\", \"Anna-Karin\")";
    public const string InvalidEmail = "Invalid email address. Example format: name@domain.com";
    public const string OnlyNumbers = "This field can only contain numbers. Please enter without spaces";
    public const string Adress = "This field can only contain letters and spaces.";
    public const string StreetNumber = "This field can only contain numbers and letters. Please enter without spaces";
}
