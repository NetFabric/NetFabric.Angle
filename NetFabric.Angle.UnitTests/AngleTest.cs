using FluentAssertions;
using System;
using Xunit;

namespace NetFabric.UnitTests
{
    public partial class AngleTests
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

        public static TheoryData<int, double, AngleDegrees> DegreesMinutesData = new TheoryData<int, double, AngleDegrees>
        {
            { 40, 0.0, Angle.FromDegrees(40) },
            { -40, 0.0, Angle.FromDegrees(-40) },
            { 40, 30.0, Angle.FromDegrees(40.5) },
            { -40, 30.0, Angle.FromDegrees(-40.5) },
        };

        public static TheoryData<int, int, double, AngleDegrees> DegreesMinutesSecondsData = new TheoryData<int, int, double, AngleDegrees>
        {
            { 40, 0, 0.0, Angle.FromDegrees(40) },
            { -40, 0, 0.0, Angle.FromDegrees(-40) },
            { 40, 30, 30.0, Angle.FromDegrees(40.50833) },
            { -40, 30, 30.0, Angle.FromDegrees(-40.50833) },
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
        [MemberData(nameof(DegreesMinutesData))]
        public void FromDegrees_When_AngleMinutes_Should_Succeed(int degrees, double minutes, AngleDegrees expected)
        {
            // arrange

            // act
            var angle = Angle.FromDegrees(degrees, minutes);

            // assert
            angle.Degrees.Should().BeApproximately(expected.Degrees, 0.0001);
        }

        [Theory]
        [MemberData(nameof(DegreesMinutesSecondsData))]
        public void FromDegrees_When_AngleMinutesSeconds_Should_Succeed(int degrees, int minutes, double seconds, AngleDegrees expected)
        {
            // arrange

            // act
            var angle = Angle.FromDegrees(degrees, minutes, seconds);

            // assert
            angle.Degrees.Should().BeApproximately(expected.Degrees, 0.0001);
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
    }
}
