

using Business.Models;

namespace Business.Interfaces;

public interface IFileService
{
    /// <summary>
    /// Saves a list of objects to a file.
    /// </summary>
    /// <typeparam name="T">Represents the type of listed objects.</typeparam>
    /// <param name="list">The list to save</param>
    /// <returns>
    /// A <see cref="Result{T}"/> message, indicating whether the operation was successful or not.
    /// </returns>
    Result<string> SaveListToFile<T>(List<T> list);

    /// <summary>
    /// Reads a list of objects from a file.
    /// </summary>
    /// <typeparam name="T">The type of objects to read from the file.</typeparam>
    /// <param name="filePath">The filepath to read from</param>
    /// <returns>
    /// A <see cref="Result{T}"/> containing a list of objects if successful.
    /// If unsuccessful, the result contains an error message.
    /// </returns>

    Result<List<T>> ReadListFromFile<T>();
}
