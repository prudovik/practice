namespace FileSystemCommands;

using CommandLib;

public class FindFilesCommand : ICommand
{
    public string Dir { get; set; }
    public string Mask { get; set; }
    public FindFilesCommand(string dir, string mask)
    {
        Dir = dir;
        Mask = mask;
    }
    public void Execute()
    {
        FindFiles.FindFilesByMask(Dir, Mask);
    }
}

public class FindFiles
{
    public static void FindFilesByMask(string dir, string mask)
    {
        string[] files = Directory.GetFiles(@dir, mask);
        foreach(string file in files) Console.WriteLine(file);
    }
}
