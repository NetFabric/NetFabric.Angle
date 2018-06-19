using FluentAssertions;
using System;
using System.Globalization;
using Xunit;

namespace NetFabric.UnitTests
{
    public class AngleRadiansTests
    {
        static readonly AngleRadians AcuteAngle = AngleRadians.Right / 2.0;

        public static TheoryData<AngleRadians, object, bool, bool, bool> CompareInvalidData = new TheoryData<AngleRadians, object, bool, bool, bool>
        {
            { AngleRadians.Right, null, false, false, false },
            { AngleRadians.Right, 90.0, false, false, false },
        };

        public static TheoryData<AngleRadians, AngleRadians, bool, bool, bool> CompareData = new TheoryData<AngleRadians, AngleRadians, bool, bool, bool>
        {
            { AngleRadians.Zero, AngleRadians.Right - AngleRadians.Full, false, false, true },
            { AngleRadians.Right, AngleRadians.Right - AngleRadians.Full, false, false, true },
            { AngleRadians.Straight, AngleRadians.Right - AngleRadians.Full, false, false, true },

            { AngleRadians.Zero, AngleRadians.Right, true, false, false },
            { AngleRadians.Right, AngleRadians.Right, false, true, false },
            { AngleRadians.Straight, AngleRadians.Right, false, false, true },

            { AngleRadians.Zero, AngleRadians.Right + AngleRadians.Full, true, false, false },
            { AngleRadians.Right, AngleRadians.Right + AngleRadians.Full, true, false, false },
            { AngleRadians.Straight, AngleRadians.Right + AngleRadians.Full, true, false, false },
        };

        public static TheoryData<AngleRadians, AngleRadians, bool, bool, bool> CompareReducedData = new TheoryData<AngleRadians, AngleRadians, bool, bool, bool>
        {
            { AngleRadians.Zero, AngleRadians.Right - AngleRadians.Full, true, false, false },
            { AngleRadians.Right, AngleRadians.Right - AngleRadians.Full, false, true, false },
            { AngleRadians.Straight, AngleRadians.Right - AngleRadians.Full, false, false, true },

            { AngleRadians.Zero, AngleRadians.Right, true, false, false },
            { AngleRadians.Right, AngleRadians.Right, false, true, false },
            { AngleRadians.Straight, AngleRadians.Right, false, false, true },

            { AngleRadians.Zero, AngleRadians.Right + AngleRadians.Full, true, false, false },
            { AngleRadians.Right, AngleRadians.Right + AngleRadians.Full, false, true, false },
            { AngleRadians.Straight, AngleRadians.Right + AngleRadians.Full, false, false, true },
        };

