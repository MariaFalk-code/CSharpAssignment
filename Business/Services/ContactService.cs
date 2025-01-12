

using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Messages;
using Business.Models;
using Business.Utilities;

namespace Business.Services;
/// <summary>
/// A service for managing contacts. ChatGPT4o helped write the code for the constructor. IFileService is injected via dependency injection.
/// An initial list of contacts is read from a file when the service is created (if non-existent/not read an empty list is initiated),
/// then updated as contacts are added, updated, or deleted via the usage of the ContactService methods.
/// </summary>
public class ContactService : IContactService
{
    private readonly IFileService _fileService;
    private List<ContactDto> _contacts;

    public ContactService(IFileService fileService)
    {
        _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));

        var readResult = _fileService.ReadListFromFile<ContactDto>();
        _contacts = readResult.Data ?? [];
    }

    public Result<ContactDto> CreateAndAddContact(ContactRegistrationForm form)
    {
        if (form == null) return Result<ContactDto>.Failure("Form cannot be null");

        var sanitizedForm = InputSanitizer.Sanitize(form);

        var contact = ContactFactory.Create(sanitizedForm);

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

        return Result<ContactDto>.Success(contact, SuccessMessages.ContactAdded);
    }
    public Result<ContactDto> ShowContact(string contactId)
    {
        var contactToRetrieve = _contacts.FirstOrDefault(c => c.Id == contactId);
        if (contactToRetrieve == null)
        {
            return Result<ContactDto>.Failure(ErrorMessages.ContactNotFound);
        }
        return Result<ContactDto>.Success(contactToRetrieve, SuccessMessages.ContactRetrieved);
    }
    public Result<ContactDto> UpdateContact(ContactDto existingContact, ContactRegistrationForm form)
    {
        var sanitizedForm = InputSanitizer.Sanitize(form);
        var updatedDto = ContactFactory.Update(existingContact, sanitizedForm);

        var saveResult = _fileService.SaveListToFile(_contacts);
        if (!saveResult.IsSuccess)
        {
            return Result<ContactDto>.Failure(ErrorMessages.ContactNotUpdated);
        }

        return Result<ContactDto>.Success(updatedDto, SuccessMessages.ContactUpdated);
    }
    public Result<ContactDto> DeleteContact(string contactId)
    {

        var contactToDelete = _contacts.FirstOrDefault(c => c.Id == contactId);
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
    public Result<IEnumerable<ContactDto>> ShowAllContacts()
    {
        if (_contacts.Count == 0)
        {
            return Result<IEnumerable<ContactDto>>.Failure(ErrorMessages.ContactsEmpty);
        }

        return Result<IEnumerable<ContactDto>>.Success(_contacts, SuccessMessages.ContactsRetrieved);
    }
}
