using FluentAssertions;
using System;
using System.Globalization;
using Xunit;

namespace NetFabric.UnitTests
{
    public class GradiansAngleTests
    {
        readonly GradiansAngle AcuteAngle = GradiansAngle.Right / 2.0;

        [Fact]
        public void ObjectEquals()
        {
            GradiansAngle.Right.Equals(null).Should().BeFalse();
            GradiansAngle.Right.Equals(90.0).Should().BeFalse();
            GradiansAngle.Zero.Equals((object)GradiansAngle.Right).Should().BeFalse();
            GradiansAngle.Right.Equals((object)GradiansAngle.Right).Should().BeTrue();
        }

        [Fact]
        public void ObjectGetHashCode()
        {
            GradiansAngle.Zero.GetHashCode().Should().NotBe(GradiansAngle.Right.GetHashCode());
            GradiansAngle.Right.GetHashCode().Should().Be(GradiansAngle.Right.GetHashCode());
        }

        [Fact]
        public void EquatableEquals()
        {
            GradiansAngle.Zero.Equals(GradiansAngle.Right).Should().BeFalse();
            GradiansAngle.Right.Equals(GradiansAngle.Right).Should().BeTrue();
        }

        [Fact]
        public void OperatorEquality()
        {
            (GradiansAngle.Zero == GradiansAngle.Right).Should().BeFalse();
            (GradiansAngle.Right == GradiansAngle.Right).Should().BeTrue();
        }

        [Fact]
        public void OperatorInequality()
        {
            (GradiansAngle.Zero != GradiansAngle.Right).Should().BeTrue();
            (GradiansAngle.Right != GradiansAngle.Right).Should().BeFalse();
        }

        [Fact]
        public void ComparableCompareToObjectThrowsExcetionOnNull()
        {
            Action act = () => ((IComparable)GradiansAngle.Right).CompareTo(null);
            act.ShouldThrow<ArgumentException>()
                .WithMessage("Argument has to be an GradiansAngle.\r\nParameter name: obj");
        }

        [Fact]
        public void ComparableCompareToObjectThrowsExcetionOnOtherType()
        {
            Action act = () => ((IComparable)GradiansAngle.Right).CompareTo(90.0);
            act.ShouldThrow<ArgumentException>()
                .WithMessage("Argument has to be an GradiansAngle.\r\nParameter name: obj");
        }

        [Fact]
        public void ComparableCompareToObject()
        {
            ((IComparable)GradiansAngle.Right).CompareTo((object)GradiansAngle.Straight).Should().BeNegative();
            ((IComparable)GradiansAngle.Right).CompareTo((object)GradiansAngle.Right).Should().Be(0);
            ((IComparable)GradiansAngle.Right).CompareTo((object)GradiansAngle.Zero).Should().BePositive();
        }

        [Fact]
        public void ComparableCompareToAngle()
        {
            ((IComparable)GradiansAngle.Right).CompareTo(GradiansAngle.Straight).Should().BeNegative();
            ((IComparable)GradiansAngle.Right).CompareTo(GradiansAngle.Right).Should().Be(0);
            ((IComparable)GradiansAngle.Right).CompareTo(GradiansAngle.Zero).Should().BePositive();
        }

        [Fact]
        public void CompareTwoAngles()
        {
            Angle.Compare(GradiansAngle.Right, GradiansAngle.Straight).Should().BeNegative();
            Angle.Compare(GradiansAngle.Right, GradiansAngle.Right).Should().Be(0);
            Angle.Compare(GradiansAngle.Right, GradiansAngle.Zero).Should().BePositive();
            Angle.Compare(GradiansAngle.Right + GradiansAngle.Full, GradiansAngle.Straight).Should().BePositive();
            Angle.Compare(GradiansAngle.Right, GradiansAngle.Right + GradiansAngle.Full).Should().BeNegative();
            Angle.Compare(GradiansAngle.Right, GradiansAngle.Zero + GradiansAngle.Full).Should().BeNegative();
        }

        [Fact]
        public void CompareReducedTwoAngles()
        {
            Angle.CompareReduced(GradiansAngle.Right, GradiansAngle.Straight).Should().BeNegative();
            Angle.CompareReduced(GradiansAngle.Right, GradiansAngle.Right).Should().Be(0);
            Angle.CompareReduced(GradiansAngle.Right, GradiansAngle.Zero).Should().BePositive();
            Angle.CompareReduced(GradiansAngle.Right + GradiansAngle.Full, GradiansAngle.Straight).Should().BeNegative();
            Angle.CompareReduced(GradiansAngle.Right, GradiansAngle.Right + GradiansAngle.Full).Should().Be(0);
            Angle.CompareReduced(GradiansAngle.Right, GradiansAngle.Zero + GradiansAngle.Full).Should().BePositive();
        }

