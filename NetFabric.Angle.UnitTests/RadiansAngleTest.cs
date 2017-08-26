using FluentAssertions;
using System;
using System.Globalization;
using Xunit;

namespace NetFabric.UnitTests
{
    public class RadiansAngleTests
    {
        readonly RadiansAngle AcuteAngle = RadiansAngle.Right / 2.0;

        [Fact]
        public void ObjectEquals()
        {
            RadiansAngle.Right.Equals(null).Should().BeFalse();
            RadiansAngle.Right.Equals(90.0).Should().BeFalse();
            RadiansAngle.Zero.Equals((object)RadiansAngle.Right).Should().BeFalse();
            RadiansAngle.Right.Equals((object)RadiansAngle.Right).Should().BeTrue();
        }

        [Fact]
        public void ObjectGetHashCode()
        {
            RadiansAngle.Zero.GetHashCode().Should().NotBe(RadiansAngle.Right.GetHashCode());
            RadiansAngle.Right.GetHashCode().Should().Be(RadiansAngle.Right.GetHashCode());
        }

        [Fact]
        public void EquatableEquals()
        {
            RadiansAngle.Zero.Equals(RadiansAngle.Right).Should().BeFalse();
            RadiansAngle.Right.Equals(RadiansAngle.Right).Should().BeTrue();
        }

        [Fact]
        public void OperatorEquality()
        {
            (RadiansAngle.Zero == RadiansAngle.Right).Should().BeFalse();
            (RadiansAngle.Right == RadiansAngle.Right).Should().BeTrue();
        }

        [Fact]
        public void OperatorInequality()
        {
            (RadiansAngle.Zero != RadiansAngle.Right).Should().BeTrue();
            (RadiansAngle.Right != RadiansAngle.Right).Should().BeFalse();
        }

        [Fact]
        public void ComparableCompareToObjectThrowsExcetionOnNull()
        {
            Action act = () => ((IComparable)RadiansAngle.Right).CompareTo(null);
            act.ShouldThrow<ArgumentException>()
                .WithMessage("Argument has to be an RadiansAngle.\r\nParameter name: obj");
        }

        [Fact]
        public void ComparableCompareToObjectThrowsExcetionOnOtherType()
        {
            Action act = () => ((IComparable)RadiansAngle.Right).CompareTo(90.0);
            act.ShouldThrow<ArgumentException>()
                .WithMessage("Argument has to be an RadiansAngle.\r\nParameter name: obj");
        }

        [Fact]
        public void ComparableCompareToObject()
        {
            ((IComparable)RadiansAngle.Right).CompareTo((object)RadiansAngle.Straight).Should().BeNegative();
            ((IComparable)RadiansAngle.Right).CompareTo((object)RadiansAngle.Right).Should().Be(0);
            ((IComparable)RadiansAngle.Right).CompareTo((object)RadiansAngle.Zero).Should().BePositive();
        }

        [Fact]
        public void ComparableCompareToAngle()
        {
            ((IComparable)RadiansAngle.Right).CompareTo(RadiansAngle.Straight).Should().BeNegative();
            ((IComparable)RadiansAngle.Right).CompareTo(RadiansAngle.Right).Should().Be(0);
            ((IComparable)RadiansAngle.Right).CompareTo(RadiansAngle.Zero).Should().BePositive();
        }

        [Fact]
        public void CompareTwoAngles()
        {
            Angle.Compare(RadiansAngle.Right, RadiansAngle.Straight).Should().BeNegative();
            Angle.Compare(RadiansAngle.Right, RadiansAngle.Right).Should().Be(0);
            Angle.Compare(RadiansAngle.Right, RadiansAngle.Zero).Should().BePositive();
            Angle.Compare(RadiansAngle.Right + RadiansAngle.Full, RadiansAngle.Straight).Should().BePositive();
            Angle.Compare(RadiansAngle.Right, RadiansAngle.Right + RadiansAngle.Full).Should().BeNegative();
            Angle.Compare(RadiansAngle.Right, RadiansAngle.Zero + RadiansAngle.Full).Should().BeNegative();
        }

