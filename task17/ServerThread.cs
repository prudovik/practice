namespace task17;

using System.Threading;
using System.Collections.Concurrent;

public class ServerThread
{
    private readonly BlockingCollection<ICommand> commands = new BlockingCollection<ICommand>();
    private Thread thread;
    public volatile bool isRunning;
    private bool _SoftStop;

    public void Start()
    {
        isRunning = true;
        thread = new Thread(Run);
        thread.Start();
    }

    private void Run()
    {
        while (isRunning)
        {
            if (commands.TryTake(out var command, 1000))
            {
                command.Execute();
            }
            if (_SoftStop && commands.Count == 0)
            {
                isRunning = false;
            }
        }
    }

    public void AddCommand(ICommand command)
    {
        commands.Add(command);
    }

    public void SoftStop()
    {
        if (Thread.CurrentThread != thread) throw new InvalidOperationException("Нельзя остановить данный поток");
    _SoftStop = true;
    }

    public void HardStop()
    {
        if (Thread.CurrentThread != thread) throw new InvalidOperationException("Нельзя остановить данный поток");
        isRunning = false;
    }
}
