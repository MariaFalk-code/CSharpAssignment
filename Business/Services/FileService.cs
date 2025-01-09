

using Business.Interfaces;
using Business.Models;
using Business.Utilities;
using System.Text.Json;

namespace Business.Services;

public class FileService : IFileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;

    public FileService(string directoryPath = "Data", string fileName = "list.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
    }

    public Result<string> SaveListToFile<T>(List<T> list)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list), ErrorMessages.NullListException);
        }

        try
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }

            var json = JsonSerializer.Serialize(list);
            File.WriteAllText(_filePath, json);

            return Result<string>.EmptySuccess(SuccessMessages.FileSaved);
        }
        catch (Exception ex)
        {
            return Result<string>.Failure($"{ErrorMessages.FileNotSaved}: {ex.Message}");
        }
    }
    public Result<List<T>> ReadListFromFile<T>(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                return Result<List<T>>.Failure(ErrorMessages.FileNotFound);
            }
            var json = File.ReadAllText(filePath);
            var list = JsonSerializer.Deserialize<List<T>>(json);

            if (list == null)
            {
                return Result<List<T>>.Failure(ErrorMessages.FileInvalid);
            }
            return Result<List<T>>.Success(list, SuccessMessages.FileRead);
        }
        catch (Exception ex)
        {
            return Result<List<T>>.Failure($"{ErrorMessages.FileNotRead}: {ex.Message}");
        }
    }
}