        [Fact]
        public void CompareReducedTwoAngles()
        {
            Angle.CompareReduced(RadiansAngle.Right, RadiansAngle.Straight).Should().BeNegative();
            Angle.CompareReduced(RadiansAngle.Right, RadiansAngle.Right).Should().Be(0);
            Angle.CompareReduced(RadiansAngle.Right, RadiansAngle.Zero).Should().BePositive();
            Angle.CompareReduced(RadiansAngle.Right + RadiansAngle.Full, RadiansAngle.Straight).Should().BeNegative();
            Angle.CompareReduced(RadiansAngle.Right, RadiansAngle.Right + RadiansAngle.Full).Should().Be(0);
            Angle.CompareReduced(RadiansAngle.Right, RadiansAngle.Zero + RadiansAngle.Full).Should().BePositive();
        }

        [Fact]
        public void LessThanOperator()
        {
            (RadiansAngle.Zero < RadiansAngle.Right).Should().BeTrue();
            (RadiansAngle.Right < RadiansAngle.Right).Should().BeFalse();
            (Angle.InRadians(180) < RadiansAngle.Right).Should().BeFalse();
        }

        [Fact]
        public void LessThanOrEqualToOperator()
        {
            (RadiansAngle.Zero <= RadiansAngle.Right).Should().BeTrue();
            (RadiansAngle.Right <= RadiansAngle.Right).Should().BeTrue();
            (Angle.InRadians(180) <= RadiansAngle.Right).Should().BeFalse();
        }

        [Fact]
        public void GreaterThanOperator()
        {
            (RadiansAngle.Zero > RadiansAngle.Right).Should().BeFalse();
            (RadiansAngle.Right > RadiansAngle.Right).Should().BeFalse();
            (Angle.InRadians(180) > RadiansAngle.Right).Should().BeTrue();
        }

        [Fact]
        public void GreaterThanOrEqualToOperator()
        {
            (RadiansAngle.Zero >= RadiansAngle.Right).Should().BeFalse();
            (RadiansAngle.Right >= RadiansAngle.Right).Should().BeTrue();
            (Angle.InRadians(180) >= RadiansAngle.Right).Should().BeTrue();
        }

        [Fact]
        public void ReduceIsDefinedCorrectly()
        {
            Angle.Reduce(RadiansAngle.Zero).Should().Be(RadiansAngle.Zero);
            Angle.Reduce(AcuteAngle).Should().Be(AcuteAngle);
            Angle.Reduce(RadiansAngle.Right).Should().Be(RadiansAngle.Right);
            Angle.Reduce(RadiansAngle.Right + AcuteAngle).Should().Be(RadiansAngle.Right + AcuteAngle);
            Angle.Reduce(RadiansAngle.Straight).Should().Be(RadiansAngle.Straight);

            Angle.Reduce(RadiansAngle.Full).Should().Be(RadiansAngle.Zero);
            Angle.Reduce(RadiansAngle.Full + AcuteAngle).Should().Be(AcuteAngle);
            Angle.Reduce(RadiansAngle.Full + RadiansAngle.Right).Should().Be(RadiansAngle.Right);
            Angle.Reduce(RadiansAngle.Full + RadiansAngle.Right + AcuteAngle).ShouldBeEquivalentTo(RadiansAngle.Right + AcuteAngle, options => options
                .Using<double>(ctx => ctx.Subject.Should().BeApproximately(ctx.Expectation, Math.Pow(10, -8)))
                .When(info => info.SelectedMemberPath == "Radians"));
            Angle.Reduce(RadiansAngle.Full + RadiansAngle.Straight).Should().Be(RadiansAngle.Straight);

            Angle.Reduce(-RadiansAngle.Full).Should().Be(RadiansAngle.Zero);
            Angle.Reduce(-AcuteAngle).Should().Be(RadiansAngle.Full - AcuteAngle);
            Angle.Reduce(-RadiansAngle.Right).Should().Be(RadiansAngle.Full - RadiansAngle.Right);
            Angle.Reduce(-RadiansAngle.Straight).Should().Be(RadiansAngle.Straight);
            Angle.Reduce(-RadiansAngle.Straight - RadiansAngle.Right).Should().Be(RadiansAngle.Right);
        }

