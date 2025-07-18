namespace task17tests;

using Xunit;
using task17;

public class TestCommand : ICommand
{
    public void Execute()
    {
        Thread.Sleep(1000);
    }
}
public class StopsTests
{
    [Fact]
    public void HardStop_StopsThreadImmediately()
    {
        var server = new ServerThread();

        server.AddCommand(new TestCommand());
        server.AddCommand(new HardStopper(server));
        server.AddCommand(new TestCommand());

        Thread.Sleep(1000);

        Assert.False(server.isRunning);
    }

    [Fact]
    public void HardStop_ReturnsErrorInWrongThread()
    {
        var server = new ServerThread();
        var hardStop = new HardStopper(server);

        Assert.Throws<InvalidOperationException>(() => hardStop.Execute());
    }

    [Fact]
    public void SoftStop_StopsThreadAfterAllCommands()
    {
        var server = new ServerThread();

        server.AddCommand(new TestCommand());
        server.AddCommand(new SoftStopper(server));
        server.AddCommand(new TestCommand());

        Thread.Sleep(2000);

        Assert.False(server.isRunning);
    }

    [Fact]
    public void SoftStop_ReturnsErrorInWrongThread()
    {
        var server = new ServerThread();
        var softStop = new SoftStopper(server);

        Assert.Throws<InvalidOperationException>(() => softStop.Execute());
    }
}