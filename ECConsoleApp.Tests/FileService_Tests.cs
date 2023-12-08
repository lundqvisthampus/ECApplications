using ECConsoleApp.Services;
using System.Runtime.CompilerServices;

namespace ECConsoleApp.Tests;

public class FileService_Tests
{
    [Fact]
    public void SaveContentToFileShould_SaveContentToFile_ThenReturnTrue()
    {
        // Arrange
        string content = "Test";
        string filePath = @"C:\Coding\Test\Test.txt";
        FileService fileService = new FileService(filePath);

        // Act
        bool result = fileService.SaveContentToFile(content);

        // Assert
        Assert.True(result);
        Assert.True(File.Exists(filePath));
    }

    [Fact]
    public void GetContentFromFileShould_GetContentFromFile_ThenReturnContent()
    {
        // Arrange
        string filePath = @"C:\Coding\Test\Test.txt";
        FileService fileService = new FileService(filePath);

        // Act
        string content = fileService.GetContentFromFile();

        // Assert
        Assert.NotEmpty(content);
    }
}
