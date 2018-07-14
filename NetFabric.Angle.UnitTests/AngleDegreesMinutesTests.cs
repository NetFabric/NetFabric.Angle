using FluentAssertions;
using System;
using System.Globalization;
using Xunit;

namespace NetFabric.UnitTests
{
    public class AngleDegreesMinutesTests
    {
        static readonly AngleDegreesMinutes AcuteAngle = AngleDegreesMinutes.Right / 2.0;

        public static TheoryData<AngleRadians, AngleDegreesMinutes> AngleRadiansData = new TheoryData<AngleRadians, AngleDegreesMinutes>
        {
            { -AngleRadians.Full, -AngleDegreesMinutes.Full },
            { -AngleRadians.Straight, -AngleDegreesMinutes.Straight },
            { -AngleRadians.Right, -AngleDegreesMinutes.Right },
            { AngleRadians.Zero, AngleDegreesMinutes.Zero },
            { AngleRadians.Right, AngleDegreesMinutes.Right },
            { AngleRadians.Straight, AngleDegreesMinutes.Straight },
            { AngleRadians.Full, AngleDegreesMinutes.Full },
        };

        [Theory]
        [MemberData(nameof(AngleRadiansData))]
        public void ToDegrees_When_AngleRadians_Should_Succeed(AngleRadians value, in AngleDegreesMinutes expected)
        {
            // arrange

            // act
            var angle = Angle.ToDegreesMinutes(value);

            // assert
            angle.Should().BeOfType<AngleDegreesMinutes>().And.Be(expected);
        }

        public static TheoryData<AngleGradians, AngleDegreesMinutes> AngleGradiansData = new TheoryData<AngleGradians, AngleDegreesMinutes>
        {
            { -AngleGradians.Full, -AngleDegreesMinutes.Full },
            { -AngleGradians.Straight, -AngleDegreesMinutes.Straight },
            { -AngleGradians.Right, -AngleDegreesMinutes.Right },
            { AngleGradians.Zero, AngleDegreesMinutes.Zero },
            { AngleGradians.Right, AngleDegreesMinutes.Right },
            { AngleGradians.Straight, AngleDegreesMinutes.Straight },
            { AngleGradians.Full, AngleDegreesMinutes.Full },
        };

        [Theory]
        [MemberData(nameof(AngleGradiansData))]
        public void ToDegreesMinutes_When_AngleGradians_Should_Succeed(AngleGradians value, in AngleDegreesMinutes expected)
        {
            // arrange

            // act
            var angle = Angle.ToDegreesMinutes(value);

            // assert
            angle.Should().BeOfType<AngleDegreesMinutes>().And.Be(expected);
        }

        public static TheoryData<AngleDegrees, AngleDegreesMinutes> AngleDegreesData = new TheoryData<AngleDegrees, AngleDegreesMinutes>
        {
            { -AngleDegrees.Full, -AngleDegreesMinutes.Full },
            { -AngleDegrees.Straight, -AngleDegreesMinutes.Straight },
            { -AngleDegrees.Right, -AngleDegreesMinutes.Right },
            { AngleDegrees.Zero, AngleDegreesMinutes.Zero },
            { AngleDegrees.Right, AngleDegreesMinutes.Right },
            { AngleDegrees.Straight, AngleDegreesMinutes.Straight },
            { AngleDegrees.Full, AngleDegreesMinutes.Full },
        };

        [Theory]
        [MemberData(nameof(AngleDegreesData))]
        public void ToDegreesMinutes_When_AngleDegrees_Should_Succeed(AngleDegrees value, in AngleDegreesMinutes expected)
        {
            // arrange

            // act
            var angle = Angle.ToDegreesMinutes(value);

            // assert
            angle.Should().BeOfType<AngleDegreesMinutes>().And.Be(expected);
        }

        public static TheoryData<AngleDegreesMinutes, object, bool, bool, bool> CompareInvalidData => new TheoryData<AngleDegreesMinutes, object, bool, bool, bool>
        {
            { AngleDegreesMinutes.Right, null, false, false, false },
            { AngleDegreesMinutes.Right, 90.0, false, false, false },
        };

