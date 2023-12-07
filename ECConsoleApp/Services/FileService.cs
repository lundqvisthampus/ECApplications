using ECConsoleApp.Interfaces;
using System.Diagnostics;

namespace ECConsoleApp.Services;

/// <summary>
/// Methods for manageing the getting/saving of the contactlist to a json formated file.
/// </summary>

public class FileService : IFileService
{
    private readonly string _filePath;

    public FileService(string filePath)
    {
        _filePath = filePath;
    }

    // Checks if user has the directory path (_filePath), if not, it will be created.
    // Then saves the content to file.
    public bool SaveContentToFile(string content)
    {
        try
        {
            string directoryPath = Path.GetDirectoryName(_filePath)!;
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (var sw = new StreamWriter(_filePath)) 
            {
                sw.WriteLine(content);
            }
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    // Using streamreader to get the content from a file.
    public string GetContentFromFile()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                using (var sr = new StreamReader(_filePath))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

}
