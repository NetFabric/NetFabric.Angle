using FluentAssertions;
using System;
using System.Globalization;
using Xunit;

namespace NetFabric.UnitTests
{
    public class DegreesAngleTests
    {
        static readonly AngleDegrees AcuteAngle = AngleDegrees.Right / 2.0;

        [Fact]
        public void ObjectEquals()
        {
            AngleDegrees.Right.Equals(null).Should().BeFalse();
            AngleDegrees.Right.Equals(90.0).Should().BeFalse();
            AngleDegrees.Zero.Equals((object)AngleDegrees.Right).Should().BeFalse();
            AngleDegrees.Right.Equals((object)AngleDegrees.Right).Should().BeTrue();
        }

        [Fact]
        public void ObjectGetHashCode()
        {
            AngleDegrees.Zero.GetHashCode().Should().NotBe(AngleDegrees.Right.GetHashCode());
            AngleDegrees.Right.GetHashCode().Should().Be(AngleDegrees.Right.GetHashCode());
        }

        [Fact]
        public void EquatableEquals()
        {
            AngleDegrees.Zero.Equals(AngleDegrees.Right).Should().BeFalse();
            AngleDegrees.Right.Equals(AngleDegrees.Right).Should().BeTrue();
        }

        [Fact]
        public void OperatorEquality()
        {
            (AngleDegrees.Zero == AngleDegrees.Right).Should().BeFalse();
            (AngleDegrees.Right == AngleDegrees.Right).Should().BeTrue();
        }

        [Fact]
        public void OperatorInequality()
        {
            (AngleDegrees.Zero != AngleDegrees.Right).Should().BeTrue();
            (AngleDegrees.Right != AngleDegrees.Right).Should().BeFalse();
        }

        [Fact]
        public void ComparableCompareToObjectThrowsExcetionOnNull()
        {
            Action act = () => ((IComparable)AngleDegrees.Right).CompareTo(null);
            act.Should().Throw<ArgumentException>()
                .WithMessage("Argument has to be an DegreesAngle.\r\nParameter name: obj");
        }

        [Fact]
        public void ComparableCompareToObjectThrowsExcetionOnOtherType()
        {
            Action act = () => ((IComparable)AngleDegrees.Right).CompareTo(90.0);
            act.Should().Throw<ArgumentException>()
                .WithMessage("Argument has to be an DegreesAngle.\r\nParameter name: obj");
        }

        [Fact]
        public void ComparableCompareToObject()
        {
            ((IComparable)AngleDegrees.Right).CompareTo((object)AngleDegrees.Straight).Should().BeNegative();
            ((IComparable)AngleDegrees.Right).CompareTo((object)AngleDegrees.Right).Should().Be(0);
            ((IComparable)AngleDegrees.Right).CompareTo((object)AngleDegrees.Zero).Should().BePositive();
        }

        [Fact]
        public void ComparableCompareToAngle()
        {
            ((IComparable)AngleDegrees.Right).CompareTo(AngleDegrees.Straight).Should().BeNegative();
            ((IComparable)AngleDegrees.Right).CompareTo(AngleDegrees.Right).Should().Be(0);
            ((IComparable)AngleDegrees.Right).CompareTo(AngleDegrees.Zero).Should().BePositive();
        }

        [Fact]
        public void CompareTwoAngles()
        {
            Angle.Compare(AngleDegrees.Right, AngleDegrees.Straight).Should().BeNegative();
            Angle.Compare(AngleDegrees.Right, AngleDegrees.Right).Should().Be(0);
            Angle.Compare(AngleDegrees.Right, AngleDegrees.Zero).Should().BePositive();
            Angle.Compare(AngleDegrees.Right + AngleDegrees.Full, AngleDegrees.Straight).Should().BePositive();
            Angle.Compare(AngleDegrees.Right, AngleDegrees.Right + AngleDegrees.Full).Should().BeNegative();
            Angle.Compare(AngleDegrees.Right, AngleDegrees.Zero + AngleDegrees.Full).Should().BeNegative();
        }

        [Fact]
        public void CompareReducedTwoAngles()
        {
            Angle.CompareReduced(AngleDegrees.Right, AngleDegrees.Straight).Should().BeNegative();
            Angle.CompareReduced(AngleDegrees.Right, AngleDegrees.Right).Should().Be(0);
            Angle.CompareReduced(AngleDegrees.Right, AngleDegrees.Zero).Should().BePositive();
            Angle.CompareReduced(AngleDegrees.Right + AngleDegrees.Full, AngleDegrees.Straight).Should().BeNegative();
            Angle.CompareReduced(AngleDegrees.Right, AngleDegrees.Right + AngleDegrees.Full).Should().Be(0);
            Angle.CompareReduced(AngleDegrees.Right, AngleDegrees.Zero + AngleDegrees.Full).Should().BePositive();
        }

