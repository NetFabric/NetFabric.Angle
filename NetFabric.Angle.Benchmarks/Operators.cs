using BenchmarkDotNet.Attributes;
using System;

namespace NetFabric.Benchmarks
{
    [MemoryDiagnoser]
    public class Operators
    {
        AngleDegrees angle0 = Angle.InDegrees(45.0);
        AngleDegrees angle1 = Angle.InDegrees(30.0);

        [Benchmark]
        public double Sin()
        {
            return Angle.Sin(Angle.InRadians(angle0));
        }

        [Benchmark]
        public AngleDegrees Add()
        {
            return Angle.Add(angle0, angle1);
        }

        [Benchmark]
        public AngleDegrees AddOperator()
        {
            return angle0 + angle1;
        }

    }
}
