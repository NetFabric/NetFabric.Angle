using FluentAssertions;
using System;
using System.Globalization;
using Xunit;

namespace NetFabric.UnitTests
{
    public class GradiansAngleTests
    {
        readonly AngleGradians AcuteAngle = AngleGradians.Right / 2.0;

        [Fact]
        public void ObjectEquals()
        {
            AngleGradians.Right.Equals(null).Should().BeFalse();
            AngleGradians.Right.Equals(90.0).Should().BeFalse();
            AngleGradians.Zero.Equals((object)AngleGradians.Right).Should().BeFalse();
            AngleGradians.Right.Equals((object)AngleGradians.Right).Should().BeTrue();
        }

        [Fact]
        public void ObjectGetHashCode()
        {
            AngleGradians.Zero.GetHashCode().Should().NotBe(AngleGradians.Right.GetHashCode());
            AngleGradians.Right.GetHashCode().Should().Be(AngleGradians.Right.GetHashCode());
        }

        [Fact]
        public void EquatableEquals()
        {
            AngleGradians.Zero.Equals(AngleGradians.Right).Should().BeFalse();
            AngleGradians.Right.Equals(AngleGradians.Right).Should().BeTrue();
        }

        [Fact]
        public void OperatorEquality()
        {
            (AngleGradians.Zero == AngleGradians.Right).Should().BeFalse();
            (AngleGradians.Right == AngleGradians.Right).Should().BeTrue();
        }

        [Fact]
        public void OperatorInequality()
        {
            (AngleGradians.Zero != AngleGradians.Right).Should().BeTrue();
            (AngleGradians.Right != AngleGradians.Right).Should().BeFalse();
        }

        [Fact]
        public void ComparableCompareToObjectThrowsExcetionOnNull()
        {
            Action act = () => ((IComparable)AngleGradians.Right).CompareTo(null);
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("Argument has to be an GradiansAngle.\r\nParameter name: obj");
        }

        [Fact]
        public void ComparableCompareToObjectThrowsExcetionOnOtherType()
        {
            Action act = () => ((IComparable)AngleGradians.Right).CompareTo(90.0);
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("Argument has to be an GradiansAngle.\r\nParameter name: obj");
        }

        [Fact]
        public void ComparableCompareToObject()
        {
            ((IComparable)AngleGradians.Right).CompareTo((object)AngleGradians.Straight).Should().BeNegative();
            ((IComparable)AngleGradians.Right).CompareTo((object)AngleGradians.Right).Should().Be(0);
            ((IComparable)AngleGradians.Right).CompareTo((object)AngleGradians.Zero).Should().BePositive();
        }

        [Fact]
        public void ComparableCompareToAngle()
        {
            ((IComparable)AngleGradians.Right).CompareTo(AngleGradians.Straight).Should().BeNegative();
            ((IComparable)AngleGradians.Right).CompareTo(AngleGradians.Right).Should().Be(0);
            ((IComparable)AngleGradians.Right).CompareTo(AngleGradians.Zero).Should().BePositive();
        }

        [Fact]
        public void CompareTwoAngles()
        {
            Angle.Compare(AngleGradians.Right, AngleGradians.Straight).Should().BeNegative();
            Angle.Compare(AngleGradians.Right, AngleGradians.Right).Should().Be(0);
            Angle.Compare(AngleGradians.Right, AngleGradians.Zero).Should().BePositive();
            Angle.Compare(AngleGradians.Right + AngleGradians.Full, AngleGradians.Straight).Should().BePositive();
            Angle.Compare(AngleGradians.Right, AngleGradians.Right + AngleGradians.Full).Should().BeNegative();
            Angle.Compare(AngleGradians.Right, AngleGradians.Zero + AngleGradians.Full).Should().BeNegative();
        }

        [Fact]
        public void CompareReducedTwoAngles()
        {
            Angle.CompareReduced(AngleGradians.Right, AngleGradians.Straight).Should().BeNegative();
            Angle.CompareReduced(AngleGradians.Right, AngleGradians.Right).Should().Be(0);
            Angle.CompareReduced(AngleGradians.Right, AngleGradians.Zero).Should().BePositive();
            Angle.CompareReduced(AngleGradians.Right + AngleGradians.Full, AngleGradians.Straight).Should().BeNegative();
            Angle.CompareReduced(AngleGradians.Right, AngleGradians.Right + AngleGradians.Full).Should().Be(0);
            Angle.CompareReduced(AngleGradians.Right, AngleGradians.Zero + AngleGradians.Full).Should().BePositive();
        }

