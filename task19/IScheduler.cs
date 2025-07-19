namespace task19;

public interface IScheduler
{
    bool HasCommand();
    ICommand Select();
    void Add(ICommand command);
}
