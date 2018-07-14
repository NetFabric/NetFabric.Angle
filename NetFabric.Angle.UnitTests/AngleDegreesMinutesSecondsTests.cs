using FluentAssertions;
using System;
using System.Globalization;
using Xunit;

namespace NetFabric.UnitTests
{
    public class AngleDegreesMinutesSecondsTests
    {
        static readonly AngleDegreesMinutesSeconds AcuteAngle = AngleDegreesMinutesSeconds.Right / 2.0;

        public static TheoryData<AngleRadians, AngleDegreesMinutesSeconds> AngleRadiansData = new TheoryData<AngleRadians, AngleDegreesMinutesSeconds>
        {
            { -AngleRadians.Full, -AngleDegreesMinutesSeconds.Full },
            { -AngleRadians.Straight, -AngleDegreesMinutesSeconds.Straight },
            { -AngleRadians.Right, -AngleDegreesMinutesSeconds.Right },
            { AngleRadians.Zero, AngleDegreesMinutesSeconds.Zero },
            { AngleRadians.Right, AngleDegreesMinutesSeconds.Right },
            { AngleRadians.Straight, AngleDegreesMinutesSeconds.Straight },
            { AngleRadians.Full, AngleDegreesMinutesSeconds.Full },
        };

        [Theory]
        [MemberData(nameof(AngleRadiansData))]
        public void ToDegrees_When_AngleRadians_Should_Succeed(AngleRadians value, in AngleDegreesMinutesSeconds expected)
        {
            // arrange

            // act
            var angle = Angle.ToDegreesMinutesSeconds(value);

            // assert
            angle.Should().BeOfType<AngleDegreesMinutesSeconds>().And.Be(expected);
        }

        public static TheoryData<AngleGradians, AngleDegreesMinutesSeconds> AngleGradiansData = new TheoryData<AngleGradians, AngleDegreesMinutesSeconds>
        {
            { -AngleGradians.Full, -AngleDegreesMinutesSeconds.Full },
            { -AngleGradians.Straight, -AngleDegreesMinutesSeconds.Straight },
            { -AngleGradians.Right, -AngleDegreesMinutesSeconds.Right },
            { AngleGradians.Zero, AngleDegreesMinutesSeconds.Zero },
            { AngleGradians.Right, AngleDegreesMinutesSeconds.Right },
            { AngleGradians.Straight, AngleDegreesMinutesSeconds.Straight },
            { AngleGradians.Full, AngleDegreesMinutesSeconds.Full },
        };

        [Theory]
        [MemberData(nameof(AngleGradiansData))]
        public void ToDegreesMinutes_When_AngleGradians_Should_Succeed(AngleGradians value, in AngleDegreesMinutesSeconds expected)
        {
            // arrange

            // act
            var angle = Angle.ToDegreesMinutesSeconds(value);

            // assert
            angle.Should().BeOfType<AngleDegreesMinutesSeconds>().And.Be(expected);
        }

        public static TheoryData<AngleDegrees, AngleDegreesMinutesSeconds> AngleDegreesData = new TheoryData<AngleDegrees, AngleDegreesMinutesSeconds>
        {
            { -AngleDegrees.Full, -AngleDegreesMinutesSeconds.Full },
            { -AngleDegrees.Straight, -AngleDegreesMinutesSeconds.Straight },
            { -AngleDegrees.Right, -AngleDegreesMinutesSeconds.Right },
            { AngleDegrees.Zero, AngleDegreesMinutesSeconds.Zero },
            { AngleDegrees.Right, AngleDegreesMinutesSeconds.Right },
            { AngleDegrees.Straight, AngleDegreesMinutesSeconds.Straight },
            { AngleDegrees.Full, AngleDegreesMinutesSeconds.Full },
        };

        [Theory]
        [MemberData(nameof(AngleDegreesData))]
        public void ToDegreesMinutes_When_AngleDegrees_Should_Succeed(AngleDegrees value, in AngleDegreesMinutesSeconds expected)
        {
            // arrange

            // act
            var angle = Angle.ToDegreesMinutesSeconds(value);

            // assert
            angle.Should().BeOfType<AngleDegreesMinutesSeconds>().And.Be(expected);
        }

