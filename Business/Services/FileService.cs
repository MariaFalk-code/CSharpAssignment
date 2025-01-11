

using Business.Interfaces;
using Business.Messages;
using Business.Models;
using System.Text.Json;

namespace Business.Services;

public class FileService : IFileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;

    public FileService(string directoryPath = "Data", string fileName = "contacts.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
    }

    public Result<string> SaveListToFile<T>(List<T> list)
    {
        try
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }

            var json = JsonSerializer.Serialize(list);
            File.WriteAllText(_filePath, json);

            return Result<string>.EmptySuccess();
        }
        catch (Exception ex)
        {
            return Result<string>.Failure($"{ErrorMessages.FileNotSaved}: {ex.Message}");
        }
    }
    public Result<List<T>> ReadListFromFile<T>()
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                return Result<List<T>>.Failure(ErrorMessages.FileNotFound);
            }
            var json = File.ReadAllText(_filePath);
            var list = JsonSerializer.Deserialize<List<T>>(json);

            if (list == null)
            {
                return Result<List<T>>.Failure(ErrorMessages.FileInvalid);
            }
            return Result<List<T>>.Success(list);
        }
        catch (Exception ex)
        {
            return Result<List<T>>.Failure(ex.Message);
        }
    }
}