        [Fact]
        public void GetQuadrantIsDefinedCorrectly()
        {
            Angle.GetQuadrant(RadiansAngle.Zero).Should().Be(Quadrant.First);
            Angle.GetQuadrant(AcuteAngle).Should().Be(Quadrant.First);
            Angle.GetQuadrant(RadiansAngle.Right).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(RadiansAngle.Right + AcuteAngle).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(RadiansAngle.Straight).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(RadiansAngle.Straight + AcuteAngle).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(RadiansAngle.Straight + RadiansAngle.Right).Should().Be(Quadrant.Fourth);
            Angle.GetQuadrant(RadiansAngle.Straight + RadiansAngle.Right + AcuteAngle).Should().Be(Quadrant.Fourth);

            Angle.GetQuadrant(RadiansAngle.Full).Should().Be(Quadrant.First);
            Angle.GetQuadrant(RadiansAngle.Full + AcuteAngle).Should().Be(Quadrant.First);
            Angle.GetQuadrant(RadiansAngle.Full + RadiansAngle.Right).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(RadiansAngle.Full + RadiansAngle.Right + AcuteAngle).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(RadiansAngle.Full + RadiansAngle.Straight).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(RadiansAngle.Full + RadiansAngle.Straight + AcuteAngle).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(RadiansAngle.Full + RadiansAngle.Straight + RadiansAngle.Right).Should().Be(Quadrant.Fourth);
            Angle.GetQuadrant(RadiansAngle.Full + RadiansAngle.Straight + RadiansAngle.Right + AcuteAngle).Should().Be(Quadrant.Fourth);
        }

