namespace task14;

using System.Threading;

public class DefiniteIntegral
{
    public static double IntegralStep(double start, double end, Func<double, double> function, double step)
    {
        double res = 0.0;
        for(double i = start; i < end; i += step)
        {
            if(end < i + step) res += (function(i) + function(end)) / 2 * (end - i);
            else res += (function(i) + function(i + step)) / 2 * step;
        }
        return res;
    }
    public static double Solve(double a, double b, Func<double, double> function, double step, int threadsnumber)
    {
        double res = 0.0;
        double segment = (b - a)/threadsnumber;
        Barrier barrier = new Barrier(threadsnumber + 1);
        object locker = new object();
        for(int i = 0; i < threadsnumber; i++)
        {
            double start = a + segment * i;
            double end;
            if(i == threadsnumber - 1) end = b;
            else end = start + segment;

            Thread thread = new Thread( () =>
            {
                lock (locker)
                {
                    res += IntegralStep(start, end, function, step);
                }
                barrier.SignalAndWait();
            });
            thread.Start();
        }
        barrier.SignalAndWait();
        
        return res;
    }
}
