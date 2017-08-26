using FluentAssertions;
using System;
using System.Globalization;
using Xunit;

namespace NetFabric.UnitTests
{
    public class DegreesAngleTests
    {
        readonly DegreesAngle AcuteAngle = DegreesAngle.Right / 2.0;

        [Fact]
        public void ObjectEquals()
        {
            DegreesAngle.Right.Equals(null).Should().BeFalse();
            DegreesAngle.Right.Equals(90.0).Should().BeFalse();
            DegreesAngle.Zero.Equals((object)DegreesAngle.Right).Should().BeFalse();
            DegreesAngle.Right.Equals((object)DegreesAngle.Right).Should().BeTrue();
        }

        [Fact]
        public void ObjectGetHashCode()
        {
            DegreesAngle.Zero.GetHashCode().Should().NotBe(DegreesAngle.Right.GetHashCode());
            DegreesAngle.Right.GetHashCode().Should().Be(DegreesAngle.Right.GetHashCode());
        }

        [Fact]
        public void EquatableEquals()
        {
            DegreesAngle.Zero.Equals(DegreesAngle.Right).Should().BeFalse();
            DegreesAngle.Right.Equals(DegreesAngle.Right).Should().BeTrue();
        }

        [Fact]
        public void OperatorEquality()
        {
            (DegreesAngle.Zero == DegreesAngle.Right).Should().BeFalse();
            (DegreesAngle.Right == DegreesAngle.Right).Should().BeTrue();
        }

        [Fact]
        public void OperatorInequality()
        {
            (DegreesAngle.Zero != DegreesAngle.Right).Should().BeTrue();
            (DegreesAngle.Right != DegreesAngle.Right).Should().BeFalse();
        }

        [Fact]
        public void ComparableCompareToObjectThrowsExcetionOnNull()
        {
            Action act = () => ((IComparable)DegreesAngle.Right).CompareTo(null);
            act.ShouldThrow<ArgumentException>()
                .WithMessage("Argument has to be an DegreesAngle.\r\nParameter name: obj");
        }

        [Fact]
        public void ComparableCompareToObjectThrowsExcetionOnOtherType()
        {
            Action act = () => ((IComparable)DegreesAngle.Right).CompareTo(90.0);
            act.ShouldThrow<ArgumentException>()
                .WithMessage("Argument has to be an DegreesAngle.\r\nParameter name: obj");
        }

        [Fact]
        public void ComparableCompareToObject()
        {
            ((IComparable)DegreesAngle.Right).CompareTo((object)DegreesAngle.Straight).Should().BeNegative();
            ((IComparable)DegreesAngle.Right).CompareTo((object)DegreesAngle.Right).Should().Be(0);
            ((IComparable)DegreesAngle.Right).CompareTo((object)DegreesAngle.Zero).Should().BePositive();
        }

        [Fact]
        public void ComparableCompareToAngle()
        {
            ((IComparable)DegreesAngle.Right).CompareTo(DegreesAngle.Straight).Should().BeNegative();
            ((IComparable)DegreesAngle.Right).CompareTo(DegreesAngle.Right).Should().Be(0);
            ((IComparable)DegreesAngle.Right).CompareTo(DegreesAngle.Zero).Should().BePositive();
        }

        [Fact]
        public void CompareTwoAngles()
        {
            Angle.Compare(DegreesAngle.Right, DegreesAngle.Straight).Should().BeNegative();
            Angle.Compare(DegreesAngle.Right, DegreesAngle.Right).Should().Be(0);
            Angle.Compare(DegreesAngle.Right, DegreesAngle.Zero).Should().BePositive();
            Angle.Compare(DegreesAngle.Right + DegreesAngle.Full, DegreesAngle.Straight).Should().BePositive();
            Angle.Compare(DegreesAngle.Right, DegreesAngle.Right + DegreesAngle.Full).Should().BeNegative();
            Angle.Compare(DegreesAngle.Right, DegreesAngle.Zero + DegreesAngle.Full).Should().BeNegative();
        }

        [Fact]
        public void CompareReducedTwoAngles()
        {
            Angle.CompareReduced(DegreesAngle.Right, DegreesAngle.Straight).Should().BeNegative();
            Angle.CompareReduced(DegreesAngle.Right, DegreesAngle.Right).Should().Be(0);
            Angle.CompareReduced(DegreesAngle.Right, DegreesAngle.Zero).Should().BePositive();
            Angle.CompareReduced(DegreesAngle.Right + DegreesAngle.Full, DegreesAngle.Straight).Should().BeNegative();
            Angle.CompareReduced(DegreesAngle.Right, DegreesAngle.Right + DegreesAngle.Full).Should().Be(0);
            Angle.CompareReduced(DegreesAngle.Right, DegreesAngle.Zero + DegreesAngle.Full).Should().BePositive();
        }