        [Fact]
        public void ReferenceIsDefinedCorrectly()
        {
            Angle.GetReference(RadiansAngle.Zero).Should().Be(RadiansAngle.Zero);
            Angle.GetReference(AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(RadiansAngle.Right).Should().Be(RadiansAngle.Right);
            Angle.GetReference(RadiansAngle.Right + AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(RadiansAngle.Straight).Should().Be(RadiansAngle.Zero);
            Angle.GetReference(RadiansAngle.Straight + AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(RadiansAngle.Straight + RadiansAngle.Right).Should().Be(RadiansAngle.Right);
            Angle.GetReference(RadiansAngle.Straight + RadiansAngle.Right + AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(RadiansAngle.Full).Should().Be(RadiansAngle.Zero);
        }

        [Fact]
        public void IsZeroIsDefinedCorrectly()
        {
            Angle.IsZero(RadiansAngle.Zero).Should().BeTrue();
            Angle.IsZero(AcuteAngle).Should().BeFalse();
            Angle.IsZero(RadiansAngle.Right).Should().BeFalse();
            Angle.IsZero(RadiansAngle.Right + AcuteAngle).Should().BeFalse();
            Angle.IsZero(RadiansAngle.Straight).Should().BeFalse();
            Angle.IsZero(RadiansAngle.Straight + RadiansAngle.Right).Should().BeFalse();
            Angle.IsZero(RadiansAngle.Full).Should().BeTrue();

            Angle.IsZero(-AcuteAngle).Should().BeFalse();
            Angle.IsZero(-RadiansAngle.Right).Should().BeFalse();
            Angle.IsZero(-RadiansAngle.Right - AcuteAngle).Should().BeFalse();
            Angle.IsZero(-RadiansAngle.Straight).Should().BeFalse();
            Angle.IsZero(-RadiansAngle.Straight - RadiansAngle.Right).Should().BeFalse();
            Angle.IsZero(-RadiansAngle.Full).Should().BeTrue();
        }

        [Fact]
        public void IsAcuteIsDefinedCorrectly()
        {
            Angle.IsAcute(RadiansAngle.Zero).Should().BeFalse();
            Angle.IsAcute(AcuteAngle).Should().BeTrue();
            Angle.IsAcute(RadiansAngle.Right).Should().BeFalse();
            Angle.IsAcute(RadiansAngle.Right + AcuteAngle).Should().BeFalse();
            Angle.IsAcute(RadiansAngle.Straight).Should().BeFalse();
            Angle.IsAcute(RadiansAngle.Straight + RadiansAngle.Right).Should().BeFalse();
            Angle.IsAcute(RadiansAngle.Full).Should().BeFalse();

            Angle.IsAcute(-AcuteAngle).Should().BeTrue();
            Angle.IsAcute(-RadiansAngle.Right).Should().BeFalse();
            Angle.IsAcute(-RadiansAngle.Right - AcuteAngle).Should().BeFalse();
            Angle.IsAcute(-RadiansAngle.Straight).Should().BeFalse();
            Angle.IsAcute(-RadiansAngle.Straight - RadiansAngle.Right).Should().BeFalse();
            Angle.IsAcute(-RadiansAngle.Full).Should().BeFalse();
        }

        [Fact]
        public void IsRightIsDefinedCorrectly()
        {
            Angle.IsRight(RadiansAngle.Zero).Should().BeFalse();
            Angle.IsRight(AcuteAngle).Should().BeFalse();
            Angle.IsRight(RadiansAngle.Right).Should().BeTrue();
            Angle.IsRight(RadiansAngle.Right + AcuteAngle).Should().BeFalse();
            Angle.IsRight(RadiansAngle.Straight).Should().BeFalse();
            Angle.IsRight(RadiansAngle.Straight + RadiansAngle.Right).Should().BeFalse();
            Angle.IsRight(RadiansAngle.Full).Should().BeFalse();

            Angle.IsRight(-AcuteAngle).Should().BeFalse();
            Angle.IsRight(-RadiansAngle.Right).Should().BeTrue();
            Angle.IsRight(-RadiansAngle.Right - AcuteAngle).Should().BeFalse();
            Angle.IsRight(-RadiansAngle.Straight).Should().BeFalse();
            Angle.IsRight(-RadiansAngle.Straight - RadiansAngle.Right).Should().BeFalse();
            Angle.IsRight(-RadiansAngle.Full).Should().BeFalse();
        }

        [Fact]
        public void IsObtuseIsDefinedCorrectly()
        {
            Angle.IsObtuse(RadiansAngle.Zero).Should().BeFalse();
            Angle.IsObtuse(AcuteAngle).Should().BeFalse();
            Angle.IsObtuse(RadiansAngle.Right).Should().BeFalse();
            Angle.IsObtuse(RadiansAngle.Right + AcuteAngle).Should().BeTrue();
            Angle.IsObtuse(RadiansAngle.Straight).Should().BeFalse();
            Angle.IsObtuse(RadiansAngle.Straight + RadiansAngle.Right).Should().BeFalse();
            Angle.IsObtuse(RadiansAngle.Full).Should().BeFalse();

            Angle.IsObtuse(-AcuteAngle).Should().BeFalse();
            Angle.IsObtuse(-RadiansAngle.Right).Should().BeFalse();
            Angle.IsObtuse(-RadiansAngle.Right - AcuteAngle).Should().BeTrue();
            Angle.IsObtuse(-RadiansAngle.Straight).Should().BeFalse();
            Angle.IsObtuse(-RadiansAngle.Straight - RadiansAngle.Right).Should().BeFalse();
            Angle.IsObtuse(-RadiansAngle.Full).Should().BeFalse();
        }

        [Fact]
        public void IsStraightIsDefinedCorrectly()
        {
            Angle.IsStraight(RadiansAngle.Zero).Should().BeFalse();
            Angle.IsStraight(AcuteAngle).Should().BeFalse();
            Angle.IsStraight(RadiansAngle.Right).Should().BeFalse();
            Angle.IsStraight(RadiansAngle.Right - AcuteAngle).Should().BeFalse();
            Angle.IsStraight(RadiansAngle.Straight).Should().BeTrue();
            Angle.IsStraight(RadiansAngle.Straight - RadiansAngle.Right).Should().BeFalse();
            Angle.IsStraight(RadiansAngle.Full).Should().BeFalse();

            Angle.IsStraight(-AcuteAngle).Should().BeFalse();
            Angle.IsStraight(-RadiansAngle.Right).Should().BeFalse();
            Angle.IsStraight(-RadiansAngle.Right - AcuteAngle).Should().BeFalse();
            Angle.IsStraight(-RadiansAngle.Straight).Should().BeTrue();
            Angle.IsStraight(-RadiansAngle.Straight - RadiansAngle.Right).Should().BeFalse();
            Angle.IsStraight(-RadiansAngle.Full).Should().BeFalse();
        }

        [Fact]
        public void IsReflexIsDefinedCorrectly()
        {
            Angle.IsReflex(RadiansAngle.Zero).Should().BeFalse();
            Angle.IsReflex(AcuteAngle).Should().BeFalse();
            Angle.IsReflex(RadiansAngle.Right).Should().BeFalse();
            Angle.IsReflex(RadiansAngle.Right + AcuteAngle).Should().BeFalse();
            Angle.IsReflex(RadiansAngle.Straight).Should().BeFalse();
            Angle.IsReflex(RadiansAngle.Straight + RadiansAngle.Right).Should().BeTrue();
            Angle.IsReflex(RadiansAngle.Full).Should().BeFalse();

            Angle.IsReflex(-AcuteAngle).Should().BeFalse();
            Angle.IsReflex(-RadiansAngle.Right).Should().BeFalse();
            Angle.IsReflex(-RadiansAngle.Right - AcuteAngle).Should().BeFalse();
            Angle.IsReflex(-RadiansAngle.Straight).Should().BeFalse();
            Angle.IsReflex(-RadiansAngle.Straight - RadiansAngle.Right).Should().BeTrue();
            Angle.IsReflex(-RadiansAngle.Full).Should().BeFalse();
        }

        [Fact]
        public void IsObliqueIsDefinedCorrectly()
        {
            Angle.IsOblique(RadiansAngle.Zero).Should().BeFalse();
            Angle.IsOblique(AcuteAngle).Should().BeTrue();
            Angle.IsOblique(RadiansAngle.Right).Should().BeFalse();
            Angle.IsOblique(RadiansAngle.Right + AcuteAngle).Should().BeTrue();
            Angle.IsOblique(RadiansAngle.Straight).Should().BeFalse();
            Angle.IsOblique(RadiansAngle.Straight + RadiansAngle.Right).Should().BeFalse();
            Angle.IsOblique(RadiansAngle.Full).Should().BeFalse();

            Angle.IsOblique(-AcuteAngle).Should().BeTrue();
            Angle.IsOblique(-RadiansAngle.Right).Should().BeFalse();
            Angle.IsOblique(-RadiansAngle.Right - AcuteAngle).Should().BeTrue();
            Angle.IsOblique(-RadiansAngle.Straight).Should().BeFalse();
            Angle.IsOblique(-RadiansAngle.Straight - RadiansAngle.Right).Should().BeFalse();
            Angle.IsOblique(-RadiansAngle.Full).Should().BeFalse();
        }

        [Fact]
        public void LerpIsDefinedCorrectly()
        {
            Angle.Lerp(AcuteAngle, RadiansAngle.Right + AcuteAngle, -0.5).Should().Be(RadiansAngle.Zero);
            Angle.Lerp(AcuteAngle, RadiansAngle.Right + AcuteAngle, 0.0).Should().Be(AcuteAngle);
            Angle.Lerp(AcuteAngle, RadiansAngle.Right + AcuteAngle, 0.5).Should().Be(RadiansAngle.Right);
            Angle.Lerp(AcuteAngle, RadiansAngle.Right + AcuteAngle, 1.0).Should().Be(RadiansAngle.Right + AcuteAngle);
            Angle.Lerp(AcuteAngle, RadiansAngle.Right + AcuteAngle, 1.5).Should().Be(RadiansAngle.Straight);

            Angle.Lerp(-AcuteAngle, -RadiansAngle.Right - AcuteAngle, -0.5).Should().Be(RadiansAngle.Zero);
            Angle.Lerp(-AcuteAngle, -RadiansAngle.Right - AcuteAngle, 0.0).Should().Be(-AcuteAngle);
            Angle.Lerp(-AcuteAngle, -RadiansAngle.Right - AcuteAngle, 0.5).Should().Be(-RadiansAngle.Right);
            Angle.Lerp(-AcuteAngle, -RadiansAngle.Right - AcuteAngle, 1.0).Should().Be(-RadiansAngle.Right - AcuteAngle);
            Angle.Lerp(-AcuteAngle, -RadiansAngle.Right - AcuteAngle, 1.5).Should().Be(-RadiansAngle.Straight);

            Angle.Lerp(RadiansAngle.Right + AcuteAngle, AcuteAngle, -0.5).Should().Be(RadiansAngle.Straight);
            Angle.Lerp(RadiansAngle.Right + AcuteAngle, AcuteAngle, 0.0).Should().Be(RadiansAngle.Right + AcuteAngle);
            Angle.Lerp(RadiansAngle.Right + AcuteAngle, AcuteAngle, 0.5).Should().Be(RadiansAngle.Right);
            Angle.Lerp(RadiansAngle.Right + AcuteAngle, AcuteAngle, 1.0).Should().Be(AcuteAngle);
            Angle.Lerp(RadiansAngle.Right + AcuteAngle, AcuteAngle, 1.5).Should().Be(RadiansAngle.Zero);
        }

        [Fact]
        public void ToStringIsDefinedCorrectly()
        {
#if NET35
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
#else
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
#endif

            RadiansAngle.Straight.ToString().Should().Be("3.14159265358979");
            RadiansAngle.Straight.ToString("0.00").Should().Be("3.14");
            RadiansAngle.Straight.ToString("0.00", new CultureInfo("pt-PT")).Should().Be("3,14");
        }

    }
}
