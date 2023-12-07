namespace ECConsoleApp.Interfaces;

/// <summary>
/// Interface for the FileService class, which needs to be implemented in the FileService if it uses the interface.
/// </summary>
internal interface IFileService
{
    bool SaveContentToFile(string content);
    string GetContentFromFile();
}