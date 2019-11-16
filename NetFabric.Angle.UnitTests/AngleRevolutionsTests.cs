using FluentAssertions;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Xunit;

namespace NetFabric.UnitTests
{
    public class AngleRevolutionsTests
    {
        static readonly AngleRevolutions AcuteAngle = AngleRevolutions.Right / 2.0;

        public static TheoryData<AngleRevolutions> SerializableData = new TheoryData<AngleRevolutions>
        {
            -AngleRevolutions.Full,
            -AngleRevolutions.Straight,
            -AngleRevolutions.Right,
            AngleRevolutions.Zero,
            AngleRevolutions.Right,
            AngleRevolutions.Straight,
            AngleRevolutions.Full,
        };

        [Theory]
        [MemberData(nameof(SerializableData))]
        public void Serializable_Should_Succeed(AngleRevolutions angle)
        {
            // arrange
            var formatter = new BinaryFormatter();
            var stream = new MemoryStream();

            // act
            formatter.Serialize(stream, angle);
            stream.Seek(0, SeekOrigin.Begin);
            var result = (AngleRevolutions)formatter.Deserialize(stream);

            // assert
            result.Should().Be(angle);
        }

        public static TheoryData<AngleRevolutions, object, bool, bool, bool> CompareInvalidData => new TheoryData<AngleRevolutions, object, bool, bool, bool>
        {
            { AngleRevolutions.Right, null, false, false, false },
            { AngleRevolutions.Right, 90.0, false, false, false },
        };

        public static TheoryData<AngleRevolutions, AngleRevolutions, bool, bool, bool> CompareData => new TheoryData<AngleRevolutions, AngleRevolutions, bool, bool, bool>
        {
            { AngleRevolutions.Zero, AngleRevolutions.Right - AngleRevolutions.Full, false, false, true },
            { AngleRevolutions.Right, AngleRevolutions.Right - AngleRevolutions.Full, false, false, true },
            { AngleRevolutions.Straight, AngleRevolutions.Right - AngleRevolutions.Full, false, false, true },

            { AngleRevolutions.Zero, AngleRevolutions.Right, true, false, false },
            { AngleRevolutions.Right, AngleRevolutions.Right, false, true, false },
            { AngleRevolutions.Straight, AngleRevolutions.Right, false, false, true },

            { AngleRevolutions.Zero, AngleRevolutions.Right + AngleRevolutions.Full, true, false, false },
            { AngleRevolutions.Right, AngleRevolutions.Right + AngleRevolutions.Full, true, false, false },
            { AngleRevolutions.Straight, AngleRevolutions.Right + AngleRevolutions.Full, true, false, false },
        };

        public static TheoryData<AngleRevolutions, AngleRevolutions, bool, bool, bool> CompareReducedData => new TheoryData<AngleRevolutions, AngleRevolutions, bool, bool, bool>
        {
            { AngleRevolutions.Zero, AngleRevolutions.Right - AngleRevolutions.Full, true, false, false },
            { AngleRevolutions.Right, AngleRevolutions.Right - AngleRevolutions.Full, false, true, false },
            { AngleRevolutions.Straight, AngleRevolutions.Right - AngleRevolutions.Full, false, false, true },

            { AngleRevolutions.Zero, AngleRevolutions.Right, true, false, false },
            { AngleRevolutions.Right, AngleRevolutions.Right, false, true, false },
            { AngleRevolutions.Straight, AngleRevolutions.Right, false, false, true },

            { AngleRevolutions.Zero, AngleRevolutions.Right + AngleRevolutions.Full, true, false, false },
            { AngleRevolutions.Right, AngleRevolutions.Right + AngleRevolutions.Full, false, true, false },
            { AngleRevolutions.Straight, AngleRevolutions.Right + AngleRevolutions.Full, false, false, true },
        };

