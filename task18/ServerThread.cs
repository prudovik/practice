﻿namespace task18;

using System.Threading;
using System.Collections.Concurrent;

public class ServerThread
{
    private readonly BlockingCollection<ICommand> commands = new BlockingCollection<ICommand>();
    public Thread thread;
    public volatile bool isRunning = true;
    public bool _SoftStop = false;
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
            ICommand command = null;

            if(scheduler.HasCommand())
            {
                command = scheduler.Select();
            }
            else if(commands.TryTake(out var com, 1000))
            {
                command = com;
            }
            if(command != null)
            {
                    command.Execute();
                    if(!command.isCompleted) scheduler.Add(command);
            }
            if (_SoftStop && !scheduler.HasCommand())
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
        if(Thread.CurrentThread != thread) throw new InvalidOperationException("Нельзя остановить данный поток");
        if(!scheduler.HasCommand()) isRunning = false;
        else _SoftStop = true; 
    }

    public void HardStop()
    {
        if(Thread.CurrentThread != thread) throw new InvalidOperationException("Нельзя остановить данный поток");
        isRunning = false;
    }

    public void Stop()
    {
        isRunning = false;
        thread.Join();
    }
}
