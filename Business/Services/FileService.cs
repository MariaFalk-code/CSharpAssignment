

using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class FileService : IFileService
{
     public Result<string> SaveListToFile<T>(List<T> list)
    {
        throw new NotImplementedException();
    }
    public Result<List<T>> ReadListFromFile<T>(string filePath)
    {
        throw new NotImplementedException();
    }
}
{

}