        [Fact]
        public void LessThanOperator()
        {
            (AngleDegrees.Zero < AngleDegrees.Right).Should().BeTrue();
            (AngleDegrees.Right < AngleDegrees.Right).Should().BeFalse();
            (Angle.FromDegrees(180) < AngleDegrees.Right).Should().BeFalse();
        }

        [Fact]
        public void LessThanOrEqualToOperator()
        {
            (AngleDegrees.Zero <= AngleDegrees.Right).Should().BeTrue();
            (AngleDegrees.Right <= AngleDegrees.Right).Should().BeTrue();
            (Angle.FromDegrees(180) <= AngleDegrees.Right).Should().BeFalse();
        }

        [Fact]
        public void GreaterThanOperator()
        {
            (AngleDegrees.Zero > AngleDegrees.Right).Should().BeFalse();
            (AngleDegrees.Right > AngleDegrees.Right).Should().BeFalse();
            (Angle.FromDegrees(180) > AngleDegrees.Right).Should().BeTrue();
        }

        public static TheoryData<AngleDegrees, AngleDegrees, bool> GreaterThanOrEqualToOperatorData =>
            new TheoryData<AngleDegrees, AngleDegrees, bool>
            {
                { AngleDegrees.Zero, AngleDegrees.Right, false },
                { AngleDegrees.Right, AngleDegrees.Right, true },
                { AngleDegrees.Straight, AngleDegrees.Right, true },
            };

        [Theory]
        [MemberData(nameof(GreaterThanOrEqualToOperatorData))]
        public void GreaterThanOrEqualToOperator(AngleDegrees left, AngleDegrees right, bool expected)
        {
            // arrange

            // act
            var result = left >= right;

            // assert
            result.Should().Be(expected);
        }

        public static TheoryData<AngleDegrees, AngleDegrees> ReduceData => new TheoryData<AngleDegrees, AngleDegrees> {
            { AngleDegrees.Zero, AngleDegrees.Zero },
            { AcuteAngle, AcuteAngle },
            { AngleDegrees.Right, AngleDegrees.Right },
            { AngleDegrees.Right + AcuteAngle, AngleDegrees.Right + AcuteAngle },
            { AngleDegrees.Straight, AngleDegrees.Straight },

            { AngleDegrees.Full, AngleDegrees.Zero },
            { AngleDegrees.Full + AcuteAngle, AcuteAngle },
            { AngleDegrees.Full + AngleDegrees.Right, AngleDegrees.Right },
            { AngleDegrees.Full + AngleDegrees.Right + AcuteAngle, AngleDegrees.Right + AcuteAngle },
            { AngleDegrees.Full + AngleDegrees.Straight, AngleDegrees.Straight },

            { -AngleDegrees.Full, AngleDegrees.Zero },
            {- AcuteAngle, AcuteAngle },
            { -AngleDegrees.Right, AngleDegrees.Right },
            { -AngleDegrees.Straight, AngleDegrees.Straight },
            { -AngleDegrees.Straight - AngleDegrees.Right, AngleDegrees.Right },
        };

        [Theory]
        [MemberData(nameof(ReduceData))]
        public void ReduceIsDefinedCorrectly(AngleDegrees angle, AngleDegrees expected)
        {
            // arrange

            // act
            var result = Angle.Reduce(angle);

            // assert
            result.Degrees.Should().BeApproximately(expected.Degrees, Math.Pow(10, -8));
        }

