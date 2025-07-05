using BenchmarkDotNet.Running;

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run(typeof(Program).Assembly);

        // BenchmarkRunner.Run<UserRepositoryBenchmarks>();
    }
}