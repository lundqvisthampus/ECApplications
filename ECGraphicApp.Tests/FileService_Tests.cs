using ECGraphicApp.Models;
using ECGraphicApp.Services;

namespace ECGraphicApp.Tests;

public class FileService_Tests
{
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