        [Fact]
        public void GetQuadrantIsDefinedCorrectly()
        {
            var AcuteAngle = AngleDegrees.Right / 2.0;

            Angle.GetQuadrant(AngleDegrees.Zero).Should().Be(Quadrant.First);
            Angle.GetQuadrant(AcuteAngle).Should().Be(Quadrant.First);
            Angle.GetQuadrant(AngleDegrees.Right).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(AngleDegrees.Right + AcuteAngle).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(AngleDegrees.Straight).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(AngleDegrees.Straight + AcuteAngle).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(AngleDegrees.Straight + AngleDegrees.Right).Should().Be(Quadrant.Fourth);
            Angle.GetQuadrant(AngleDegrees.Straight + AngleDegrees.Right + AcuteAngle).Should().Be(Quadrant.Fourth);

            Angle.GetQuadrant(AngleDegrees.Full).Should().Be(Quadrant.First);
            Angle.GetQuadrant(AngleDegrees.Full + AcuteAngle).Should().Be(Quadrant.First);
            Angle.GetQuadrant(AngleDegrees.Full + AngleDegrees.Right).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(AngleDegrees.Full + AngleDegrees.Right + AcuteAngle).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(AngleDegrees.Full + AngleDegrees.Straight).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(AngleDegrees.Full + AngleDegrees.Straight + AcuteAngle).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(AngleDegrees.Full + AngleDegrees.Straight + AngleDegrees.Right).Should().Be(Quadrant.Fourth);
            Angle.GetQuadrant(AngleDegrees.Full + AngleDegrees.Straight + AngleDegrees.Right + AcuteAngle).Should().Be(Quadrant.Fourth);
        }

