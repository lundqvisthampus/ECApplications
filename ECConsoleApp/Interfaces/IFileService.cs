namespace ECConsoleApp.Interfaces;

internal interface IFileService
{
    bool SaveContentToFile(string content);
    string GetContentFromFile();
}
