using NUnit.Framework;
using System;
using System.Globalization;

namespace NetFabric.UnitTests
{
    [TestFixture]
    public class AngleTests
    {
        [Test]
        public void FromRadiansCreatesAngleCorrectly()
        {
            var angle = Angle.FromRadians(0.0);
            Assert.That(angle.ToRadians(), Is.Zero);

            angle = Angle.FromRadians(Math.PI);
            Assert.That(angle.ToRadians(), Is.EqualTo(Math.PI));

            angle = Angle.FromRadians(double.NaN);
            Assert.That(angle.ToRadians(), Is.EqualTo(double.NaN));
        }

        [Test]
        public void FromDegreesConvertsToRadiansCorrectly()
        {
            var angle = Angle.FromDegrees(0.0);
            Assert.That(angle.ToRadians(), Is.Zero);

            angle = Angle.FromDegrees(45.0);
            Assert.That(angle.ToRadians(), Is.EqualTo(Math.PI / 4.0));

            angle = Angle.FromDegrees(90.0);
            Assert.That(angle.ToRadians(), Is.EqualTo(Math.PI / 2.0));

            angle = Angle.FromDegrees(180.0);
            Assert.That(angle.ToRadians(), Is.EqualTo(Math.PI));

            angle = Angle.FromDegrees(360.0);
            Assert.That(angle.ToRadians(), Is.EqualTo(Math.PI * 2.0));

            angle = Angle.FromDegrees(double.NaN);
            Assert.That(angle.ToRadians(), Is.NaN);
        }

        [Test]
        public void ToDegreesConvertsFromRadiansCorrectly()
        {
            var angle = Angle.FromRadians(0.0);
            Assert.That(angle.ToDegrees(), Is.Zero);

            angle = Angle.FromRadians(Math.PI / 4.0);
            Assert.That(angle.ToDegrees(), Is.EqualTo(45.0));

            angle = Angle.FromRadians(Math.PI / 2.0);
            Assert.That(angle.ToDegrees(), Is.EqualTo(90.0));

            angle = Angle.FromRadians(Math.PI);
            Assert.That(angle.ToDegrees(), Is.EqualTo(180.0));

            angle = Angle.FromRadians(Math.PI * 2.0);
            Assert.That(angle.ToDegrees(), Is.EqualTo(360.0));

            angle = Angle.FromRadians(double.NaN);
            Assert.That(angle.ToDegrees(), Is.NaN);
        }

        [Test]
        public void FromDegreesMinutesConvertsToRadiansCorrectly()
        {
            var angle = Angle.FromDegrees(0, 0.0);
            Assert.That(angle.ToRadians(), Is.Zero);

            angle = Angle.FromDegrees(40, 30.0);
            Assert.That(angle.ToRadians(), Is.EqualTo(0.706858347).Within(0.000000001));

            angle = Angle.FromDegrees(-40, 30.0);
            Assert.That(angle.ToRadians(), Is.EqualTo(-0.706858347).Within(0.000000001));
        }

        [Test]
        public void ToDegreesMinutesConvertsFromRadiansCorrectly()
        {

            var angle = Angle.FromRadians(0.0);
            angle.ToDegrees(out int degrees, out double minutes);
            Assert.That(degrees, Is.Zero);
            Assert.That(minutes, Is.Zero.Within(0.000001));

            angle = Angle.FromRadians(0.706858347);
            angle.ToDegrees(out degrees, out minutes);
            Assert.That(degrees, Is.EqualTo(40));
            Assert.That(minutes, Is.EqualTo(30.0).Within(0.000001));

            angle = Angle.FromRadians(-0.706858347);
            angle.ToDegrees(out degrees, out minutes);
            Assert.That(degrees, Is.EqualTo(-40));
            Assert.That(minutes, Is.EqualTo(30.0).Within(0.000001));
        }

        [Test]
        public void FromDegreesMinutesSecondsConvertsToRadiansCorrectly()
        {
            var angle = Angle.FromDegrees(0, 0, 0.0);
            Assert.That(angle.ToRadians(), Is.Zero);

            angle = Angle.FromDegrees(40, 30, 30.0);
            Assert.That(angle.ToRadians(), Is.EqualTo(0.707003791).Within(0.000000001));

            angle = Angle.FromDegrees(-40, 30, 30.0);
            Assert.That(angle.ToRadians(), Is.EqualTo(-0.707003791).Within(0.000000001));
        }