        [Theory]
        [MemberData(nameof(CompareInvalidData))]
        [MemberData(nameof(CompareData))]
        [SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters")]
        public void EqualsObject_Should_Succeed(AngleRevolutions left, object right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left.Equals(right);

            // assert
            result.Should().Be(equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        [SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters")]
        public void Equals_Should_Succeed(AngleRevolutions left, AngleRevolutions right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left.Equals(right);

            // assert
            result.Should().Be(equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        [SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters")]
        public void GetHashCode_Should_Succeed(AngleRevolutions left, AngleRevolutions right, bool lessThan, bool equal, bool greaterThan)
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
        [SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters")]
        public void OperatorEquality_Should_Succeed(AngleRevolutions left, AngleRevolutions right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left == right;

            // assert
            result.Should().Be(equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        [SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters")]
        public void OperatorInequality_Should_Succeed(AngleRevolutions left, AngleRevolutions right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left != right;

            // assert
            result.Should().Be(!equal);
        }

        [Theory]
        [MemberData(nameof(CompareInvalidData))]
        [SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters")]
        public void CompareTo_When_InvalidData_Should_Thrown(AngleRevolutions angle, object obj, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            Action act = () => ((IComparable)angle).CompareTo(obj);

            // assert
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage($"Argument has to be an {nameof(AngleRevolutions)}.*");
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        [SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters")]
        public void CompareTo_Should_Succeed(AngleRevolutions left, AngleRevolutions right, bool lessThan, bool equal, bool greaterThan)
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
        [SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters")]
        public void Compare_Should_Succeed(AngleRevolutions left, AngleRevolutions right, bool lessThan, bool equal, bool greaterThan)
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
        [SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters")]
        public void CompareReduced_Should_Succeed(AngleRevolutions left, AngleRevolutions right, bool lessThan, bool equal, bool greaterThan)
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
        [SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters")]
        public void LessThan_Should_Succeed(AngleRevolutions left, AngleRevolutions right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left < right;

            // assert
            result.Should().Be(lessThan);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        [SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters")]
        public void LessThanOrEqual_Should_Succeed(AngleRevolutions left, AngleRevolutions right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left <= right;

            // assert
            result.Should().Be(lessThan || equal);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        [SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters")]
        public void GreaterThan_Should_Succeed(AngleRevolutions left, AngleRevolutions right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left > right;

            // assert
            result.Should().Be(greaterThan);
        }

        [Theory]
        [MemberData(nameof(CompareData))]
        [SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters")]
        public void GreaterThanOrEqual_Should_Succeed(AngleRevolutions left, AngleRevolutions right, bool lessThan, bool equal, bool greaterThan)
        {
            // arrange

            // act
            var result = left >= right;

            // assert
            result.Should().Be(greaterThan || equal);
        }

        public static TheoryData<AngleRevolutions, AngleRevolutions> ReduceData => new TheoryData<AngleRevolutions, AngleRevolutions> {
            { AngleRevolutions.Zero, AngleRevolutions.Zero },
            { AcuteAngle, AcuteAngle },
            { AngleRevolutions.Right, AngleRevolutions.Right },
            { AngleRevolutions.Right + AcuteAngle, AngleRevolutions.Right + AcuteAngle },
            { AngleRevolutions.Straight, AngleRevolutions.Straight },

            { AngleRevolutions.Full, AngleRevolutions.Zero },
            { AngleRevolutions.Full + AcuteAngle, AcuteAngle },
            { AngleRevolutions.Full + AngleRevolutions.Right, AngleRevolutions.Right },
            { AngleRevolutions.Full + AngleRevolutions.Right + AcuteAngle, AngleRevolutions.Right + AcuteAngle },
            { AngleRevolutions.Full + AngleRevolutions.Straight, AngleRevolutions.Straight },

            { -AngleRevolutions.Full, AngleRevolutions.Zero },
            { -AcuteAngle, AngleRevolutions.Full - AcuteAngle },
            { -AngleRevolutions.Right, AngleRevolutions.Full - AngleRevolutions.Right },
            { -AngleRevolutions.Straight, AngleRevolutions.Straight },
            { -AngleRevolutions.Straight - AngleRevolutions.Right, AngleRevolutions.Right },
        };

        [Theory]
        [MemberData(nameof(ReduceData))]
        public void Reduce_Should_Succeed(AngleRevolutions angle, AngleRevolutions expected)
        {
            // arrange

            // act
            var result = Angle.Reduce(angle);

            // assert
            result.Revolutions.Should().BeApproximately(expected.Revolutions, Math.Pow(10, 8));
        }

        public static TheoryData<AngleRevolutions, Quadrant> QuadrantData => new TheoryData<AngleRevolutions, Quadrant> {
            {AngleRevolutions.Zero, Quadrant.First},
            {AcuteAngle, Quadrant.First},
            {AngleRevolutions.Right, Quadrant.Second},
            {AngleRevolutions.Right + AcuteAngle, Quadrant.Second},
            {AngleRevolutions.Straight, Quadrant.Third},
            {AngleRevolutions.Straight + AcuteAngle, Quadrant.Third},
            {AngleRevolutions.Straight + AngleRevolutions.Right, Quadrant.Fourth},
            {AngleRevolutions.Straight + AngleRevolutions.Right + AcuteAngle, Quadrant.Fourth},

            {AngleRevolutions.Full, Quadrant.First},
            {AngleRevolutions.Full + AcuteAngle, Quadrant.First},
            {AngleRevolutions.Full + AngleRevolutions.Right, Quadrant.Second},
            {AngleRevolutions.Full + AngleRevolutions.Right + AcuteAngle, Quadrant.Second},
            {AngleRevolutions.Full + AngleRevolutions.Straight, Quadrant.Third},
            {AngleRevolutions.Full + AngleRevolutions.Straight + AcuteAngle, Quadrant.Third},
            {AngleRevolutions.Full + AngleRevolutions.Straight + AngleRevolutions.Right, Quadrant.Fourth},
            {AngleRevolutions.Full + AngleRevolutions.Straight + AngleRevolutions.Right + AcuteAngle, Quadrant.Fourth},
        };

        [Theory]
        [MemberData(nameof(QuadrantData))]
        public void GetQuadrant_Should_Succeed(AngleRevolutions angle, Quadrant expected)
        {
            // arrange

            // act
            var result = Angle.GetQuadrant(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRevolutions, AngleRevolutions> ReferencetData => new TheoryData<AngleRevolutions, AngleRevolutions> {
            {AngleRevolutions.Zero, AngleRevolutions.Zero},
            {AcuteAngle, AcuteAngle},
            {AngleRevolutions.Right ,AngleRevolutions.Right},
            {AngleRevolutions.Right + AcuteAngle, AcuteAngle},
            {AngleRevolutions.Straight, AngleRevolutions.Zero},
            {AngleRevolutions.Straight + AcuteAngle, AcuteAngle},
            {AngleRevolutions.Straight + AngleRevolutions.Right, AngleRevolutions.Right},
            {AngleRevolutions.Straight + AngleRevolutions.Right + AcuteAngle, AcuteAngle},
            {AngleRevolutions.Full, AngleRevolutions.Zero},
        };

        [Theory]
        [MemberData(nameof(ReferencetData))]
        public void Reference_Should_Succeed(AngleRevolutions angle, AngleRevolutions expected)
        {
            // arrange

            // act
            var result = Angle.GetReference(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRevolutions, bool> IsZeroData => new TheoryData<AngleRevolutions, bool> {
            {AngleRevolutions.Zero, true},
            {AcuteAngle, false},
            {AngleRevolutions.Right, false},
            {AngleRevolutions.Right + AcuteAngle, false},
            {AngleRevolutions.Straight, false},
            {AngleRevolutions.Straight + AngleRevolutions.Right, false},
            {AngleRevolutions.Full, true},

            {-AcuteAngle, false},
            {-AngleRevolutions.Right, false},
            {-AngleRevolutions.Right - AcuteAngle, false},
            {-AngleRevolutions.Straight, false},
            {-AngleRevolutions.Straight - AngleRevolutions.Right, false},
            {-AngleRevolutions.Full, true},
        };

        [Theory]
        [MemberData(nameof(IsZeroData))]
        public void IsZero_Should_Succeed(AngleRevolutions angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsZero(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRevolutions, bool> IsAcuteData => new TheoryData<AngleRevolutions, bool> {
            {AngleRevolutions.Zero, false},
            {AcuteAngle, true},
            {AngleRevolutions.Right, false},
            {AngleRevolutions.Right + AcuteAngle, false},
            {AngleRevolutions.Straight, false},
            {AngleRevolutions.Straight + AngleRevolutions.Right, false},
            {AngleRevolutions.Full, false},

            {-AcuteAngle, true},
            {-AngleRevolutions.Right, false},
            {-AngleRevolutions.Right - AcuteAngle, false},
            {-AngleRevolutions.Straight, false},
            {-AngleRevolutions.Straight - AngleRevolutions.Right, false},
            {-AngleRevolutions.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsAcuteData))]
        public void IsAcute_Should_Succeed(AngleRevolutions angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsAcute(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRevolutions, bool> IsRightData => new TheoryData<AngleRevolutions, bool> {
            {AngleRevolutions.Zero, false},
            {AcuteAngle, false},
            {AngleRevolutions.Right, true},
            {AngleRevolutions.Right + AcuteAngle, false},
            {AngleRevolutions.Straight, false},
            {AngleRevolutions.Straight + AngleRevolutions.Right, false},
            {AngleRevolutions.Full, false},

            {-AcuteAngle, false},
            {-AngleRevolutions.Right, true},
            {-AngleRevolutions.Right - AcuteAngle, false},
            {-AngleRevolutions.Straight, false},
            {-AngleRevolutions.Straight - AngleRevolutions.Right, false},
            {-AngleRevolutions.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsRightData))]
        public void IsRight_Should_Succeed(AngleRevolutions angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsRight(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRevolutions, bool> IsObtuseData => new TheoryData<AngleRevolutions, bool> {
            {AngleRevolutions.Zero, false},
            {AcuteAngle, false},
            {AngleRevolutions.Right, false},
            {AngleRevolutions.Right + AcuteAngle, true},
            {AngleRevolutions.Straight, false},
            {AngleRevolutions.Straight + AngleRevolutions.Right, false},
            {AngleRevolutions.Full, false},

            {-AcuteAngle, false},
            {-AngleRevolutions.Right, false},
            {-AngleRevolutions.Right - AcuteAngle, true},
            {-AngleRevolutions.Straight, false},
            {-AngleRevolutions.Straight - AngleRevolutions.Right, false},
            {-AngleRevolutions.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsObtuseData))]
        public void IsObtuse_Should_Succeed(AngleRevolutions angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsObtuse(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRevolutions, bool> IsStraightData => new TheoryData<AngleRevolutions, bool> {
            {AngleRevolutions.Zero, false},
            {AcuteAngle, false},
            {AngleRevolutions.Right, false},
            {AngleRevolutions.Right - AcuteAngle, false},
            {AngleRevolutions.Straight, true},
            {AngleRevolutions.Straight - AngleRevolutions.Right, false},
            {AngleRevolutions.Full, false},

            {-AcuteAngle, false},
            {-AngleRevolutions.Right, false},
            {-AngleRevolutions.Right - AcuteAngle, false},
            {-AngleRevolutions.Straight, true},
            {-AngleRevolutions.Straight - AngleRevolutions.Right, false},
            {-AngleRevolutions.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsStraightData))]
        public void IsStraight_Should_Succeed(AngleRevolutions angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsStraight(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRevolutions, bool> IsReflexData => new TheoryData<AngleRevolutions, bool> {
            {AngleRevolutions.Zero, false},
            {AcuteAngle, false},
            {AngleRevolutions.Right, false},
            {AngleRevolutions.Right + AcuteAngle, false},
            {AngleRevolutions.Straight, false},
            {AngleRevolutions.Straight + AngleRevolutions.Right, true},
            {AngleRevolutions.Full, false},

            {-AcuteAngle, false},
            {-AngleRevolutions.Right, false},
            {-AngleRevolutions.Right - AcuteAngle, false},
            {-AngleRevolutions.Straight, false},
            {-AngleRevolutions.Straight - AngleRevolutions.Right, true},
            {-AngleRevolutions.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsReflexData))]
        public void IsReflex_Should_Succeed(AngleRevolutions angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsReflex(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRevolutions, bool> IsObliqueData => new TheoryData<AngleRevolutions, bool> {
            {AngleRevolutions.Zero, false},
            {AcuteAngle, true},
            {AngleRevolutions.Right, false},
            {AngleRevolutions.Right + AcuteAngle, true},
            {AngleRevolutions.Straight, false},
            {AngleRevolutions.Straight + AngleRevolutions.Right, false},
            {AngleRevolutions.Full, false},

            {-AcuteAngle, true},
            {-AngleRevolutions.Right, false},
            {-AngleRevolutions.Right - AcuteAngle, true},
            {-AngleRevolutions.Straight, false},
            {-AngleRevolutions.Straight - AngleRevolutions.Right, false},
            {-AngleRevolutions.Full, false},
        };

        [Theory]
        [MemberData(nameof(IsObliqueData))]
        public void IsOblique_Should_Succeed(AngleRevolutions angle, bool expected)
        {
            // arrange

            // act
            var result = Angle.IsOblique(angle);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRevolutions, AngleRevolutions, double, AngleRevolutions> LerpData => new TheoryData<AngleRevolutions, AngleRevolutions, double, AngleRevolutions>
        {
            {AcuteAngle, AngleRevolutions.Right + AcuteAngle, -0.5, AngleRevolutions.Zero},
            {AcuteAngle, AngleRevolutions.Right + AcuteAngle, 0.0, AcuteAngle},
            {AcuteAngle, AngleRevolutions.Right + AcuteAngle, 0.5, AngleRevolutions.Right},
            {AcuteAngle, AngleRevolutions.Right + AcuteAngle, 1.0, AngleRevolutions.Right + AcuteAngle},
            {AcuteAngle, AngleRevolutions.Right + AcuteAngle, 1.5, AngleRevolutions.Straight},

            {-AcuteAngle, -AngleRevolutions.Right - AcuteAngle, -0.5, AngleRevolutions.Zero},
            {-AcuteAngle, -AngleRevolutions.Right - AcuteAngle, 0.0, -AcuteAngle},
            {-AcuteAngle, -AngleRevolutions.Right - AcuteAngle, 0.5, -AngleRevolutions.Right},
            {-AcuteAngle, -AngleRevolutions.Right - AcuteAngle, 1.0, -AngleRevolutions.Right - AcuteAngle},
            {-AcuteAngle, -AngleRevolutions.Right - AcuteAngle, 1.5, -AngleRevolutions.Straight},

            {AngleRevolutions.Right + AcuteAngle, AcuteAngle, -0.5, AngleRevolutions.Straight},
            {AngleRevolutions.Right + AcuteAngle, AcuteAngle, 0.0, AngleRevolutions.Right + AcuteAngle},
            {AngleRevolutions.Right + AcuteAngle, AcuteAngle, 0.5, AngleRevolutions.Right},
            {AngleRevolutions.Right + AcuteAngle, AcuteAngle, 1.0, AcuteAngle},
            {AngleRevolutions.Right + AcuteAngle, AcuteAngle, 1.5, AngleRevolutions.Zero},
        };

        [Theory]
        [MemberData(nameof(LerpData))]
        public void Lerp_Should_Succeed(AngleRevolutions a1, AngleRevolutions a2, double t, AngleRevolutions expected)
        {
            // arrange

            // act
            var result = Angle.Lerp(a1, a2, t);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRevolutions, string> ToStringData => new TheoryData<AngleRevolutions, string>
        {
            {AngleRevolutions.Straight, "0.5"},
        };

        [Theory]
        [MemberData(nameof(ToStringData))]
        public void ToString_Should_Succeed(AngleRevolutions angle, string expected)
        {
            // arrange
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

            // act
            var result = angle.ToString();

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRevolutions, string, string> ToStringFormatData => new TheoryData<AngleRevolutions, string, string>
        {
            {AngleRevolutions.Straight, "0.00", "0.50"},
        };

        [Theory]
        [MemberData(nameof(ToStringFormatData))]
        public void ToStringFormat_Should_Succeed(AngleRevolutions angle, string format, string expected)
        {
            // arrange
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

            // act
            var result = angle.ToString(format);

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleRevolutions, string, CultureInfo, string> ToStringFormatCultureData => new TheoryData<AngleRevolutions, string, CultureInfo, string>
        {
            {AngleRevolutions.Straight, "0.00", new CultureInfo("pt-PT"), "0,50"},
        };

        [Theory]
        [MemberData(nameof(ToStringFormatCultureData))]
        public void ToStringFormatCulture_Should_Succeed(AngleRevolutions angle, string format, CultureInfo culture, string expected)
        {
            // arrange

            // act
            var result = angle.ToString(format, culture);

            // assert
            result.Should().Be(expected);
        }

    }
}