        [Fact]
        public void LessThanOperator()
        {
            (DegreesAngle.Zero < DegreesAngle.Right).Should().BeTrue();
            (DegreesAngle.Right < DegreesAngle.Right).Should().BeFalse();
            (Angle.InDegrees(180) < DegreesAngle.Right).Should().BeFalse();
        }

        [Fact]
        public void LessThanOrEqualToOperator()
        {
            (DegreesAngle.Zero <= DegreesAngle.Right).Should().BeTrue();
            (DegreesAngle.Right <= DegreesAngle.Right).Should().BeTrue();
            (Angle.InDegrees(180) <= DegreesAngle.Right).Should().BeFalse();
        }

        [Fact]
        public void GreaterThanOperator()
        {
            (DegreesAngle.Zero > DegreesAngle.Right).Should().BeFalse();
            (DegreesAngle.Right > DegreesAngle.Right).Should().BeFalse();
            (Angle.InDegrees(180) > DegreesAngle.Right).Should().BeTrue();
        }

        [Fact]
        public void GreaterThanOrEqualToOperator()
        {
            (DegreesAngle.Zero >= DegreesAngle.Right).Should().BeFalse();
            (DegreesAngle.Right >= DegreesAngle.Right).Should().BeTrue();
            (Angle.InDegrees(180) >= DegreesAngle.Right).Should().BeTrue();
        }

        [Fact]
        public void ReduceIsDefinedCorrectly()
        {
            Angle.Reduce(DegreesAngle.Zero).Should().Be(DegreesAngle.Zero);
            Angle.Reduce(AcuteAngle).Should().Be(AcuteAngle);
            Angle.Reduce(DegreesAngle.Right).Should().Be(DegreesAngle.Right);
            Angle.Reduce(DegreesAngle.Right + AcuteAngle).Should().Be(DegreesAngle.Right + AcuteAngle);
            Angle.Reduce(DegreesAngle.Straight).Should().Be(DegreesAngle.Straight);

            Angle.Reduce(DegreesAngle.Full).Should().Be(DegreesAngle.Zero);
            Angle.Reduce(DegreesAngle.Full + AcuteAngle).Should().Be(AcuteAngle);
            Angle.Reduce(DegreesAngle.Full + DegreesAngle.Right).Should().Be(DegreesAngle.Right);
            Angle.Reduce(DegreesAngle.Full + DegreesAngle.Right + AcuteAngle).ShouldBeEquivalentTo(DegreesAngle.Right + AcuteAngle, options => options
                .Using<double>(ctx => ctx.Subject.Should().BeApproximately(ctx.Expectation, Math.Pow(10, -8)))
                .When(info => info.SelectedMemberPath == "Degrees"));

            Angle.Reduce(DegreesAngle.Full + DegreesAngle.Straight).Should().Be(DegreesAngle.Straight);

            Angle.Reduce(-DegreesAngle.Full).Should().Be(DegreesAngle.Zero);
            Angle.Reduce(-AcuteAngle).Should().Be(DegreesAngle.Full - AcuteAngle);
            Angle.Reduce(-DegreesAngle.Right).Should().Be(DegreesAngle.Full - DegreesAngle.Right);
            Angle.Reduce(-DegreesAngle.Straight).Should().Be(DegreesAngle.Straight);
            Angle.Reduce(-DegreesAngle.Straight - DegreesAngle.Right).Should().Be(DegreesAngle.Right);
        }

