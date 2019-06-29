using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System;

namespace NetFabric.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [DisassemblyDiagnoser(printAsm: true, printSource: true)]
    [MarkdownExporterAttribute.GitHub]
    public class OperatorsBenchmarks
    {
        const double DegreesInRadians = 360.0 / (Math.PI * 2.0);

        static readonly double degrees0 = 45.0;
        static readonly double degrees1 = 30.0;
        static readonly AngleDegrees angleDegrees0 = Angle.InDegrees(degrees0);
        static readonly AngleDegrees angleDegrees1 = Angle.InDegrees(degrees1);
        static readonly AngleRadians angleRadians0 = Angle.InRadians(angleDegrees0);
        static readonly AngleRadians angleRadians1 = Angle.InRadians(angleDegrees1);
        static readonly double radians0 = angleRadians0.Radians;
        static readonly double radians1 = angleRadians1.Radians;

        [BenchmarkCategory("Conversion")]
        [Benchmark(Baseline = true)]
        public double Conversion_Double() => degrees0 / DegreesInRadians;

        [BenchmarkCategory("Conversion")]
        [Benchmark]
        public AngleRadians Conversion_Angle() => Angle.InRadians(angleDegrees0);

        [BenchmarkCategory("Sin")]
        [Benchmark(Baseline = true)]
        public double Sin_Double() => Math.Sin(radians0);

        [BenchmarkCategory("Sin")]
        [Benchmark]
        public double Sin_Angle() => Angle.Sin(angleRadians0);

        [BenchmarkCategory("Equal")]
        [Benchmark(Baseline = true)]
        public bool Equal_Double() => degrees0 == degrees1;

        [BenchmarkCategory("Equal")]
        [Benchmark]
        public bool Equal_Angle_Operator() => angleDegrees0 == angleDegrees1;

        [BenchmarkCategory("Equal")]
        [Benchmark]
        public bool Equal_Angle_Method() => Angle.Equal(angleDegrees0, angleDegrees1);

        [BenchmarkCategory("Compare")]
        [Benchmark(Baseline = true)]
        public bool Compare_Double() => degrees0 < degrees1;

        [BenchmarkCategory("Compare")]
        [Benchmark]
        public bool Compare_Angle_Operator() => angleDegrees0 < angleDegrees1;

        [BenchmarkCategory("Compare")]
        [Benchmark]
        public bool Compare_Angle_Method() => Angle.Compare(angleDegrees0, angleDegrees1) < 0;

        [BenchmarkCategory("Add")]
        [Benchmark(Baseline = true)]
        public double Add_Double() => degrees0 + degrees1;

        [BenchmarkCategory("Add")]
        [Benchmark]
        public AngleDegrees Add_Angle_Operator() => angleDegrees0 + angleDegrees1;

        [BenchmarkCategory("Add")]
        [Benchmark]
        public AngleDegrees Add_Angle_Method() => Angle.Add(angleDegrees0, angleDegrees1);
    }
}