        [Fact]
        public void ReferenceIsDefinedCorrectly()
        {
            Angle.GetReference(AngleDegrees.Zero).Should().Be(AngleDegrees.Zero);
            Angle.GetReference(AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(AngleDegrees.Right).Should().Be(AngleDegrees.Right);
            Angle.GetReference(AngleDegrees.Right + AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(AngleDegrees.Straight).Should().Be(AngleDegrees.Zero);
            Angle.GetReference(AngleDegrees.Straight + AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(AngleDegrees.Straight + AngleDegrees.Right).Should().Be(AngleDegrees.Right);
            Angle.GetReference(AngleDegrees.Straight + AngleDegrees.Right + AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(AngleDegrees.Full).Should().Be(AngleDegrees.Zero);
        }

        [Fact]
        public void IsZeroIsDefinedCorrectly()
        {
            Angle.IsZero(AngleDegrees.Zero).Should().BeTrue();
            Angle.IsZero(AcuteAngle).Should().BeFalse();
            Angle.IsZero(AngleDegrees.Right).Should().BeFalse();
            Angle.IsZero(AngleDegrees.Right + AcuteAngle).Should().BeFalse();
            Angle.IsZero(AngleDegrees.Straight).Should().BeFalse();
            Angle.IsZero(AngleDegrees.Straight + AngleDegrees.Right).Should().BeFalse();
            Angle.IsZero(AngleDegrees.Full).Should().BeTrue();

            Angle.IsZero(-AcuteAngle).Should().BeFalse();
            Angle.IsZero(-AngleDegrees.Right).Should().BeFalse();
            Angle.IsZero(-AngleDegrees.Right - AcuteAngle).Should().BeFalse();
            Angle.IsZero(-AngleDegrees.Straight).Should().BeFalse();
            Angle.IsZero(-AngleDegrees.Straight - AngleDegrees.Right).Should().BeFalse();
            Angle.IsZero(-AngleDegrees.Full).Should().BeTrue();
        }

        [Fact]
        public void IsAcuteIsDefinedCorrectly()
        {
            Angle.IsAcute(AngleDegrees.Zero).Should().BeFalse();
            Angle.IsAcute(AcuteAngle).Should().BeTrue();
            Angle.IsAcute(AngleDegrees.Right).Should().BeFalse();
            Angle.IsAcute(AngleDegrees.Right + AcuteAngle).Should().BeFalse();
            Angle.IsAcute(AngleDegrees.Straight).Should().BeFalse();
            Angle.IsAcute(AngleDegrees.Straight + AngleDegrees.Right).Should().BeFalse();
            Angle.IsAcute(AngleDegrees.Full).Should().BeFalse();

            Angle.IsAcute(-AcuteAngle).Should().BeTrue();
            Angle.IsAcute(-AngleDegrees.Right).Should().BeFalse();
            Angle.IsAcute(-AngleDegrees.Right - AcuteAngle).Should().BeFalse();
            Angle.IsAcute(-AngleDegrees.Straight).Should().BeFalse();
            Angle.IsAcute(-AngleDegrees.Straight - AngleDegrees.Right).Should().BeFalse();
            Angle.IsAcute(-AngleDegrees.Full).Should().BeFalse();
        }

        [Fact]
        public void IsRightIsDefinedCorrectly()
        {
            Angle.IsRight(AngleDegrees.Zero).Should().BeFalse();
            Angle.IsRight(AcuteAngle).Should().BeFalse();
            Angle.IsRight(AngleDegrees.Right).Should().BeTrue();
            Angle.IsRight(AngleDegrees.Right + AcuteAngle).Should().BeFalse();
            Angle.IsRight(AngleDegrees.Straight).Should().BeFalse();
            Angle.IsRight(AngleDegrees.Straight + AngleDegrees.Right).Should().BeFalse();
            Angle.IsRight(AngleDegrees.Full).Should().BeFalse();

            Angle.IsRight(-AcuteAngle).Should().BeFalse();
            Angle.IsRight(-AngleDegrees.Right).Should().BeTrue();
            Angle.IsRight(-AngleDegrees.Right - AcuteAngle).Should().BeFalse();
            Angle.IsRight(-AngleDegrees.Straight).Should().BeFalse();
            Angle.IsRight(-AngleDegrees.Straight - AngleDegrees.Right).Should().BeFalse();
            Angle.IsRight(-AngleDegrees.Full).Should().BeFalse();
        }

        [Fact]
        public void IsObtuseIsDefinedCorrectly()
        {
            Angle.IsObtuse(AngleDegrees.Zero).Should().BeFalse();
            Angle.IsObtuse(AcuteAngle).Should().BeFalse();
            Angle.IsObtuse(AngleDegrees.Right).Should().BeFalse();
            Angle.IsObtuse(AngleDegrees.Right + AcuteAngle).Should().BeTrue();
            Angle.IsObtuse(AngleDegrees.Straight).Should().BeFalse();
            Angle.IsObtuse(AngleDegrees.Straight + AngleDegrees.Right).Should().BeFalse();
            Angle.IsObtuse(AngleDegrees.Full).Should().BeFalse();

            Angle.IsObtuse(-AcuteAngle).Should().BeFalse();
            Angle.IsObtuse(-AngleDegrees.Right).Should().BeFalse();
            Angle.IsObtuse(-AngleDegrees.Right - AcuteAngle).Should().BeTrue();
            Angle.IsObtuse(-AngleDegrees.Straight).Should().BeFalse();
            Angle.IsObtuse(-AngleDegrees.Straight - AngleDegrees.Right).Should().BeFalse();
            Angle.IsObtuse(-AngleDegrees.Full).Should().BeFalse();
        }

        [Fact]
        public void IsStraightIsDefinedCorrectly()
        {
            Angle.IsStraight(AngleDegrees.Zero).Should().BeFalse();
            Angle.IsStraight(AcuteAngle).Should().BeFalse();
            Angle.IsStraight(AngleDegrees.Right).Should().BeFalse();
            Angle.IsStraight(AngleDegrees.Right - AcuteAngle).Should().BeFalse();
            Angle.IsStraight(AngleDegrees.Straight).Should().BeTrue();
            Angle.IsStraight(AngleDegrees.Straight - AngleDegrees.Right).Should().BeFalse();
            Angle.IsStraight(AngleDegrees.Full).Should().BeFalse();

            Angle.IsStraight(-AcuteAngle).Should().BeFalse();
            Angle.IsStraight(-AngleDegrees.Right).Should().BeFalse();
            Angle.IsStraight(-AngleDegrees.Right - AcuteAngle).Should().BeFalse();
            Angle.IsStraight(-AngleDegrees.Straight).Should().BeTrue();
            Angle.IsStraight(-AngleDegrees.Straight - AngleDegrees.Right).Should().BeFalse();
            Angle.IsStraight(-AngleDegrees.Full).Should().BeFalse();
        }

        [Fact]
        public void IsReflexIsDefinedCorrectly()
        {
            Angle.IsReflex(AngleDegrees.Zero).Should().BeFalse();
            Angle.IsReflex(AcuteAngle).Should().BeFalse();
            Angle.IsReflex(AngleDegrees.Right).Should().BeFalse();
            Angle.IsReflex(AngleDegrees.Right + AcuteAngle).Should().BeFalse();
            Angle.IsReflex(AngleDegrees.Straight).Should().BeFalse();
            Angle.IsReflex(AngleDegrees.Straight + AngleDegrees.Right).Should().BeTrue();
            Angle.IsReflex(AngleDegrees.Full).Should().BeFalse();

            Angle.IsReflex(-AcuteAngle).Should().BeFalse();
            Angle.IsReflex(-AngleDegrees.Right).Should().BeFalse();
            Angle.IsReflex(-AngleDegrees.Right - AcuteAngle).Should().BeFalse();
            Angle.IsReflex(-AngleDegrees.Straight).Should().BeFalse();
            Angle.IsReflex(-AngleDegrees.Straight - AngleDegrees.Right).Should().BeTrue();
            Angle.IsReflex(-AngleDegrees.Full).Should().BeFalse();
        }

        [Fact]
        public void IsObliqueIsDefinedCorrectly()
        {
            Angle.IsOblique(AngleDegrees.Zero).Should().BeFalse();
            Angle.IsOblique(AcuteAngle).Should().BeTrue();
            Angle.IsOblique(AngleDegrees.Right).Should().BeFalse();
            Angle.IsOblique(AngleDegrees.Right + AcuteAngle).Should().BeTrue();
            Angle.IsOblique(AngleDegrees.Straight).Should().BeFalse();
            Angle.IsOblique(AngleDegrees.Straight + AngleDegrees.Right).Should().BeFalse();
            Angle.IsOblique(AngleDegrees.Full).Should().BeFalse();

            Angle.IsOblique(-AcuteAngle).Should().BeTrue();
            Angle.IsOblique(-AngleDegrees.Right).Should().BeFalse();
            Angle.IsOblique(-AngleDegrees.Right - AcuteAngle).Should().BeTrue();
            Angle.IsOblique(-AngleDegrees.Straight).Should().BeFalse();
            Angle.IsOblique(-AngleDegrees.Straight - AngleDegrees.Right).Should().BeFalse();
            Angle.IsOblique(-AngleDegrees.Full).Should().BeFalse();
        }

        [Fact]
        public void LerpIsDefinedCorrectly()
        {
            Angle.Lerp(AcuteAngle, AngleDegrees.Right + AcuteAngle, -0.5).Should().Be(AngleDegrees.Zero);
            Angle.Lerp(AcuteAngle, AngleDegrees.Right + AcuteAngle, 0.0).Should().Be(AcuteAngle);
            Angle.Lerp(AcuteAngle, AngleDegrees.Right + AcuteAngle, 0.5).Should().Be(AngleDegrees.Right);
            Angle.Lerp(AcuteAngle, AngleDegrees.Right + AcuteAngle, 1.0).Should().Be(AngleDegrees.Right + AcuteAngle);
            Angle.Lerp(AcuteAngle, AngleDegrees.Right + AcuteAngle, 1.5).Should().Be(AngleDegrees.Straight);

            Angle.Lerp(-AcuteAngle, -AngleDegrees.Right - AcuteAngle, -0.5).Should().Be(AngleDegrees.Zero);
            Angle.Lerp(-AcuteAngle, -AngleDegrees.Right - AcuteAngle, 0.0).Should().Be(-AcuteAngle);
            Angle.Lerp(-AcuteAngle, -AngleDegrees.Right - AcuteAngle, 0.5).Should().Be(-AngleDegrees.Right);
            Angle.Lerp(-AcuteAngle, -AngleDegrees.Right - AcuteAngle, 1.0).Should().Be(-AngleDegrees.Right - AcuteAngle);
            Angle.Lerp(-AcuteAngle, -AngleDegrees.Right - AcuteAngle, 1.5).Should().Be(-AngleDegrees.Straight);

            Angle.Lerp(AngleDegrees.Right + AcuteAngle, AcuteAngle, -0.5).Should().Be(AngleDegrees.Straight);
            Angle.Lerp(AngleDegrees.Right + AcuteAngle, AcuteAngle, 0.0).Should().Be(AngleDegrees.Right + AcuteAngle);
            Angle.Lerp(AngleDegrees.Right + AcuteAngle, AcuteAngle, 0.5).Should().Be(AngleDegrees.Right);
            Angle.Lerp(AngleDegrees.Right + AcuteAngle, AcuteAngle, 1.0).Should().Be(AcuteAngle);
            Angle.Lerp(AngleDegrees.Right + AcuteAngle, AcuteAngle, 1.5).Should().Be(AngleDegrees.Zero);
        }

        [Fact]
        public void ToStringIsDefinedCorrectly()
        {
#if NET35
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
#else
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
#endif

            AngleDegrees.Straight.ToString().Should().Be("180");
            AngleDegrees.Straight.ToString("0.00").Should().Be("180.00");
            AngleDegrees.Straight.ToString("0.00", new CultureInfo("pt-PT")).Should().Be("180,00");
        }
    }
}
