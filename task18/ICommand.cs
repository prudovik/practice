namespace task18;

public interface ICommand
{
    void Execute();
    bool isCompleted { get; }
}
