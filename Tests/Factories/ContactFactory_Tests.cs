

using Business.Factories;
using Business.Models;

namespace Tests.Factories;

public class ContactFactory_Tests
{
    [Fact]
    public void CreateRegistrationForm_ReturnsNewInstance()
    {
        // Act
        var result = ContactFactory.CreateRegistrationForm();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<ContactRegistrationForm>(result);
    }
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

        // Assert
    }
