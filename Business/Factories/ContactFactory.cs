

using Business.Dtos;
using Business.Models;
using Business.Utilities;

namespace Business.Factories;

/// <summary>
/// Provides methods for creating instances of <see cref="ContactRegistrationForm"/> and <see cref="ContactDto"/>
/// </summary>
public class ContactFactory
{
    /// <summary>
    /// Creates a new instance of <see cref="ContactRegistrationForm"/>
    /// </summary>
    public static ContactRegistrationForm CreateContactRegistrationForm()
    {
        return new ContactRegistrationForm();
    }

    /// <summary>
    /// Creates a new instance of <see cref="ContactDto"/> from a given <see cref="ContactRegistrationForm"/>.
    /// </summary>
    /// <param name="form">The form containing contact information to populate the DTO.</param>
    /// <returns>A new <see cref="ContactDto"/> populated with the contact details from the form.</returns>
    /// /// <exception cref="ArgumentNullException">
    /// Thrown if the provided <see cref="ContactRegistrationForm"/> is null.
    /// </exception>
    public static ContactDto Create(ContactRegistrationForm form)
    {
        if (form == null)
        {
            throw new ArgumentNullException(nameof(form), ErrorMessages.NullFormException);
        }

        return new ContactDto
        {
            Id = GuidGenerator.GenerateGuid(),
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            PhoneNumber = form.PhoneNumber,
            StreetAddress = form.StreetAddress,
            StreetNumber = form.StreetNumber,
            City = form.City,
            PostalCode = form.PostalCode
        };
    }
}