        [Test]
        public void ToDegreesMinutesSecondsConvertsFromRadiansCorrectly()
        {

            var angle = Angle.FromRadians(0.0);
            angle.ToDegrees(out int degrees, out int minutes, out double seconds);
            Assert.That(degrees, Is.Zero);
            Assert.That(minutes, Is.Zero);
            Assert.That(seconds, Is.Zero.Within(0.001));

            angle = Angle.FromRadians(0.707003791);
            angle.ToDegrees(out degrees, out minutes, out seconds);
            Assert.That(degrees, Is.EqualTo(40));
            Assert.That(minutes, Is.EqualTo(30));
            Assert.That(seconds, Is.EqualTo(30.0).Within(0.001));

            angle = Angle.FromRadians(-0.707003791);
            angle.ToDegrees(out degrees, out minutes, out seconds);
            Assert.That(degrees, Is.EqualTo(-40));
            Assert.That(minutes, Is.EqualTo(30));
            Assert.That(seconds, Is.EqualTo(30.0).Within(0.001));
        }

        [Test]
        public void FromGradiansConvertsToRadiansCorrectly()
        {
            var angle = Angle.FromGradians(0.0);
            Assert.That(angle.ToRadians(), Is.Zero);

            angle = Angle.FromGradians(50.0);
            Assert.That(angle.ToRadians(), Is.EqualTo(Math.PI / 4.0));

            angle = Angle.FromGradians(100.0);
            Assert.That(angle.ToRadians(), Is.EqualTo(Math.PI / 2.0));

            angle = Angle.FromGradians(200.0);
            Assert.That(angle.ToRadians(), Is.EqualTo(Math.PI));

            angle = Angle.FromGradians(400.0);
            Assert.That(angle.ToRadians(), Is.EqualTo(Math.PI * 2.0));

            angle = Angle.FromGradians(double.NaN);
            Assert.That(angle.ToRadians(), Is.NaN);
        }

        [Test]
        public void ToGradiansConvertsFromRadiansCorrectly()
        {
            var angle = Angle.FromRadians(0.0);
            Assert.That(angle.ToGradians(), Is.Zero);

            angle = Angle.FromRadians(Math.PI / 4.0);
            Assert.That(angle.ToGradians(), Is.EqualTo(50.0));

            angle = Angle.FromRadians(Math.PI / 2.0);
            Assert.That(angle.ToGradians(), Is.EqualTo(100.0));

            angle = Angle.FromRadians(Math.PI);
            Assert.That(angle.ToGradians(), Is.EqualTo(200.0));

            angle = Angle.FromRadians(Math.PI * 2.0);
            Assert.That(angle.ToGradians(), Is.EqualTo(400.0));

            angle = Angle.FromRadians(double.NaN);
            Assert.That(angle.ToGradians(), Is.NaN);
        }

        [Test]
        public void ZeroAngleIsDefinedCorrectly()
        {
            var angle = Angle.Zero;
            Assert.That(angle.ToGradians(), Is.Zero);
            Assert.That(angle.ToDegrees(), Is.Zero);
            Assert.That(angle.ToGradians(), Is.Zero);
        }

        [Test]
        public void RightAngleIsDefinedCorrectly()
        {
            var angle = Angle.Right;
            Assert.That(angle.ToRadians(), Is.EqualTo(Math.PI / 2.0));
            Assert.That(angle.ToDegrees(), Is.EqualTo(90.0));
            Assert.That(angle.ToGradians(), Is.EqualTo(100.0));
        }

        [Test]
        public void StraightAngleIsDefinedCorrectly()
        {
            var angle = Angle.Straight;
            Assert.That(angle.ToRadians(), Is.EqualTo(Math.PI));
            Assert.That(angle.ToDegrees(), Is.EqualTo(180.0));
            Assert.That(angle.ToGradians(), Is.EqualTo(200.0));
        }

        [Test]
        public void FullAngleIsDefinedCorrectly()
        {
            var angle = Angle.Full;
            Assert.That(angle.ToRadians(), Is.EqualTo(Math.PI * 2.0));
            Assert.That(angle.ToDegrees(), Is.EqualTo(360.0));
            Assert.That(angle.ToGradians(), Is.EqualTo(400.0));
        }

