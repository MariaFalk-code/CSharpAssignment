
using Business.Models;
using Business.Utilities;

namespace Tests.Utilities;

public class InputSanitizer_Tests
{
    [Fact]
    public void Sanitize_WhenCalled_ReturnsSanitizedForm()
    {
        // Arrange
        var form = new ContactRegistrationForm
        {
            FirstName = "  john  ",
            LastName = "  doe   grEEn ",
            Email = "   john.doe@example.com  ",
            PhoneNumber = "  070 123 45 67  ",
            StreetAddress = "  main    STREET  ",
            StreetNumber = "  123a  ",
            PostalCode = "  12345  ",
            City = "  STOCKHOLM  "
        };

        // Act
        var sanitizedForm = InputSanitizer.Sanitize(form);

        // Assert
        Assert.NotNull(sanitizedForm);
        Assert.IsType<ContactRegistrationForm>(sanitizedForm);
        Assert.Equal("John", sanitizedForm.FirstName);
        Assert.Equal("Doe Green", sanitizedForm.LastName);
        Assert.Equal("john.doe@example.com", sanitizedForm.Email);
        Assert.Equal("070 123 45 67", sanitizedForm.PhoneNumber);
        Assert.Equal("Main Street", sanitizedForm.StreetAddress);
        Assert.Equal("123a", sanitizedForm.StreetNumber);
        Assert.Equal("12345", sanitizedForm.PostalCode);
        Assert.Equal("Stockholm", sanitizedForm.City);
    }

    [Fact]
    public void Sanitize_WhenCalledWithEmptyForm_ReturnsEmptyForm()
    {
        // Arrange
        var form = new ContactRegistrationForm();

        // Act
        var sanitizedForm = InputSanitizer.Sanitize(form);

        // Assert
        Assert.NotNull(sanitizedForm);
        Assert.IsType<ContactRegistrationForm>(sanitizedForm);
        Assert.Equal(string.Empty, sanitizedForm.FirstName);
        Assert.Equal(string.Empty, sanitizedForm.LastName);
        Assert.Equal(string.Empty, sanitizedForm.Email);
        Assert.Equal(string.Empty, sanitizedForm.PhoneNumber);
        Assert.Equal(string.Empty, sanitizedForm.StreetAddress);
        Assert.Equal(string.Empty, sanitizedForm.StreetNumber);
        Assert.Equal(string.Empty, sanitizedForm.PostalCode);
        Assert.Equal(string.Empty, sanitizedForm.City);
    }
}
