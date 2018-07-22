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

        [Theory]
        [MemberData(nameof(DoubleData))]
        public void FromRevolutions_Should_Succeed(double value)
        {
            // arrange

            // act
            var angle = Angle.FromRevolutions(value);

            // assert
            angle.Should().BeOfType<AngleRevolutions>();
            angle.Revolutions.Should().Be(value);
        }

        public static TheoryData<int, double> DegreesMinutes_InvalidMinutes_Data = new TheoryData<int, double>
        {
            { 0, -90.0 },
            { 0, 90.0 },
        };

        [Theory]
        [MemberData(nameof(DegreesMinutes_InvalidMinutes_Data))]
        public void FromDegreesMinutes_With_InvalidMinutes_Should_Throw(int degrees, double minutes)
        {
            // arrange

            // act
            Action action = () => Angle.FromDegrees(degrees, minutes);

            // assert
            action.Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage($"Argument must be positive and less than 60.{Environment.NewLine}Parameter name: {nameof(minutes)}{Environment.NewLine}Actual value was {minutes}.")
                .Where(ex => ex.ParamName == nameof(minutes))
                .Where(ex => (double)ex.ActualValue == minutes);
        }

        public static TheoryData<int, int, double> DegreesMinutesSeconds_InvalidMinutes_Data = new TheoryData<int, int, double>
        {
            { 0, -90, 0 },
            { 0, 90, 0 },
        };

        [Theory]
        [MemberData(nameof(DegreesMinutesSeconds_InvalidMinutes_Data))]
        public void FromDegreesMinutesSeconds_With_InvalidMinutes_Should_Throw(int degrees, int minutes, double seconds)
        {
            // arrange

            // act
            Action action = () => Angle.FromDegrees(degrees, minutes, seconds);

            // assert
            action.Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage($"Argument must be greater or equal to 0 and less than 60.{Environment.NewLine}Parameter name: {nameof(minutes)}{Environment.NewLine}Actual value was {minutes}.")
                .Where(ex => ex.ParamName == "minutes")
                .Where(ex => (int)ex.ActualValue == minutes);
        }

        public static TheoryData<int, int, double> DegreesMinutesSeconds_InvalidSeconds_Data = new TheoryData<int, int, double>
        {
            { 0, 0, -90.0 },
            { 0, 0, 90.0 },
        };

        [Theory]
        [MemberData(nameof(DegreesMinutesSeconds_InvalidSeconds_Data))]
        public void FromDegreesMinutesSeconds_With_InvalidSeconds_Should_Throw(int degrees, int minutes, double seconds)
        {
            // arrange

            // act
            Action action = () => Angle.FromDegrees(degrees, minutes, seconds);

            // assert
            action.Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage($"Argument must be greater or equal to 0 and less than 60.{Environment.NewLine}Parameter name: {nameof(seconds)}{Environment.NewLine}Actual value was {seconds}.")
                .Where(ex => ex.ParamName == "seconds")
                .Where(ex => (double)ex.ActualValue == seconds);
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