        [Test]
        public void ObjectEquals()
        {
            Assert.That(Angle.Right.Equals(null), Is.False);
            Assert.That(Angle.Right.Equals(90.0), Is.False);
            Assert.That(Angle.Zero.Equals((object)Angle.Right), Is.False);
            Assert.That(Angle.Right.Equals((object)Angle.Right), Is.True);
        }

        [Test]
        public void ObjectGetHashCode()
        {
            Assert.That(Angle.Zero.GetHashCode(), Is.Not.EqualTo(Angle.Right.GetHashCode()));
            Assert.That(Angle.Right.GetHashCode(), Is.EqualTo(Angle.Right.GetHashCode()));
        }

        [Test]
        public void EquatableEquals()
        {
            Assert.That(Angle.Zero.Equals(Angle.Right), Is.False);
            Assert.That(Angle.Right.Equals(Angle.Right), Is.True);
        }

        [Test]
        public void AproximatelyEquals()
        {
            Assert.That(Angle.Equals(Angle.Right, Angle.FromDegrees(90.00001), Angle.Zero), Is.False);
            Assert.That(Angle.Equals(Angle.Right, Angle.FromDegrees(90.00001), Angle.FromDegrees(0.001)), Is.True);
            Assert.That(Angle.Equals(Angle.Right, Angle.FromDegrees(89.99999), Angle.FromDegrees(0.001)), Is.True);
        }

        [Test]
        public void OperatorEquality()
        {
            Assert.That(Angle.FromDegrees(0) == Angle.FromDegrees(90), Is.False);
            Assert.That(Angle.FromDegrees(90) == Angle.FromDegrees(90), Is.True);
        }

        [Test]
        public void OperatorInequality()
        {
            Assert.That(Angle.FromDegrees(0) != Angle.FromDegrees(90), Is.True);
            Assert.That(Angle.FromDegrees(90) != Angle.FromDegrees(90), Is.False);
        }

        [Test]
        public void ComparableCompareToObjectThrowsExcetionOnNull()
        {
            Assert.That(() => Angle.Right.CompareTo(null), Throws.ArgumentException);
        }

        [Test]
        public void ComparableCompareToObjectThrowsExcetionOnOtherType()
        {
            Assert.That(() => Angle.Right.CompareTo(90.0), Throws.ArgumentException);
        }

        [Test]
        public void ComparableCompareToObject()
        {
            Assert.That(Angle.Right.CompareTo((object)Angle.Straight), Is.LessThan(0));
            Assert.That(Angle.Right.CompareTo((object)Angle.Right), Is.Zero);
            Assert.That(Angle.Right.CompareTo((object)Angle.Zero), Is.GreaterThan(0));
        }

        [Test]
        public void ComparableCompareToAngle()
        {
            Assert.That(Angle.Right.CompareTo(Angle.Straight), Is.LessThan(0));
            Assert.That(Angle.Right.CompareTo(Angle.Right), Is.Zero);
            Assert.That(Angle.Right.CompareTo(Angle.Zero), Is.GreaterThan(0));
        }

        [Test]
        public void CompareTwoAngles()
        {
            Assert.That(Angle.Compare(Angle.Right, Angle.Straight), Is.LessThan(0));
            Assert.That(Angle.Compare(Angle.Right, Angle.Right), Is.Zero);
            Assert.That(Angle.Compare(Angle.Right, Angle.Zero), Is.GreaterThan(0));
            Assert.AreNotEqual(Angle.Compare(Angle.Right + Angle.Full, Angle.Straight), Is.LessThan(0));
            Assert.AreNotEqual(Angle.Compare(Angle.Right, Angle.Right + Angle.Full), Is.Zero);
            Assert.AreNotEqual(1, Angle.Compare(Angle.Right, Angle.Zero + Angle.Full));
        }

        [Test]
        public void CompareReducedTwoAngles()
        {
            Assert.That(Angle.CompareReduced(Angle.Right, Angle.Straight), Is.LessThan(0));
            Assert.That(Angle.CompareReduced(Angle.Right, Angle.Right), Is.Zero);
            Assert.That(Angle.CompareReduced(Angle.Right, Angle.Zero), Is.GreaterThan(0));
            Assert.That(Angle.CompareReduced(Angle.Right + Angle.Full, Angle.Straight), Is.LessThan(0));
            Assert.That(Angle.CompareReduced(Angle.Right, Angle.Right + Angle.Full), Is.Zero);
            Assert.That(Angle.CompareReduced(Angle.Right, Angle.Zero + Angle.Full), Is.GreaterThan(0));
        }