        public static TheoryData<AngleDegreesMinutes, AngleDegreesMinutes, bool, bool, bool> CompareData => new TheoryData<AngleDegreesMinutes, AngleDegreesMinutes, bool, bool, bool>
        {
            { Angle.FromDegrees(-10, 0.0), Angle.FromDegrees(-10, 0.001), false, false, true },
            { Angle.FromDegrees(-10, 0.0), Angle.FromDegrees(-9, 59.999), true, false, false },
            { Angle.FromDegrees(10, 0.0), Angle.FromDegrees(10, 0.001), true, false, false },
            { Angle.FromDegrees(10, 0.0), Angle.FromDegrees(9, 59.999), false, false, true },

            { AngleDegreesMinutes.Zero, AngleDegreesMinutes.Right - AngleDegreesMinutes.Full, false, false, true },
            { AngleDegreesMinutes.Right, AngleDegreesMinutes.Right - AngleDegreesMinutes.Full, false, false, true },
            { AngleDegreesMinutes.Straight, AngleDegreesMinutes.Right - AngleDegreesMinutes.Full, false, false, true },

            { AngleDegreesMinutes.Zero, AngleDegreesMinutes.Right, true, false, false },
            { AngleDegreesMinutes.Right, AngleDegreesMinutes.Right, false, true, false },
            { AngleDegreesMinutes.Straight, AngleDegreesMinutes.Right, false, false, true },

            { AngleDegreesMinutes.Zero, AngleDegreesMinutes.Right + AngleDegreesMinutes.Full, true, false, false },
            { AngleDegreesMinutes.Right, AngleDegreesMinutes.Right + AngleDegreesMinutes.Full, true, false, false },
            { AngleDegreesMinutes.Straight, AngleDegreesMinutes.Right + AngleDegreesMinutes.Full, true, false, false },
        };

        public static TheoryData<AngleDegreesMinutes, AngleDegreesMinutes, bool, bool, bool> CompareReducedData => new TheoryData<AngleDegreesMinutes, AngleDegreesMinutes, bool, bool, bool>
        {
            { Angle.FromDegrees(-10, 0.0), Angle.FromDegrees(-10, 0.001), false, false, true },
            { Angle.FromDegrees(-10, 0.0), Angle.FromDegrees(-9, 59.999), true, false, false },
            { Angle.FromDegrees(10, 0.0), Angle.FromDegrees(10, 0.001), true, false, false },
            { Angle.FromDegrees(10, 0.0), Angle.FromDegrees(9, 59.999), false, false, true },

            { AngleDegreesMinutes.Zero, AngleDegreesMinutes.Right - AngleDegreesMinutes.Full, true, false, false },
            { AngleDegreesMinutes.Right, AngleDegreesMinutes.Right - AngleDegreesMinutes.Full, false, true, false },
            { AngleDegreesMinutes.Straight, AngleDegreesMinutes.Right - AngleDegreesMinutes.Full, false, false, true },

            { AngleDegreesMinutes.Zero, AngleDegreesMinutes.Right, true, false, false },
            { AngleDegreesMinutes.Right, AngleDegreesMinutes.Right, false, true, false },
            { AngleDegreesMinutes.Straight, AngleDegreesMinutes.Right, false, false, true },

            { AngleDegreesMinutes.Zero, AngleDegreesMinutes.Right + AngleDegreesMinutes.Full, true, false, false },
            { AngleDegreesMinutes.Right, AngleDegreesMinutes.Right + AngleDegreesMinutes.Full, false, true, false },
            { AngleDegreesMinutes.Straight, AngleDegreesMinutes.Right + AngleDegreesMinutes.Full, false, false, true },
        };