        [Theory]
        [MemberData(nameof(CompareInvalidData))]
        [MemberData(nameof(CompareData))]
        public void EqualsObject_Should_Succeed(AngleRadians left, object right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left.Equals(right);

            // assert
            result.Should().Be(equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void Equals_Should_Succeed(AngleRadians left, AngleRadians right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left.Equals(right);

            // assert
            result.Should().Be(equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void GetHashCode_Should_Succeed(AngleRadians left, AngleRadians right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left.GetHashCode();

            // assert
            if (equal)
                result.Should().Be(right.GetHashCode());
            else
                result.Should().NotBe(right.GetHashCode());
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void OperatorEquality_Should_Succeed(AngleRadians left, AngleRadians right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left == right;

            // assert
            result.Should().Be(equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void OperatorInequality_Should_Succeed(AngleRadians left, AngleRadians right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left != right;

            // assert
            result.Should().Be(!equal);
        }

        [Theory]
        [MemberData(nameof(CompareInvalidData))]
        public void CompareTo_When_InvalidData_Should_Thrown(AngleRadians angle, object obj, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            Action act = () => ((IComparable)angle).CompareTo(obj);

            // assert
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage($"Argument has to be an {nameof(AngleRadians)}.\r\nParameter name: obj");
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void CompareTo_Should_Succeed(AngleRadians left, AngleRadians right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = ((IComparable)left).CompareTo(right);

            // assert
            if (lessThan)
                result.Should().BeNegative();
            else if (equal)
                result.Should().Be(0);
            else
                result.Should().BePositive();
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void Compare_Should_Succeed(AngleRadians left, AngleRadians right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = Angle.Compare(left, right);

            // assert
            if (lessThan)
                result.Should().BeNegative();
            else if (equal)
                result.Should().Be(0);
            else
                result.Should().BePositive();
        }

        [Theory]
        [MemberData(nameof(CompareReducedData))]
        public void CompareReduced_Should_Succeed(AngleRadians left, AngleRadians right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = Angle.CompareReduced(left, right);

            // assert
            if (lessThan)
                result.Should().BeNegative();
            else if (equal)
                result.Should().Be(0);
            else
                result.Should().BePositive();
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void LessThan_Should_Succeed(AngleRadians left, AngleRadians right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left < right;

            // assert
            result.Should().Be(lessThan);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void LessThanOrEqual_Should_Succeed(AngleRadians left, AngleRadians right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left <= right;

            // assert
            result.Should().Be(lessThan || equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void GreaterThan_Should_Succeed(AngleRadians left, AngleRadians right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left > right;

            // assert
            result.Should().Be(greaterThan);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void GreaterThanOrEqual_Should_Succeed(AngleRadians left, AngleRadians right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left >= right;

            // assert
            result.Should().Be(greaterThan || equal);
        }

        public static TheoryData<AngleRadians, AngleRadians> ReduceData => new TheoryData<AngleRadians, AngleRadians> {
            { AngleRadians.Zero, AngleRadians.Zero },
            { AcuteAngle, AcuteAngle },
            { AngleRadians.Right, AngleRadians.Right },
            { AngleRadians.Right + AcuteAngle, AngleRadians.Right + AcuteAngle },
            { AngleRadians.Straight, AngleRadians.Straight },

            { AngleRadians.Full, AngleRadians.Zero },
            { AngleRadians.Full + AcuteAngle, AcuteAngle },
            { AngleRadians.Full + AngleRadians.Right, AngleRadians.Right },
            { AngleRadians.Full + AngleRadians.Right + AcuteAngle, AngleRadians.Right + AcuteAngle },
            { AngleRadians.Full + AngleRadians.Straight, AngleRadians.Straight },

            { -AngleRadians.Full, AngleRadians.Zero },
            {- AcuteAngle, AcuteAngle },
            { -AngleRadians.Right, AngleRadians.Right },
            { -AngleRadians.Straight, AngleRadians.Straight },
            { -AngleRadians.Straight - AngleRadians.Right, AngleRadians.Right },
        };

        [Theory]
        [MemberData(nameof(ReduceData))]
        public void Reduce_Should_Succeed(AngleRadians angle, AngleRadians expected)
        {
            // arrange

            // act
            var result = Angle.Reduce(angle);

            // asseret
            result.Radians.Should().BeApproximately(expected.Radians, Math.Pow(10, 8));
        }

        [Fact]
        public void GetQuadrant_Should_Succeed()
        {
            Angle.GetQuadrant(AngleRadians.Zero).Should().Be(Quadrant.First);
            Angle.GetQuadrant(AcuteAngle).Should().Be(Quadrant.First);
            Angle.GetQuadrant(AngleRadians.Right).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(AngleRadians.Right + AcuteAngle).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(AngleRadians.Straight).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(AngleRadians.Straight + AcuteAngle).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(AngleRadians.Straight + AngleRadians.Right).Should().Be(Quadrant.Fourth);
            Angle.GetQuadrant(AngleRadians.Straight + AngleRadians.Right + AcuteAngle).Should().Be(Quadrant.Fourth);

            Angle.GetQuadrant(AngleRadians.Full).Should().Be(Quadrant.First);
            Angle.GetQuadrant(AngleRadians.Full + AcuteAngle).Should().Be(Quadrant.First);
            Angle.GetQuadrant(AngleRadians.Full + AngleRadians.Right).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(AngleRadians.Full + AngleRadians.Right + AcuteAngle).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(AngleRadians.Full + AngleRadians.Straight).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(AngleRadians.Full + AngleRadians.Straight + AcuteAngle).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(AngleRadians.Full + AngleRadians.Straight + AngleRadians.Right).Should().Be(Quadrant.Fourth);
            Angle.GetQuadrant(AngleRadians.Full + AngleRadians.Straight + AngleRadians.Right + AcuteAngle).Should().Be(Quadrant.Fourth);
        }

        [Fact]
        public void Reference_Should_Succeed()
        {
            Angle.GetReference(AngleRadians.Zero).Should().Be(AngleRadians.Zero);
            Angle.GetReference(AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(AngleRadians.Right).Should().Be(AngleRadians.Right);
            Angle.GetReference(AngleRadians.Right + AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(AngleRadians.Straight).Should().Be(AngleRadians.Zero);
            Angle.GetReference(AngleRadians.Straight + AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(AngleRadians.Straight + AngleRadians.Right).Should().Be(AngleRadians.Right);
            Angle.GetReference(AngleRadians.Straight + AngleRadians.Right + AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(AngleRadians.Full).Should().Be(AngleRadians.Zero);
        }

        [Fact]
        public void IsZero_Should_Succeed()
        {
            Angle.IsZero(AngleRadians.Zero).Should().BeTrue();
            Angle.IsZero(AcuteAngle).Should().BeFalse();
            Angle.IsZero(AngleRadians.Right).Should().BeFalse();
            Angle.IsZero(AngleRadians.Right + AcuteAngle).Should().BeFalse();
            Angle.IsZero(AngleRadians.Straight).Should().BeFalse();
            Angle.IsZero(AngleRadians.Straight + AngleRadians.Right).Should().BeFalse();
            Angle.IsZero(AngleRadians.Full).Should().BeTrue();

            Angle.IsZero(-AcuteAngle).Should().BeFalse();
            Angle.IsZero(-AngleRadians.Right).Should().BeFalse();
            Angle.IsZero(-AngleRadians.Right - AcuteAngle).Should().BeFalse();
            Angle.IsZero(-AngleRadians.Straight).Should().BeFalse();
            Angle.IsZero(-AngleRadians.Straight - AngleRadians.Right).Should().BeFalse();
            Angle.IsZero(-AngleRadians.Full).Should().BeTrue();
        }

        [Fact]
        public void IsAcute_Should_Succeed()
        {
            Angle.IsAcute(AngleRadians.Zero).Should().BeFalse();
            Angle.IsAcute(AcuteAngle).Should().BeTrue();
            Angle.IsAcute(AngleRadians.Right).Should().BeFalse();
            Angle.IsAcute(AngleRadians.Right + AcuteAngle).Should().BeFalse();
            Angle.IsAcute(AngleRadians.Straight).Should().BeFalse();
            Angle.IsAcute(AngleRadians.Straight + AngleRadians.Right).Should().BeFalse();
            Angle.IsAcute(AngleRadians.Full).Should().BeFalse();

            Angle.IsAcute(-AcuteAngle).Should().BeTrue();
            Angle.IsAcute(-AngleRadians.Right).Should().BeFalse();
            Angle.IsAcute(-AngleRadians.Right - AcuteAngle).Should().BeFalse();
            Angle.IsAcute(-AngleRadians.Straight).Should().BeFalse();
            Angle.IsAcute(-AngleRadians.Straight - AngleRadians.Right).Should().BeFalse();
            Angle.IsAcute(-AngleRadians.Full).Should().BeFalse();
        }

        [Fact]
        public void IsRight_Should_Succeed()
        {
            Angle.IsRight(AngleRadians.Zero).Should().BeFalse();
            Angle.IsRight(AcuteAngle).Should().BeFalse();
            Angle.IsRight(AngleRadians.Right).Should().BeTrue();
            Angle.IsRight(AngleRadians.Right + AcuteAngle).Should().BeFalse();
            Angle.IsRight(AngleRadians.Straight).Should().BeFalse();
            Angle.IsRight(AngleRadians.Straight + AngleRadians.Right).Should().BeFalse();
            Angle.IsRight(AngleRadians.Full).Should().BeFalse();

            Angle.IsRight(-AcuteAngle).Should().BeFalse();
            Angle.IsRight(-AngleRadians.Right).Should().BeTrue();
            Angle.IsRight(-AngleRadians.Right - AcuteAngle).Should().BeFalse();
            Angle.IsRight(-AngleRadians.Straight).Should().BeFalse();
            Angle.IsRight(-AngleRadians.Straight - AngleRadians.Right).Should().BeFalse();
            Angle.IsRight(-AngleRadians.Full).Should().BeFalse();
        }

        [Fact]
        public void IsObtuse_Should_Succeed()
        {
            Angle.IsObtuse(AngleRadians.Zero).Should().BeFalse();
            Angle.IsObtuse(AcuteAngle).Should().BeFalse();
            Angle.IsObtuse(AngleRadians.Right).Should().BeFalse();
            Angle.IsObtuse(AngleRadians.Right + AcuteAngle).Should().BeTrue();
            Angle.IsObtuse(AngleRadians.Straight).Should().BeFalse();
            Angle.IsObtuse(AngleRadians.Straight + AngleRadians.Right).Should().BeFalse();
            Angle.IsObtuse(AngleRadians.Full).Should().BeFalse();

            Angle.IsObtuse(-AcuteAngle).Should().BeFalse();
            Angle.IsObtuse(-AngleRadians.Right).Should().BeFalse();
            Angle.IsObtuse(-AngleRadians.Right - AcuteAngle).Should().BeTrue();
            Angle.IsObtuse(-AngleRadians.Straight).Should().BeFalse();
            Angle.IsObtuse(-AngleRadians.Straight - AngleRadians.Right).Should().BeFalse();
            Angle.IsObtuse(-AngleRadians.Full).Should().BeFalse();
        }

        [Fact]
        public void IsStraight_Should_Succeed()
        {
            Angle.IsStraight(AngleRadians.Zero).Should().BeFalse();
            Angle.IsStraight(AcuteAngle).Should().BeFalse();
            Angle.IsStraight(AngleRadians.Right).Should().BeFalse();
            Angle.IsStraight(AngleRadians.Right - AcuteAngle).Should().BeFalse();
            Angle.IsStraight(AngleRadians.Straight).Should().BeTrue();
            Angle.IsStraight(AngleRadians.Straight - AngleRadians.Right).Should().BeFalse();
            Angle.IsStraight(AngleRadians.Full).Should().BeFalse();

            Angle.IsStraight(-AcuteAngle).Should().BeFalse();
            Angle.IsStraight(-AngleRadians.Right).Should().BeFalse();
            Angle.IsStraight(-AngleRadians.Right - AcuteAngle).Should().BeFalse();
            Angle.IsStraight(-AngleRadians.Straight).Should().BeTrue();
            Angle.IsStraight(-AngleRadians.Straight - AngleRadians.Right).Should().BeFalse();
            Angle.IsStraight(-AngleRadians.Full).Should().BeFalse();
        }

        [Fact]
        public void IsReflex_Should_Succeed()
        {
            Angle.IsReflex(AngleRadians.Zero).Should().BeFalse();
            Angle.IsReflex(AcuteAngle).Should().BeFalse();
            Angle.IsReflex(AngleRadians.Right).Should().BeFalse();
            Angle.IsReflex(AngleRadians.Right + AcuteAngle).Should().BeFalse();
            Angle.IsReflex(AngleRadians.Straight).Should().BeFalse();
            Angle.IsReflex(AngleRadians.Straight + AngleRadians.Right).Should().BeTrue();
            Angle.IsReflex(AngleRadians.Full).Should().BeFalse();

            Angle.IsReflex(-AcuteAngle).Should().BeFalse();
            Angle.IsReflex(-AngleRadians.Right).Should().BeFalse();
            Angle.IsReflex(-AngleRadians.Right - AcuteAngle).Should().BeFalse();
            Angle.IsReflex(-AngleRadians.Straight).Should().BeFalse();
            Angle.IsReflex(-AngleRadians.Straight - AngleRadians.Right).Should().BeTrue();
            Angle.IsReflex(-AngleRadians.Full).Should().BeFalse();
        }

        [Fact]
        public void IsOblique_Should_Succeed()
        {
            Angle.IsOblique(AngleRadians.Zero).Should().BeFalse();
            Angle.IsOblique(AcuteAngle).Should().BeTrue();
            Angle.IsOblique(AngleRadians.Right).Should().BeFalse();
            Angle.IsOblique(AngleRadians.Right + AcuteAngle).Should().BeTrue();
            Angle.IsOblique(AngleRadians.Straight).Should().BeFalse();
            Angle.IsOblique(AngleRadians.Straight + AngleRadians.Right).Should().BeFalse();
            Angle.IsOblique(AngleRadians.Full).Should().BeFalse();

            Angle.IsOblique(-AcuteAngle).Should().BeTrue();
            Angle.IsOblique(-AngleRadians.Right).Should().BeFalse();
            Angle.IsOblique(-AngleRadians.Right - AcuteAngle).Should().BeTrue();
            Angle.IsOblique(-AngleRadians.Straight).Should().BeFalse();
            Angle.IsOblique(-AngleRadians.Straight - AngleRadians.Right).Should().BeFalse();
            Angle.IsOblique(-AngleRadians.Full).Should().BeFalse();
        }

        public static TheoryData<AngleRadians, AngleRadians, double, AngleRadians> LerpData = new TheoryData<AngleRadians, AngleRadians, double, AngleRadians>
        {
            {AcuteAngle, AngleRadians.Right + AcuteAngle, -0.5, AngleRadians.Zero},
            {AcuteAngle, AngleRadians.Right + AcuteAngle, 0.0, AcuteAngle},
            {AcuteAngle, AngleRadians.Right + AcuteAngle, 0.5, AngleRadians.Right},
            {AcuteAngle, AngleRadians.Right + AcuteAngle, 1.0, AngleRadians.Right + AcuteAngle},
            {AcuteAngle, AngleRadians.Right + AcuteAngle, 1.5, AngleRadians.Straight},

            {-AcuteAngle, -AngleRadians.Right - AcuteAngle, -0.5, AngleRadians.Zero},
            {-AcuteAngle, -AngleRadians.Right - AcuteAngle, 0.0, -AcuteAngle},
            {-AcuteAngle, -AngleRadians.Right - AcuteAngle, 0.5, -AngleRadians.Right},
            {-AcuteAngle, -AngleRadians.Right - AcuteAngle, 1.0, -AngleRadians.Right - AcuteAngle},
            {-AcuteAngle, -AngleRadians.Right - AcuteAngle, 1.5, -AngleRadians.Straight},

            {AngleRadians.Right + AcuteAngle, AcuteAngle, -0.5, AngleRadians.Straight},
            {AngleRadians.Right + AcuteAngle, AcuteAngle, 0.0, AngleRadians.Right + AcuteAngle},
            {AngleRadians.Right + AcuteAngle, AcuteAngle, 0.5, AngleRadians.Right},
            {AngleRadians.Right + AcuteAngle, AcuteAngle, 1.0, AcuteAngle},
            {AngleRadians.Right + AcuteAngle, AcuteAngle, 1.5, AngleRadians.Zero},
        };

        [Theory]
        [MemberData(nameof(LerpData))]
        public void Lerp_Should_Succeed(AngleRadians a1, AngleRadians a2, double t, AngleRadians expected)
        {
            // arrange

            // act
            var result = Angle.Lerp(a1, a2, t);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRadians, string> ToStringData = new TheoryData<AngleRadians, string>
        {
            {AngleRadians.Straight, "3.14159265358979"},
        };

        [Theory]
        [MemberData(nameof(ToStringData))]
        public void ToString_Should_Succeed(AngleRadians angle, string expected)
        {
            // arrange
#if NET35
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
#else
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
#endif

            // act
            var result = angle.ToString();

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRadians, string, string> ToStringFormatData = new TheoryData<AngleRadians, string, string>
        {
            {AngleRadians.Straight, "0.00", "3.14"},
        };

        [Theory]
        [MemberData(nameof(ToStringFormatData))]
        public void ToStringFormat_Should_Succeed(AngleRadians angle, string format, string expected)
        {
            // arrange
#if NET35
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
#else
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
#endif

            // act
            var result = angle.ToString(format);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRadians, string, CultureInfo, string> ToStringFormatCultureData = new TheoryData<AngleRadians, string, CultureInfo, string>
        {
            {AngleRadians.Straight, "0.00", new CultureInfo("pt-PT"), "3,14"},
        };

        [Theory]
        [MemberData(nameof(ToStringFormatCultureData))]
        public void ToStringFormatCulture_Should_Succeed(AngleRadians angle, string format, CultureInfo culture, string expected)
        {
            // arrange

            // act
            var result = angle.ToString(format, culture);

            // assert
            result.Should().Be(expected);
        }

    }
}