        [Test]
        public void LessThanOperator()
        {
            Assert.That(Angle.Zero < Angle.FromDegrees(90), Is.True);
            Assert.That(Angle.FromDegrees(90) < Angle.FromDegrees(90), Is.False);
            Assert.That(Angle.FromDegrees(180) < Angle.FromDegrees(90), Is.False);
        }

        [Test]
        public void LessThanOrEqualToOperator()
        {
            Assert.That(Angle.FromDegrees(0) <= Angle.FromDegrees(90), Is.True);
            Assert.That(Angle.FromDegrees(90) <= Angle.FromDegrees(90), Is.True);
            Assert.That(Angle.FromDegrees(180) <= Angle.FromDegrees(90), Is.False);
        }

        [Test]
        public void GreaterThanOperator()
        {
            Assert.That(Angle.FromDegrees(0) > Angle.FromDegrees(90), Is.False);
            Assert.That(Angle.FromDegrees(90) > Angle.FromDegrees(90), Is.False);
            Assert.That(Angle.FromDegrees(180) > Angle.FromDegrees(90));
        }

        [Test]
        public void GreaterThanOrEqualToOperator()
        {
            Assert.That(Angle.FromDegrees(0) >= Angle.FromDegrees(90), Is.False);
            Assert.That(Angle.FromDegrees(90) >= Angle.FromDegrees(90), Is.True);
            Assert.That(Angle.FromDegrees(180) >= Angle.FromDegrees(90), Is.True);
        }

        [Test]
        public void ReduceIsDefinedCorrectly()
        {
            Assert.That(Angle.Reduce(Angle.Zero), Is.EqualTo(Angle.Zero));
            Assert.That(Angle.Reduce(Angle.FromDegrees(45)), Is.EqualTo(Angle.FromDegrees(45)));
            Assert.That(Angle.Reduce(Angle.Right), Is.EqualTo(Angle.Right));
            Assert.That(Angle.Reduce(Angle.FromDegrees(135)), Is.EqualTo(Angle.FromDegrees(135)));
            Assert.That(Angle.Reduce(Angle.Straight), Is.EqualTo(Angle.Straight));

            Assert.That(Angle.Reduce(Angle.Full), Is.EqualTo(Angle.Zero));
            Assert.That(Angle.Reduce(Angle.FromDegrees(45) + Angle.Full), Is.EqualTo(Angle.FromDegrees(45)));
            Assert.That(Angle.Reduce(Angle.Right + Angle.Full), Is.EqualTo(Angle.Right));
            Assert.That(Angle.Reduce(Angle.FromDegrees(135) + Angle.Full).ToRadians(), Is.EqualTo(Angle.FromDegrees(135).ToRadians()).Within(0.000001));
            Assert.That(Angle.Reduce(Angle.Straight + Angle.Full), Is.EqualTo(Angle.Straight));

            Assert.That(Angle.Reduce(-Angle.Full), Is.EqualTo(Angle.Zero));
            Assert.That(Angle.Reduce(-Angle.FromDegrees(45)), Is.EqualTo(Angle.FromDegrees(315)));
            Assert.That(Angle.Reduce(-Angle.Right), Is.EqualTo(Angle.FromDegrees(270)));
            Assert.That(Angle.Reduce(-Angle.Straight), Is.EqualTo(Angle.Straight));
            Assert.That(Angle.Reduce(-Angle.FromDegrees(270)), Is.EqualTo(Angle.Right));

        }

