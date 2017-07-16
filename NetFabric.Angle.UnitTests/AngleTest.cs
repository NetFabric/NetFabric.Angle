using FluentAssertions;
using System;
using System.Globalization;
using Xunit;

namespace NetFabric.UnitTests
{
    public class AngleTests
    {
        [Fact]
        public void FromRadiansCreatesAngleCorrectly()
        {
            var angle = Angle.FromRadians(0.0);
            angle.ToRadians().Should().Be(0.0);

            angle = Angle.FromRadians(Math.PI);
            angle.ToRadians().Should().Be(Math.PI);

            angle = Angle.FromRadians(double.NaN);
            angle.ToRadians().Should().Be(double.NaN);
        }

        [Fact]
        public void FromDegreesConvertsToRadiansCorrectly()
        {
            var angle = Angle.FromDegrees(0.0);
            angle.ToRadians().Should().Be(0.0);

            angle = Angle.FromDegrees(45.0);
            angle.ToRadians().Should().Be(Math.PI / 4.0);

            angle = Angle.FromDegrees(90.0);
            angle.ToRadians().Should().Be(Math.PI / 2.0);

            angle = Angle.FromDegrees(180.0);
            angle.ToRadians().Should().Be(Math.PI);

            angle = Angle.FromDegrees(360.0);
            angle.ToRadians().Should().Be(Math.PI * 2.0);

            angle = Angle.FromDegrees(double.NaN);
            angle.ToRadians().Should().Be(Double.NaN);
        }

        [Fact]
        public void ToDegreesConvertsFromRadiansCorrectly()
        {
            var angle = Angle.FromRadians(0.0);
            angle.ToDegrees().Should().Be(0.0);

            angle = Angle.FromRadians(Math.PI / 4.0);
            angle.ToDegrees().Should().Be(45.0);

            angle = Angle.FromRadians(Math.PI / 2.0);
            angle.ToDegrees().Should().Be(90.0);

            angle = Angle.FromRadians(Math.PI);
            angle.ToDegrees().Should().Be(180.0);

            angle = Angle.FromRadians(Math.PI * 2.0);
            angle.ToDegrees().Should().Be(360.0);

            angle = Angle.FromRadians(double.NaN);
            angle.ToDegrees().Should().Be(Double.NaN);
        }

        [Fact]
        public void FromDegreesMinutesConvertsToRadiansCorrectly()
        {
            var angle = Angle.FromDegrees(0, 0.0);
            angle.ToRadians().Should().Be(0.0);

            angle = Angle.FromDegrees(40, 30.0);
            angle.ToRadians().Should().BeApproximately(0.706858347, 0.000000001);

            angle = Angle.FromDegrees(-40, 30.0);
            angle.ToRadians().Should().BeApproximately(-0.706858347, 0.000000001);
        }

        [Fact]
        public void ToDegreesMinutesConvertsFromRadiansCorrectly()
        {

            var angle = Angle.FromRadians(0.0);
            angle.ToDegrees(out int degrees, out double minutes);
            degrees.Should().Be(0);
            minutes.Should().BeApproximately(0.0, 0.000001);

            angle = Angle.FromRadians(0.706858347);
            angle.ToDegrees(out degrees, out minutes);
            degrees.Should().Be(40);
            minutes.Should().BeApproximately(30.0, 0.000001);

            angle = Angle.FromRadians(-0.706858347);
            angle.ToDegrees(out degrees, out minutes);
            degrees.Should().Be(-40);
            minutes.Should().BeApproximately(30.0, 0.000001);
        }

        [Fact]
        public void FromDegreesMinutesSecondsConvertsToRadiansCorrectly()
        {
            var angle = Angle.FromDegrees(0, 0, 0.0);
            angle.ToRadians().Should().Be(0.0);

            angle = Angle.FromDegrees(40, 30, 30.0);
            angle.ToRadians().Should().BeApproximately(0.707003791, 0.000000001);

            angle = Angle.FromDegrees(-40, 30, 30.0);
            angle.ToRadians().Should().BeApproximately(-0.707003791, 0.000000001);
        }