        public static TheoryData<AngleDegreesMinutesSeconds, object, Comparison> CompareInvalidData => new TheoryData<AngleDegreesMinutesSeconds, object, Comparison>
        {
            { AngleDegreesMinutesSeconds.Right, null, Comparison.Invalid },
            { AngleDegreesMinutesSeconds.Right, 90.0, Comparison.Invalid },
        };

        public static TheoryData<AngleDegreesMinutesSeconds, AngleDegreesMinutesSeconds, Comparison> CompareData => new TheoryData<AngleDegreesMinutesSeconds, AngleDegreesMinutesSeconds, Comparison>
        {
            { Angle.FromDegrees(-10, 0, 0.0), Angle.FromDegrees(-10, 0, 0.001), Comparison.GreaterThan },
            { Angle.FromDegrees(-10, 0, 0.0), Angle.FromDegrees(-9, 0, 59.999), Comparison.LessThan },
            { Angle.FromDegrees(10, 0, 0.0), Angle.FromDegrees(10, 0, 0.001), Comparison.LessThan },
            { Angle.FromDegrees(10, 0, 0.0), Angle.FromDegrees(9, 0, 59.999), Comparison.GreaterThan },

            { AngleDegreesMinutesSeconds.Zero, AngleDegreesMinutesSeconds.Right - AngleDegreesMinutesSeconds.Full, Comparison.GreaterThan },
            { AngleDegreesMinutesSeconds.Right, AngleDegreesMinutesSeconds.Right - AngleDegreesMinutesSeconds.Full, Comparison.GreaterThan },
            { AngleDegreesMinutesSeconds.Straight, AngleDegreesMinutesSeconds.Right - AngleDegreesMinutesSeconds.Full, Comparison.GreaterThan },

            { AngleDegreesMinutesSeconds.Zero, AngleDegreesMinutesSeconds.Right, Comparison.LessThan },
            { AngleDegreesMinutesSeconds.Right, AngleDegreesMinutesSeconds.Right, Comparison.Equal },
            { AngleDegreesMinutesSeconds.Straight, AngleDegreesMinutesSeconds.Right, Comparison.GreaterThan },

            { AngleDegreesMinutesSeconds.Zero, AngleDegreesMinutesSeconds.Right + AngleDegreesMinutesSeconds.Full, Comparison.LessThan },
            { AngleDegreesMinutesSeconds.Right, AngleDegreesMinutesSeconds.Right + AngleDegreesMinutesSeconds.Full, Comparison.LessThan },
            { AngleDegreesMinutesSeconds.Straight, AngleDegreesMinutesSeconds.Right + AngleDegreesMinutesSeconds.Full, Comparison.LessThan },
        };

        public static TheoryData<AngleDegreesMinutesSeconds, AngleDegreesMinutesSeconds, Comparison> CompareReducedData => new TheoryData<AngleDegreesMinutesSeconds, AngleDegreesMinutesSeconds, Comparison>
        {
            { Angle.FromDegrees(-10, 0, 0.0), Angle.FromDegrees(-10, 0, 0.001), Comparison.GreaterThan },
            { Angle.FromDegrees(-10, 0, 0.0), Angle.FromDegrees(-9, 0, 59.999), Comparison.LessThan },
            { Angle.FromDegrees(10, 0, 0.0), Angle.FromDegrees(10, 0, 0.001), Comparison.LessThan },
            { Angle.FromDegrees(10, 0, 0.0), Angle.FromDegrees(9, 0, 59.999), Comparison.GreaterThan },

            { AngleDegreesMinutesSeconds.Zero, AngleDegreesMinutesSeconds.Right - AngleDegreesMinutesSeconds.Full, Comparison.LessThan },
            { AngleDegreesMinutesSeconds.Right, AngleDegreesMinutesSeconds.Right - AngleDegreesMinutesSeconds.Full, Comparison.Equal },
            { AngleDegreesMinutesSeconds.Straight, AngleDegreesMinutesSeconds.Right - AngleDegreesMinutesSeconds.Full, Comparison.GreaterThan },

            { AngleDegreesMinutesSeconds.Zero, AngleDegreesMinutesSeconds.Right, Comparison.LessThan },
            { AngleDegreesMinutesSeconds.Right, AngleDegreesMinutesSeconds.Right, Comparison.Equal },
            { AngleDegreesMinutesSeconds.Straight, AngleDegreesMinutesSeconds.Right, Comparison.GreaterThan },

            { AngleDegreesMinutesSeconds.Zero, AngleDegreesMinutesSeconds.Right + AngleDegreesMinutesSeconds.Full, Comparison.LessThan },
            { AngleDegreesMinutesSeconds.Right, AngleDegreesMinutesSeconds.Right + AngleDegreesMinutesSeconds.Full, Comparison.Equal },
            { AngleDegreesMinutesSeconds.Straight, AngleDegreesMinutesSeconds.Right + AngleDegreesMinutesSeconds.Full, Comparison.GreaterThan },
        };