        [Test]
        public void GetQuadrantIsDefinedCorrectly()
        {
            Assert.That(Angle.GetQuadrant(Angle.Zero), Is.EqualTo(Angle.Quadrant.First));
            Assert.That(Angle.GetQuadrant(Angle.FromDegrees(45)), Is.EqualTo(Angle.Quadrant.First));
            Assert.That(Angle.GetQuadrant(Angle.Right), Is.EqualTo(Angle.Quadrant.Second));
            Assert.That(Angle.GetQuadrant(Angle.FromDegrees(135)), Is.EqualTo(Angle.Quadrant.Second));
            Assert.That(Angle.GetQuadrant(Angle.Straight), Is.EqualTo(Angle.Quadrant.Third));
            Assert.That(Angle.GetQuadrant(Angle.FromDegrees(225)), Is.EqualTo(Angle.Quadrant.Third));
            Assert.That(Angle.GetQuadrant(Angle.FromDegrees(270)), Is.EqualTo(Angle.Quadrant.Fourth));
            Assert.That(Angle.GetQuadrant(Angle.FromDegrees(315)), Is.EqualTo(Angle.Quadrant.Fourth));

            Assert.That(Angle.GetQuadrant(Angle.Full), Is.EqualTo(Angle.Quadrant.First));
            Assert.That(Angle.GetQuadrant(Angle.FromDegrees(45) + Angle.Full), Is.EqualTo(Angle.Quadrant.First));
            Assert.That(Angle.GetQuadrant(Angle.Right + Angle.Full), Is.EqualTo(Angle.Quadrant.Second));
            Assert.That(Angle.GetQuadrant(Angle.FromDegrees(135) + Angle.Full), Is.EqualTo(Angle.Quadrant.Second));
            Assert.That(Angle.GetQuadrant(Angle.Straight + Angle.Full), Is.EqualTo(Angle.Quadrant.Third));
            Assert.That(Angle.GetQuadrant(Angle.FromDegrees(225) + Angle.Full), Is.EqualTo(Angle.Quadrant.Third));
            Assert.That(Angle.GetQuadrant(Angle.FromDegrees(270) + Angle.Full), Is.EqualTo(Angle.Quadrant.Fourth));
            Assert.That(Angle.GetQuadrant(Angle.FromDegrees(315) + Angle.Full), Is.EqualTo(Angle.Quadrant.Fourth));

        }

        [Test]
        public void ReferenceIsDefinedCorrectly()
        {
            Assert.That(Angle.GetReference(Angle.Zero), Is.EqualTo(Angle.Zero));
            Assert.That(Angle.GetReference(Angle.FromDegrees(45)), Is.EqualTo(Angle.FromDegrees(45)));
            Assert.That(Angle.GetReference(Angle.Right), Is.EqualTo(Angle.Right));
            Assert.That(Angle.GetReference(Angle.FromDegrees(135)), Is.EqualTo(Angle.FromDegrees(45)));
            Assert.That(Angle.GetReference(Angle.Straight), Is.EqualTo(Angle.Zero));
            Assert.That(Angle.GetReference(Angle.FromDegrees(225)), Is.EqualTo(Angle.FromDegrees(45)));
            Assert.That(Angle.GetReference(Angle.FromDegrees(270)), Is.EqualTo(Angle.Right));
            Assert.That(Angle.GetReference(Angle.FromDegrees(315)), Is.EqualTo(Angle.FromDegrees(45)));
            Assert.That(Angle.GetReference(Angle.Full), Is.EqualTo(Angle.Zero));

            Assert.That(Angle.GetReference(Angle.FromDegrees(45) + Angle.Full), Is.EqualTo(Angle.FromDegrees(45)));
            Assert.That(Angle.GetReference(Angle.Right + Angle.Full), Is.EqualTo(Angle.Right));
            Assert.That(Angle.GetReference(Angle.FromDegrees(135) + Angle.Full).ToRadians(), Is.EqualTo(Angle.FromDegrees(45).ToRadians()).Within(0.000001));

        }

        [Test]
        public void IsAcuteIsDefinedCorrectly()
        {
            Assert.That(Angle.IsAcute(Angle.Zero), Is.False);
            Assert.That(Angle.IsAcute(Angle.FromDegrees(45)), Is.True);
            Assert.That(Angle.IsAcute(Angle.Right), Is.False);
            Assert.That(Angle.IsAcute(Angle.FromDegrees(135)), Is.False);
            Assert.That(Angle.IsAcute(Angle.Straight), Is.False);
            Assert.That(Angle.IsAcute(Angle.FromDegrees(270)), Is.False);
            Assert.That(Angle.IsAcute(Angle.Full), Is.False);

            Assert.That(Angle.IsAcute(-Angle.FromDegrees(45)), Is.True);
            Assert.That(Angle.IsAcute(-Angle.Right), Is.False);
            Assert.That(Angle.IsAcute(-Angle.FromDegrees(135)), Is.False);
            Assert.That(Angle.IsAcute(-Angle.Straight), Is.False);
            Assert.That(Angle.IsAcute(-Angle.FromDegrees(270)), Is.False);
            Assert.That(Angle.IsAcute(-Angle.Full), Is.False);
        }

