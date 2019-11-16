using FluentAssertions;
using System;
using Xunit;

namespace NetFabric.UnitTests
{
    public partial class AngleTests
    {
        public static TheoryData<AngleDegrees, AngleGradians> DegreesToGradiansData = new TheoryData<AngleDegrees, AngleGradians>
        {
            { -AngleDegrees.Full, -AngleGradians.Full },
            { -AngleDegrees.Straight, -AngleGradians.Straight },
            { -AngleDegrees.Right, -AngleGradians.Right },
            { AngleDegrees.Zero, AngleGradians.Zero },
            { AngleDegrees.Right, AngleGradians.Right },
            { AngleDegrees.Straight, AngleGradians.Straight },
            { AngleDegrees.Full, AngleGradians.Full },
        };

        [Theory]
        [MemberData(nameof(DegreesToGradiansData))]
        public void ToGradians_With_AngleDegrees_Should_Succeed(AngleDegrees angle, AngleGradians expected)
        {
            // arrange

            // act
            var result = Angle.ToGradians(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRadians, AngleGradians> RadiansToGradiansData = new TheoryData<AngleRadians, AngleGradians>
        {
            { -AngleRadians.Full, -AngleGradians.Full },
            { -AngleRadians.Straight, -AngleGradians.Straight },
            { -AngleRadians.Right, -AngleGradians.Right },
            { AngleRadians.Zero, AngleGradians.Zero },
            { AngleRadians.Right, AngleGradians.Right },
            { AngleRadians.Straight, AngleGradians.Straight },
            { AngleRadians.Full, AngleGradians.Full },
        };

        [Theory]
        [MemberData(nameof(RadiansToGradiansData))]
        public void ToGradians_With_AngleRadians_Should_Succeed(AngleRadians angle, AngleGradians expected)
        {
            // arrange

            // act
            var result = Angle.ToGradians(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRevolutions, AngleGradians> RevolutionsToGradiansData = new TheoryData<AngleRevolutions, AngleGradians>
        {
            { -AngleRevolutions.Full, -AngleGradians.Full },
            { -AngleRevolutions.Straight, -AngleGradians.Straight },
            { -AngleRevolutions.Right, -AngleGradians.Right },
            { AngleRevolutions.Zero, AngleGradians.Zero },
            { AngleRevolutions.Right, AngleGradians.Right },
            { AngleRevolutions.Straight, AngleGradians.Straight },
            { AngleRevolutions.Full, AngleGradians.Full },
        };

        [Theory]
        [MemberData(nameof(RevolutionsToGradiansData))]
        public void ToGradians_With_AngleRevolutions_Should_Succeed(AngleRevolutions angle, AngleGradians expected)
        {
            // arrange

            // act
            var result = Angle.ToGradians(angle);

            // assert
            result.Should().Be(expected);
        }

    }
}
