namespace task19;

using System.Threading;
using System.Collections.Concurrent;

public class ServerThread
{
    private readonly BlockingCollection<ICommand> commands = new BlockingCollection<ICommand>();
    public Thread thread;
    public volatile bool isRunning = true;
    private IScheduler scheduler;

    public ServerThread(IScheduler _scheduler)
    {
        scheduler = _scheduler;
        thread = new Thread(Run);
        thread.Start();
    }

    private void Run()
    {
        while(isRunning)
        {
            while(commands.TryTake(out var command))
                scheduler.Add(command);

            if(scheduler.HasCommand())
            {
                var currentCommand = scheduler.Select();
                currentCommand.Execute();
                Thread.Sleep(10); 
            }
            else Thread.Sleep(9);
        }
    }

    public void AddCommand(ICommand command)
    {
        commands.Add(command);
    }

    public void HardStop()
    {
        isRunning = false;
        thread.Join();
    }
}