        [Test]
        public void IsRightIsDefinedCorrectly()
        {
            Assert.That(Angle.IsRight(Angle.Zero), Is.False);
            Assert.That(Angle.IsRight(Angle.FromDegrees(45)), Is.False);
            Assert.That(Angle.IsRight(Angle.Right), Is.True);
            Assert.That(Angle.IsRight(Angle.FromDegrees(135)), Is.False);
            Assert.That(Angle.IsRight(Angle.Straight), Is.False);
            Assert.That(Angle.IsRight(Angle.FromDegrees(270)), Is.False);
            Assert.That(Angle.IsRight(Angle.Full), Is.False);

            Assert.That(Angle.IsRight(-Angle.FromDegrees(45)), Is.False);
            Assert.That(Angle.IsRight(-Angle.Right), Is.True);
            Assert.That(Angle.IsRight(-Angle.FromDegrees(135)), Is.False);
            Assert.That(Angle.IsRight(-Angle.Straight), Is.False);
            Assert.That(Angle.IsRight(-Angle.FromDegrees(270)), Is.False);
            Assert.That(Angle.IsRight(-Angle.Full), Is.False);
        }

        [Test]
        public void IsAproximatelyRightIsDefinedCorrectly()
        {
            Assert.That(Angle.IsRight(Angle.FromDegrees(90.00001), Angle.Zero), Is.False);
            Assert.That(Angle.IsRight(Angle.FromDegrees(90.00001), Angle.FromDegrees(0.001)), Is.True);
            Assert.That(Angle.IsRight(Angle.FromDegrees(89.99999), Angle.FromDegrees(0.001)), Is.True);
        }

        [Test]
        public void IsObtuseIsDefinedCorrectly()
        {
            Assert.That(Angle.IsObtuse(Angle.Zero), Is.False);
            Assert.That(Angle.IsObtuse(Angle.FromDegrees(45)), Is.False);
            Assert.That(Angle.IsObtuse(Angle.Right), Is.False);
            Assert.That(Angle.IsObtuse(Angle.FromDegrees(135)), Is.True);
            Assert.That(Angle.IsObtuse(Angle.Straight), Is.False);
            Assert.That(Angle.IsObtuse(Angle.FromDegrees(270)), Is.False);
            Assert.That(Angle.IsObtuse(Angle.Full), Is.False);

            Assert.That(Angle.IsObtuse(-Angle.FromDegrees(45)), Is.False);
            Assert.That(Angle.IsObtuse(-Angle.Right), Is.False);
            Assert.That(Angle.IsObtuse(-Angle.FromDegrees(135)), Is.True);
            Assert.That(Angle.IsObtuse(-Angle.Straight), Is.False);
            Assert.That(Angle.IsObtuse(-Angle.FromDegrees(270)), Is.False);
            Assert.That(Angle.IsObtuse(-Angle.Full), Is.False);
        }

        [Test]
        public void IsStraightIsDefinedCorrectly()
        {
            Assert.That(Angle.IsStraight(Angle.Zero), Is.False);
            Assert.That(Angle.IsStraight(Angle.FromDegrees(45)), Is.False);
            Assert.That(Angle.IsStraight(Angle.Right), Is.False);
            Assert.That(Angle.IsStraight(Angle.FromDegrees(135)), Is.False);
            Assert.That(Angle.IsStraight(Angle.Straight), Is.True);
            Assert.That(Angle.IsStraight(Angle.FromDegrees(270)), Is.False);
            Assert.That(Angle.IsStraight(Angle.Full), Is.False);

            Assert.That(Angle.IsStraight(-Angle.FromDegrees(45)), Is.False);
            Assert.That(Angle.IsStraight(-Angle.Right), Is.False);
            Assert.That(Angle.IsStraight(-Angle.FromDegrees(135)), Is.False);
            Assert.That(Angle.IsStraight(-Angle.Straight), Is.True);
            Assert.That(Angle.IsStraight(-Angle.FromDegrees(270)), Is.False);
            Assert.That(Angle.IsStraight(-Angle.Full), Is.False);
        }

        [Test]
        public void IsAproximatelyStraightIsDefinedCorrectly()
        {
            Assert.That(Angle.IsStraight(Angle.FromDegrees(180.00001), Angle.Zero), Is.False);
            Assert.That(Angle.IsStraight(Angle.FromDegrees(180.00001), Angle.FromDegrees(0.001)), Is.True);
            Assert.That(Angle.IsStraight(Angle.FromDegrees(179.99999), Angle.FromDegrees(0.001)), Is.True);
        }

