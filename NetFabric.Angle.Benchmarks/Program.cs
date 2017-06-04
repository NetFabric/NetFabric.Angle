using BenchmarkDotNet.Running;
using System;

namespace NetFabric.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run(typeof(Operators));
        }
    }
}
