using BenchmarkDotNet.Attributes;
using System;

namespace NetFabric.Benchmarks
{
    public class Operators
    {
        Angle angle0 = Angle.FromDegrees(45.0);
        Angle angle1 = Angle.FromDegrees(30.0);

        [Benchmark]
        public double Sin()
        {
            return Angle.Sin(angle0);
        }

        [Benchmark]
        public double SinByRef()
        {
            Angle.Sin(ref angle0, out double result);
            return result;
        }

        [Benchmark]
        public Angle Add()
        {
            return Angle.Add(angle0, angle1);
        }

        [Benchmark]
        public Angle AddByRef()
        {
            Angle.Add(ref angle0, ref angle1, out Angle result);
            return result;
        }

        [Benchmark]
        public Angle AddOperator()
        {
            return angle0 + angle1;
        }

    }
}
