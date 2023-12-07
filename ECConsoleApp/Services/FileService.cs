using ECConsoleApp.Interfaces;
using System.Diagnostics;

namespace ECConsoleApp.Services;

public class FileService : IFileService
{
    private readonly string _filePath;

    /// <summary>
    /// Constructor that takes the string filePath as an argument.
    /// </summary>
    public FileService(string filePath)
    {
        _filePath = filePath;
    }

    /// <summary>
    /// Method that checks if the user has a directory with the path of _filePath, if not it will be created.
    /// Then tries to use StreamWriter to save the content to the correct filepath. If failed, it will write out an exception.
    /// </summary>
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

    /// <summary>
    /// Method that tries to get the content from filepath if the file exists.. If failed, it will write out an exception.
    /// </summary>
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
