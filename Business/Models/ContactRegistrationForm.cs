
using Business.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

/// <summary>
/// Represents the contact registration form with validation logic.
/// </summary>
public class ContactRegistrationForm
{
    [Required(ErrorMessage = ErrorMessages.Required)]
    [RegularExpression(@"^[a-zA-Z\s\-]+$", ErrorMessage = ErrorMessages.InvalidName)]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = ErrorMessages.Required)]
    [RegularExpression(@"^[a-zA-Z\s\-]+$", ErrorMessage = ErrorMessages.InvalidName)]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = ErrorMessages.Required)]
    [EmailAddress(ErrorMessage =ErrorMessages.InvalidEmail)]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = ErrorMessages.Required)]
    [RegularExpression(@"^(\+46|0)[\d\s\-]{6,}$", ErrorMessage = ErrorMessages.InvalidPhoneNumber)]
    public string PhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = ErrorMessages.Required)]
    [RegularExpression(@"^[a-zA-ZåäöÅÄÖ\s]+$", ErrorMessage = ErrorMessages.InvalidAddress)]
    public string StreetAddress { get; set; } = null!;

    [Required(ErrorMessage = ErrorMessages.Required)]
    [RegularExpression(@"^[a-zA-ZåäöÅÄÖ0-9]+$", ErrorMessage = ErrorMessages.InvalidStreetNumber)]
    public string StreetNumber { get; set; } = null!;

    [Required(ErrorMessage = ErrorMessages.Required)]
    [RegularExpression(@"^[a-zA-ZåäöÅÄÖ\s]+$", ErrorMessage = ErrorMessages.InvalidAddress)]
    public string City { get; set; } = null!;

    [Required(ErrorMessage = ErrorMessages.Required)]
    [RegularExpression(@"^\d{5}$", ErrorMessage = ErrorMessages.InvalidPostalCode)]
    public string PostalCode { get; set; } = null!;
}
