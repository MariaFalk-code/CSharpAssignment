

using Business.Dtos;
using Business.Interfaces;
using Business.Messages;
using Business.Models;

namespace Business.Services;
/// <summary>
/// A service for managing contacts. ChatGPT4o helped write the code for the constructor. IFileService is injected via dependency injection.
/// An initial list of contacts is read from a file when the service is created (if non-existent/not read an empty list is initiated),
/// then updated as contacts are added, updated, or deleted via the usage of the ContactService methods.
/// </summary>
public class ContactService : IContactService
{
    private readonly IFileService _fileService;
    private readonly string _filePath;
    private List<ContactDto> _contacts;

    public ContactService(IFileService fileService, string filePath)
    {
        _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));

        var readResult = _fileService.ReadListFromFile<ContactDto>(_filePath);
        _contacts = readResult.Data ?? new List<ContactDto>();
    }

    public Result<ContactDto> AddContact(ContactDto contact)
    {

        if (contact == null)
        {
            return Result<ContactDto>.Failure(ErrorMessages.ContactNotAdded);
        }

        _contacts.Add(contact);
        var saveResult = _fileService.SaveListToFile(_contacts);
        if (!saveResult.IsSuccess)
        {
            return Result<ContactDto>.Failure(ErrorMessages.ContactNotAdded);
        }

        return Result<ContactDto>.EmptySuccess(SuccessMessages.ContactAdded);
    }
    public Result<ContactDto> UpdateContact(ContactDto contact)
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

        var saveResult = _fileService.SaveListToFile(_contacts);
        if (!saveResult.IsSuccess)
        {
            return Result<ContactDto>.Failure(ErrorMessages.ContactNotUpdated);
        }

        return Result<ContactDto>.Success(existingContact, SuccessMessages.ContactUpdated);
    }
    public Result<ContactDto> DeleteContact(ContactDto contact)
    {

        var contactToDelete = _contacts.FirstOrDefault(c => c.Id == contact.Id);
        if (contactToDelete == null)
        {
            return Result<ContactDto>.Failure(ErrorMessages.ContactNotFound);
        }

        _contacts.Remove(contactToDelete);
        var saveResult = _fileService.SaveListToFile(_contacts);

        if (!saveResult.IsSuccess)
        {
            return Result<ContactDto>.Failure(ErrorMessages.ContactNotDeleted);
        }

        return Result<ContactDto>.Success(contactToDelete, SuccessMessages.ContactDeleted);
    }
    public Result<ContactDto> ShowContact(ContactDto contact)
    {
        var contactToRetrieve = _contacts.FirstOrDefault(c => c.Id == contact.Id);
        if (contactToRetrieve == null)
        {
            return Result<ContactDto>.Failure(ErrorMessages.ContactNotFound);
        }
        return Result<ContactDto>.Success(contactToRetrieve, SuccessMessages.ContactRetrieved);
    }
    public Result<IEnumerable<ContactDto>> ShowAllContacts()
    {
        if (_contacts.Count == 0)
        {
            return Result<IEnumerable<ContactDto>>.Failure(ErrorMessages.ContactsEmpty);
        }

        return Result<IEnumerable<ContactDto>>.Success(_contacts, SuccessMessages.ContactsRetrieved);
    }
}
