

using Business.Models;

namespace Business.Utilities;

public static class InputSanitizer
{
    public static void SanitizeInput(ContactRegistrationForm form)
    {
        form.FirstName = form.FirstName.Trim();
        form.LastName = form.LastName.Trim();
        form.Email = form.Email.Trim();
        form.PhoneNumber = form.PhoneNumber.Trim();
        form.StreetAddress = form.StreetAddress.Trim();
        form.StreetNumber = form.StreetNumber.Trim();
        form.City = form.City.Trim();
    }
}
