namespace task14tests;

using Xunit;
using task14;

public class DefiniteIntegralTests
{
    public static double X(double x) => x;
    public static double SIN(double x) => Math.Sin(x);

    [Fact]
    public void Test1()
    {
        Assert.Equal(0, DefiniteIntegral.Solve(-1, 1, X, 1e-4, 2), 1e-4);
    }

    [Fact]
    public void Test2()
    {
        Assert.Equal(0, DefiniteIntegral.Solve(-1, 1, SIN, 1e-5, 8), 1e-4);
    }

    [Fact]
    public void Test3()
    {
        Assert.Equal(12.5, DefiniteIntegral.Solve(0, 5, X, 1e-6, 8), 1e-5);
    }
}