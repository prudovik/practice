namespace CommandRunner;

using System.Reflection;
using System.IO;
using CommandLib;

public class Program
{
    public static void Main(string[] args)
    {
        Assembly asm = Assembly.LoadFrom("FileSystemCommands.dll");
        var testDir1 = Path.Combine(Path.GetTempPath(), "TestDir");
        Directory.CreateDirectory(testDir1);
        File.WriteAllText(Path.Combine(testDir1, "test1.txt"), "Hello");
        File.WriteAllText(Path.Combine(testDir1, "test2.txt"), "World");
        var command1 = new DirectorySizeCommand(testDir1);
        command1.Execute();
        Directory.Delete(testDir1, true);

        var testDir2 = Path.Combine(Path.GetTempPath(), "TestDir");
        Directory.CreateDirectory(testDir2);
        File.WriteAllText(Path.Combine(testDir2, "file1.txt"), "Text");
        File.WriteAllText(Path.Combine(testDir2, "file2.log"), "Log");
        var command2 = new FindFilesCommand(testDir2, "*.txt");
        command2.Execute();
        Directory.Delete(testDir2, true);
    }
}

