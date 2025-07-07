namespace FileSystemCommands;

using CommandLib;
using System.IO;

public class DirectorySizeCommand : ICommand
{
    public string Dir { get; set; }
    public DirectorySizeCommand(string dir) => Dir = dir;
    public void Execute()
    {
        Console.WriteLine(DirectorySize.DirSizeCalc(Dir));
    }
}

public class DirectorySize
{
    public static long DirSizeCalc(string dir)
    {
        long size = 0;
        try
        {
            DirectoryInfo directory = new DirectoryInfo(dir);
            FileInfo[] files = directory.GetFiles();
            foreach (var file in files)
            {
                size += file.Length;
            }
            DirectoryInfo[] subdirectory = directory.GetDirectories();
            foreach (var subdir in subdirectory)
            {
                size += DirSizeCalc(subdir.FullName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при обработке каталога {dir}: {ex.Message}");
        }
        return size;
    }
}
