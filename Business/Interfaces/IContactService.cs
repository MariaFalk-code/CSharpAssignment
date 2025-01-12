

using Business.Dtos;
using Business.Models;

namespace Business.Interfaces;

public interface IContactService
{
    /// <summary>
    /// Adds a contact to the list of contacts.
    /// </summary>
    /// <param name="form">The contact registration form.</param>
    /// <returns>
    /// A <see cref="Result{T}"/> containing the added <see cref="ContactDto"/> if successful.
    /// If unsuccessful, the result contains an error message.
    /// </returns>
    Result<ContactDto> CreateAndAddContact(ContactRegistrationForm form);

    /// <summary>
    /// Gets a contact from the list of contacts.
    /// </summary>
    /// <param name="ContactId">The GUID of the contact to retrieve</param>
    /// <returns>
    /// A <see cref="Result{T}"/> containing the requested <see cref="ContactDto"/> if successful.
    /// If unsuccessful, the result contains an error message.
    /// </returns>
    Result<ContactDto> GetContact(string contactId);

    /// <summary>
    /// Updates a contact in the list of contacts.
    /// </summary>
    /// <param name="existingContact">The DTO of the contact to update.</param>
    /// <param name="form">The contact registration form.</param>
    /// <returns>
    /// A <see cref="Result{T}"/> containing the updated <see cref="ContactDto"/> if successful.
    /// If unsuccessful, the result contains an error message. 
    /// </returns>
    Result<ContactDto> UpdateContact(ContactDto existingContact, ContactRegistrationForm form);

    /// <summary>
    /// Deletes a contact from the list of contacts.
    /// </summary>
    /// <param name="contactId">The GUID, as a string, of the contact to delete</param>
    /// <returns>
    /// A <see cref="Result{T}"/> containing the deleted <see cref="ContactDto"/> if successful.
    /// If unsuccessful, the result contains an error message.
    /// </returns>
    Result<ContactDto> DeleteContact(string contactId);

    /// <summary>
    /// Gets all contacts from the list of contacts.
    /// </summary>
    /// <returns>
    /// A <see cref="Result{T}"/> containing a list of <see cref="ContactDto"/> if successful.
    /// If unsuccessful, the result contains an error message.
    /// </returns>
    Result<IEnumerable<ContactDto>> ShowAllContacts();
}
