namespace CommandRunner;

using System.Reflection;

public class Program
{
    public static void Main(string[] args)
    {
        Assembly asm = Assembly.LoadFrom("FileSystemCommands.dll");
        var testDir = Path.Combine(Path.GetTempPath(), "TestDir");
        Directory.CreateDirectory(testDir);
        File.WriteAllText(Path.Combine(testDir, "test1.txt"), "Hello");
        File.WriteAllText(Path.Combine(testDir, "test2.txt"), "World");
        var command = new DirectorySizeCommand(testDir);
        command.Execute();
        Directory.Delete(testDir, true);

        var testDir = Path.Combine(Path.GetTempPath(), "TestDir");
        Directory.CreateDirectory(testDir);
        File.WriteAllText(Path.Combine(testDir, "file1.txt"), "Text");
        File.WriteAllText(Path.Combine(testDir, "file2.log"), "Log");
        var command = new FindFilesCommand(testDir, "*.txt");
        command.Execute();
        Directory.Delete(testDir, true);
    }
}