        [Test]
        public void IsReflexIsDefinedCorrectly()
        {
            Assert.That(Angle.IsReflex(Angle.Zero), Is.False);
            Assert.That(Angle.IsReflex(Angle.FromDegrees(45)), Is.False);
            Assert.That(Angle.IsReflex(Angle.Right), Is.False);
            Assert.That(Angle.IsReflex(Angle.FromDegrees(135)), Is.False);
            Assert.That(Angle.IsReflex(Angle.Straight), Is.False);
            Assert.That(Angle.IsReflex(Angle.FromDegrees(270)), Is.True);
            Assert.That(Angle.IsReflex(Angle.Full), Is.False);

            Assert.That(Angle.IsReflex(-Angle.FromDegrees(45)), Is.False);
            Assert.That(Angle.IsReflex(-Angle.Right), Is.False);
            Assert.That(Angle.IsReflex(-Angle.FromDegrees(135)), Is.False);
            Assert.That(Angle.IsReflex(-Angle.Straight), Is.False);
            Assert.That(Angle.IsReflex(-Angle.FromDegrees(270)), Is.True);
            Assert.That(Angle.IsReflex(-Angle.Full), Is.False);
        }

        [Test]
        public void LerpIsDefinedCorrectly()
        {
            Assert.That(Angle.Lerp(Angle.FromDegrees(45.0), Angle.FromDegrees(135.0), -0.5), Is.EqualTo(Angle.FromDegrees(0.0)));
            Assert.That(Angle.Lerp(Angle.FromDegrees(45.0), Angle.FromDegrees(135.0), 0.0), Is.EqualTo(Angle.FromDegrees(45.0)));
            Assert.That(Angle.Lerp(Angle.FromDegrees(45.0), Angle.FromDegrees(135.0), 0.5), Is.EqualTo(Angle.FromDegrees(90.0)));
            Assert.That(Angle.Lerp(Angle.FromDegrees(45.0), Angle.FromDegrees(135.0), 1.0), Is.EqualTo(Angle.FromDegrees(135.0)));
            Assert.That(Angle.Lerp(Angle.FromDegrees(45.0), Angle.FromDegrees(135.0), 1.5), Is.EqualTo(Angle.FromDegrees(180.0)));

            Assert.That(Angle.Lerp(Angle.FromDegrees(-45.0), Angle.FromDegrees(-135.0), -0.5), Is.EqualTo(Angle.FromDegrees(0.0)));
            Assert.That(Angle.Lerp(Angle.FromDegrees(-45.0), Angle.FromDegrees(-135.0), 0.0), Is.EqualTo(Angle.FromDegrees(-45.0)));
            Assert.That(Angle.Lerp(Angle.FromDegrees(-45.0), Angle.FromDegrees(-135.0), 0.5), Is.EqualTo(Angle.FromDegrees(-90.0)));
            Assert.That(Angle.Lerp(Angle.FromDegrees(-45.0), Angle.FromDegrees(-135.0), 1.0), Is.EqualTo(Angle.FromDegrees(-135.0)));
            Assert.That(Angle.Lerp(Angle.FromDegrees(-45.0), Angle.FromDegrees(-135.0), 1.5), Is.EqualTo(Angle.FromDegrees(-180.0)));

            Assert.That(Angle.Lerp(Angle.FromDegrees(135.0), Angle.FromDegrees(45.0), -0.5), Is.EqualTo(Angle.FromDegrees(180.0)));
            Assert.That(Angle.Lerp(Angle.FromDegrees(135.0), Angle.FromDegrees(45.0), 0.0), Is.EqualTo(Angle.FromDegrees(135.0)));
            Assert.That(Angle.Lerp(Angle.FromDegrees(135.0), Angle.FromDegrees(45.0), 0.5), Is.EqualTo(Angle.FromDegrees(90.0)));
            Assert.That(Angle.Lerp(Angle.FromDegrees(135.0), Angle.FromDegrees(45.0), 1.0), Is.EqualTo(Angle.FromDegrees(45.0)));
            Assert.That(Angle.Lerp(Angle.FromDegrees(135.0), Angle.FromDegrees(45.0), 1.5), Is.EqualTo(Angle.FromDegrees(0.0)));
        }