        [Fact]
        public void ToDegreesMinutesSecondsConvertsFromRadiansCorrectly()
        {

            var angle = Angle.FromRadians(0.0);
            angle.ToDegrees(out int degrees, out int minutes, out double seconds);
            degrees.Should().Be(0);
            minutes.Should().Be(0);
            seconds.Should().BeApproximately(0.0, 0.001);

            angle = Angle.FromRadians(0.707003791);
            angle.ToDegrees(out degrees, out minutes, out seconds);
            degrees.Should().Be(40);
            minutes.Should().Be(30);
            seconds.Should().BeApproximately(30.0, 0.001);

            angle = Angle.FromRadians(-0.707003791);
            angle.ToDegrees(out degrees, out minutes, out seconds);
            degrees.Should().Be(-40);
            minutes.Should().Be(30);
            seconds.Should().BeApproximately(30.0, 0.001);
        }

        [Fact]
        public void FromGradiansConvertsToRadiansCorrectly()
        {
            var angle = Angle.FromGradians(0.0);
            angle.ToRadians().Should().Be(0.0);

            angle = Angle.FromGradians(50.0);
            angle.ToRadians().Should().Be(Math.PI / 4.0);

            angle = Angle.FromGradians(100.0);
            angle.ToRadians().Should().Be(Math.PI / 2.0);

            angle = Angle.FromGradians(200.0);
            angle.ToRadians().Should().Be(Math.PI);

            angle = Angle.FromGradians(400.0);
            angle.ToRadians().Should().Be(Math.PI * 2.0);

            angle = Angle.FromGradians(double.NaN);
            angle.ToRadians().Should().Be(Double.NaN);
        }

        [Fact]
        public void ToGradiansConvertsFromRadiansCorrectly()
        {
            var angle = Angle.FromRadians(0.0);
            angle.ToGradians().Should().Be(0.0);

            angle = Angle.FromRadians(Math.PI / 4.0);
            angle.ToGradians().Should().Be(50.0);

            angle = Angle.FromRadians(Math.PI / 2.0);
            angle.ToGradians().Should().Be(100.0);

            angle = Angle.FromRadians(Math.PI);
            angle.ToGradians().Should().Be(200.0);

            angle = Angle.FromRadians(Math.PI * 2.0);
            angle.ToGradians().Should().Be(400.0);

            angle = Angle.FromRadians(double.NaN);
            angle.ToGradians().Should().Be(Double.NaN);
        }

        [Fact]
        public void ZeroAngleIsDefinedCorrectly()
        {
            var angle = Angle.Zero;
            angle.ToGradians().Should().Be(0.0);
            angle.ToDegrees().Should().Be(0.0);
            angle.ToGradians().Should().Be(0.0);
        }

        [Fact]
        public void RightAngleIsDefinedCorrectly()
        {
            var angle = Angle.Right;
            angle.ToRadians().Should().Be(Math.PI / 2.0);
            angle.ToDegrees().Should().Be(90.0);
            angle.ToGradians().Should().Be(100.0);
        }

        [Fact]
        public void StraightAngleIsDefinedCorrectly()
        {
            var angle = Angle.Straight;
            angle.ToRadians().Should().Be(Math.PI);
            angle.ToDegrees().Should().Be(180.0);
            angle.ToGradians().Should().Be(200.0);
        }

        [Fact]
        public void FullAngleIsDefinedCorrectly()
        {
            var angle = Angle.Full;
            angle.ToRadians().Should().Be(Math.PI * 2.0);
            angle.ToDegrees().Should().Be(360.0);
            angle.ToGradians().Should().Be(400.0);
        }

        [Fact]
        public void ObjectEquals()
        {
            Angle.Right.Equals(null).Should().BeFalse();
            Angle.Right.Equals(90.0).Should().BeFalse();
            Angle.Zero.Equals((object)Angle.Right).Should().BeFalse();
            Angle.Right.Equals((object)Angle.Right).Should().BeTrue();
        }

