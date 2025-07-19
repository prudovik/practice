namespace task19tests;

using Xunit;
using task19;

public class LongOperationsTests
{
    [Fact]
    public void LongOperation_ExecuteCorrectNumberOfTimes()
    {
        Scheduler scheduler = new Scheduler();
        ServerThread server = new ServerThread(scheduler);

        TestCommand[] commands = new TestCommand[5];
        for (int i = 0; i < 5; i++)
        {
            commands[i] = new TestCommand(i + 1);
            server.AddCommand(commands[i]);
        }
        var waitingTime = 5000;
        var stopWatch = System.Diagnostics.Stopwatch.StartNew();
        while (stopWatch.ElapsedMilliseconds < waitingTime && commands.Any(c => c.counter < 3))
        {
            Thread.Sleep(15);
        }
        server.AddCommand(new HardStopper(server));
        Assert.All(commands, c => Assert.True(c.counter >= 3));
    }
}