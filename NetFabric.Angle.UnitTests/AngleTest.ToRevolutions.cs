using FluentAssertions;
using System;
using Xunit;

namespace NetFabric.UnitTests
{
    public partial class AngleTests
    {
        public static TheoryData<AngleDegrees, AngleRevolutions> DegreesToRevolutionsData = new TheoryData<AngleDegrees, AngleRevolutions>
        {
            { -AngleDegrees.Full, -AngleRevolutions.Full },
            { -AngleDegrees.Straight, -AngleRevolutions.Straight },
            { -AngleDegrees.Right, -AngleRevolutions.Right },
            { AngleDegrees.Zero, AngleRevolutions.Zero },
            { AngleDegrees.Right, AngleRevolutions.Right },
            { AngleDegrees.Straight, AngleRevolutions.Straight },
            { AngleDegrees.Full, AngleRevolutions.Full },
        };

        [Theory]
        [MemberData(nameof(DegreesToRevolutionsData))]
        public void ToRevolutions_With_AngleDegrees_Should_Succeed(AngleDegrees angle, AngleRevolutions expected)
        {
            // arrange

            // act
            var result = Angle.ToRevolutions(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleGradians, AngleRevolutions> GradiansToRevolutionsData = new TheoryData<AngleGradians, AngleRevolutions>
        {
            { -AngleGradians.Full, -AngleRevolutions.Full },
            { -AngleGradians.Straight, -AngleRevolutions.Straight },
            { -AngleGradians.Right, -AngleRevolutions.Right },
            { AngleGradians.Zero, AngleRevolutions.Zero },
            { AngleGradians.Right, AngleRevolutions.Right },
            { AngleGradians.Straight, AngleRevolutions.Straight },
            { AngleGradians.Full, AngleRevolutions.Full },
        };

        [Theory]
        [MemberData(nameof(GradiansToRevolutionsData))]
        public void ToRevolutions_With_AngleGradians_Should_Succeed(AngleGradians angle, AngleRevolutions expected)
        {
            // arrange

            // act
            var result = Angle.ToRevolutions(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRadians, AngleRevolutions> RadiansToRevolutionsData = new TheoryData<AngleRadians, AngleRevolutions>
        {
            { -AngleRadians.Full, -AngleRevolutions.Full },
            { -AngleRadians.Straight, -AngleRevolutions.Straight },
            { -AngleRadians.Right, -AngleRevolutions.Right },
            { AngleRadians.Zero, AngleRevolutions.Zero },
            { AngleRadians.Right, AngleRevolutions.Right },
            { AngleRadians.Straight, AngleRevolutions.Straight },
            { AngleRadians.Full, AngleRevolutions.Full },
        };

        [Theory]
        [MemberData(nameof(RadiansToRevolutionsData))]
        public void ToRevolutions_With_AngleRadians_Should_Succeed(AngleRadians angle, AngleRevolutions expected)
        {
            // arrange

            // act
            var result = Angle.ToRevolutions(angle);

            // assert
            result.Should().Be(expected);
        }

    }
}
