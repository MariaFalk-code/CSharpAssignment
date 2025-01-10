
using System.ComponentModel.DataAnnotations;

namespace Business.Utilities;

public static class PromptAndValidate
{
    /// <summary>
    /// A utility method that prompts user input and validates it against the specified property of a given instance, using data annotation attributes.
    /// </summary>
    /// <param name="promptMessage">The promptmessage to display.</param>
    /// <param name="instance">the objectinstance providing the property to validate.</param>
    /// <param name="propertyName">The name of the property to validate.</param>
    /// <returns>The validated input provided by the user.</returns>
    public static string Prompt(string promptMessage, object instance, string propertyName)
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine(promptMessage);
            string input = Console.ReadLine() ?? string.Empty;

            var context = new ValidationContext(instance) { MemberName = propertyName };
            var results = new List<ValidationResult>();

            if (Validator.TryValidateProperty(input, context, results))
            {
                return input;
            }

            Console.WriteLine(results[0].ErrorMessage);
            Console.WriteLine("Please try again.");
        }
    }
}


