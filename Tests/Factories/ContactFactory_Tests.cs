

using Business.Dtos;
using Business.Factories;
using Business.Models;

namespace Tests.Factories;

public class ContactFactory_Tests
{
    [Fact]
    public void Create_WithValidForm_ReturnsNewContactDto()
    {
        // Arrange
        var form = new ContactRegistrationForm
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            PhoneNumber = "0123456789",
            StreetAddress = "Main St",
            StreetNumber = "10A",
            PostalCode = "12345",
            City = "Sample City"
        };

        // Act
        var result = ContactFactory.Create(form);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<ContactDto>(result);
        Assert.Equal(form.FirstName, result.FirstName);
        Assert.Equal(form.LastName, result.LastName);
        Assert.Equal(form.Email, result.Email);
        Assert.Equal(form.PhoneNumber, result.PhoneNumber);
        Assert.Equal(form.StreetAddress, result.StreetAddress);
        Assert.Equal(form.StreetNumber, result.StreetNumber);
        Assert.Equal(form.PostalCode, result.PostalCode);
        Assert.Equal(form.City, result.City);
    }

    [Fact]
    public void Create_WithNullForm_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => ContactFactory.Create(null!));
    }

    [Fact]
    public void Update_WithValidDtoAndForm_ReturnsUpdatedContactDto()
    {
        // Arrange
        var dto = new ContactDto
        {
            FirstName = "Jane",
            LastName = "Smith",
            Email = "old.email@example.com",
            PhoneNumber = "1234567890",
            StreetAddress = "Old St",
            StreetNumber = "1",
            City = "Old City",
            PostalCode = "00000"
        };
        var form = new ContactRegistrationForm
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            PhoneNumber = "0123456789",
            StreetAddress = "New St",
            StreetNumber = "10A",
            PostalCode = "12345",
            City = "New City"
        };

        // Act
        var updatedDto = ContactFactory.Update(dto, form);

        // Assert
        Assert.NotNull(updatedDto);
        Assert.IsType<ContactDto>(updatedDto);
        Assert.Equal(form.FirstName, updatedDto.FirstName);
        Assert.Equal(form.LastName, updatedDto.LastName);
        Assert.Equal(form.Email, updatedDto.Email);
        Assert.Equal(form.PhoneNumber, updatedDto.PhoneNumber);
        Assert.Equal(form.StreetAddress, updatedDto.StreetAddress);
        Assert.Equal(form.StreetNumber, updatedDto.StreetNumber);
        Assert.Equal(form.PostalCode, updatedDto.PostalCode);
        Assert.Equal(form.City, updatedDto.City);
    }

    [Fact]
    public void Update_WithNullDto_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => ContactFactory.Update(null!, new ContactRegistrationForm()));
    }

    [Fact]
    public void Update_WithNullForm_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => ContactFactory.Update(new ContactDto(), null!));
    }
}
