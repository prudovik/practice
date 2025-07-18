namespace task18;

using System.Threading;
using System.Collections.Concurrent;

public class SoftStopper : ICommand
{
    private readonly ServerThread server;
    public SoftStopper(ServerThread s) => server = s;
    public void Execute() => server.SoftStop();
    public bool isCompleted { get; }
}
