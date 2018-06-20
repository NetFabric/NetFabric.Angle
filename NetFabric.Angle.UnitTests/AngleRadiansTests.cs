using FluentAssertions;
using System;
using System.Globalization;
using Xunit;

namespace NetFabric.UnitTests
{
    public class AngleRadiansTests
    {
        static readonly AngleRadians AcuteAngle = AngleRadians.Right / 2.0;

        public static TheoryData<AngleRadians, object, bool, bool, bool> CompareInvalidData => new TheoryData<AngleRadians, object, bool, bool, bool>
        {
            { AngleRadians.Right, null, false, false, false },
            { AngleRadians.Right, 90.0, false, false, false },
        };

        public static TheoryData<AngleRadians, AngleRadians, bool, bool, bool> CompareData => new TheoryData<AngleRadians, AngleRadians, bool, bool, bool>
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

        public static TheoryData<AngleRadians, AngleRadians, bool, bool, bool> CompareReducedData => new TheoryData<AngleRadians, AngleRadians, bool, bool, bool>
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

            // assert
            result.Radians.Should().BeApproximately(expected.Radians, Math.Pow(10, 8));
        }

        public static TheoryData<AngleRadians, Quadrant> QuadrantData => new TheoryData<AngleRadians, Quadrant> {
            {AngleRadians.Zero, Quadrant.First},
            {AcuteAngle, Quadrant.First},
            {AngleRadians.Right, Quadrant.Second},
            {AngleRadians.Right + AcuteAngle, Quadrant.Second},
            {AngleRadians.Straight, Quadrant.Third},
            {AngleRadians.Straight + AcuteAngle, Quadrant.Third},
            {AngleRadians.Straight + AngleRadians.Right, Quadrant.Fourth},
            {AngleRadians.Straight + AngleRadians.Right + AcuteAngle, Quadrant.Fourth},
            
            {AngleRadians.Full, Quadrant.First},
            {AngleRadians.Full + AcuteAngle, Quadrant.First},
            {AngleRadians.Full + AngleRadians.Right, Quadrant.Second},
            {AngleRadians.Full + AngleRadians.Right + AcuteAngle, Quadrant.Second},
            {AngleRadians.Full + AngleRadians.Straight, Quadrant.Third},
            {AngleRadians.Full + AngleRadians.Straight + AcuteAngle, Quadrant.Third},
            {AngleRadians.Full + AngleRadians.Straight + AngleRadians.Right, Quadrant.Fourth},
            {AngleRadians.Full + AngleRadians.Straight + AngleRadians.Right + AcuteAngle, Quadrant.Fourth},
        };