        [Fact]
        public void ObjectGetHashCode()
        {
            Angle.Zero.GetHashCode().Should().NotBe(Angle.Right.GetHashCode());
            Angle.Right.GetHashCode().Should().Be(Angle.Right.GetHashCode());
        }

        [Fact]
        public void EquatableEquals()
        {
            Angle.Zero.Equals(Angle.Right).Should().BeFalse();
            Angle.Right.Equals(Angle.Right).Should().BeTrue();
        }

        [Fact]
        public void AproximatelyEquals()
        {
            Angle.Equals(Angle.Right, Angle.FromDegrees(90.00001), Angle.Zero).Should().BeFalse();
            Angle.Equals(Angle.Right, Angle.FromDegrees(90.00001), Angle.FromDegrees(0.001)).Should().BeTrue();
            Angle.Equals(Angle.Right, Angle.FromDegrees(89.99999), Angle.FromDegrees(0.001)).Should().BeTrue();
        }

        [Fact]
        public void OperatorEquality()
        {
            (Angle.FromDegrees(0) == Angle.FromDegrees(90)).Should().BeFalse();
            (Angle.FromDegrees(90) == Angle.FromDegrees(90)).Should().BeTrue();
        }

        [Fact]
        public void OperatorInequality()
        {
            (Angle.FromDegrees(0) != Angle.FromDegrees(90)).Should().BeTrue();
            (Angle.FromDegrees(90) != Angle.FromDegrees(90)).Should().BeFalse();
        }

        [Fact]
        public void ComparableCompareToObjectThrowsExcetionOnNull()
        {
            Action act = () => Angle.Right.CompareTo(null);
            act.ShouldThrow<ArgumentException>()
                .WithMessage("Argument has to be an Angle.\r\nParameter name: obj");
        }

        [Fact]
        public void ComparableCompareToObjectThrowsExcetionOnOtherType()
        {
            Action act = () => Angle.Right.CompareTo(90.0);
            act.ShouldThrow<ArgumentException>()
                .WithMessage("Argument has to be an Angle.\r\nParameter name: obj");
        }

        [Fact]
        public void ComparableCompareToObject()
        {
            Angle.Right.CompareTo((object)Angle.Straight).Should().BeNegative();
            Angle.Right.CompareTo((object)Angle.Right).Should().Be(0);
            Angle.Right.CompareTo((object)Angle.Zero).Should().BePositive();
        }

        [Fact]
        public void ComparableCompareToAngle()
        {
            Angle.Right.CompareTo(Angle.Straight).Should().BeNegative();
            Angle.Right.CompareTo(Angle.Right).Should().Be(0);
            Angle.Right.CompareTo(Angle.Zero).Should().BePositive();
        }

        [Fact]
        public void CompareTwoAngles()
        {
            Angle.Compare(Angle.Right, Angle.Straight).Should().BeNegative();
            Angle.Compare(Angle.Right, Angle.Right).Should().Be(0);
            Angle.Compare(Angle.Right, Angle.Zero).Should().BePositive();
            Angle.Compare(Angle.Right + Angle.Full, Angle.Straight).Should().BePositive();
            Angle.Compare(Angle.Right, Angle.Right + Angle.Full).Should().BeNegative();
            Angle.Compare(Angle.Right, Angle.Zero + Angle.Full).Should().BeNegative();
        }

        [Fact]
        public void CompareReducedTwoAngles()
        {
            Angle.CompareReduced(Angle.Right, Angle.Straight).Should().BeNegative();
            Angle.CompareReduced(Angle.Right, Angle.Right).Should().Be(0);
            Angle.CompareReduced(Angle.Right, Angle.Zero).Should().BePositive();
            Angle.CompareReduced(Angle.Right + Angle.Full, Angle.Straight).Should().BeNegative();
            Angle.CompareReduced(Angle.Right, Angle.Right + Angle.Full).Should().Be(0);
            Angle.CompareReduced(Angle.Right, Angle.Zero + Angle.Full).Should().BePositive();
        }