        [Theory]
        [MemberData(nameof(CompareInvalidData))]
        [MemberData(nameof(CompareData))]
        public void EqualsObject_Should_Succeed(in AngleDegreesMinutesSeconds left, object right, Comparison comparison)
        {
            // arrange

            // act
            var result = left.Equals(right);

            // assert
            result.Should().Be(comparison == Comparison.Equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void Equals_Should_Succeed(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right, Comparison comparison)
        {
            // arrange

            // act
            var result = left.Equals(right);

            // assert
            result.Should().Be(comparison == Comparison.Equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void GetHashCode_Should_Succeed(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right, Comparison comparison)
        {
            // arrange

            // act
            var result = left.GetHashCode();

            // assert
            if (comparison == Comparison.Equal)
                result.Should().Be(right.GetHashCode());
            else
                result.Should().NotBe(right.GetHashCode());
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void OperatorEquality_Should_Succeed(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right, Comparison comparison)
        {
            // arrange

            // act
            var result = left == right;

            // assert
            result.Should().Be(comparison == Comparison.Equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void OperatorInequality_Should_Succeed(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right, Comparison comparison)
        {
            // arrange

            // act
            var result = left != right;

            // assert
            result.Should().Be(comparison != Comparison.Equal);
        }

        [Theory]
        [MemberData(nameof(CompareInvalidData))]
        public void CompareTo_When_InvalidData_Should_Thrown(in AngleDegreesMinutesSeconds angle, object obj, Comparison comparison)
        {
            // arrange

            // act
            var comparable = angle as IComparable;
            Action act = () => comparable.CompareTo(obj);

            // assert
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage($"Argument has to be an {nameof(AngleDegreesMinutesSeconds)}.\r\nParameter name: obj");
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void CompareTo_Should_Succeed(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right, Comparison comparison)
        {
            // arrange

            // act
            var result = ((IComparable)left).CompareTo(right);

            // assert
            switch (comparison)
            {
                case Comparison.LessThan:
                    result.Should().BeNegative();
                    break;

                case Comparison.Equal:
                    result.Should().Be(0);
                    break;

                case Comparison.GreaterThan:
                    result.Should().BePositive();
                    break;

                default:
                    throw new NotSupportedException();
            }
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void Compare_Should_Succeed(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right, Comparison comparison)
        {
            // arrange

            // act
            var result = Angle.Compare(left, right);

            // assert
            switch (comparison)
            {
                case Comparison.LessThan:
                    result.Should().BeNegative();
                    break;

                case Comparison.Equal:
                    result.Should().Be(0);
                    break;

                case Comparison.GreaterThan:
                    result.Should().BePositive();
                    break;

                default:
                    throw new NotSupportedException();
            }
        }

        [Theory]
        [MemberData(nameof(CompareReducedData))]
        public void CompareReduced_Should_Succeed(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right, Comparison comparison)
        {
            // arrange

            // act
            var result = Angle.CompareReduced(left, right);

            // assert
            switch (comparison)
            {
                case Comparison.LessThan:
                    result.Should().BeNegative();
                    break;

                case Comparison.Equal:
                    result.Should().Be(0);
                    break;

                case Comparison.GreaterThan:
                    result.Should().BePositive();
                    break;

                default:
                    throw new NotSupportedException();
            }
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void LessThan_Should_Succeed(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right, Comparison comparison)
        {
            // arrange

            // act
            var result = left < right;

            // assert
            result.Should().Be(comparison == Comparison.LessThan);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void LessThanOrEqual_Should_Succeed(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right, Comparison comparison)
        {
            // arrange

            // act
            var result = left <= right;

            // assert
            result.Should().Be(comparison == Comparison.LessThan || comparison == Comparison.Equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void GreaterThan_Should_Succeed(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right, Comparison comparison)
        {
            // arrange

            // act
            var result = left > right;

            // assert
            result.Should().Be(comparison == Comparison.GreaterThan);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void GreaterThanOrEqual_Should_Succeed(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right, Comparison comparison)
        {
            // arrange

            // act
            var result = left >= right;

            // assert
            result.Should().Be(comparison == Comparison.GreaterThan || comparison == Comparison.Equal);
        }

        public static TheoryData<AngleDegreesMinutesSeconds, AngleDegreesMinutesSeconds> ReduceData => new TheoryData<AngleDegreesMinutesSeconds, AngleDegreesMinutesSeconds> {
            { AngleDegreesMinutesSeconds.Zero, AngleDegreesMinutesSeconds.Zero },
            { AcuteAngle, AcuteAngle },
            { AngleDegreesMinutesSeconds.Right, AngleDegreesMinutesSeconds.Right },
            { AngleDegreesMinutesSeconds.Right + AcuteAngle, AngleDegreesMinutesSeconds.Right + AcuteAngle },
            { AngleDegreesMinutesSeconds.Straight, AngleDegreesMinutesSeconds.Straight },

            { AngleDegreesMinutesSeconds.Full, AngleDegreesMinutesSeconds.Zero },
            { AngleDegreesMinutesSeconds.Full + AcuteAngle, AcuteAngle },
            { AngleDegreesMinutesSeconds.Full + AngleDegreesMinutesSeconds.Right, AngleDegreesMinutesSeconds.Right },
            { AngleDegreesMinutesSeconds.Full + AngleDegreesMinutesSeconds.Right + AcuteAngle, AngleDegreesMinutesSeconds.Right + AcuteAngle },
            { AngleDegreesMinutesSeconds.Full + AngleDegreesMinutesSeconds.Straight, AngleDegreesMinutesSeconds.Straight },

            { -AngleDegreesMinutesSeconds.Full, AngleDegreesMinutesSeconds.Zero },
            { -AcuteAngle, AngleDegreesMinutesSeconds.Full - AcuteAngle },
            { -AngleDegreesMinutesSeconds.Right, AngleDegreesMinutesSeconds.Full - AngleDegreesMinutesSeconds.Right },
            { -AngleDegreesMinutesSeconds.Straight, AngleDegreesMinutesSeconds.Straight },
            { -AngleDegreesMinutesSeconds.Straight - AngleDegreesMinutesSeconds.Right, AngleDegreesMinutesSeconds.Right },
        };

        [Theory]
        [MemberData(nameof(ReduceData))]
        public void Reduce_Should_Succeed(in AngleDegreesMinutesSeconds angle, in AngleDegreesMinutesSeconds expected)
        {
            // arrange

            // act
            var result = Angle.Reduce(angle);

            // assert
            result.Degrees.Should().Be(expected.Degrees);
            result.Minutes.Should().Be(expected.Minutes);
            result.Seconds.Should().BeApproximately(expected.Seconds, Math.Pow(10, 8));
        }

        public static TheoryData<AngleDegreesMinutesSeconds, Quadrant> QuadrantData => new TheoryData<AngleDegreesMinutesSeconds, Quadrant> {
            {AngleDegreesMinutesSeconds.Zero, Quadrant.First},
            {AcuteAngle, Quadrant.First},
            {AngleDegreesMinutesSeconds.Right, Quadrant.Second},
            {AngleDegreesMinutesSeconds.Right + AcuteAngle, Quadrant.Second},
            {AngleDegreesMinutesSeconds.Straight, Quadrant.Third},
            {AngleDegreesMinutesSeconds.Straight + AcuteAngle, Quadrant.Third},
            {AngleDegreesMinutesSeconds.Straight + AngleDegreesMinutesSeconds.Right, Quadrant.Fourth},
            {AngleDegreesMinutesSeconds.Straight + AngleDegreesMinutesSeconds.Right + AcuteAngle, Quadrant.Fourth},

            {AngleDegreesMinutesSeconds.Full, Quadrant.First},
            {AngleDegreesMinutesSeconds.Full + AcuteAngle, Quadrant.First},
            {AngleDegreesMinutesSeconds.Full + AngleDegreesMinutesSeconds.Right, Quadrant.Second},
            {AngleDegreesMinutesSeconds.Full + AngleDegreesMinutesSeconds.Right + AcuteAngle, Quadrant.Second},
            {AngleDegreesMinutesSeconds.Full + AngleDegreesMinutesSeconds.Straight, Quadrant.Third},
            {AngleDegreesMinutesSeconds.Full + AngleDegreesMinutesSeconds.Straight + AcuteAngle, Quadrant.Third},
            {AngleDegreesMinutesSeconds.Full + AngleDegreesMinutesSeconds.Straight + AngleDegreesMinutesSeconds.Right, Quadrant.Fourth},
            {AngleDegreesMinutesSeconds.Full + AngleDegreesMinutesSeconds.Straight + AngleDegreesMinutesSeconds.Right + AcuteAngle, Quadrant.Fourth},
        };

        [Theory]
        [MemberData(nameof(QuadrantData))]
        public void GetQuadrant_Should_Succeed(in AngleDegreesMinutesSeconds angle, Quadrant expected)
        {
            // arrange

            // act
            var result = Angle.GetQuadrant(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegreesMinutesSeconds, AngleDegreesMinutesSeconds> ReferencetData => new TheoryData<AngleDegreesMinutesSeconds, AngleDegreesMinutesSeconds> {
            {AngleDegreesMinutesSeconds.Zero, AngleDegreesMinutesSeconds.Zero},
            {AcuteAngle, AcuteAngle},
            {AngleDegreesMinutesSeconds.Right ,AngleDegreesMinutesSeconds.Right},
            {AngleDegreesMinutesSeconds.Right + AcuteAngle, AcuteAngle},
            {AngleDegreesMinutesSeconds.Straight, AngleDegreesMinutesSeconds.Zero},
            {AngleDegreesMinutesSeconds.Straight + AcuteAngle, AcuteAngle},
            {AngleDegreesMinutesSeconds.Straight + AngleDegreesMinutesSeconds.Right, AngleDegreesMinutesSeconds.Right},
            {AngleDegreesMinutesSeconds.Straight + AngleDegreesMinutesSeconds.Right + AcuteAngle, AcuteAngle},
            {AngleDegreesMinutesSeconds.Full, AngleDegreesMinutesSeconds.Zero},
        };

        [Theory]
        [MemberData(nameof(ReferencetData))]
        public void Reference_Should_Succeed(in AngleDegreesMinutesSeconds angle, in AngleDegreesMinutesSeconds expected)
        {
            // arrange

            // act
            var result = Angle.GetReference(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegreesMinutesSeconds, bool> IsZeroData => new TheoryData<AngleDegreesMinutesSeconds, bool> {
            {AngleDegreesMinutesSeconds.Zero, true},
            {AcuteAngle, false},
            {AngleDegreesMinutesSeconds.Right, false},
            {AngleDegreesMinutesSeconds.Right + AcuteAngle, false},
            {AngleDegreesMinutesSeconds.Straight, false},
            {AngleDegreesMinutesSeconds.Straight + AngleDegreesMinutesSeconds.Right, false},
            {AngleDegreesMinutesSeconds.Full, true},

            {-AcuteAngle, false},
            {-AngleDegreesMinutesSeconds.Right, false},
            {-AngleDegreesMinutesSeconds.Right - AcuteAngle, false},
            {-AngleDegreesMinutesSeconds.Straight, false},
            {-AngleDegreesMinutesSeconds.Straight - AngleDegreesMinutesSeconds.Right, false},
            {-AngleDegreesMinutesSeconds.Full, true},
        };

        [Theory]
        [MemberData(nameof(IsZeroData))]
        public void IsZero_Should_Succeed(in AngleDegreesMinutesSeconds angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsZero(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegreesMinutesSeconds, bool> IsAcuteData => new TheoryData<AngleDegreesMinutesSeconds, bool> {
            {AngleDegreesMinutesSeconds.Zero, false},
            {AcuteAngle, true},
            {AngleDegreesMinutesSeconds.Right, false},
            {AngleDegreesMinutesSeconds.Right + AcuteAngle, false},
            {AngleDegreesMinutesSeconds.Straight, false},
            {AngleDegreesMinutesSeconds.Straight + AngleDegreesMinutesSeconds.Right, false},
            {AngleDegreesMinutesSeconds.Full, false},

            {-AcuteAngle, true},
            {-AngleDegreesMinutesSeconds.Right, false},
            {-AngleDegreesMinutesSeconds.Right - AcuteAngle, false},
            {-AngleDegreesMinutesSeconds.Straight, false},
            {-AngleDegreesMinutesSeconds.Straight - AngleDegreesMinutesSeconds.Right, false},
            {-AngleDegreesMinutesSeconds.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsAcuteData))]
        public void IsAcute_Should_Succeed(in AngleDegreesMinutesSeconds angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsAcute(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegreesMinutesSeconds, bool> IsRightData => new TheoryData<AngleDegreesMinutesSeconds, bool> {
            {AngleDegreesMinutesSeconds.Zero, false},
            {AcuteAngle, false},
            {AngleDegreesMinutesSeconds.Right, true},
            {AngleDegreesMinutesSeconds.Right + AcuteAngle, false},
            {AngleDegreesMinutesSeconds.Straight, false},
            {AngleDegreesMinutesSeconds.Straight + AngleDegreesMinutesSeconds.Right, false},
            {AngleDegreesMinutesSeconds.Full, false},

            {-AcuteAngle, false},
            {-AngleDegreesMinutesSeconds.Right, true},
            {-AngleDegreesMinutesSeconds.Right - AcuteAngle, false},
            {-AngleDegreesMinutesSeconds.Straight, false},
            {-AngleDegreesMinutesSeconds.Straight - AngleDegreesMinutesSeconds.Right, false},
            {-AngleDegreesMinutesSeconds.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsRightData))]
        public void IsRight_Should_Succeed(in AngleDegreesMinutesSeconds angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsRight(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegreesMinutesSeconds, bool> IsObtuseData => new TheoryData<AngleDegreesMinutesSeconds, bool> {
            {AngleDegreesMinutesSeconds.Zero, false},
            {AcuteAngle, false},
            {AngleDegreesMinutesSeconds.Right, false},
            {AngleDegreesMinutesSeconds.Right + AcuteAngle, true},
            {AngleDegreesMinutesSeconds.Straight, false},
            {AngleDegreesMinutesSeconds.Straight + AngleDegreesMinutesSeconds.Right, false},
            {AngleDegreesMinutesSeconds.Full, false},

            {-AcuteAngle, false},
            {-AngleDegreesMinutesSeconds.Right, false},
            {-AngleDegreesMinutesSeconds.Right - AcuteAngle, true},
            {-AngleDegreesMinutesSeconds.Straight, false},
            {-AngleDegreesMinutesSeconds.Straight - AngleDegreesMinutesSeconds.Right, false},
            {-AngleDegreesMinutesSeconds.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsObtuseData))]
        public void IsObtuse_Should_Succeed(in AngleDegreesMinutesSeconds angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsObtuse(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegreesMinutesSeconds, bool> IsStraightData => new TheoryData<AngleDegreesMinutesSeconds, bool> {
            {AngleDegreesMinutesSeconds.Zero, false},
            {AcuteAngle, false},
            {AngleDegreesMinutesSeconds.Right, false},
            {AngleDegreesMinutesSeconds.Right - AcuteAngle, false},
            {AngleDegreesMinutesSeconds.Straight, true},
            {AngleDegreesMinutesSeconds.Straight - AngleDegreesMinutesSeconds.Right, false},
            {AngleDegreesMinutesSeconds.Full, false},

            {-AcuteAngle, false},
            {-AngleDegreesMinutesSeconds.Right, false},
            {-AngleDegreesMinutesSeconds.Right - AcuteAngle, false},
            {-AngleDegreesMinutesSeconds.Straight, true},
            {-AngleDegreesMinutesSeconds.Straight - AngleDegreesMinutesSeconds.Right, false},
            {-AngleDegreesMinutesSeconds.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsStraightData))]
        public void IsStraight_Should_Succeed(in AngleDegreesMinutesSeconds angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsStraight(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegreesMinutesSeconds, bool> IsReflexData => new TheoryData<AngleDegreesMinutesSeconds, bool> {
            {AngleDegreesMinutesSeconds.Zero, false},
            {AcuteAngle, false},
            {AngleDegreesMinutesSeconds.Right, false},
            {AngleDegreesMinutesSeconds.Right + AcuteAngle, false},
            {AngleDegreesMinutesSeconds.Straight, false},
            {AngleDegreesMinutesSeconds.Straight + AngleDegreesMinutesSeconds.Right, true},
            {AngleDegreesMinutesSeconds.Full, false},

            {-AcuteAngle, false},
            {-AngleDegreesMinutesSeconds.Right, false},
            {-AngleDegreesMinutesSeconds.Right - AcuteAngle, false},
            {-AngleDegreesMinutesSeconds.Straight, false},
            {-AngleDegreesMinutesSeconds.Straight - AngleDegreesMinutesSeconds.Right, true},
            {-AngleDegreesMinutesSeconds.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsReflexData))]
        public void IsReflex_Should_Succeed(in AngleDegreesMinutesSeconds angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsReflex(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegreesMinutesSeconds, bool> IsObliqueData => new TheoryData<AngleDegreesMinutesSeconds, bool> {
            {AngleDegreesMinutesSeconds.Zero, false},
            {AcuteAngle, true},
            {AngleDegreesMinutesSeconds.Right, false},
            {AngleDegreesMinutesSeconds.Right + AcuteAngle, true},
            {AngleDegreesMinutesSeconds.Straight, false},
            {AngleDegreesMinutesSeconds.Straight + AngleDegreesMinutesSeconds.Right, false},
            {AngleDegreesMinutesSeconds.Full, false},

            {-AcuteAngle, true},
            {-AngleDegreesMinutesSeconds.Right, false},
            {-AngleDegreesMinutesSeconds.Right - AcuteAngle, true},
            {-AngleDegreesMinutesSeconds.Straight, false},
            {-AngleDegreesMinutesSeconds.Straight - AngleDegreesMinutesSeconds.Right, false},
            {-AngleDegreesMinutesSeconds.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsObliqueData))]
        public void IsOblique_Should_Succeed(in AngleDegreesMinutesSeconds angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsOblique(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegreesMinutesSeconds, AngleDegreesMinutesSeconds, double, AngleDegreesMinutesSeconds> LerpData => new TheoryData<AngleDegreesMinutesSeconds, AngleDegreesMinutesSeconds, double, AngleDegreesMinutesSeconds>
        {
            {AcuteAngle, AngleDegreesMinutesSeconds.Right + AcuteAngle, -0.5, AngleDegreesMinutesSeconds.Zero},
            {AcuteAngle, AngleDegreesMinutesSeconds.Right + AcuteAngle, 0.0, AcuteAngle},
            {AcuteAngle, AngleDegreesMinutesSeconds.Right + AcuteAngle, 0.5, AngleDegreesMinutesSeconds.Right},
            {AcuteAngle, AngleDegreesMinutesSeconds.Right + AcuteAngle, 1.0, AngleDegreesMinutesSeconds.Right + AcuteAngle},
            {AcuteAngle, AngleDegreesMinutesSeconds.Right + AcuteAngle, 1.5, AngleDegreesMinutesSeconds.Straight},

            {-AcuteAngle, -AngleDegreesMinutesSeconds.Right - AcuteAngle, -0.5, AngleDegreesMinutesSeconds.Zero},
            {-AcuteAngle, -AngleDegreesMinutesSeconds.Right - AcuteAngle, 0.0, -AcuteAngle},
            {-AcuteAngle, -AngleDegreesMinutesSeconds.Right - AcuteAngle, 0.5, -AngleDegreesMinutesSeconds.Right},
            {-AcuteAngle, -AngleDegreesMinutesSeconds.Right - AcuteAngle, 1.0, -AngleDegreesMinutesSeconds.Right - AcuteAngle},
            {-AcuteAngle, -AngleDegreesMinutesSeconds.Right - AcuteAngle, 1.5, -AngleDegreesMinutesSeconds.Straight},

            {AngleDegreesMinutesSeconds.Right + AcuteAngle, AcuteAngle, -0.5, AngleDegreesMinutesSeconds.Straight},
            {AngleDegreesMinutesSeconds.Right + AcuteAngle, AcuteAngle, 0.0, AngleDegreesMinutesSeconds.Right + AcuteAngle},
            {AngleDegreesMinutesSeconds.Right + AcuteAngle, AcuteAngle, 0.5, AngleDegreesMinutesSeconds.Right},
            {AngleDegreesMinutesSeconds.Right + AcuteAngle, AcuteAngle, 1.0, AcuteAngle},
            {AngleDegreesMinutesSeconds.Right + AcuteAngle, AcuteAngle, 1.5, AngleDegreesMinutesSeconds.Zero},
        };

        [Theory]
        [MemberData(nameof(LerpData))]
        public void Lerp_Should_Succeed(in AngleDegreesMinutesSeconds a1, in AngleDegreesMinutesSeconds a2, double t, in AngleDegreesMinutesSeconds expected)
        {
            // arrange

            // act
            var result = Angle.Lerp(a1, a2, t);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegreesMinutesSeconds, string> ToStringData => new TheoryData<AngleDegreesMinutesSeconds, string>
        {
            {AngleDegreesMinutesSeconds.Straight, "180° 0' 0\""},
        };

        [Theory]
        [MemberData(nameof(ToStringData))]
        public void ToString_Should_Succeed(in AngleDegreesMinutesSeconds angle, string expected)
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

        public static TheoryData<AngleDegreesMinutesSeconds, string, string> ToStringFormatData => new TheoryData<AngleDegreesMinutesSeconds, string, string>
        {
            {AngleDegreesMinutesSeconds.Straight, "0.00", "180° 0' 0.00\""},
        };

        [Theory]
        [MemberData(nameof(ToStringFormatData))]
        public void ToStringFormat_Should_Succeed(in AngleDegreesMinutesSeconds angle, string format, string expected)
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

        public static TheoryData<AngleDegreesMinutesSeconds, string, CultureInfo, string> ToStringFormatCultureData => new TheoryData<AngleDegreesMinutesSeconds, string, CultureInfo, string>
        {
            {AngleDegreesMinutesSeconds.Straight, "0.00", new CultureInfo("pt-PT"), "180° 0' 0,00\""},
        };

        [Theory]
        [MemberData(nameof(ToStringFormatCultureData))]
        public void ToStringFormatCulture_Should_Succeed(in AngleDegreesMinutesSeconds angle, string format, CultureInfo culture, string expected)
        {
            // arrange

            // act
            var result = angle.ToString(format, culture);

            // assert
            result.Should().Be(expected);
        }

    }
}
