

using Business.Dtos;
using Business.Messages;
using Business.Models;
using System.Text.RegularExpressions;

namespace Business.Utilities;

public static class InputSanitizer
{
    /// <summary>
    /// Sanitizes the input of a <see cref="ContactRegistrationForm"/> by removing extra spaces (leading, trailing and between words)
    /// When applicable, the method also converts the input to title case.
    /// </summary>
    /// <param name="form">The form to sanitize</param>
    public static ContactRegistrationForm Sanitize(ContactRegistrationForm form)
    {
        if (form == null)
        {
            throw new ArgumentNullException(nameof(form), ErrorMessages.NullFormException);
        }
        form.FirstName = ToTitleCase(RemoveExtraSpaces(form.FirstName));
        form.LastName = ToTitleCase(RemoveExtraSpaces(form.LastName));
        form.Email = RemoveExtraSpaces(form.Email);
        form.PhoneNumber = RemoveExtraSpaces(form.PhoneNumber);
        form.StreetAddress = ToTitleCase(RemoveExtraSpaces(form.StreetAddress));
        form.StreetNumber = RemoveExtraSpaces(form.StreetNumber);
        form.PostalCode = RemoveExtraSpaces(form.PostalCode);
        form.City = ToTitleCase(RemoveExtraSpaces(form.City));

        return form;
    }

    private static string RemoveExtraSpaces(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return string.Empty;

        return Regex.Replace(input.Trim(), @"\s{2,}", " ");
    }

    private static string ToTitleCase(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return string.Empty;

        return string.Join(' ', input.Split(' ')
            .Where(word => !string.IsNullOrWhiteSpace(word)).Select(word => word.Length > 1 ? char.ToUpper(word[0]) + word.Substring(1).ToLower() : word.ToUpper()));
    }
}