        [Fact]
        public void LessThanOperator()
        {
            (Angle.Zero < Angle.FromDegrees(90)).Should().BeTrue();
            (Angle.FromDegrees(90) < Angle.FromDegrees(90)).Should().BeFalse();
            (Angle.FromDegrees(180) < Angle.FromDegrees(90)).Should().BeFalse();
        }

        [Fact]
        public void LessThanOrEqualToOperator()
        {
            (Angle.FromDegrees(0) <= Angle.FromDegrees(90)).Should().BeTrue();
            (Angle.FromDegrees(90) <= Angle.FromDegrees(90)).Should().BeTrue();
            (Angle.FromDegrees(180) <= Angle.FromDegrees(90)).Should().BeFalse();
        }

        [Fact]
        public void GreaterThanOperator()
        {
            (Angle.FromDegrees(0) > Angle.FromDegrees(90)).Should().BeFalse();
            (Angle.FromDegrees(90) > Angle.FromDegrees(90)).Should().BeFalse();
            (Angle.FromDegrees(180) > Angle.FromDegrees(90)).Should().BeTrue();
        }

        [Fact]
        public void GreaterThanOrEqualToOperator()
        {
            (Angle.FromDegrees(0) >= Angle.FromDegrees(90)).Should().BeFalse();
            (Angle.FromDegrees(90) >= Angle.FromDegrees(90)).Should().BeTrue();
            (Angle.FromDegrees(180) >= Angle.FromDegrees(90)).Should().BeTrue();
        }

        [Fact]
        public void ReduceIsDefinedCorrectly()
        {
            Angle.Reduce(Angle.Zero).Should().Be(Angle.Zero);
            Angle.Reduce(Angle.FromDegrees(45)).Should().Be(Angle.FromDegrees(45));
            Angle.Reduce(Angle.Right).Should().Be(Angle.Right);
            Angle.Reduce(Angle.FromDegrees(135)).Should().Be(Angle.FromDegrees(135));
            Angle.Reduce(Angle.Straight).Should().Be(Angle.Straight);

            Angle.Reduce(Angle.Full).Should().Be(Angle.Zero);
            Angle.Reduce(Angle.FromDegrees(45) + Angle.Full).Should().Be(Angle.FromDegrees(45));
            Angle.Reduce(Angle.Right + Angle.Full).Should().Be(Angle.Right);
            Angle.Reduce(Angle.FromDegrees(135) + Angle.Full).ToRadians().Should().BeApproximately(Angle.FromDegrees(135).ToRadians(), 0.000001);
            Angle.Reduce(Angle.Straight + Angle.Full).Should().Be(Angle.Straight);

            Angle.Reduce(-Angle.Full).Should().Be(Angle.Zero);
            Angle.Reduce(-Angle.FromDegrees(45)).Should().Be(Angle.FromDegrees(315));
            Angle.Reduce(-Angle.Right).Should().Be(Angle.FromDegrees(270));
            Angle.Reduce(-Angle.Straight).Should().Be(Angle.Straight);
            Angle.Reduce(-Angle.FromDegrees(270)).Should().Be(Angle.Right);

        }

