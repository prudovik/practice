namespace task18;

using System.Threading;
using System.Collections.Concurrent;

public class Scheduler : IScheduler
{
    public readonly Queue<ICommand> commands = new();

    public void Add(ICommand command)
    {
        commands.Enqueue(command);
    }

    public bool HasCommand()
    {
        return commands.Count > 0;
    }

    public ICommand Select()
    {
        ICommand command = commands.Dequeue();
        commands.Enqueue(command);
        return command;
    }
}
