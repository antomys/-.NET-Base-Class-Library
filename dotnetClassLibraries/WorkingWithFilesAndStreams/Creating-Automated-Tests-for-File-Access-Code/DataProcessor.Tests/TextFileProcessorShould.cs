using System.IO.Abstractions.TestingHelpers;
using ApprovalTests.Reporters;
using Xunit;

namespace DataProcessor.Tests
{
    public class TextFileProcessorShould
    {
        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void MakeOddUppercase()
        {
            // Arrange
            // Create a mock input file
            var mockInput = new MockFileData("Line1\nLine2\nLine3");
            var mockFs = new MockFileSystem();
            mockFs.AddFile(@"c:\root\in\myFile.txt", mockInput);
            mockFs.AddDirectory(@"c:\root\out");
            
            // Act
            // Create TextFileProcessor with mock fs
            var textProcessor = new TextFileProcessor(@"c:\root\in\myFile.txt",
                @"c:\root\out\myFile.txt", mockFs);

            textProcessor.ProcessFileStreamLines();
            
            // Assert
            
            Assert.True(mockFs.FileExists(@"c:\root\out\myFile.txt"));

            var processedFile = mockFs.GetFile(@"c:\root\out\myFile.txt");

            var lines = processedFile.TextContents.Split('\n');
            
            Assert.Equal("Line1".ToUpper(),lines[0]);
        }
        
        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void ReverseByte()
        {
            // Arrange
            // Create a mock input file
            var mockInput = new MockFileData(new byte[]{0xff,0x34,0x56,0xd2});
            var mockFs = new MockFileSystem();
            mockFs.AddFile(@"c:\root\in\myFile.csv", mockInput);
            mockFs.AddDirectory(@"c:\root\out");
            
            // Act
            // Create TextFileProcessor with mock fs
            var textProcessor = new TextFileProcessor(@"c:\root\in\myFile.csv",
                @"c:\root\out\myFile.csv", mockFs);

            textProcessor.ProcessFileStreamLines();
            
            // Assert
            
            Assert.True(mockFs.FileExists(@"c:\root\out\myFile.csv"));

            var processedFile = mockFs.GetFile(@"c:\root\out\myFile.csv");

            var lines = processedFile.Contents;
            
            Assert.Equal(7, lines.Length);
            Assert.Equal(0x56,lines[4]);
        }
    }
}