        [Fact]
        public void GetQuadrantIsDefinedCorrectly()
        {
            Angle.GetQuadrant(Angle.Zero).Should().Be(Angle.Quadrant.First);
            Angle.GetQuadrant(Angle.FromDegrees(45)).Should().Be(Angle.Quadrant.First);
            Angle.GetQuadrant(Angle.Right).Should().Be(Angle.Quadrant.Second);
            Angle.GetQuadrant(Angle.FromDegrees(135)).Should().Be(Angle.Quadrant.Second);
            Angle.GetQuadrant(Angle.Straight).Should().Be(Angle.Quadrant.Third);
            Angle.GetQuadrant(Angle.FromDegrees(225)).Should().Be(Angle.Quadrant.Third);
            Angle.GetQuadrant(Angle.FromDegrees(270)).Should().Be(Angle.Quadrant.Fourth);
            Angle.GetQuadrant(Angle.FromDegrees(315)).Should().Be(Angle.Quadrant.Fourth);

            Angle.GetQuadrant(Angle.Full).Should().Be(Angle.Quadrant.First);
            Angle.GetQuadrant(Angle.FromDegrees(45) + Angle.Full).Should().Be(Angle.Quadrant.First);
            Angle.GetQuadrant(Angle.Right + Angle.Full).Should().Be(Angle.Quadrant.Second);
            Angle.GetQuadrant(Angle.FromDegrees(135) + Angle.Full).Should().Be(Angle.Quadrant.Second);
            Angle.GetQuadrant(Angle.Straight + Angle.Full).Should().Be(Angle.Quadrant.Third);
            Angle.GetQuadrant(Angle.FromDegrees(225) + Angle.Full).Should().Be(Angle.Quadrant.Third);
            Angle.GetQuadrant(Angle.FromDegrees(270) + Angle.Full).Should().Be(Angle.Quadrant.Fourth);
            Angle.GetQuadrant(Angle.FromDegrees(315) + Angle.Full).Should().Be(Angle.Quadrant.Fourth);

        }

        [Fact]
        public void ReferenceIsDefinedCorrectly()
        {
            Angle.GetReference(Angle.Zero).Should().Be(Angle.Zero);
            Angle.GetReference(Angle.FromDegrees(45)).Should().Be(Angle.FromDegrees(45));
            Angle.GetReference(Angle.Right).Should().Be(Angle.Right);
            Angle.GetReference(Angle.FromDegrees(135)).Should().Be(Angle.FromDegrees(45));
            Angle.GetReference(Angle.Straight).Should().Be(Angle.Zero);
            Angle.GetReference(Angle.FromDegrees(225)).Should().Be(Angle.FromDegrees(45));
            Angle.GetReference(Angle.FromDegrees(270)).Should().Be(Angle.Right);
            Angle.GetReference(Angle.FromDegrees(315)).Should().Be(Angle.FromDegrees(45));
            Angle.GetReference(Angle.Full).Should().Be(Angle.Zero);

            Angle.GetReference(Angle.FromDegrees(45) + Angle.Full).Should().Be(Angle.FromDegrees(45));
            Angle.GetReference(Angle.Right + Angle.Full).Should().Be(Angle.Right);
            Angle.GetReference(Angle.FromDegrees(135) + Angle.Full).ToRadians().Should().BeApproximately(Angle.FromDegrees(45).ToRadians(), 0.000001);

        }

        [Fact]
        public void IsAcuteIsDefinedCorrectly()
        {
            Angle.IsAcute(Angle.Zero).Should().BeFalse();
            Angle.IsAcute(Angle.FromDegrees(45)).Should().BeTrue();
            Angle.IsAcute(Angle.Right).Should().BeFalse();
            Angle.IsAcute(Angle.FromDegrees(135)).Should().BeFalse();
            Angle.IsAcute(Angle.Straight).Should().BeFalse();
            Angle.IsAcute(Angle.FromDegrees(270)).Should().BeFalse();
            Angle.IsAcute(Angle.Full).Should().BeFalse();

            Angle.IsAcute(-Angle.FromDegrees(45)).Should().BeTrue();
            Angle.IsAcute(-Angle.Right).Should().BeFalse();
            Angle.IsAcute(-Angle.FromDegrees(135)).Should().BeFalse();
            Angle.IsAcute(-Angle.Straight).Should().BeFalse();
            Angle.IsAcute(-Angle.FromDegrees(270)).Should().BeFalse();
            Angle.IsAcute(-Angle.Full).Should().BeFalse();
        }

