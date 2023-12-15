namespace Shared.Interfaces;

/// <summary>
/// Interface for the FileService class. Everything in the interface needs to be implemented to the class, if it implements the IFileService.
/// </summary>
public interface IFileService
{
    bool SaveContentToFile(string content);
    string GetContentFromFile();
}
