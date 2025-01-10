

using Business.Dtos;
using Business.Models;

namespace Business.Interfaces;

public interface IContactService
{
    /// <summary>
    /// Adds a contact to the list of contacts.
    /// </summary>
    /// <param name="contact">The contact to add</param>
    /// <returns>
    /// A <see cref="Result{T}"/> containing the added <see cref="ContactDto"/> if successful.
    /// If unsuccessful, the result contains an error message.
    /// </returns>
    Result<ContactDto> AddContact(ContactDto contact);

    /// <summary>
    /// Updates a contact in the list of contacts.
    /// </summary>
    /// <param name="contact">The contact to update</param>
    /// <returns>
    /// A <see cref="Result{T}"/> containing the updated <see cref="ContactDto"/> if successful.
    /// If unsuccessful, the result contains an error message. 
    /// </returns>
    Result<ContactDto> UpdateContact(ContactDto contact);

    /// <summary>
    /// Deletes a contact from the list of contacts.
    /// </summary>
    /// <param name="contact">The contact to delete</param>
    /// <returns>
    /// A <see cref="Result{T}"/> containing the deleted <see cref="ContactDto"/> if successful.
    /// If unsuccessful, the result contains an error message.
    /// </returns>
    Result<ContactDto> DeleteContact(ContactDto contact);

    /// <summary>
    /// Gets a contact from the list of contacts.
    /// </summary>
    /// <param name="contact">The contact to retrieve</param>
    /// <returns>
    /// A <see cref="Result{T}"/> containing the requested <see cref="ContactDto"/> if successful.
    /// If unsuccessful, the result contains an error message.
    /// </returns>
    Result<ContactDto> ShowContact(ContactDto contact);

    /// <summary>
    /// Gets all contacts from the list of contacts.
    /// </summary>
    /// <returns>
    /// A <see cref="Result{T}"/> containing a list of <see cref="ContactDto"/> if successful.
    /// If unsuccessful, the result contains an error message.
    /// </returns>
    Result<IEnumerable<ContactDto>> ShowAllContacts();
}