        [Test]
        public void ToStringIsDefinedCorrectly()
        {
#if NET35
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
#else
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
#endif

            Assert.That(Angle.Straight.ToString(), Is.EqualTo("3.14159265358979"));

            Assert.That(Angle.Straight.ToString("R"), Is.EqualTo("3.14159265358979"));
            Assert.That(Angle.Straight.ToString("D"), Is.EqualTo("180°"));
            Assert.That(Angle.FromDegrees(12, 34.56).ToString("M"), Is.EqualTo("12° 34.56'"));
            Assert.That(Angle.FromDegrees(12, 34, 56.78).ToString("S"), Is.EqualTo("12° 34' 56.7800000000018\""));
            Assert.That(Angle.Straight.ToString("G"), Is.EqualTo("200"));

            Assert.That(Angle.Straight.ToString("R", new CultureInfo("pt-PT")), Is.EqualTo("3,14159265358979"));
            Assert.That(Angle.Straight.ToString("D", new CultureInfo("pt-PT")), Is.EqualTo("180°"));
            Assert.That(Angle.FromDegrees(12, 34.56).ToString("M", new CultureInfo("pt-PT")), Is.EqualTo("12° 34,56'"));
            Assert.That(Angle.FromDegrees(12, 34, 56.78).ToString("S", new CultureInfo("pt-PT")), Is.EqualTo("12° 34' 56,7800000000018\""));
            Assert.That(Angle.Straight.ToString("G", new CultureInfo("pt-PT")), Is.EqualTo("200"));

            Assert.That(String.Format("Radians: {0:R}", Angle.Straight), Is.EqualTo("Radians: 3.14159265358979"));
            Assert.That(String.Format("Degrees: {0:D}", Angle.Straight), Is.EqualTo("Degrees: 180°"));
            Assert.That(String.Format("Degrees: {0:M}", Angle.FromDegrees(12, 34.56)), Is.EqualTo("Degrees: 12° 34.56'"));
            Assert.That(String.Format("Degrees: {0:S}", Angle.FromDegrees(12, 34, 56.78)), Is.EqualTo("Degrees: 12° 34' 56.7800000000018\""));
            Assert.That(String.Format("Gradians: {0:G}", Angle.Straight), Is.EqualTo("Gradians: 200"));

            Assert.That(Angle.Straight.ToString("R2"), Is.EqualTo("3.14"));
            Assert.That(Angle.Straight.ToString("D2"), Is.EqualTo("180.00°"));
            Assert.That(Angle.FromDegrees(12, 34.56).ToString("M2"), Is.EqualTo("12° 34.56'"));
            Assert.That(Angle.FromDegrees(12, 34, 56.78).ToString("S2"), Is.EqualTo("12° 34' 56.78\""));
            Assert.That(Angle.Straight.ToString("G2"), Is.EqualTo("200.00"));

            Assert.That(Angle.Straight.ToString("R2", new CultureInfo("pt-PT")), Is.EqualTo("3,14"));
            Assert.That(Angle.Straight.ToString("D2", new CultureInfo("pt-PT")), Is.EqualTo("180,00°"));
            Assert.That(Angle.FromDegrees(12, 34.56).ToString("M2", new CultureInfo("pt-PT")), Is.EqualTo("12° 34,56'"));
            Assert.That(Angle.FromDegrees(12, 34, 56.78).ToString("S2", new CultureInfo("pt-PT")), Is.EqualTo("12° 34' 56,78\""));
            Assert.That(Angle.Straight.ToString("G2", new CultureInfo("pt-PT")), Is.EqualTo("200,00"));

            Assert.That(String.Format(new CultureInfo("pt-PT"), "Radians: {0:R2}", Angle.Straight), Is.EqualTo("Radians: 3,14"));
            Assert.That(String.Format(new CultureInfo("pt-PT"), "Degrees: {0:D2}", Angle.Straight), Is.EqualTo("Degrees: 180,00°"));
            Assert.That(String.Format(new CultureInfo("pt-PT"), "Degrees: {0:M2}", Angle.FromDegrees(12, 34.56)), Is.EqualTo("Degrees: 12° 34,56'"));
            Assert.That(String.Format(new CultureInfo("pt-PT"), "Degrees: {0:S2}", Angle.FromDegrees(12, 34, 56.78)), Is.EqualTo("Degrees: 12° 34' 56,78\""));
            Assert.That(String.Format(new CultureInfo("pt-PT"), "Gradians: {0:G2}", Angle.Straight), Is.EqualTo("Gradians: 200,00"));

        }

    }
}