        [Fact]
        public void LessThanOperator()
        {
            (GradiansAngle.Zero < GradiansAngle.Right).Should().BeTrue();
            (GradiansAngle.Right < GradiansAngle.Right).Should().BeFalse();
            (Angle.InGradians(180) < GradiansAngle.Right).Should().BeFalse();
        }

        [Fact]
        public void LessThanOrEqualToOperator()
        {
            (GradiansAngle.Zero <= GradiansAngle.Right).Should().BeTrue();
            (GradiansAngle.Right <= GradiansAngle.Right).Should().BeTrue();
            (Angle.InGradians(180) <= GradiansAngle.Right).Should().BeFalse();
        }

        [Fact]
        public void GreaterThanOperator()
        {
            (GradiansAngle.Zero > GradiansAngle.Right).Should().BeFalse();
            (GradiansAngle.Right > GradiansAngle.Right).Should().BeFalse();
            (Angle.InGradians(180) > GradiansAngle.Right).Should().BeTrue();
        }

        [Fact]
        public void GreaterThanOrEqualToOperator()
        {
            (GradiansAngle.Zero >= GradiansAngle.Right).Should().BeFalse();
            (GradiansAngle.Right >= GradiansAngle.Right).Should().BeTrue();
            (Angle.InGradians(180) >= GradiansAngle.Right).Should().BeTrue();
        }

        [Fact]
        public void ReduceIsDefinedCorrectly()
        {
            Angle.Reduce(GradiansAngle.Zero).Should().Be(GradiansAngle.Zero);
            Angle.Reduce(AcuteAngle).Should().Be(AcuteAngle);
            Angle.Reduce(GradiansAngle.Right).Should().Be(GradiansAngle.Right);
            Angle.Reduce(GradiansAngle.Right + AcuteAngle).Should().Be(GradiansAngle.Right + AcuteAngle);
            Angle.Reduce(GradiansAngle.Straight).Should().Be(GradiansAngle.Straight);

            Angle.Reduce(GradiansAngle.Full).Should().Be(GradiansAngle.Zero);
            Angle.Reduce(GradiansAngle.Full + AcuteAngle).Should().Be(AcuteAngle);
            Angle.Reduce(GradiansAngle.Full + GradiansAngle.Right).Should().Be(GradiansAngle.Right);
            Angle.Reduce(GradiansAngle.Full + GradiansAngle.Right + AcuteAngle).ShouldBeEquivalentTo(GradiansAngle.Right + AcuteAngle, options => options
                .Using<double>(ctx => ctx.Subject.Should().BeApproximately(ctx.Expectation, Math.Pow(10, -8)))
                .When(info => info.SelectedMemberPath == "Gradians"));

            Angle.Reduce(GradiansAngle.Full + GradiansAngle.Straight).Should().Be(GradiansAngle.Straight);

            Angle.Reduce(-GradiansAngle.Full).Should().Be(GradiansAngle.Zero);
            Angle.Reduce(-AcuteAngle).Should().Be(GradiansAngle.Full - AcuteAngle);
            Angle.Reduce(-GradiansAngle.Right).Should().Be(GradiansAngle.Full - GradiansAngle.Right);
            Angle.Reduce(-GradiansAngle.Straight).Should().Be(GradiansAngle.Straight);
            Angle.Reduce(-GradiansAngle.Straight - GradiansAngle.Right).Should().Be(GradiansAngle.Right);
        }