        [Theory]
        [MemberData(nameof(CompareInvalidData))]
        [MemberData(nameof(CompareData))]
        public void EqualsObject_Should_Succeed(in AngleDegreesMinutes left, object right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left.Equals(right);

            // assert
            result.Should().Be(equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void Equals_Should_Succeed(in AngleDegreesMinutes left, in AngleDegreesMinutes right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left.Equals(right);

            // assert
            result.Should().Be(equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void GetHashCode_Should_Succeed(in AngleDegreesMinutes left, in AngleDegreesMinutes right, bool lessThan, bool equal, bool greaterThan)
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
        public void OperatorEquality_Should_Succeed(in AngleDegreesMinutes left, in AngleDegreesMinutes right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left == right;

            // assert
            result.Should().Be(equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void OperatorInequality_Should_Succeed(in AngleDegreesMinutes left, in AngleDegreesMinutes right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left != right;

            // assert
            result.Should().Be(!equal);
        }

        [Theory]
        [MemberData(nameof(CompareInvalidData))]
        public void CompareTo_When_InvalidData_Should_Thrown(in AngleDegreesMinutes angle, object obj, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var comparable = angle as IComparable;
            Action act = () => comparable.CompareTo(obj);

            // assert
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage($"Argument has to be an {nameof(AngleDegreesMinutes)}.\r\nParameter name: obj");
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void CompareTo_Should_Succeed(in AngleDegreesMinutes left, in AngleDegreesMinutes right, bool lessThan, bool equal, bool greaterThan)
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
        public void Compare_Should_Succeed(in AngleDegreesMinutes left, in AngleDegreesMinutes right, bool lessThan, bool equal, bool greaterThan)
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
        public void CompareReduced_Should_Succeed(in AngleDegreesMinutes left, in AngleDegreesMinutes right, bool lessThan, bool equal, bool greaterThan)
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
        public void LessThan_Should_Succeed(in AngleDegreesMinutes left, in AngleDegreesMinutes right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left < right;

            // assert
            result.Should().Be(lessThan);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void LessThanOrEqual_Should_Succeed(in AngleDegreesMinutes left, in AngleDegreesMinutes right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left <= right;

            // assert
            result.Should().Be(lessThan || equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void GreaterThan_Should_Succeed(in AngleDegreesMinutes left, in AngleDegreesMinutes right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left > right;

            // assert
            result.Should().Be(greaterThan);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        public void GreaterThanOrEqual_Should_Succeed(in AngleDegreesMinutes left, in AngleDegreesMinutes right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left >= right;

            // assert
            result.Should().Be(greaterThan || equal);
        }

        public static TheoryData<AngleDegreesMinutes, AngleDegreesMinutes> ReduceData => new TheoryData<AngleDegreesMinutes, AngleDegreesMinutes> {
            { AngleDegreesMinutes.Zero, AngleDegreesMinutes.Zero },
            { AcuteAngle, AcuteAngle },
            { AngleDegreesMinutes.Right, AngleDegreesMinutes.Right },
            { AngleDegreesMinutes.Right + AcuteAngle, AngleDegreesMinutes.Right + AcuteAngle },
            { AngleDegreesMinutes.Straight, AngleDegreesMinutes.Straight },

            { AngleDegreesMinutes.Full, AngleDegreesMinutes.Zero },
            { AngleDegreesMinutes.Full + AcuteAngle, AcuteAngle },
            { AngleDegreesMinutes.Full + AngleDegreesMinutes.Right, AngleDegreesMinutes.Right },
            { AngleDegreesMinutes.Full + AngleDegreesMinutes.Right + AcuteAngle, AngleDegreesMinutes.Right + AcuteAngle },
            { AngleDegreesMinutes.Full + AngleDegreesMinutes.Straight, AngleDegreesMinutes.Straight },

            { -AngleDegreesMinutes.Full, AngleDegreesMinutes.Zero },
            { -AcuteAngle, AngleDegreesMinutes.Full - AcuteAngle },
            { -AngleDegreesMinutes.Right, AngleDegreesMinutes.Full - AngleDegreesMinutes.Right },
            { -AngleDegreesMinutes.Straight, AngleDegreesMinutes.Straight },
            { -AngleDegreesMinutes.Straight - AngleDegreesMinutes.Right, AngleDegreesMinutes.Right },
        };

        [Theory]
        [MemberData(nameof(ReduceData))]
        public void Reduce_Should_Succeed(in AngleDegreesMinutes angle, in AngleDegreesMinutes expected)
        {
            // arrange

            // act
            var result = Angle.Reduce(angle);

            // assert
            result.Degrees.Should().Be(expected.Degrees);
            result.Minutes.Should().BeApproximately(expected.Minutes, Math.Pow(10, 8));
        }

        public static TheoryData<AngleDegreesMinutes, Quadrant> QuadrantData => new TheoryData<AngleDegreesMinutes, Quadrant> {
            {AngleDegreesMinutes.Zero, Quadrant.First},
            {AcuteAngle, Quadrant.First},
            {AngleDegreesMinutes.Right, Quadrant.Second},
            {AngleDegreesMinutes.Right + AcuteAngle, Quadrant.Second},
            {AngleDegreesMinutes.Straight, Quadrant.Third},
            {AngleDegreesMinutes.Straight + AcuteAngle, Quadrant.Third},
            {AngleDegreesMinutes.Straight + AngleDegreesMinutes.Right, Quadrant.Fourth},
            {AngleDegreesMinutes.Straight + AngleDegreesMinutes.Right + AcuteAngle, Quadrant.Fourth},

            {AngleDegreesMinutes.Full, Quadrant.First},
            {AngleDegreesMinutes.Full + AcuteAngle, Quadrant.First},
            {AngleDegreesMinutes.Full + AngleDegreesMinutes.Right, Quadrant.Second},
            {AngleDegreesMinutes.Full + AngleDegreesMinutes.Right + AcuteAngle, Quadrant.Second},
            {AngleDegreesMinutes.Full + AngleDegreesMinutes.Straight, Quadrant.Third},
            {AngleDegreesMinutes.Full + AngleDegreesMinutes.Straight + AcuteAngle, Quadrant.Third},
            {AngleDegreesMinutes.Full + AngleDegreesMinutes.Straight + AngleDegreesMinutes.Right, Quadrant.Fourth},
            {AngleDegreesMinutes.Full + AngleDegreesMinutes.Straight + AngleDegreesMinutes.Right + AcuteAngle, Quadrant.Fourth},
        };

        [Theory]
        [MemberData(nameof(QuadrantData))]
        public void GetQuadrant_Should_Succeed(in AngleDegreesMinutes angle, Quadrant expected)
        {
            // arrange

            // act
            var result = Angle.GetQuadrant(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegreesMinutes, AngleDegreesMinutes> ReferencetData => new TheoryData<AngleDegreesMinutes, AngleDegreesMinutes> {
            {AngleDegreesMinutes.Zero, AngleDegreesMinutes.Zero},
            {AcuteAngle, AcuteAngle},
            {AngleDegreesMinutes.Right ,AngleDegreesMinutes.Right},
            {AngleDegreesMinutes.Right + AcuteAngle, AcuteAngle},
            {AngleDegreesMinutes.Straight, AngleDegreesMinutes.Zero},
            {AngleDegreesMinutes.Straight + AcuteAngle, AcuteAngle},
            {AngleDegreesMinutes.Straight + AngleDegreesMinutes.Right, AngleDegreesMinutes.Right},
            {AngleDegreesMinutes.Straight + AngleDegreesMinutes.Right + AcuteAngle, AcuteAngle},
            {AngleDegreesMinutes.Full, AngleDegreesMinutes.Zero},
        };

        [Theory]
        [MemberData(nameof(ReferencetData))]
        public void Reference_Should_Succeed(in AngleDegreesMinutes angle, in AngleDegreesMinutes expected)
        {
            // arrange

            // act
            var result = Angle.GetReference(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegreesMinutes, bool> IsZeroData => new TheoryData<AngleDegreesMinutes, bool> {
            {AngleDegreesMinutes.Zero, true},
            {AcuteAngle, false},
            {AngleDegreesMinutes.Right, false},
            {AngleDegreesMinutes.Right + AcuteAngle, false},
            {AngleDegreesMinutes.Straight, false},
            {AngleDegreesMinutes.Straight + AngleDegreesMinutes.Right, false},
            {AngleDegreesMinutes.Full, true},

            {-AcuteAngle, false},
            {-AngleDegreesMinutes.Right, false},
            {-AngleDegreesMinutes.Right - AcuteAngle, false},
            {-AngleDegreesMinutes.Straight, false},
            {-AngleDegreesMinutes.Straight - AngleDegreesMinutes.Right, false},
            {-AngleDegreesMinutes.Full, true},
        };

        [Theory]
        [MemberData(nameof(IsZeroData))]
        public void IsZero_Should_Succeed(in AngleDegreesMinutes angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsZero(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegreesMinutes, bool> IsAcuteData => new TheoryData<AngleDegreesMinutes, bool> {
            {AngleDegreesMinutes.Zero, false},
            {AcuteAngle, true},
            {AngleDegreesMinutes.Right, false},
            {AngleDegreesMinutes.Right + AcuteAngle, false},
            {AngleDegreesMinutes.Straight, false},
            {AngleDegreesMinutes.Straight + AngleDegreesMinutes.Right, false},
            {AngleDegreesMinutes.Full, false},

            {-AcuteAngle, true},
            {-AngleDegreesMinutes.Right, false},
            {-AngleDegreesMinutes.Right - AcuteAngle, false},
            {-AngleDegreesMinutes.Straight, false},
            {-AngleDegreesMinutes.Straight - AngleDegreesMinutes.Right, false},
            {-AngleDegreesMinutes.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsAcuteData))]
        public void IsAcute_Should_Succeed(in AngleDegreesMinutes angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsAcute(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegreesMinutes, bool> IsRightData => new TheoryData<AngleDegreesMinutes, bool> {
            {AngleDegreesMinutes.Zero, false},
            {AcuteAngle, false},
            {AngleDegreesMinutes.Right, true},
            {AngleDegreesMinutes.Right + AcuteAngle, false},
            {AngleDegreesMinutes.Straight, false},
            {AngleDegreesMinutes.Straight + AngleDegreesMinutes.Right, false},
            {AngleDegreesMinutes.Full, false},

            {-AcuteAngle, false},
            {-AngleDegreesMinutes.Right, true},
            {-AngleDegreesMinutes.Right - AcuteAngle, false},
            {-AngleDegreesMinutes.Straight, false},
            {-AngleDegreesMinutes.Straight - AngleDegreesMinutes.Right, false},
            {-AngleDegreesMinutes.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsRightData))]
        public void IsRight_Should_Succeed(in AngleDegreesMinutes angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsRight(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegreesMinutes, bool> IsObtuseData => new TheoryData<AngleDegreesMinutes, bool> {
            {AngleDegreesMinutes.Zero, false},
            {AcuteAngle, false},
            {AngleDegreesMinutes.Right, false},
            {AngleDegreesMinutes.Right + AcuteAngle, true},
            {AngleDegreesMinutes.Straight, false},
            {AngleDegreesMinutes.Straight + AngleDegreesMinutes.Right, false},
            {AngleDegreesMinutes.Full, false},

            {-AcuteAngle, false},
            {-AngleDegreesMinutes.Right, false},
            {-AngleDegreesMinutes.Right - AcuteAngle, true},
            {-AngleDegreesMinutes.Straight, false},
            {-AngleDegreesMinutes.Straight - AngleDegreesMinutes.Right, false},
            {-AngleDegreesMinutes.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsObtuseData))]
        public void IsObtuse_Should_Succeed(in AngleDegreesMinutes angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsObtuse(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegreesMinutes, bool> IsStraightData => new TheoryData<AngleDegreesMinutes, bool> {
            {AngleDegreesMinutes.Zero, false},
            {AcuteAngle, false},
            {AngleDegreesMinutes.Right, false},
            {AngleDegreesMinutes.Right - AcuteAngle, false},
            {AngleDegreesMinutes.Straight, true},
            {AngleDegreesMinutes.Straight - AngleDegreesMinutes.Right, false},
            {AngleDegreesMinutes.Full, false},

            {-AcuteAngle, false},
            {-AngleDegreesMinutes.Right, false},
            {-AngleDegreesMinutes.Right - AcuteAngle, false},
            {-AngleDegreesMinutes.Straight, true},
            {-AngleDegreesMinutes.Straight - AngleDegreesMinutes.Right, false},
            {-AngleDegreesMinutes.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsStraightData))]
        public void IsStraight_Should_Succeed(in AngleDegreesMinutes angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsStraight(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegreesMinutes, bool> IsReflexData => new TheoryData<AngleDegreesMinutes, bool> {
            {AngleDegreesMinutes.Zero, false},
            {AcuteAngle, false},
            {AngleDegreesMinutes.Right, false},
            {AngleDegreesMinutes.Right + AcuteAngle, false},
            {AngleDegreesMinutes.Straight, false},
            {AngleDegreesMinutes.Straight + AngleDegreesMinutes.Right, true},
            {AngleDegreesMinutes.Full, false},

            {-AcuteAngle, false},
            {-AngleDegreesMinutes.Right, false},
            {-AngleDegreesMinutes.Right - AcuteAngle, false},
            {-AngleDegreesMinutes.Straight, false},
            {-AngleDegreesMinutes.Straight - AngleDegreesMinutes.Right, true},
            {-AngleDegreesMinutes.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsReflexData))]
        public void IsReflex_Should_Succeed(in AngleDegreesMinutes angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsReflex(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegreesMinutes, bool> IsObliqueData => new TheoryData<AngleDegreesMinutes, bool> {
            {AngleDegreesMinutes.Zero, false},
            {AcuteAngle, true},
            {AngleDegreesMinutes.Right, false},
            {AngleDegreesMinutes.Right + AcuteAngle, true},
            {AngleDegreesMinutes.Straight, false},
            {AngleDegreesMinutes.Straight + AngleDegreesMinutes.Right, false},
            {AngleDegreesMinutes.Full, false},

            {-AcuteAngle, true},
            {-AngleDegreesMinutes.Right, false},
            {-AngleDegreesMinutes.Right - AcuteAngle, true},
            {-AngleDegreesMinutes.Straight, false},
            {-AngleDegreesMinutes.Straight - AngleDegreesMinutes.Right, false},
            {-AngleDegreesMinutes.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsObliqueData))]
        public void IsOblique_Should_Succeed(in AngleDegreesMinutes angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsOblique(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegreesMinutes, AngleDegreesMinutes, double, AngleDegreesMinutes> LerpData => new TheoryData<AngleDegreesMinutes, AngleDegreesMinutes, double, AngleDegreesMinutes>
        {
            {AcuteAngle, AngleDegreesMinutes.Right + AcuteAngle, -0.5, AngleDegreesMinutes.Zero},
            {AcuteAngle, AngleDegreesMinutes.Right + AcuteAngle, 0.0, AcuteAngle},
            {AcuteAngle, AngleDegreesMinutes.Right + AcuteAngle, 0.5, AngleDegreesMinutes.Right},
            {AcuteAngle, AngleDegreesMinutes.Right + AcuteAngle, 1.0, AngleDegreesMinutes.Right + AcuteAngle},
            {AcuteAngle, AngleDegreesMinutes.Right + AcuteAngle, 1.5, AngleDegreesMinutes.Straight},

            {-AcuteAngle, -AngleDegreesMinutes.Right - AcuteAngle, -0.5, AngleDegreesMinutes.Zero},
            {-AcuteAngle, -AngleDegreesMinutes.Right - AcuteAngle, 0.0, -AcuteAngle},
            {-AcuteAngle, -AngleDegreesMinutes.Right - AcuteAngle, 0.5, -AngleDegreesMinutes.Right},
            {-AcuteAngle, -AngleDegreesMinutes.Right - AcuteAngle, 1.0, -AngleDegreesMinutes.Right - AcuteAngle},
            {-AcuteAngle, -AngleDegreesMinutes.Right - AcuteAngle, 1.5, -AngleDegreesMinutes.Straight},

            {AngleDegreesMinutes.Right + AcuteAngle, AcuteAngle, -0.5, AngleDegreesMinutes.Straight},
            {AngleDegreesMinutes.Right + AcuteAngle, AcuteAngle, 0.0, AngleDegreesMinutes.Right + AcuteAngle},
            {AngleDegreesMinutes.Right + AcuteAngle, AcuteAngle, 0.5, AngleDegreesMinutes.Right},
            {AngleDegreesMinutes.Right + AcuteAngle, AcuteAngle, 1.0, AcuteAngle},
            {AngleDegreesMinutes.Right + AcuteAngle, AcuteAngle, 1.5, AngleDegreesMinutes.Zero},
        };

        [Theory]
        [MemberData(nameof(LerpData))]
        public void Lerp_Should_Succeed(in AngleDegreesMinutes a1, in AngleDegreesMinutes a2, double t, in AngleDegreesMinutes expected)
        {
            // arrange

            // act
            var result = Angle.Lerp(a1, a2, t);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegreesMinutes, string> ToStringData => new TheoryData<AngleDegreesMinutes, string>
        {
            {AngleDegreesMinutes.Straight, "180° 0'"},
        };

        [Theory]
        [MemberData(nameof(ToStringData))]
        public void ToString_Should_Succeed(in AngleDegreesMinutes angle, string expected)
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

        public static TheoryData<AngleDegreesMinutes, string, string> ToStringFormatData => new TheoryData<AngleDegreesMinutes, string, string>
        {
            {AngleDegreesMinutes.Straight, "0.00", "180° 0.00'"},
        };

        [Theory]
        [MemberData(nameof(ToStringFormatData))]
        public void ToStringFormat_Should_Succeed(in AngleDegreesMinutes angle, string format, string expected)
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

        public static TheoryData<AngleDegreesMinutes, string, CultureInfo, string> ToStringFormatCultureData => new TheoryData<AngleDegreesMinutes, string, CultureInfo, string>
        {
            {AngleDegreesMinutes.Straight, "0.00", new CultureInfo("pt-PT"), "180° 0,00'"},
        };

        [Theory]
        [MemberData(nameof(ToStringFormatCultureData))]
        public void ToStringFormatCulture_Should_Succeed(in AngleDegreesMinutes angle, string format, CultureInfo culture, string expected)
        {
            // arrange

            // act
            var result = angle.ToString(format, culture);

            // assert
            result.Should().Be(expected);
        }

    }
}