        [Fact]
        public void IsRightIsDefinedCorrectly()
        {
            Angle.IsRight(Angle.Zero).Should().BeFalse();
            Angle.IsRight(Angle.FromDegrees(45)).Should().BeFalse();
            Angle.IsRight(Angle.Right).Should().BeTrue();
            Angle.IsRight(Angle.FromDegrees(135)).Should().BeFalse();
            Angle.IsRight(Angle.Straight).Should().BeFalse();
            Angle.IsRight(Angle.FromDegrees(270)).Should().BeFalse();
            Angle.IsRight(Angle.Full).Should().BeFalse();

            Angle.IsRight(-Angle.FromDegrees(45)).Should().BeFalse();
            Angle.IsRight(-Angle.Right).Should().BeTrue();
            Angle.IsRight(-Angle.FromDegrees(135)).Should().BeFalse();
            Angle.IsRight(-Angle.Straight).Should().BeFalse();
            Angle.IsRight(-Angle.FromDegrees(270)).Should().BeFalse();
            Angle.IsRight(-Angle.Full).Should().BeFalse();
        }

        [Fact]
        public void IsAproximatelyRightIsDefinedCorrectly()
        {
            Angle.IsRight(Angle.FromDegrees(90.00001), Angle.Zero).Should().BeFalse();
            Angle.IsRight(Angle.FromDegrees(90.00001), Angle.FromDegrees(0.001)).Should().BeTrue();
            Angle.IsRight(Angle.FromDegrees(89.99999), Angle.FromDegrees(0.001)).Should().BeTrue();
        }

        [Fact]
        public void IsObtuseIsDefinedCorrectly()
        {
            Angle.IsObtuse(Angle.Zero).Should().BeFalse();
            Angle.IsObtuse(Angle.FromDegrees(45)).Should().BeFalse();
            Angle.IsObtuse(Angle.Right).Should().BeFalse();
            Angle.IsObtuse(Angle.FromDegrees(135)).Should().BeTrue();
            Angle.IsObtuse(Angle.Straight).Should().BeFalse();
            Angle.IsObtuse(Angle.FromDegrees(270)).Should().BeFalse();
            Angle.IsObtuse(Angle.Full).Should().BeFalse();

            Angle.IsObtuse(-Angle.FromDegrees(45)).Should().BeFalse();
            Angle.IsObtuse(-Angle.Right).Should().BeFalse();
            Angle.IsObtuse(-Angle.FromDegrees(135)).Should().BeTrue();
            Angle.IsObtuse(-Angle.Straight).Should().BeFalse();
            Angle.IsObtuse(-Angle.FromDegrees(270)).Should().BeFalse();
            Angle.IsObtuse(-Angle.Full).Should().BeFalse();
        }

        [Fact]
        public void IsStraightIsDefinedCorrectly()
        {
            Angle.IsStraight(Angle.Zero).Should().BeFalse();
            Angle.IsStraight(Angle.FromDegrees(45)).Should().BeFalse();
            Angle.IsStraight(Angle.Right).Should().BeFalse();
            Angle.IsStraight(Angle.FromDegrees(135)).Should().BeFalse();
            Angle.IsStraight(Angle.Straight).Should().BeTrue();
            Angle.IsStraight(Angle.FromDegrees(270)).Should().BeFalse();
            Angle.IsStraight(Angle.Full).Should().BeFalse();

            Angle.IsStraight(-Angle.FromDegrees(45)).Should().BeFalse();
            Angle.IsStraight(-Angle.Right).Should().BeFalse();
            Angle.IsStraight(-Angle.FromDegrees(135)).Should().BeFalse();
            Angle.IsStraight(-Angle.Straight).Should().BeTrue();
            Angle.IsStraight(-Angle.FromDegrees(270)).Should().BeFalse();
            Angle.IsStraight(-Angle.Full).Should().BeFalse();
        }