        [Theory]
        [MemberData(nameof(QuadrantData))]
        public void GetQuadrant_Should_Succeed(AngleRadians angle, Quadrant expected)
        {
            // arrange

            // act
            var result = Angle.GetQuadrant(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRadians, AngleRadians> ReferencetData => new TheoryData<AngleRadians, AngleRadians> {
            {AngleRadians.Zero, AngleRadians.Zero},
            {AcuteAngle, AcuteAngle},
            {AngleRadians.Right ,AngleRadians.Right},
            {AngleRadians.Right + AcuteAngle, AcuteAngle},
            {AngleRadians.Straight, AngleRadians.Zero},
            {AngleRadians.Straight + AcuteAngle, AcuteAngle},
            {AngleRadians.Straight + AngleRadians.Right, AngleRadians.Right},
            {AngleRadians.Straight + AngleRadians.Right + AcuteAngle, AcuteAngle},
            {AngleRadians.Full, AngleRadians.Zero},
        };

        [Theory]
        [MemberData(nameof(ReferencetData))]
        public void Reference_Should_Succeed(AngleRadians angle, AngleRadians expected)
        {
            // arrange

            // act
            var result = Angle.GetReference(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRadians, bool> IsZeroData => new TheoryData<AngleRadians, bool> {
            {AngleRadians.Zero, true},
            {AcuteAngle, false},
            {AngleRadians.Right, false},
            {AngleRadians.Right + AcuteAngle, false},
            {AngleRadians.Straight, false},
            {AngleRadians.Straight + AngleRadians.Right, false},
            {AngleRadians.Full, true},
            
            {-AcuteAngle, false},
            {-AngleRadians.Right, false},
            {-AngleRadians.Right - AcuteAngle, false},
            {-AngleRadians.Straight, false},
            {-AngleRadians.Straight - AngleRadians.Right, false},
            {-AngleRadians.Full, true},
        };

        [Theory]
        [MemberData(nameof(IsZeroData))]
        public void IsZero_Should_Succeed(AngleRadians angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsZero(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRadians, bool> IsAcuteData => new TheoryData<AngleRadians, bool> {
            {AngleRadians.Zero, false},
            {AcuteAngle, true},
            {AngleRadians.Right, false},
            {AngleRadians.Right + AcuteAngle, false},
            {AngleRadians.Straight, false},
            {AngleRadians.Straight + AngleRadians.Right, false},
            {AngleRadians.Full, false},
            
            {-AcuteAngle, true},
            {-AngleRadians.Right, false},
            {-AngleRadians.Right - AcuteAngle, false},
            {-AngleRadians.Straight, false},
            {-AngleRadians.Straight - AngleRadians.Right, false},
            {-AngleRadians.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsAcuteData))]
        public void IsAcute_Should_Succeed(AngleRadians angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsAcute(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRadians, bool> IsRightData => new TheoryData<AngleRadians, bool> {
            {AngleRadians.Zero, false},
            {AcuteAngle, false},
            {AngleRadians.Right, true},
            {AngleRadians.Right + AcuteAngle, false},
            {AngleRadians.Straight, false},
            {AngleRadians.Straight + AngleRadians.Right, false},
            {AngleRadians.Full, false},
            
            {-AcuteAngle, false},
            {-AngleRadians.Right, true},
            {-AngleRadians.Right - AcuteAngle, false},
            {-AngleRadians.Straight, false},
            {-AngleRadians.Straight - AngleRadians.Right, false},
            {-AngleRadians.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsRightData))]
        public void IsRight_Should_Succeed(AngleRadians angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsRight(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRadians, bool> IsObtuseData => new TheoryData<AngleRadians, bool> {
            {AngleRadians.Zero, false},
            {AcuteAngle, false},
            {AngleRadians.Right, false},
            {AngleRadians.Right + AcuteAngle, true},
            {AngleRadians.Straight, false},
            {AngleRadians.Straight + AngleRadians.Right, false},
            {AngleRadians.Full, false},
            
            {-AcuteAngle, false},
            {-AngleRadians.Right, false},
            {-AngleRadians.Right - AcuteAngle, true},
            {-AngleRadians.Straight, false},
            {-AngleRadians.Straight - AngleRadians.Right, false},
            {-AngleRadians.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsObtuseData))]
        public void IsObtuse_Should_Succeed(AngleRadians angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsObtuse(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRadians, bool> IsStraightData => new TheoryData<AngleRadians, bool> {
            {AngleRadians.Zero, false},
            {AcuteAngle, false},
            {AngleRadians.Right, false},
            {AngleRadians.Right - AcuteAngle, false},
            {AngleRadians.Straight, true},
            {AngleRadians.Straight - AngleRadians.Right, false},
            {AngleRadians.Full, false},
            
            {-AcuteAngle, false},
            {-AngleRadians.Right, false},
            {-AngleRadians.Right - AcuteAngle, false},
            {-AngleRadians.Straight, true},
            {-AngleRadians.Straight - AngleRadians.Right, false},
            {-AngleRadians.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsStraightData))]
        public void IsStraight_Should_Succeed(AngleRadians angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsStraight(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRadians, bool> IsReflexData => new TheoryData<AngleRadians, bool> {
            {AngleRadians.Zero, false},
            {AcuteAngle, false},
            {AngleRadians.Right, false},
            {AngleRadians.Right + AcuteAngle, false},
            {AngleRadians.Straight, false},
            {AngleRadians.Straight + AngleRadians.Right, true},
            {AngleRadians.Full, false},
            
            {-AcuteAngle, false},
            {-AngleRadians.Right, false},
            {-AngleRadians.Right - AcuteAngle, false},
            {-AngleRadians.Straight, false},
            {-AngleRadians.Straight - AngleRadians.Right, true},
            {-AngleRadians.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsReflexData))]
        public void IsReflex_Should_Succeed(AngleRadians angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsReflex(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRadians, bool> IsObliqueData => new TheoryData<AngleRadians, bool> {
            {AngleRadians.Zero, false},
            {AcuteAngle, true},
            {AngleRadians.Right, false},
            {AngleRadians.Right + AcuteAngle, true},
            {AngleRadians.Straight, false},
            {AngleRadians.Straight + AngleRadians.Right, false},
            {AngleRadians.Full, false},
            
            {-AcuteAngle, true},
            {-AngleRadians.Right, false},
            {-AngleRadians.Right - AcuteAngle, true},
            {-AngleRadians.Straight, false},
            {-AngleRadians.Straight - AngleRadians.Right, false},
            {-AngleRadians.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsObliqueData))]
        public void IsOblique_Should_Succeed(AngleRadians angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsOblique(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRadians, AngleRadians, double, AngleRadians> LerpData => new TheoryData<AngleRadians, AngleRadians, double, AngleRadians>
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

        public static TheoryData<AngleRadians, string> ToStringData => new TheoryData<AngleRadians, string>
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

        public static TheoryData<AngleRadians, string, string> ToStringFormatData => new TheoryData<AngleRadians, string, string>
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

        public static TheoryData<AngleRadians, string, CultureInfo, string> ToStringFormatCultureData => new TheoryData<AngleRadians, string, CultureInfo, string>
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
