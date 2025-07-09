namespace CommandRunner;

using System;
using System.Reflection;
using System.IO;
using CommandLib;

public class Program
{
    public static void Main()
    {
        var asm = Assembly.LoadFrom("FileSystemCommands.dll");
        var testDir1 = Path.Combine(Path.GetTempPath(), "TestDir");
        Directory.CreateDirectory(testDir1);
        File.WriteAllText(Path.Combine(testDir1, "test1.txt"), "Hello");
        File.WriteAllText(Path.Combine(testDir1, "test2.txt"), "World");
        Type dirsize = asm.GetType("DirectorySizeCommands");
        MethodInfo ex1 = dirsize.GetMethod("Execute");
        ex1.Invoke(null, new object[] { testDir1 });
        Directory.Delete(testDir1, true);

        var testDir2 = Path.Combine(Path.GetTempPath(), "TestDir");
        Directory.CreateDirectory(testDir2);
        File.WriteAllText(Path.Combine(testDir2, "file1.txt"), "Text");
        File.WriteAllText(Path.Combine(testDir2, "file2.log"), "Log");
        Type findfiles = asm.GetType("findfiles");
        MethodInfo ex2 = findfiles.GetMethod("Execute");
        ex2.Invoke(null, new object[] { testDir2, "*.txt" });
        Directory.Delete(testDir2, true);
    }
}