        [Fact]
        public void LessThanOperator()
        {
            (AngleGradians.Zero < AngleGradians.Right).Should().BeTrue();
            (AngleGradians.Right < AngleGradians.Right).Should().BeFalse();
            (Angle.FromGradians(180) < AngleGradians.Right).Should().BeFalse();
        }

        [Fact]
        public void LessThanOrEqualToOperator()
        {
            (AngleGradians.Zero <= AngleGradians.Right).Should().BeTrue();
            (AngleGradians.Right <= AngleGradians.Right).Should().BeTrue();
            (Angle.FromGradians(180) <= AngleGradians.Right).Should().BeFalse();
        }

        [Fact]
        public void GreaterThanOperator()
        {
            (AngleGradians.Zero > AngleGradians.Right).Should().BeFalse();
            (AngleGradians.Right > AngleGradians.Right).Should().BeFalse();
            (Angle.FromGradians(180) > AngleGradians.Right).Should().BeTrue();
        }

        [Fact]
        public void GreaterThanOrEqualToOperator()
        {
            (AngleGradians.Zero >= AngleGradians.Right).Should().BeFalse();
            (AngleGradians.Right >= AngleGradians.Right).Should().BeTrue();
            (Angle.FromGradians(180) >= AngleGradians.Right).Should().BeTrue();
        }

        [Fact]
        public void ReduceIsDefinedCorrectly()
        {
            Angle.Reduce(AngleGradians.Zero).Should().Be(AngleGradians.Zero);
            Angle.Reduce(AcuteAngle).Should().Be(AcuteAngle);
            Angle.Reduce(AngleGradians.Right).Should().Be(AngleGradians.Right);
            Angle.Reduce(AngleGradians.Right + AcuteAngle).Should().Be(AngleGradians.Right + AcuteAngle);
            Angle.Reduce(AngleGradians.Straight).Should().Be(AngleGradians.Straight);

            Angle.Reduce(AngleGradians.Full).Should().Be(AngleGradians.Zero);
            Angle.Reduce(AngleGradians.Full + AcuteAngle).Should().Be(AcuteAngle);
            Angle.Reduce(AngleGradians.Full + AngleGradians.Right).Should().Be(AngleGradians.Right);
            Angle.Reduce(AngleGradians.Full + AngleGradians.Right + AcuteAngle).Should()
                .BeEquivalentTo(AngleGradians.Right + AcuteAngle, options => options
                .Using<double>(ctx => ctx.Subject.Should().BeApproximately(ctx.Expectation, Math.Pow(10, -8)))
                .When(info => info.SelectedMemberPath == "Gradians"));

            Angle.Reduce(AngleGradians.Full + AngleGradians.Straight).Should().Be(AngleGradians.Straight);

            Angle.Reduce(-AngleGradians.Full).Should().Be(AngleGradians.Zero);
            Angle.Reduce(-AcuteAngle).Should().Be(AngleGradians.Full - AcuteAngle);
            Angle.Reduce(-AngleGradians.Right).Should().Be(AngleGradians.Full - AngleGradians.Right);
            Angle.Reduce(-AngleGradians.Straight).Should().Be(AngleGradians.Straight);
            Angle.Reduce(-AngleGradians.Straight - AngleGradians.Right).Should().Be(AngleGradians.Right);
        }