        [Fact]
        public void GetQuadrantIsDefinedCorrectly()
        {
            var AcuteAngle = GradiansAngle.Right / 2.0;

            Angle.GetQuadrant(GradiansAngle.Zero).Should().Be(Quadrant.First);
            Angle.GetQuadrant(AcuteAngle).Should().Be(Quadrant.First);
            Angle.GetQuadrant(GradiansAngle.Right).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(GradiansAngle.Right + AcuteAngle).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(GradiansAngle.Straight).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(GradiansAngle.Straight + AcuteAngle).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(GradiansAngle.Straight + GradiansAngle.Right).Should().Be(Quadrant.Fourth);
            Angle.GetQuadrant(GradiansAngle.Straight + GradiansAngle.Right + AcuteAngle).Should().Be(Quadrant.Fourth);

            Angle.GetQuadrant(GradiansAngle.Full).Should().Be(Quadrant.First);
            Angle.GetQuadrant(GradiansAngle.Full + AcuteAngle).Should().Be(Quadrant.First);
            Angle.GetQuadrant(GradiansAngle.Full + GradiansAngle.Right).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(GradiansAngle.Full + GradiansAngle.Right + AcuteAngle).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(GradiansAngle.Full + GradiansAngle.Straight).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(GradiansAngle.Full + GradiansAngle.Straight + AcuteAngle).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(GradiansAngle.Full + GradiansAngle.Straight + GradiansAngle.Right).Should().Be(Quadrant.Fourth);
            Angle.GetQuadrant(GradiansAngle.Full + GradiansAngle.Straight + GradiansAngle.Right + AcuteAngle).Should().Be(Quadrant.Fourth);
        }

