using FluentAssertions;
using System;
using System.Globalization;
using Xunit;

namespace NetFabric.UnitTests
{
    public class AngleGradiansTests
    {
        static readonly AngleGradians AcuteAngle = AngleGradians.Right / 2.0;

        public static TheoryData<AngleRadians, AngleGradians> AngleRadiansData = new TheoryData<AngleRadians, AngleGradians>
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
        [MemberData(nameof(AngleRadiansData))]
        public void ToGradians_When_AngleRadians_Should_Succeed(AngleRadians value, AngleGradians expected)
        {
            // arrange

            // act
            var angle = Angle.ToGradians(value);

            // assert
            angle.Should().BeOfType<AngleGradians>().And.Be(expected);
        }

        public static TheoryData<AngleDegrees, AngleGradians> AngleDegreesData = new TheoryData<AngleDegrees, AngleGradians>
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
        [MemberData(nameof(AngleDegreesData))]
        public void ToGradians_When_AngleDegrees_Should_Succeed(AngleDegrees value, AngleGradians expected)
        {
            // arrange

            // act
            var angle = Angle.ToGradians(value);

            // assert
            angle.Should().BeOfType<AngleGradians>().And.Be(expected);
        }

        public static TheoryData<AngleGradians, object, bool, bool, bool> CompareInvalidData => new TheoryData<AngleGradians, object, bool, bool, bool>
        {
            { AngleGradians.Right, null, false, false, false },
            { AngleGradians.Right, 90.0, false, false, false },
        };

        public static TheoryData<AngleGradians, AngleGradians, bool, bool, bool> CompareData => new TheoryData<AngleGradians, AngleGradians, bool, bool, bool>
        {
            { AngleGradians.Zero, AngleGradians.Right - AngleGradians.Full, false, false, true },
            { AngleGradians.Right, AngleGradians.Right - AngleGradians.Full, false, false, true },
            { AngleGradians.Straight, AngleGradians.Right - AngleGradians.Full, false, false, true },

            { AngleGradians.Zero, AngleGradians.Right, true, false, false },
            { AngleGradians.Right, AngleGradians.Right, false, true, false },
            { AngleGradians.Straight, AngleGradians.Right, false, false, true },

            { AngleGradians.Zero, AngleGradians.Right + AngleGradians.Full, true, false, false },
            { AngleGradians.Right, AngleGradians.Right + AngleGradians.Full, true, false, false },
            { AngleGradians.Straight, AngleGradians.Right + AngleGradians.Full, true, false, false },
        };

        public static TheoryData<AngleGradians, AngleGradians, bool, bool, bool> CompareReducedData => new TheoryData<AngleGradians, AngleGradians, bool, bool, bool>
        {
            { AngleGradians.Zero, AngleGradians.Right - AngleGradians.Full, true, false, false },
            { AngleGradians.Right, AngleGradians.Right - AngleGradians.Full, false, true, false },
            { AngleGradians.Straight, AngleGradians.Right - AngleGradians.Full, false, false, true },

            { AngleGradians.Zero, AngleGradians.Right, true, false, false },
            { AngleGradians.Right, AngleGradians.Right, false, true, false },
            { AngleGradians.Straight, AngleGradians.Right, false, false, true },

            { AngleGradians.Zero, AngleGradians.Right + AngleGradians.Full, true, false, false },
            { AngleGradians.Right, AngleGradians.Right + AngleGradians.Full, false, true, false },
            { AngleGradians.Straight, AngleGradians.Right + AngleGradians.Full, false, false, true },
        };