        [Fact]
        public void GetQuadrantIsDefinedCorrectly()
        {
            var AcuteAngle = AngleGradians.Right / 2.0;

            Angle.GetQuadrant(AngleGradians.Zero).Should().Be(Quadrant.First);
            Angle.GetQuadrant(AcuteAngle).Should().Be(Quadrant.First);
            Angle.GetQuadrant(AngleGradians.Right).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(AngleGradians.Right + AcuteAngle).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(AngleGradians.Straight).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(AngleGradians.Straight + AcuteAngle).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(AngleGradians.Straight + AngleGradians.Right).Should().Be(Quadrant.Fourth);
            Angle.GetQuadrant(AngleGradians.Straight + AngleGradians.Right + AcuteAngle).Should().Be(Quadrant.Fourth);

            Angle.GetQuadrant(AngleGradians.Full).Should().Be(Quadrant.First);
            Angle.GetQuadrant(AngleGradians.Full + AcuteAngle).Should().Be(Quadrant.First);
            Angle.GetQuadrant(AngleGradians.Full + AngleGradians.Right).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(AngleGradians.Full + AngleGradians.Right + AcuteAngle).Should().Be(Quadrant.Second);
            Angle.GetQuadrant(AngleGradians.Full + AngleGradians.Straight).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(AngleGradians.Full + AngleGradians.Straight + AcuteAngle).Should().Be(Quadrant.Third);
            Angle.GetQuadrant(AngleGradians.Full + AngleGradians.Straight + AngleGradians.Right).Should().Be(Quadrant.Fourth);
            Angle.GetQuadrant(AngleGradians.Full + AngleGradians.Straight + AngleGradians.Right + AcuteAngle).Should().Be(Quadrant.Fourth);
        }

