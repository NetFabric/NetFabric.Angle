using FluentAssertions;
using System;
using Xunit;

namespace NetFabric.UnitTests
{
    public class AngleTests
    {
        public static TheoryData<double> DoubleData = new TheoryData<double>
        {
            0.0,
            Math.PI,
            double.NaN,
            double.MinValue,
            double.MaxValue,
            double.PositiveInfinity,
            double.NegativeInfinity,
        };

        [Theory]
        [MemberData(nameof(DoubleData))]
        public void FromRadians_Should_Succeed(double value)
        {
            // arrange

            // act
            var angle = Angle.FromRadians(value);

            // assert
            angle.Should().BeOfType<AngleRadians>();
            angle.Radians.Should().Be(value);
        }

        [Theory]
        [MemberData(nameof(DoubleData))]
        public void FromDegrees_Should_Succeed(double value)
        {
            // arrange

            // act
            var angle = Angle.FromDegrees(value);

            // assert
            angle.Should().BeOfType<AngleDegrees>();
            angle.Degrees.Should().Be(value);
        }

        [Theory]
        [MemberData(nameof(DoubleData))]
        public void FromGradians_Should_Succeed(double value)
        {
            // arrange

            // act
            var angle = Angle.FromGradians(value);

            // assert
            angle.Should().BeOfType<AngleGradians>();
            angle.Gradians.Should().Be(value);
        }

        /*
        [Fact]
        public void ToString_Should_Succeed()
        {
#if NET35
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
#else
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
#endif

            RadiansAngle.Straight.ToString().Should().Be("3.14159265358979");

            RadiansAngle.Straight.ToString("R").Should().Be("3.14159265358979");
            RadiansAngle.Straight.ToString("D").Should().Be("180°");
            Angle.InRadians(12, 34.56).ToString("M").Should().Be("12° 34.56'");
            Angle.InRadians(12, 34, 56.78).ToString("S").Should().Be("12° 34' 56.7800000000018\"");
            RadiansAngle.Straight.ToString("G").Should().Be("200");

            RadiansAngle.Straight.ToString("R", new CultureInfo("pt-PT")).Should().Be("3,14159265358979");
            RadiansAngle.Straight.ToString("D", new CultureInfo("pt-PT")).Should().Be("180°");
            Angle.InRadians(12, 34.56).ToString("M", new CultureInfo("pt-PT")).Should().Be("12° 34,56'");
            Angle.InRadians(12, 34, 56.78).ToString("S", new CultureInfo("pt-PT")).Should().Be("12° 34' 56,7800000000018\"");
            RadiansAngle.Straight.ToString("G", new CultureInfo("pt-PT")).Should().Be("200");

            String.Format("Radians: {0:R}", RadiansAngle.Straight).Should().Be("Radians: 3.14159265358979");
            String.Format("Degrees: {0:D}", RadiansAngle.Straight).Should().Be("Degrees: 180°");
            String.Format("Degrees: {0:M}", Angle.InRadians(12, 34.56)).Should().Be("Degrees: 12° 34.56'");
            String.Format("Degrees: {0:S}", Angle.InRadians(12, 34, 56.78)).Should().Be("Degrees: 12° 34' 56.7800000000018\"");
            String.Format("Gradians: {0:G}", RadiansAngle.Straight).Should().Be("Gradians: 200");

            RadiansAngle.Straight.ToString("R2").Should().Be("3.14");
            RadiansAngle.Straight.ToString("D2").Should().Be("180.00°");
            Angle.InRadians(12, 34.56).ToString("M2").Should().Be("12° 34.56'");
            Angle.InRadians(12, 34, 56.78).ToString("S2").Should().Be("12° 34' 56.78\"");
            RadiansAngle.Straight.ToString("G2").Should().Be("200.00");

            RadiansAngle.Straight.ToString("R2", new CultureInfo("pt-PT")).Should().Be("3,14");
            RadiansAngle.Straight.ToString("D2", new CultureInfo("pt-PT")).Should().Be("180,00°");
            Angle.InRadians(12, 34.56).ToString("M2", new CultureInfo("pt-PT")).Should().Be("12° 34,56'");
            Angle.InRadians(12, 34, 56.78).ToString("S2", new CultureInfo("pt-PT")).Should().Be("12° 34' 56,78\"");
            RadiansAngle.Straight.ToString("G2", new CultureInfo("pt-PT")).Should().Be("200,00");

            String.Format(new CultureInfo("pt-PT"), "Radians: {0:R2}", RadiansAngle.Straight).Should().Be("Radians: 3,14");
            String.Format(new CultureInfo("pt-PT"), "Degrees: {0:D2}", RadiansAngle.Straight).Should().Be("Degrees: 180,00°");
            String.Format(new CultureInfo("pt-PT"), "Degrees: {0:M2}", Angle.InRadians(12, 34.56)).Should().Be("Degrees: 12° 34,56'");
            String.Format(new CultureInfo("pt-PT"), "Degrees: {0:S2}", Angle.InRadians(12, 34, 56.78)).Should().Be("Degrees: 12° 34' 56,78\"");
            String.Format(new CultureInfo("pt-PT"), "Gradians: {0:G2}", RadiansAngle.Straight).Should().Be("Gradians: 200,00");

        }
*/

    }
}