        [Theory]
        [MemberData(nameof(CompareInvalidData))]
        [MemberData(nameof(CompareData))]
        public void EqualsObject_Should_Succeed(AngleGradians left, object right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left.Equals(right);

            // assert
            result.Should().Be(equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void Equals_Should_Succeed(AngleGradians left, AngleGradians right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left.Equals(right);

            // assert
            result.Should().Be(equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void GetHashCode_Should_Succeed(AngleGradians left, AngleGradians right, bool lessThan, bool equal, bool greaterThan)
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
        public void OperatorEquality_Should_Succeed(AngleGradians left, AngleGradians right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left == right;

            // assert
            result.Should().Be(equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void OperatorInequality_Should_Succeed(AngleGradians left, AngleGradians right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left != right;

            // assert
            result.Should().Be(!equal);
        }

        [Theory]
        [MemberData(nameof(CompareInvalidData))]
        public void CompareTo_When_InvalidData_Should_Thrown(AngleGradians angle, object obj, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            Action act = () => ((IComparable)angle).CompareTo(obj);

            // assert
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage($"Argument has to be an {nameof(AngleGradians)}. (Parameter 'obj')");
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void CompareTo_Should_Succeed(AngleGradians left, AngleGradians right, bool lessThan, bool equal, bool greaterThan)
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
        public void Compare_Should_Succeed(AngleGradians left, AngleGradians right, bool lessThan, bool equal, bool greaterThan)
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
        public void CompareReduced_Should_Succeed(AngleGradians left, AngleGradians right, bool lessThan, bool equal, bool greaterThan)
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
        public void LessThan_Should_Succeed(AngleGradians left, AngleGradians right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left < right;

            // assert
            result.Should().Be(lessThan);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void LessThanOrEqual_Should_Succeed(AngleGradians left, AngleGradians right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left <= right;

            // assert
            result.Should().Be(lessThan || equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void GreaterThan_Should_Succeed(AngleGradians left, AngleGradians right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left > right;

            // assert
            result.Should().Be(greaterThan);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void GreaterThanOrEqual_Should_Succeed(AngleGradians left, AngleGradians right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left >= right;

            // assert
            result.Should().Be(greaterThan || equal);
        }

        public static TheoryData<AngleGradians, AngleGradians> ReduceData => new TheoryData<AngleGradians, AngleGradians> {
            { AngleGradians.Zero, AngleGradians.Zero },
            { AcuteAngle, AcuteAngle },
            { AngleGradians.Right, AngleGradians.Right },
            { AngleGradians.Right + AcuteAngle, AngleGradians.Right + AcuteAngle },
            { AngleGradians.Straight, AngleGradians.Straight },

            { AngleGradians.Full, AngleGradians.Zero },
            { AngleGradians.Full + AcuteAngle, AcuteAngle },
            { AngleGradians.Full + AngleGradians.Right, AngleGradians.Right },
            { AngleGradians.Full + AngleGradians.Right + AcuteAngle, AngleGradians.Right + AcuteAngle },
            { AngleGradians.Full + AngleGradians.Straight, AngleGradians.Straight },

            { -AngleGradians.Full, AngleGradians.Zero },
            { -AcuteAngle, AngleGradians.Full - AcuteAngle },
            { -AngleGradians.Right, AngleGradians.Full - AngleGradians.Right },
            { -AngleGradians.Straight, AngleGradians.Straight },
            { -AngleGradians.Straight - AngleGradians.Right, AngleGradians.Right },
        };

        [Theory]
        [MemberData(nameof(ReduceData))]
        public void Reduce_Should_Succeed(AngleGradians angle, AngleGradians expected)
        {
            // arrange

            // act
            var result = Angle.Reduce(angle);

            // assert
            result.Gradians.Should().BeApproximately(expected.Gradians, Math.Pow(10, 8));
        }

        public static TheoryData<AngleGradians, Quadrant> QuadrantData => new TheoryData<AngleGradians, Quadrant> {
            {AngleGradians.Zero, Quadrant.First},
            {AcuteAngle, Quadrant.First},
            {AngleGradians.Right, Quadrant.Second},
            {AngleGradians.Right + AcuteAngle, Quadrant.Second},
            {AngleGradians.Straight, Quadrant.Third},
            {AngleGradians.Straight + AcuteAngle, Quadrant.Third},
            {AngleGradians.Straight + AngleGradians.Right, Quadrant.Fourth},
            {AngleGradians.Straight + AngleGradians.Right + AcuteAngle, Quadrant.Fourth},

            {AngleGradians.Full, Quadrant.First},
            {AngleGradians.Full + AcuteAngle, Quadrant.First},
            {AngleGradians.Full + AngleGradians.Right, Quadrant.Second},
            {AngleGradians.Full + AngleGradians.Right + AcuteAngle, Quadrant.Second},
            {AngleGradians.Full + AngleGradians.Straight, Quadrant.Third},
            {AngleGradians.Full + AngleGradians.Straight + AcuteAngle, Quadrant.Third},
            {AngleGradians.Full + AngleGradians.Straight + AngleGradians.Right, Quadrant.Fourth},
            {AngleGradians.Full + AngleGradians.Straight + AngleGradians.Right + AcuteAngle, Quadrant.Fourth},
        };

        [Theory]
        [MemberData(nameof(QuadrantData))]
        public void GetQuadrant_Should_Succeed(AngleGradians angle, Quadrant expected)
        {
            // arrange

            // act
            var result = Angle.GetQuadrant(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleGradians, AngleGradians> ReferencetData => new TheoryData<AngleGradians, AngleGradians> {
            {AngleGradians.Zero, AngleGradians.Zero},
            {AcuteAngle, AcuteAngle},
            {AngleGradians.Right ,AngleGradians.Right},
            {AngleGradians.Right + AcuteAngle, AcuteAngle},
            {AngleGradians.Straight, AngleGradians.Zero},
            {AngleGradians.Straight + AcuteAngle, AcuteAngle},
            {AngleGradians.Straight + AngleGradians.Right, AngleGradians.Right},
            {AngleGradians.Straight + AngleGradians.Right + AcuteAngle, AcuteAngle},
            {AngleGradians.Full, AngleGradians.Zero},
        };

        [Theory]
        [MemberData(nameof(ReferencetData))]
        public void Reference_Should_Succeed(AngleGradians angle, AngleGradians expected)
        {
            // arrange

            // act
            var result = Angle.GetReference(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleGradians, bool> IsZeroData => new TheoryData<AngleGradians, bool> {
            {AngleGradians.Zero, true},
            {AcuteAngle, false},
            {AngleGradians.Right, false},
            {AngleGradians.Right + AcuteAngle, false},
            {AngleGradians.Straight, false},
            {AngleGradians.Straight + AngleGradians.Right, false},
            {AngleGradians.Full, true},

            {-AcuteAngle, false},
            {-AngleGradians.Right, false},
            {-AngleGradians.Right - AcuteAngle, false},
            {-AngleGradians.Straight, false},
            {-AngleGradians.Straight - AngleGradians.Right, false},
            {-AngleGradians.Full, true},
        };

        [Theory]
        [MemberData(nameof(IsZeroData))]
        public void IsZero_Should_Succeed(AngleGradians angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsZero(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleGradians, bool> IsAcuteData => new TheoryData<AngleGradians, bool> {
            {AngleGradians.Zero, false},
            {AcuteAngle, true},
            {AngleGradians.Right, false},
            {AngleGradians.Right + AcuteAngle, false},
            {AngleGradians.Straight, false},
            {AngleGradians.Straight + AngleGradians.Right, false},
            {AngleGradians.Full, false},

            {-AcuteAngle, true},
            {-AngleGradians.Right, false},
            {-AngleGradians.Right - AcuteAngle, false},
            {-AngleGradians.Straight, false},
            {-AngleGradians.Straight - AngleGradians.Right, false},
            {-AngleGradians.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsAcuteData))]
        public void IsAcute_Should_Succeed(AngleGradians angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsAcute(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleGradians, bool> IsRightData => new TheoryData<AngleGradians, bool> {
            {AngleGradians.Zero, false},
            {AcuteAngle, false},
            {AngleGradians.Right, true},
            {AngleGradians.Right + AcuteAngle, false},
            {AngleGradians.Straight, false},
            {AngleGradians.Straight + AngleGradians.Right, false},
            {AngleGradians.Full, false},

            {-AcuteAngle, false},
            {-AngleGradians.Right, true},
            {-AngleGradians.Right - AcuteAngle, false},
            {-AngleGradians.Straight, false},
            {-AngleGradians.Straight - AngleGradians.Right, false},
            {-AngleGradians.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsRightData))]
        public void IsRight_Should_Succeed(AngleGradians angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsRight(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleGradians, bool> IsObtuseData => new TheoryData<AngleGradians, bool> {
            {AngleGradians.Zero, false},
            {AcuteAngle, false},
            {AngleGradians.Right, false},
            {AngleGradians.Right + AcuteAngle, true},
            {AngleGradians.Straight, false},
            {AngleGradians.Straight + AngleGradians.Right, false},
            {AngleGradians.Full, false},

            {-AcuteAngle, false},
            {-AngleGradians.Right, false},
            {-AngleGradians.Right - AcuteAngle, true},
            {-AngleGradians.Straight, false},
            {-AngleGradians.Straight - AngleGradians.Right, false},
            {-AngleGradians.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsObtuseData))]
        public void IsObtuse_Should_Succeed(AngleGradians angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsObtuse(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleGradians, bool> IsStraightData => new TheoryData<AngleGradians, bool> {
            {AngleGradians.Zero, false},
            {AcuteAngle, false},
            {AngleGradians.Right, false},
            {AngleGradians.Right - AcuteAngle, false},
            {AngleGradians.Straight, true},
            {AngleGradians.Straight - AngleGradians.Right, false},
            {AngleGradians.Full, false},

            {-AcuteAngle, false},
            {-AngleGradians.Right, false},
            {-AngleGradians.Right - AcuteAngle, false},
            {-AngleGradians.Straight, true},
            {-AngleGradians.Straight - AngleGradians.Right, false},
            {-AngleGradians.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsStraightData))]
        public void IsStraight_Should_Succeed(AngleGradians angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsStraight(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleGradians, bool> IsReflexData => new TheoryData<AngleGradians, bool> {
            {AngleGradians.Zero, false},
            {AcuteAngle, false},
            {AngleGradians.Right, false},
            {AngleGradians.Right + AcuteAngle, false},
            {AngleGradians.Straight, false},
            {AngleGradians.Straight + AngleGradians.Right, true},
            {AngleGradians.Full, false},

            {-AcuteAngle, false},
            {-AngleGradians.Right, false},
            {-AngleGradians.Right - AcuteAngle, false},
            {-AngleGradians.Straight, false},
            {-AngleGradians.Straight - AngleGradians.Right, true},
            {-AngleGradians.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsReflexData))]
        public void IsReflex_Should_Succeed(AngleGradians angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsReflex(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleGradians, bool> IsObliqueData => new TheoryData<AngleGradians, bool> {
            {AngleGradians.Zero, false},
            {AcuteAngle, true},
            {AngleGradians.Right, false},
            {AngleGradians.Right + AcuteAngle, true},
            {AngleGradians.Straight, false},
            {AngleGradians.Straight + AngleGradians.Right, false},
            {AngleGradians.Full, false},

            {-AcuteAngle, true},
            {-AngleGradians.Right, false},
            {-AngleGradians.Right - AcuteAngle, true},
            {-AngleGradians.Straight, false},
            {-AngleGradians.Straight - AngleGradians.Right, false},
            {-AngleGradians.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsObliqueData))]
        public void IsOblique_Should_Succeed(AngleGradians angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsOblique(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleGradians, AngleGradians, double, AngleGradians> LerpData => new TheoryData<AngleGradians, AngleGradians, double, AngleGradians>
        {
            {AcuteAngle, AngleGradians.Right + AcuteAngle, -0.5, AngleGradians.Zero},
            {AcuteAngle, AngleGradians.Right + AcuteAngle, 0.0, AcuteAngle},
            {AcuteAngle, AngleGradians.Right + AcuteAngle, 0.5, AngleGradians.Right},
            {AcuteAngle, AngleGradians.Right + AcuteAngle, 1.0, AngleGradians.Right + AcuteAngle},
            {AcuteAngle, AngleGradians.Right + AcuteAngle, 1.5, AngleGradians.Straight},

            {-AcuteAngle, -AngleGradians.Right - AcuteAngle, -0.5, AngleGradians.Zero},
            {-AcuteAngle, -AngleGradians.Right - AcuteAngle, 0.0, -AcuteAngle},
            {-AcuteAngle, -AngleGradians.Right - AcuteAngle, 0.5, -AngleGradians.Right},
            {-AcuteAngle, -AngleGradians.Right - AcuteAngle, 1.0, -AngleGradians.Right - AcuteAngle},
            {-AcuteAngle, -AngleGradians.Right - AcuteAngle, 1.5, -AngleGradians.Straight},

            {AngleGradians.Right + AcuteAngle, AcuteAngle, -0.5, AngleGradians.Straight},
            {AngleGradians.Right + AcuteAngle, AcuteAngle, 0.0, AngleGradians.Right + AcuteAngle},
            {AngleGradians.Right + AcuteAngle, AcuteAngle, 0.5, AngleGradians.Right},
            {AngleGradians.Right + AcuteAngle, AcuteAngle, 1.0, AcuteAngle},
            {AngleGradians.Right + AcuteAngle, AcuteAngle, 1.5, AngleGradians.Zero},
        };

        [Theory]
        [MemberData(nameof(LerpData))]
        public void Lerp_Should_Succeed(AngleGradians a1, AngleGradians a2, double t, AngleGradians expected)
        {
            // arrange

            // act
            var result = Angle.Lerp(a1, a2, t);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleGradians, string> ToStringData => new TheoryData<AngleGradians, string>
        {
            {AngleGradians.Straight, "200"},
        };

        [Theory]
        [MemberData(nameof(ToStringData))]
        public void ToString_Should_Succeed(AngleGradians angle, string expected)
        {
            // arrange
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

            // act
            var result = angle.ToString();

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleGradians, string, string> ToStringFormatData => new TheoryData<AngleGradians, string, string>
        {
            {AngleGradians.Straight, "0.00", "200.00"},
        };

        [Theory]
        [MemberData(nameof(ToStringFormatData))]
        public void ToStringFormat_Should_Succeed(AngleGradians angle, string format, string expected)
        {
            // arrange
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

            // act
            var result = angle.ToString(format);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleGradians, string, CultureInfo, string> ToStringFormatCultureData => new TheoryData<AngleGradians, string, CultureInfo, string>
        {
            {AngleGradians.Straight, "0.00", new CultureInfo("pt-PT"), "200,00"},
        };

        [Theory]
        [MemberData(nameof(ToStringFormatCultureData))]
        public void ToStringFormatCulture_Should_Succeed(AngleGradians angle, string format, CultureInfo culture, string expected)
        {
            // arrange

            // act
            var result = angle.ToString(format, culture);

            // assert
            result.Should().Be(expected);
        }

    }
}
