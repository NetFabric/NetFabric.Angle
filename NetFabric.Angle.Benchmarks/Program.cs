using BenchmarkDotNet.Running;
using System;

namespace NetFabric.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var switcher = new BenchmarkSwitcher(new Type[] {
            });
            switcher.Run(args);
        }
    }
}
