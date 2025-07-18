namespace task18;

using System.Threading;
using System.Collections.Concurrent;

public class HardStopper : ICommand
{
    private readonly ServerThread server;
    public HardStopper(ServerThread s)
    {
        server = s;
    }
    public void Execute()
    {
        server.HardStop();
    }
    public bool isCompleted { get; }
}