        [Fact]
        public void ReferenceIsDefinedCorrectly()
        {
            Angle.GetReference(GradiansAngle.Zero).Should().Be(GradiansAngle.Zero);
            Angle.GetReference(AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(GradiansAngle.Right).Should().Be(GradiansAngle.Right);
            Angle.GetReference(GradiansAngle.Right + AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(GradiansAngle.Straight).Should().Be(GradiansAngle.Zero);
            Angle.GetReference(GradiansAngle.Straight + AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(GradiansAngle.Straight + GradiansAngle.Right).Should().Be(GradiansAngle.Right);
            Angle.GetReference(GradiansAngle.Straight + GradiansAngle.Right + AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(GradiansAngle.Full).Should().Be(GradiansAngle.Zero);
        }

        [Fact]
        public void IsZeroIsDefinedCorrectly()
        {
            Angle.IsZero(GradiansAngle.Zero).Should().BeTrue();
            Angle.IsZero(AcuteAngle).Should().BeFalse();
            Angle.IsZero(GradiansAngle.Right).Should().BeFalse();
            Angle.IsZero(GradiansAngle.Right + AcuteAngle).Should().BeFalse();
            Angle.IsZero(GradiansAngle.Straight).Should().BeFalse();
            Angle.IsZero(GradiansAngle.Straight + GradiansAngle.Right).Should().BeFalse();
            Angle.IsZero(GradiansAngle.Full).Should().BeTrue();

            Angle.IsZero(-AcuteAngle).Should().BeFalse();
            Angle.IsZero(-GradiansAngle.Right).Should().BeFalse();
            Angle.IsZero(-GradiansAngle.Right - AcuteAngle).Should().BeFalse();
            Angle.IsZero(-GradiansAngle.Straight).Should().BeFalse();
            Angle.IsZero(-GradiansAngle.Straight - GradiansAngle.Right).Should().BeFalse();
            Angle.IsZero(-GradiansAngle.Full).Should().BeTrue();
        }

        [Fact]
        public void IsAcuteIsDefinedCorrectly()
        {
            Angle.IsAcute(GradiansAngle.Zero).Should().BeFalse();
            Angle.IsAcute(AcuteAngle).Should().BeTrue();
            Angle.IsAcute(GradiansAngle.Right).Should().BeFalse();
            Angle.IsAcute(GradiansAngle.Right + AcuteAngle).Should().BeFalse();
            Angle.IsAcute(GradiansAngle.Straight).Should().BeFalse();
            Angle.IsAcute(GradiansAngle.Straight + GradiansAngle.Right).Should().BeFalse();
            Angle.IsAcute(GradiansAngle.Full).Should().BeFalse();

            Angle.IsAcute(-AcuteAngle).Should().BeTrue();
            Angle.IsAcute(-GradiansAngle.Right).Should().BeFalse();
            Angle.IsAcute(-GradiansAngle.Right - AcuteAngle).Should().BeFalse();
            Angle.IsAcute(-GradiansAngle.Straight).Should().BeFalse();
            Angle.IsAcute(-GradiansAngle.Straight - GradiansAngle.Right).Should().BeFalse();
            Angle.IsAcute(-GradiansAngle.Full).Should().BeFalse();
        }

        [Fact]
        public void IsRightIsDefinedCorrectly()
        {
            Angle.IsRight(GradiansAngle.Zero).Should().BeFalse();
            Angle.IsRight(AcuteAngle).Should().BeFalse();
            Angle.IsRight(GradiansAngle.Right).Should().BeTrue();
            Angle.IsRight(GradiansAngle.Right + AcuteAngle).Should().BeFalse();
            Angle.IsRight(GradiansAngle.Straight).Should().BeFalse();
            Angle.IsRight(GradiansAngle.Straight + GradiansAngle.Right).Should().BeFalse();
            Angle.IsRight(GradiansAngle.Full).Should().BeFalse();

            Angle.IsRight(-AcuteAngle).Should().BeFalse();
            Angle.IsRight(-GradiansAngle.Right).Should().BeTrue();
            Angle.IsRight(-GradiansAngle.Right - AcuteAngle).Should().BeFalse();
            Angle.IsRight(-GradiansAngle.Straight).Should().BeFalse();
            Angle.IsRight(-GradiansAngle.Straight - GradiansAngle.Right).Should().BeFalse();
            Angle.IsRight(-GradiansAngle.Full).Should().BeFalse();
        }

        [Fact]
        public void IsObtuseIsDefinedCorrectly()
        {
            Angle.IsObtuse(GradiansAngle.Zero).Should().BeFalse();
            Angle.IsObtuse(AcuteAngle).Should().BeFalse();
            Angle.IsObtuse(GradiansAngle.Right).Should().BeFalse();
            Angle.IsObtuse(GradiansAngle.Right + AcuteAngle).Should().BeTrue();
            Angle.IsObtuse(GradiansAngle.Straight).Should().BeFalse();
            Angle.IsObtuse(GradiansAngle.Straight + GradiansAngle.Right).Should().BeFalse();
            Angle.IsObtuse(GradiansAngle.Full).Should().BeFalse();

            Angle.IsObtuse(-AcuteAngle).Should().BeFalse();
            Angle.IsObtuse(-GradiansAngle.Right).Should().BeFalse();
            Angle.IsObtuse(-GradiansAngle.Right - AcuteAngle).Should().BeTrue();
            Angle.IsObtuse(-GradiansAngle.Straight).Should().BeFalse();
            Angle.IsObtuse(-GradiansAngle.Straight - GradiansAngle.Right).Should().BeFalse();
            Angle.IsObtuse(-GradiansAngle.Full).Should().BeFalse();
        }

        [Fact]
        public void IsStraightIsDefinedCorrectly()
        {
            Angle.IsStraight(GradiansAngle.Zero).Should().BeFalse();
            Angle.IsStraight(AcuteAngle).Should().BeFalse();
            Angle.IsStraight(GradiansAngle.Right).Should().BeFalse();
            Angle.IsStraight(GradiansAngle.Right - AcuteAngle).Should().BeFalse();
            Angle.IsStraight(GradiansAngle.Straight).Should().BeTrue();
            Angle.IsStraight(GradiansAngle.Straight - GradiansAngle.Right).Should().BeFalse();
            Angle.IsStraight(GradiansAngle.Full).Should().BeFalse();

            Angle.IsStraight(-AcuteAngle).Should().BeFalse();
            Angle.IsStraight(-GradiansAngle.Right).Should().BeFalse();
            Angle.IsStraight(-GradiansAngle.Right - AcuteAngle).Should().BeFalse();
            Angle.IsStraight(-GradiansAngle.Straight).Should().BeTrue();
            Angle.IsStraight(-GradiansAngle.Straight - GradiansAngle.Right).Should().BeFalse();
            Angle.IsStraight(-GradiansAngle.Full).Should().BeFalse();
        }

        [Fact]
        public void IsReflexIsDefinedCorrectly()
        {
            Angle.IsReflex(GradiansAngle.Zero).Should().BeFalse();
            Angle.IsReflex(AcuteAngle).Should().BeFalse();
            Angle.IsReflex(GradiansAngle.Right).Should().BeFalse();
            Angle.IsReflex(GradiansAngle.Right + AcuteAngle).Should().BeFalse();
            Angle.IsReflex(GradiansAngle.Straight).Should().BeFalse();
            Angle.IsReflex(GradiansAngle.Straight + GradiansAngle.Right).Should().BeTrue();
            Angle.IsReflex(GradiansAngle.Full).Should().BeFalse();

            Angle.IsReflex(-AcuteAngle).Should().BeFalse();
            Angle.IsReflex(-GradiansAngle.Right).Should().BeFalse();
            Angle.IsReflex(-GradiansAngle.Right - AcuteAngle).Should().BeFalse();
            Angle.IsReflex(-GradiansAngle.Straight).Should().BeFalse();
            Angle.IsReflex(-GradiansAngle.Straight - GradiansAngle.Right).Should().BeTrue();
            Angle.IsReflex(-GradiansAngle.Full).Should().BeFalse();
        }

        [Fact]
        public void IsObliqueIsDefinedCorrectly()
        {
            Angle.IsOblique(GradiansAngle.Zero).Should().BeFalse();
            Angle.IsOblique(AcuteAngle).Should().BeTrue();
            Angle.IsOblique(GradiansAngle.Right).Should().BeFalse();
            Angle.IsOblique(GradiansAngle.Right + AcuteAngle).Should().BeTrue();
            Angle.IsOblique(GradiansAngle.Straight).Should().BeFalse();
            Angle.IsOblique(GradiansAngle.Straight + GradiansAngle.Right).Should().BeFalse();
            Angle.IsOblique(GradiansAngle.Full).Should().BeFalse();

            Angle.IsOblique(-AcuteAngle).Should().BeTrue();
            Angle.IsOblique(-GradiansAngle.Right).Should().BeFalse();
            Angle.IsOblique(-GradiansAngle.Right - AcuteAngle).Should().BeTrue();
            Angle.IsOblique(-GradiansAngle.Straight).Should().BeFalse();
            Angle.IsOblique(-GradiansAngle.Straight - GradiansAngle.Right).Should().BeFalse();
            Angle.IsOblique(-GradiansAngle.Full).Should().BeFalse();
        }

        [Fact]
        public void LerpIsDefinedCorrectly()
        {
            Angle.Lerp(AcuteAngle, GradiansAngle.Right + AcuteAngle, -0.5).Should().Be(GradiansAngle.Zero);
            Angle.Lerp(AcuteAngle, GradiansAngle.Right + AcuteAngle, 0.0).Should().Be(AcuteAngle);
            Angle.Lerp(AcuteAngle, GradiansAngle.Right + AcuteAngle, 0.5).Should().Be(GradiansAngle.Right);
            Angle.Lerp(AcuteAngle, GradiansAngle.Right + AcuteAngle, 1.0).Should().Be(GradiansAngle.Right + AcuteAngle);
            Angle.Lerp(AcuteAngle, GradiansAngle.Right + AcuteAngle, 1.5).Should().Be(GradiansAngle.Straight);

            Angle.Lerp(-AcuteAngle, -GradiansAngle.Right - AcuteAngle, -0.5).Should().Be(GradiansAngle.Zero);
            Angle.Lerp(-AcuteAngle, -GradiansAngle.Right - AcuteAngle, 0.0).Should().Be(-AcuteAngle);
            Angle.Lerp(-AcuteAngle, -GradiansAngle.Right - AcuteAngle, 0.5).Should().Be(-GradiansAngle.Right);
            Angle.Lerp(-AcuteAngle, -GradiansAngle.Right - AcuteAngle, 1.0).Should().Be(-GradiansAngle.Right - AcuteAngle);
            Angle.Lerp(-AcuteAngle, -GradiansAngle.Right - AcuteAngle, 1.5).Should().Be(-GradiansAngle.Straight);

            Angle.Lerp(GradiansAngle.Right + AcuteAngle, AcuteAngle, -0.5).Should().Be(GradiansAngle.Straight);
            Angle.Lerp(GradiansAngle.Right + AcuteAngle, AcuteAngle, 0.0).Should().Be(GradiansAngle.Right + AcuteAngle);
            Angle.Lerp(GradiansAngle.Right + AcuteAngle, AcuteAngle, 0.5).Should().Be(GradiansAngle.Right);
            Angle.Lerp(GradiansAngle.Right + AcuteAngle, AcuteAngle, 1.0).Should().Be(AcuteAngle);
            Angle.Lerp(GradiansAngle.Right + AcuteAngle, AcuteAngle, 1.5).Should().Be(GradiansAngle.Zero);
        }

        [Fact]
        public void ToStringIsDefinedCorrectly()
        {
#if NET35
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
#else
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
#endif

            GradiansAngle.Straight.ToString().Should().Be("200");
            GradiansAngle.Straight.ToString("0.00").Should().Be("200.00");
            GradiansAngle.Straight.ToString("0.00", new CultureInfo("pt-PT")).Should().Be("200,00");
        }
    }
}
