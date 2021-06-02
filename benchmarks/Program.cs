using System;
using BenchmarkDotNet.Running;

namespace benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BiconditionalBenchmarks>();
            BenchmarkRunner.Run<DistributionBenchmarks>();
            BenchmarkRunner.Run<ImplicationBenchmarks>();
            BenchmarkRunner.Run<NegationBenchmarks>();
            BenchmarkRunner.Run<SubTreeBenchmarks>();
        }
    }
}
