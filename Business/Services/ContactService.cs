

using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Business.Utilities;

namespace Business.Services;

public class ContactService : IContactService
{
    private readonly List<ContactDto> _contacts = new();

    public Result<ContactDto> AddContact(ContactDto contact)
    {
        try
        {
            _contacts.Add(contact);
            return Result<ContactDto>.EmptySuccess(SuccessMessages.ContactAdded);
        }
        catch (Exception ex)
        {
            return Result<ContactDto>.Failure($"{ErrorMessages.ContactNotAdded}: {ex.Message}");
        }
    }
    public Result<ContactDto> UpdateContact(ContactDto contact)
    {
        try
        {
            var existingContact = _contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (existingContact == null)
            {
                return Result<ContactDto>.Failure(ErrorMessages.ContactNotFound);
            }

            // Update properties
            existingContact.FirstName = contact.FirstName;
            existingContact.LastName = contact.LastName;
            existingContact.Email = contact.Email;
            existingContact.PhoneNumber = contact.PhoneNumber;
            existingContact.StreetAddress = contact.StreetAddress;
            existingContact.StreetNumber = contact.StreetNumber;
            existingContact.City = contact.City;
            existingContact.PostalCode = contact.PostalCode;

            return Result<ContactDto>.Success(existingContact, SuccessMessages.ContactUpdated);
        }
        catch (Exception ex)
        {
            return Result<ContactDto>.Failure($"{ErrorMessages.ContactNotUpdated}: {ex.Message}");
        }
    }
    public Result<ContactDto> DeleteContact(ContactDto contact)
    {
        try
        {
            var contactToDelete = _contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (contactToDelete == null)
            {
                return Result<ContactDto>.Failure(ErrorMessages.ContactNotFound);
            }

            _contacts.Remove(contactToDelete);
            return Result<ContactDto>.EmptySuccess(SuccessMessages.ContactDeleted);
        }
        catch (Exception ex)
        {
            return Result<ContactDto>.Failure($"{ErrorMessages.ContactNotDeleted}: {ex.Message}");
        }
    }
    public Result<ContactDto> GetContact(ContactDto contact)
    {
        try
        {
            var contactToRetrieve = _contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (contactToRetrieve == null)
            {
                return Result<ContactDto>.Failure(ErrorMessages.ContactNotFound);
            }
            return Result<ContactDto>.Success(contactToRetrieve, SuccessMessages.ContactRetrieved);
        }
        catch (Exception ex)
        {
            return Result<ContactDto>.Failure($"{ErrorMessages.ContactNotFound}: {ex.Message}");
        }
    }
    public Result<List<ContactDto>> GetAllContacts()
    {
        try
        {
            return Result<List<ContactDto>>.Success(_contacts, SuccessMessages.ContactsRetrieved);
        }
        catch (Exception ex)
        {
            return Result<List<ContactDto>>.Failure($"{ErrorMessages.ContactsNotRetrieved}: {ex.Message}");
        }
    }
}