        [Fact]
        public void ReferenceIsDefinedCorrectly()
        {
            Angle.GetReference(AngleGradians.Zero).Should().Be(AngleGradians.Zero);
            Angle.GetReference(AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(AngleGradians.Right).Should().Be(AngleGradians.Right);
            Angle.GetReference(AngleGradians.Right + AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(AngleGradians.Straight).Should().Be(AngleGradians.Zero);
            Angle.GetReference(AngleGradians.Straight + AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(AngleGradians.Straight + AngleGradians.Right).Should().Be(AngleGradians.Right);
            Angle.GetReference(AngleGradians.Straight + AngleGradians.Right + AcuteAngle).Should().Be(AcuteAngle);
            Angle.GetReference(AngleGradians.Full).Should().Be(AngleGradians.Zero);
        }

        [Fact]
        public void IsZeroIsDefinedCorrectly()
        {
            Angle.IsZero(AngleGradians.Zero).Should().BeTrue();
            Angle.IsZero(AcuteAngle).Should().BeFalse();
            Angle.IsZero(AngleGradians.Right).Should().BeFalse();
            Angle.IsZero(AngleGradians.Right + AcuteAngle).Should().BeFalse();
            Angle.IsZero(AngleGradians.Straight).Should().BeFalse();
            Angle.IsZero(AngleGradians.Straight + AngleGradians.Right).Should().BeFalse();
            Angle.IsZero(AngleGradians.Full).Should().BeTrue();

            Angle.IsZero(-AcuteAngle).Should().BeFalse();
            Angle.IsZero(-AngleGradians.Right).Should().BeFalse();
            Angle.IsZero(-AngleGradians.Right - AcuteAngle).Should().BeFalse();
            Angle.IsZero(-AngleGradians.Straight).Should().BeFalse();
            Angle.IsZero(-AngleGradians.Straight - AngleGradians.Right).Should().BeFalse();
            Angle.IsZero(-AngleGradians.Full).Should().BeTrue();
        }

        [Fact]
        public void IsAcuteIsDefinedCorrectly()
        {
            Angle.IsAcute(AngleGradians.Zero).Should().BeFalse();
            Angle.IsAcute(AcuteAngle).Should().BeTrue();
            Angle.IsAcute(AngleGradians.Right).Should().BeFalse();
            Angle.IsAcute(AngleGradians.Right + AcuteAngle).Should().BeFalse();
            Angle.IsAcute(AngleGradians.Straight).Should().BeFalse();
            Angle.IsAcute(AngleGradians.Straight + AngleGradians.Right).Should().BeFalse();
            Angle.IsAcute(AngleGradians.Full).Should().BeFalse();

            Angle.IsAcute(-AcuteAngle).Should().BeTrue();
            Angle.IsAcute(-AngleGradians.Right).Should().BeFalse();
            Angle.IsAcute(-AngleGradians.Right - AcuteAngle).Should().BeFalse();
            Angle.IsAcute(-AngleGradians.Straight).Should().BeFalse();
            Angle.IsAcute(-AngleGradians.Straight - AngleGradians.Right).Should().BeFalse();
            Angle.IsAcute(-AngleGradians.Full).Should().BeFalse();
        }

        [Fact]
        public void IsRightIsDefinedCorrectly()
        {
            Angle.IsRight(AngleGradians.Zero).Should().BeFalse();
            Angle.IsRight(AcuteAngle).Should().BeFalse();
            Angle.IsRight(AngleGradians.Right).Should().BeTrue();
            Angle.IsRight(AngleGradians.Right + AcuteAngle).Should().BeFalse();
            Angle.IsRight(AngleGradians.Straight).Should().BeFalse();
            Angle.IsRight(AngleGradians.Straight + AngleGradians.Right).Should().BeFalse();
            Angle.IsRight(AngleGradians.Full).Should().BeFalse();

            Angle.IsRight(-AcuteAngle).Should().BeFalse();
            Angle.IsRight(-AngleGradians.Right).Should().BeTrue();
            Angle.IsRight(-AngleGradians.Right - AcuteAngle).Should().BeFalse();
            Angle.IsRight(-AngleGradians.Straight).Should().BeFalse();
            Angle.IsRight(-AngleGradians.Straight - AngleGradians.Right).Should().BeFalse();
            Angle.IsRight(-AngleGradians.Full).Should().BeFalse();
        }

        [Fact]
        public void IsObtuseIsDefinedCorrectly()
        {
            Angle.IsObtuse(AngleGradians.Zero).Should().BeFalse();
            Angle.IsObtuse(AcuteAngle).Should().BeFalse();
            Angle.IsObtuse(AngleGradians.Right).Should().BeFalse();
            Angle.IsObtuse(AngleGradians.Right + AcuteAngle).Should().BeTrue();
            Angle.IsObtuse(AngleGradians.Straight).Should().BeFalse();
            Angle.IsObtuse(AngleGradians.Straight + AngleGradians.Right).Should().BeFalse();
            Angle.IsObtuse(AngleGradians.Full).Should().BeFalse();

            Angle.IsObtuse(-AcuteAngle).Should().BeFalse();
            Angle.IsObtuse(-AngleGradians.Right).Should().BeFalse();
            Angle.IsObtuse(-AngleGradians.Right - AcuteAngle).Should().BeTrue();
            Angle.IsObtuse(-AngleGradians.Straight).Should().BeFalse();
            Angle.IsObtuse(-AngleGradians.Straight - AngleGradians.Right).Should().BeFalse();
            Angle.IsObtuse(-AngleGradians.Full).Should().BeFalse();
        }

        [Fact]
        public void IsStraightIsDefinedCorrectly()
        {
            Angle.IsStraight(AngleGradians.Zero).Should().BeFalse();
            Angle.IsStraight(AcuteAngle).Should().BeFalse();
            Angle.IsStraight(AngleGradians.Right).Should().BeFalse();
            Angle.IsStraight(AngleGradians.Right - AcuteAngle).Should().BeFalse();
            Angle.IsStraight(AngleGradians.Straight).Should().BeTrue();
            Angle.IsStraight(AngleGradians.Straight - AngleGradians.Right).Should().BeFalse();
            Angle.IsStraight(AngleGradians.Full).Should().BeFalse();

            Angle.IsStraight(-AcuteAngle).Should().BeFalse();
            Angle.IsStraight(-AngleGradians.Right).Should().BeFalse();
            Angle.IsStraight(-AngleGradians.Right - AcuteAngle).Should().BeFalse();
            Angle.IsStraight(-AngleGradians.Straight).Should().BeTrue();
            Angle.IsStraight(-AngleGradians.Straight - AngleGradians.Right).Should().BeFalse();
            Angle.IsStraight(-AngleGradians.Full).Should().BeFalse();
        }

        [Fact]
        public void IsReflexIsDefinedCorrectly()
        {
            Angle.IsReflex(AngleGradians.Zero).Should().BeFalse();
            Angle.IsReflex(AcuteAngle).Should().BeFalse();
            Angle.IsReflex(AngleGradians.Right).Should().BeFalse();
            Angle.IsReflex(AngleGradians.Right + AcuteAngle).Should().BeFalse();
            Angle.IsReflex(AngleGradians.Straight).Should().BeFalse();
            Angle.IsReflex(AngleGradians.Straight + AngleGradians.Right).Should().BeTrue();
            Angle.IsReflex(AngleGradians.Full).Should().BeFalse();

            Angle.IsReflex(-AcuteAngle).Should().BeFalse();
            Angle.IsReflex(-AngleGradians.Right).Should().BeFalse();
            Angle.IsReflex(-AngleGradians.Right - AcuteAngle).Should().BeFalse();
            Angle.IsReflex(-AngleGradians.Straight).Should().BeFalse();
            Angle.IsReflex(-AngleGradians.Straight - AngleGradians.Right).Should().BeTrue();
            Angle.IsReflex(-AngleGradians.Full).Should().BeFalse();
        }

        [Fact]
        public void IsObliqueIsDefinedCorrectly()
        {
            Angle.IsOblique(AngleGradians.Zero).Should().BeFalse();
            Angle.IsOblique(AcuteAngle).Should().BeTrue();
            Angle.IsOblique(AngleGradians.Right).Should().BeFalse();
            Angle.IsOblique(AngleGradians.Right + AcuteAngle).Should().BeTrue();
            Angle.IsOblique(AngleGradians.Straight).Should().BeFalse();
            Angle.IsOblique(AngleGradians.Straight + AngleGradians.Right).Should().BeFalse();
            Angle.IsOblique(AngleGradians.Full).Should().BeFalse();

            Angle.IsOblique(-AcuteAngle).Should().BeTrue();
            Angle.IsOblique(-AngleGradians.Right).Should().BeFalse();
            Angle.IsOblique(-AngleGradians.Right - AcuteAngle).Should().BeTrue();
            Angle.IsOblique(-AngleGradians.Straight).Should().BeFalse();
            Angle.IsOblique(-AngleGradians.Straight - AngleGradians.Right).Should().BeFalse();
            Angle.IsOblique(-AngleGradians.Full).Should().BeFalse();
        }

        [Fact]
        public void LerpIsDefinedCorrectly()
        {
            Angle.Lerp(AcuteAngle, AngleGradians.Right + AcuteAngle, -0.5).Should().Be(AngleGradians.Zero);
            Angle.Lerp(AcuteAngle, AngleGradians.Right + AcuteAngle, 0.0).Should().Be(AcuteAngle);
            Angle.Lerp(AcuteAngle, AngleGradians.Right + AcuteAngle, 0.5).Should().Be(AngleGradians.Right);
            Angle.Lerp(AcuteAngle, AngleGradians.Right + AcuteAngle, 1.0).Should().Be(AngleGradians.Right + AcuteAngle);
            Angle.Lerp(AcuteAngle, AngleGradians.Right + AcuteAngle, 1.5).Should().Be(AngleGradians.Straight);

            Angle.Lerp(-AcuteAngle, -AngleGradians.Right - AcuteAngle, -0.5).Should().Be(AngleGradians.Zero);
            Angle.Lerp(-AcuteAngle, -AngleGradians.Right - AcuteAngle, 0.0).Should().Be(-AcuteAngle);
            Angle.Lerp(-AcuteAngle, -AngleGradians.Right - AcuteAngle, 0.5).Should().Be(-AngleGradians.Right);
            Angle.Lerp(-AcuteAngle, -AngleGradians.Right - AcuteAngle, 1.0).Should().Be(-AngleGradians.Right - AcuteAngle);
            Angle.Lerp(-AcuteAngle, -AngleGradians.Right - AcuteAngle, 1.5).Should().Be(-AngleGradians.Straight);

            Angle.Lerp(AngleGradians.Right + AcuteAngle, AcuteAngle, -0.5).Should().Be(AngleGradians.Straight);
            Angle.Lerp(AngleGradians.Right + AcuteAngle, AcuteAngle, 0.0).Should().Be(AngleGradians.Right + AcuteAngle);
            Angle.Lerp(AngleGradians.Right + AcuteAngle, AcuteAngle, 0.5).Should().Be(AngleGradians.Right);
            Angle.Lerp(AngleGradians.Right + AcuteAngle, AcuteAngle, 1.0).Should().Be(AcuteAngle);
            Angle.Lerp(AngleGradians.Right + AcuteAngle, AcuteAngle, 1.5).Should().Be(AngleGradians.Zero);
        }

        [Fact]
        public void ToStringIsDefinedCorrectly()
        {
#if NET35
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
#else
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
#endif

            AngleGradians.Straight.ToString().Should().Be("200");
            AngleGradians.Straight.ToString("0.00").Should().Be("200.00");
            AngleGradians.Straight.ToString("0.00", new CultureInfo("pt-PT")).Should().Be("200,00");
        }
    }
}
