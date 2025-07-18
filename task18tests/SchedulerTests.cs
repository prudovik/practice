namespace task18tests;

using Xunit;
using task18;

public class TestCommand : ICommand
{
    private int timesExecuted = 0;
    public bool isCompleted => timesExecuted >= 3;

    public void Execute()
    {
        timesExecuted++;
    }
}

public class SchedulerTests
{
    
    [Fact]
    public void TestCommand_ExecutesMultipleTimes()
    {
        var scheduler = new Scheduler();
        var server = new ServerThread(scheduler);
        var command = new TestCommand();
        server.AddCommand(command);
        Thread.Sleep(5000);
        server.Stop();
        Assert.True(command.isCompleted);
    }
}
