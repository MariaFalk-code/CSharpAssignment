

namespace Business.Interfaces;

public interface IFileService
{
    /// <summary>
    /// Saves a list of objects to a file.
    /// </summary>
    /// <typeparam name="T">Represents the type of listed objects.</typeparam>
    /// <param name="list">The list to save</param>
    
    void SaveListToFile<T>(List<T> list);

    /// <summary>
    /// Reads a list of objects from a file.
    /// </summary>
    /// <typeparam name="T">The type of objects to read from the file.</typeparam>
    /// <param name="filePath">The filepath to read from</param>
    /// <returns>A list of objects read from the file></returns>

    List<T> ReadListFromFile<T>(string filePath);
}