        [Fact]
        public void IsAproximatelyStraightIsDefinedCorrectly()
        {
            Angle.IsStraight(Angle.FromDegrees(180.00001), Angle.Zero).Should().BeFalse();
            Angle.IsStraight(Angle.FromDegrees(180.00001), Angle.FromDegrees(0.001)).Should().BeTrue();
            Angle.IsStraight(Angle.FromDegrees(179.99999), Angle.FromDegrees(0.001)).Should().BeTrue();
        }

        [Fact]
        public void IsReflexIsDefinedCorrectly()
        {
            Angle.IsReflex(Angle.Zero).Should().BeFalse();
            Angle.IsReflex(Angle.FromDegrees(45)).Should().BeFalse();
            Angle.IsReflex(Angle.Right).Should().BeFalse();
            Angle.IsReflex(Angle.FromDegrees(135)).Should().BeFalse();
            Angle.IsReflex(Angle.Straight).Should().BeFalse();
            Angle.IsReflex(Angle.FromDegrees(270)).Should().BeTrue();
            Angle.IsReflex(Angle.Full).Should().BeFalse();

            Angle.IsReflex(-Angle.FromDegrees(45)).Should().BeFalse();
            Angle.IsReflex(-Angle.Right).Should().BeFalse();
            Angle.IsReflex(-Angle.FromDegrees(135)).Should().BeFalse();
            Angle.IsReflex(-Angle.Straight).Should().BeFalse();
            Angle.IsReflex(-Angle.FromDegrees(270)).Should().BeTrue();
            Angle.IsReflex(-Angle.Full).Should().BeFalse();
        }

        [Fact]
        public void LerpIsDefinedCorrectly()
        {
            Angle.Lerp(Angle.FromDegrees(45.0), Angle.FromDegrees(135.0), -0.5).Should().Be(Angle.FromDegrees(0.0));
            Angle.Lerp(Angle.FromDegrees(45.0), Angle.FromDegrees(135.0), 0.0).Should().Be(Angle.FromDegrees(45.0));
            Angle.Lerp(Angle.FromDegrees(45.0), Angle.FromDegrees(135.0), 0.5).Should().Be(Angle.FromDegrees(90.0));
            Angle.Lerp(Angle.FromDegrees(45.0), Angle.FromDegrees(135.0), 1.0).Should().Be(Angle.FromDegrees(135.0));
            Angle.Lerp(Angle.FromDegrees(45.0), Angle.FromDegrees(135.0), 1.5).Should().Be(Angle.FromDegrees(180.0));

            Angle.Lerp(Angle.FromDegrees(-45.0), Angle.FromDegrees(-135.0), -0.5).Should().Be(Angle.FromDegrees(0.0));
            Angle.Lerp(Angle.FromDegrees(-45.0), Angle.FromDegrees(-135.0), 0.0).Should().Be(Angle.FromDegrees(-45.0));
            Angle.Lerp(Angle.FromDegrees(-45.0), Angle.FromDegrees(-135.0), 0.5).Should().Be(Angle.FromDegrees(-90.0));
            Angle.Lerp(Angle.FromDegrees(-45.0), Angle.FromDegrees(-135.0), 1.0).Should().Be(Angle.FromDegrees(-135.0));
            Angle.Lerp(Angle.FromDegrees(-45.0), Angle.FromDegrees(-135.0), 1.5).Should().Be(Angle.FromDegrees(-180.0));

            Angle.Lerp(Angle.FromDegrees(135.0), Angle.FromDegrees(45.0), -0.5).Should().Be(Angle.FromDegrees(180.0));
            Angle.Lerp(Angle.FromDegrees(135.0), Angle.FromDegrees(45.0), 0.0).Should().Be(Angle.FromDegrees(135.0));
            Angle.Lerp(Angle.FromDegrees(135.0), Angle.FromDegrees(45.0), 0.5).Should().Be(Angle.FromDegrees(90.0));
            Angle.Lerp(Angle.FromDegrees(135.0), Angle.FromDegrees(45.0), 1.0).Should().Be(Angle.FromDegrees(45.0));
            Angle.Lerp(Angle.FromDegrees(135.0), Angle.FromDegrees(45.0), 1.5).Should().Be(Angle.FromDegrees(0.0));
        }

