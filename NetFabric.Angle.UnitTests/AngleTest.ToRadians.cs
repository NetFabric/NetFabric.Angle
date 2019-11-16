using FluentAssertions;
using System;
using Xunit;

namespace NetFabric.UnitTests
{
    public partial class AngleTests
    {
        public static TheoryData<AngleDegrees, AngleRadians> DegreesToRadiansData = new TheoryData<AngleDegrees, AngleRadians>
        {
            { -AngleDegrees.Full, -AngleRadians.Full },
            { -AngleDegrees.Straight, -AngleRadians.Straight },
            { -AngleDegrees.Right, -AngleRadians.Right },
            { AngleDegrees.Zero, AngleRadians.Zero },
            { AngleDegrees.Right, AngleRadians.Right },
            { AngleDegrees.Straight, AngleRadians.Straight },
            { AngleDegrees.Full, AngleRadians.Full },
        };

        [Theory]
        [MemberData(nameof(DegreesToRadiansData))]
        public void ToRadians_With_AngleRadians_Should_Succeed(AngleDegrees angle, AngleRadians expected)
        {
            // arrange

            // act
            var result = Angle.ToRadians(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleGradians, AngleRadians> GradiansToRadiansData = new TheoryData<AngleGradians, AngleRadians>
        {
            { -AngleGradians.Full, -AngleRadians.Full },
            { -AngleGradians.Straight, -AngleRadians.Straight },
            { -AngleGradians.Right, -AngleRadians.Right },
            { AngleGradians.Zero, AngleRadians.Zero },
            { AngleGradians.Right, AngleRadians.Right },
            { AngleGradians.Straight, AngleRadians.Straight },
            { AngleGradians.Full, AngleRadians.Full },
        };

        [Theory]
        [MemberData(nameof(GradiansToRadiansData))]
        public void ToRadians_With_AngleGradians_Should_Succeed(AngleGradians angle, AngleRadians expected)
        {
            // arrange

            // act
            var result = Angle.ToRadians(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRevolutions, AngleRadians> RevolutionsToRadiansData = new TheoryData<AngleRevolutions, AngleRadians>
        {
            { -AngleRevolutions.Full, -AngleRadians.Full },
            { -AngleRevolutions.Straight, -AngleRadians.Straight },
            { -AngleRevolutions.Right, -AngleRadians.Right },
            { AngleRevolutions.Zero, AngleRadians.Zero },
            { AngleRevolutions.Right, AngleRadians.Right },
            { AngleRevolutions.Straight, AngleRadians.Straight },
            { AngleRevolutions.Full, AngleRadians.Full },
        };

        [Theory]
        [MemberData(nameof(RevolutionsToRadiansData))]
        public void ToRadians_With_AngleRevolutions_Should_Succeed(AngleRevolutions angle, AngleRadians expected)
        {
            // arrange

            // act
            var result = Angle.ToRadians(angle);

            // assert
            result.Should().Be(expected);
        }

    }
}
