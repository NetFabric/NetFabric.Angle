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

    }
}