        [Fact]
        public void GetQuadrantIsDefinedCorrectly()
        {
            var AcuteAngle = DegreesAngle.Right / 2.0;

            Angle.GetQuadrant(DegreesAngle.Zero).Should().Be(Quadrant.First);
            Angle.GetQuadrant(AcuteAngle).Should().Be(Quadrant.First);
            Angle.GetQuadrant(DegreesAngle.Right).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(DegreesAngle.Right + AcuteAngle).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(DegreesAngle.Straight).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(DegreesAngle.Straight + AcuteAngle).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(DegreesAngle.Straight + DegreesAngle.Right).Should().Be(Quadrant.Fourth);
            Angle.GetQuadrant(DegreesAngle.Straight + DegreesAngle.Right + AcuteAngle).Should().Be(Quadrant.Fourth);

            Angle.GetQuadrant(DegreesAngle.Full).Should().Be(Quadrant.First);
            Angle.GetQuadrant(DegreesAngle.Full + AcuteAngle).Should().Be(Quadrant.First);
            Angle.GetQuadrant(DegreesAngle.Full + DegreesAngle.Right).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(DegreesAngle.Full + DegreesAngle.Right + AcuteAngle).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(DegreesAngle.Full + DegreesAngle.Straight).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(DegreesAngle.Full + DegreesAngle.Straight + AcuteAngle).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(DegreesAngle.Full + DegreesAngle.Straight + DegreesAngle.Right).Should().Be(Quadrant.Fourth);
            Angle.GetQuadrant(DegreesAngle.Full + DegreesAngle.Straight + DegreesAngle.Right + AcuteAngle).Should().Be(Quadrant.Fourth);
        }