        [Fact]
        public void ToStringIsDefinedCorrectly()
        {
#if NET35
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
#else
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
#endif

            Angle.Straight.ToString().Should().Be("3.14159265358979");

            Angle.Straight.ToString("R").Should().Be("3.14159265358979");
            Angle.Straight.ToString("D").Should().Be("180°");
            Angle.FromDegrees(12, 34.56).ToString("M").Should().Be("12° 34.56'");
            Angle.FromDegrees(12, 34, 56.78).ToString("S").Should().Be("12° 34' 56.7800000000018\"");
            Angle.Straight.ToString("G").Should().Be("200");

            Angle.Straight.ToString("R", new CultureInfo("pt-PT")).Should().Be("3,14159265358979");
            Angle.Straight.ToString("D", new CultureInfo("pt-PT")).Should().Be("180°");
            Angle.FromDegrees(12, 34.56).ToString("M", new CultureInfo("pt-PT")).Should().Be("12° 34,56'");
            Angle.FromDegrees(12, 34, 56.78).ToString("S", new CultureInfo("pt-PT")).Should().Be("12° 34' 56,7800000000018\"");
            Angle.Straight.ToString("G", new CultureInfo("pt-PT")).Should().Be("200");

            String.Format("Radians: {0:R}", Angle.Straight).Should().Be("Radians: 3.14159265358979");
            String.Format("Degrees: {0:D}", Angle.Straight).Should().Be("Degrees: 180°");
            String.Format("Degrees: {0:M}", Angle.FromDegrees(12, 34.56)).Should().Be("Degrees: 12° 34.56'");
            String.Format("Degrees: {0:S}", Angle.FromDegrees(12, 34, 56.78)).Should().Be("Degrees: 12° 34' 56.7800000000018\"");
            String.Format("Gradians: {0:G}", Angle.Straight).Should().Be("Gradians: 200");

            Angle.Straight.ToString("R2").Should().Be("3.14");
            Angle.Straight.ToString("D2").Should().Be("180.00°");
            Angle.FromDegrees(12, 34.56).ToString("M2").Should().Be("12° 34.56'");
            Angle.FromDegrees(12, 34, 56.78).ToString("S2").Should().Be("12° 34' 56.78\"");
            Angle.Straight.ToString("G2").Should().Be("200.00");

            Angle.Straight.ToString("R2", new CultureInfo("pt-PT")).Should().Be("3,14");
            Angle.Straight.ToString("D2", new CultureInfo("pt-PT")).Should().Be("180,00°");
            Angle.FromDegrees(12, 34.56).ToString("M2", new CultureInfo("pt-PT")).Should().Be("12° 34,56'");
            Angle.FromDegrees(12, 34, 56.78).ToString("S2", new CultureInfo("pt-PT")).Should().Be("12° 34' 56,78\"");
            Angle.Straight.ToString("G2", new CultureInfo("pt-PT")).Should().Be("200,00");

            String.Format(new CultureInfo("pt-PT"), "Radians: {0:R2}", Angle.Straight).Should().Be("Radians: 3,14");
            String.Format(new CultureInfo("pt-PT"), "Degrees: {0:D2}", Angle.Straight).Should().Be("Degrees: 180,00°");
            String.Format(new CultureInfo("pt-PT"), "Degrees: {0:M2}", Angle.FromDegrees(12, 34.56)).Should().Be("Degrees: 12° 34,56'");
            String.Format(new CultureInfo("pt-PT"), "Degrees: {0:S2}", Angle.FromDegrees(12, 34, 56.78)).Should().Be("Degrees: 12° 34' 56,78\"");
            String.Format(new CultureInfo("pt-PT"), "Gradians: {0:G2}", Angle.Straight).Should().Be("Gradians: 200,00");

        }

    }
}
