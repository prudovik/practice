namespace task08tests;

using System.IO;
using Xunit;
using FileSystemCommands;

public class FileSystemCommandsTests
{
    [Fact]
    public void DirectorySizeCommand_ShouldCalculateSize()
    {
        var testDir = Path.Combine(Path.GetTempPath(), "TestDir");
        Directory.CreateDirectory(testDir);
        File.WriteAllText(Path.Combine(testDir, "test1.txt"), "Hello");
        File.WriteAllText(Path.Combine(testDir, "test2.txt"), "World");

        var command = new DirectorySizeCommand(testDir);
        var output = new StringWriter();
        Console.SetOut(output);
        string result = "10\n";
        command.Execute();
        Directory.Delete(testDir, true);
        Assert.Equal(result, output.ToString());
    }

    [Fact]
    public void FindFilesCommand_ShouldFindMatchingFiles()
    {
        var testDir = Path.Combine(Path.GetTempPath(), "TestDir");
        Directory.CreateDirectory(testDir);
        File.WriteAllText(Path.Combine(testDir, "file1.txt"), "Text");
        File.WriteAllText(Path.Combine(testDir, "file2.log"), "Log");

        var command = new FindFilesCommand(testDir, "*.txt");
        var output = new StringWriter();
        Console.SetOut(output);
        string result = "/tmp/TestDir/file1.txt\n";
        command.Execute();
        Directory.Delete(testDir, true);
        Assert.Equal(result, output.ToString());
    }
}