        [Fact]
        public void ReferenceIsDefinedCorrectly()
        {
            Angle.GetReference(DegreesAngle.Zero).Should().Be(DegreesAngle.Zero);
            Angle.GetReference(AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(DegreesAngle.Right).Should().Be(DegreesAngle.Right);
            Angle.GetReference(DegreesAngle.Right + AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(DegreesAngle.Straight).Should().Be(DegreesAngle.Zero);
            Angle.GetReference(DegreesAngle.Straight + AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(DegreesAngle.Straight + DegreesAngle.Right).Should().Be(DegreesAngle.Right);
            Angle.GetReference(DegreesAngle.Straight + DegreesAngle.Right + AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(DegreesAngle.Full).Should().Be(DegreesAngle.Zero);
        }

        [Fact]
        public void IsZeroIsDefinedCorrectly()
        {
            Angle.IsZero(DegreesAngle.Zero).Should().BeTrue();
            Angle.IsZero(AcuteAngle).Should().BeFalse();
            Angle.IsZero(DegreesAngle.Right).Should().BeFalse();
            Angle.IsZero(DegreesAngle.Right + AcuteAngle).Should().BeFalse();
            Angle.IsZero(DegreesAngle.Straight).Should().BeFalse();
            Angle.IsZero(DegreesAngle.Straight + DegreesAngle.Right).Should().BeFalse();
            Angle.IsZero(DegreesAngle.Full).Should().BeTrue();

            Angle.IsZero(-AcuteAngle).Should().BeFalse();
            Angle.IsZero(-DegreesAngle.Right).Should().BeFalse();
            Angle.IsZero(-DegreesAngle.Right - AcuteAngle).Should().BeFalse();
            Angle.IsZero(-DegreesAngle.Straight).Should().BeFalse();
            Angle.IsZero(-DegreesAngle.Straight - DegreesAngle.Right).Should().BeFalse();
            Angle.IsZero(-DegreesAngle.Full).Should().BeTrue();
        }

        [Fact]
        public void IsAcuteIsDefinedCorrectly()
        {
            Angle.IsAcute(DegreesAngle.Zero).Should().BeFalse();
            Angle.IsAcute(AcuteAngle).Should().BeTrue();
            Angle.IsAcute(DegreesAngle.Right).Should().BeFalse();
            Angle.IsAcute(DegreesAngle.Right + AcuteAngle).Should().BeFalse();
            Angle.IsAcute(DegreesAngle.Straight).Should().BeFalse();
            Angle.IsAcute(DegreesAngle.Straight + DegreesAngle.Right).Should().BeFalse();
            Angle.IsAcute(DegreesAngle.Full).Should().BeFalse();

            Angle.IsAcute(-AcuteAngle).Should().BeTrue();
            Angle.IsAcute(-DegreesAngle.Right).Should().BeFalse();
            Angle.IsAcute(-DegreesAngle.Right - AcuteAngle).Should().BeFalse();
            Angle.IsAcute(-DegreesAngle.Straight).Should().BeFalse();
            Angle.IsAcute(-DegreesAngle.Straight - DegreesAngle.Right).Should().BeFalse();
            Angle.IsAcute(-DegreesAngle.Full).Should().BeFalse();
        }

        [Fact]
        public void IsRightIsDefinedCorrectly()
        {
            Angle.IsRight(DegreesAngle.Zero).Should().BeFalse();
            Angle.IsRight(AcuteAngle).Should().BeFalse();
            Angle.IsRight(DegreesAngle.Right).Should().BeTrue();
            Angle.IsRight(DegreesAngle.Right + AcuteAngle).Should().BeFalse();
            Angle.IsRight(DegreesAngle.Straight).Should().BeFalse();
            Angle.IsRight(DegreesAngle.Straight + DegreesAngle.Right).Should().BeFalse();
            Angle.IsRight(DegreesAngle.Full).Should().BeFalse();

            Angle.IsRight(-AcuteAngle).Should().BeFalse();
            Angle.IsRight(-DegreesAngle.Right).Should().BeTrue();
            Angle.IsRight(-DegreesAngle.Right - AcuteAngle).Should().BeFalse();
            Angle.IsRight(-DegreesAngle.Straight).Should().BeFalse();
            Angle.IsRight(-DegreesAngle.Straight - DegreesAngle.Right).Should().BeFalse();
            Angle.IsRight(-DegreesAngle.Full).Should().BeFalse();
        }

        [Fact]
        public void IsObtuseIsDefinedCorrectly()
        {
            Angle.IsObtuse(DegreesAngle.Zero).Should().BeFalse();
            Angle.IsObtuse(AcuteAngle).Should().BeFalse();
            Angle.IsObtuse(DegreesAngle.Right).Should().BeFalse();
            Angle.IsObtuse(DegreesAngle.Right + AcuteAngle).Should().BeTrue();
            Angle.IsObtuse(DegreesAngle.Straight).Should().BeFalse();
            Angle.IsObtuse(DegreesAngle.Straight + DegreesAngle.Right).Should().BeFalse();
            Angle.IsObtuse(DegreesAngle.Full).Should().BeFalse();

            Angle.IsObtuse(-AcuteAngle).Should().BeFalse();
            Angle.IsObtuse(-DegreesAngle.Right).Should().BeFalse();
            Angle.IsObtuse(-DegreesAngle.Right - AcuteAngle).Should().BeTrue();
            Angle.IsObtuse(-DegreesAngle.Straight).Should().BeFalse();
            Angle.IsObtuse(-DegreesAngle.Straight - DegreesAngle.Right).Should().BeFalse();
            Angle.IsObtuse(-DegreesAngle.Full).Should().BeFalse();
        }

        [Fact]
        public void IsStraightIsDefinedCorrectly()
        {
            Angle.IsStraight(DegreesAngle.Zero).Should().BeFalse();
            Angle.IsStraight(AcuteAngle).Should().BeFalse();
            Angle.IsStraight(DegreesAngle.Right).Should().BeFalse();
            Angle.IsStraight(DegreesAngle.Right - AcuteAngle).Should().BeFalse();
            Angle.IsStraight(DegreesAngle.Straight).Should().BeTrue();
            Angle.IsStraight(DegreesAngle.Straight - DegreesAngle.Right).Should().BeFalse();
            Angle.IsStraight(DegreesAngle.Full).Should().BeFalse();

            Angle.IsStraight(-AcuteAngle).Should().BeFalse();
            Angle.IsStraight(-DegreesAngle.Right).Should().BeFalse();
            Angle.IsStraight(-DegreesAngle.Right - AcuteAngle).Should().BeFalse();
            Angle.IsStraight(-DegreesAngle.Straight).Should().BeTrue();
            Angle.IsStraight(-DegreesAngle.Straight - DegreesAngle.Right).Should().BeFalse();
            Angle.IsStraight(-DegreesAngle.Full).Should().BeFalse();
        }

        [Fact]
        public void IsReflexIsDefinedCorrectly()
        {
            Angle.IsReflex(DegreesAngle.Zero).Should().BeFalse();
            Angle.IsReflex(AcuteAngle).Should().BeFalse();
            Angle.IsReflex(DegreesAngle.Right).Should().BeFalse();
            Angle.IsReflex(DegreesAngle.Right + AcuteAngle).Should().BeFalse();
            Angle.IsReflex(DegreesAngle.Straight).Should().BeFalse();
            Angle.IsReflex(DegreesAngle.Straight + DegreesAngle.Right).Should().BeTrue();
            Angle.IsReflex(DegreesAngle.Full).Should().BeFalse();

            Angle.IsReflex(-AcuteAngle).Should().BeFalse();
            Angle.IsReflex(-DegreesAngle.Right).Should().BeFalse();
            Angle.IsReflex(-DegreesAngle.Right - AcuteAngle).Should().BeFalse();
            Angle.IsReflex(-DegreesAngle.Straight).Should().BeFalse();
            Angle.IsReflex(-DegreesAngle.Straight - DegreesAngle.Right).Should().BeTrue();
            Angle.IsReflex(-DegreesAngle.Full).Should().BeFalse();
        }

        [Fact]
        public void IsObliqueIsDefinedCorrectly()
        {
            Angle.IsOblique(DegreesAngle.Zero).Should().BeFalse();
            Angle.IsOblique(AcuteAngle).Should().BeTrue();
            Angle.IsOblique(DegreesAngle.Right).Should().BeFalse();
            Angle.IsOblique(DegreesAngle.Right + AcuteAngle).Should().BeTrue();
            Angle.IsOblique(DegreesAngle.Straight).Should().BeFalse();
            Angle.IsOblique(DegreesAngle.Straight + DegreesAngle.Right).Should().BeFalse();
            Angle.IsOblique(DegreesAngle.Full).Should().BeFalse();

            Angle.IsOblique(-AcuteAngle).Should().BeTrue();
            Angle.IsOblique(-DegreesAngle.Right).Should().BeFalse();
            Angle.IsOblique(-DegreesAngle.Right - AcuteAngle).Should().BeTrue();
            Angle.IsOblique(-DegreesAngle.Straight).Should().BeFalse();
            Angle.IsOblique(-DegreesAngle.Straight - DegreesAngle.Right).Should().BeFalse();
            Angle.IsOblique(-DegreesAngle.Full).Should().BeFalse();
        }

        [Fact]
        public void LerpIsDefinedCorrectly()
        {
            Angle.Lerp(AcuteAngle, DegreesAngle.Right + AcuteAngle, -0.5).Should().Be(DegreesAngle.Zero);
            Angle.Lerp(AcuteAngle, DegreesAngle.Right + AcuteAngle, 0.0).Should().Be(AcuteAngle);
            Angle.Lerp(AcuteAngle, DegreesAngle.Right + AcuteAngle, 0.5).Should().Be(DegreesAngle.Right);
            Angle.Lerp(AcuteAngle, DegreesAngle.Right + AcuteAngle, 1.0).Should().Be(DegreesAngle.Right + AcuteAngle);
            Angle.Lerp(AcuteAngle, DegreesAngle.Right + AcuteAngle, 1.5).Should().Be(DegreesAngle.Straight);

            Angle.Lerp(-AcuteAngle, -DegreesAngle.Right - AcuteAngle, -0.5).Should().Be(DegreesAngle.Zero);
            Angle.Lerp(-AcuteAngle, -DegreesAngle.Right - AcuteAngle, 0.0).Should().Be(-AcuteAngle);
            Angle.Lerp(-AcuteAngle, -DegreesAngle.Right - AcuteAngle, 0.5).Should().Be(-DegreesAngle.Right);
            Angle.Lerp(-AcuteAngle, -DegreesAngle.Right - AcuteAngle, 1.0).Should().Be(-DegreesAngle.Right - AcuteAngle);
            Angle.Lerp(-AcuteAngle, -DegreesAngle.Right - AcuteAngle, 1.5).Should().Be(-DegreesAngle.Straight);

            Angle.Lerp(DegreesAngle.Right + AcuteAngle, AcuteAngle, -0.5).Should().Be(DegreesAngle.Straight);
            Angle.Lerp(DegreesAngle.Right + AcuteAngle, AcuteAngle, 0.0).Should().Be(DegreesAngle.Right + AcuteAngle);
            Angle.Lerp(DegreesAngle.Right + AcuteAngle, AcuteAngle, 0.5).Should().Be(DegreesAngle.Right);
            Angle.Lerp(DegreesAngle.Right + AcuteAngle, AcuteAngle, 1.0).Should().Be(AcuteAngle);
            Angle.Lerp(DegreesAngle.Right + AcuteAngle, AcuteAngle, 1.5).Should().Be(DegreesAngle.Zero);
        }

        [Fact]
        public void ToStringIsDefinedCorrectly()
        {
#if NET35
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
#else
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
#endif

            DegreesAngle.Straight.ToString().Should().Be("180");
            DegreesAngle.Straight.ToString("0.00").Should().Be("180.00");
            DegreesAngle.Straight.ToString("0.00", new CultureInfo("pt-PT")).Should().Be("180,00");
        }
    }
}
