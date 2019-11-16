using FluentAssertions;
using System;
using Xunit;

namespace NetFabric.UnitTests
{
    public partial class AngleTests
    {
        public static TheoryData<AngleGradians, AngleDegrees> GradiansToDegreesData = new TheoryData<AngleGradians, AngleDegrees>
        {
            { -AngleGradians.Full, -AngleDegrees.Full },
            { -AngleGradians.Straight, -AngleDegrees.Straight },
            { -AngleGradians.Right, -AngleDegrees.Right },
            { AngleGradians.Zero, AngleDegrees.Zero },
            { AngleGradians.Right, AngleDegrees.Right },
            { AngleGradians.Straight, AngleDegrees.Straight },
            { AngleGradians.Full, AngleDegrees.Full },
        };

        [Theory]
        [MemberData(nameof(GradiansToDegreesData))]
        public void ToDegrees_With_AngleGradians_Should_Succeed(AngleGradians angle, AngleDegrees expected)
        {
            // arrange

            // act
            var result = Angle.ToDegrees(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRadians, AngleDegrees> RadiansToDegreesData = new TheoryData<AngleRadians, AngleDegrees>
        {
            { -AngleRadians.Full, -AngleDegrees.Full },
            { -AngleRadians.Straight, -AngleDegrees.Straight },
            { -AngleRadians.Right, -AngleDegrees.Right },
            { AngleRadians.Zero, AngleDegrees.Zero },
            { AngleRadians.Right, AngleDegrees.Right },
            { AngleRadians.Straight, AngleDegrees.Straight },
            { AngleRadians.Full, AngleDegrees.Full },
        };

        [Theory]
        [MemberData(nameof(RadiansToDegreesData))]
        public void ToDegrees_With_AngleRadians_Should_Succeed(AngleRadians angle, AngleDegrees expected)
        {
            // arrange

            // act
            var result = Angle.ToDegrees(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRevolutions, AngleDegrees> RevolutionsToDegreesData = new TheoryData<AngleRevolutions, AngleDegrees>
        {
            { -AngleRevolutions.Full, -AngleDegrees.Full },
            { -AngleRevolutions.Straight, -AngleDegrees.Straight },
            { -AngleRevolutions.Right, -AngleDegrees.Right },
            { AngleRevolutions.Zero, AngleDegrees.Zero },
            { AngleRevolutions.Right, AngleDegrees.Right },
            { AngleRevolutions.Straight, AngleDegrees.Straight },
            { AngleRevolutions.Full, AngleDegrees.Full },
        };

        [Theory]
        [MemberData(nameof(RevolutionsToDegreesData))]
        public void ToDegrees_With_AngleRevolutions_Should_Succeed(AngleRevolutions angle, AngleDegrees expected)
        {
            // arrange

            // act
            var result = Angle.ToDegrees(angle);

            // assert
            result.Should().Be(expected);
        }

    }
}
