using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using System.Threading;

namespace NetFabric.UnitTests
{
    [TestClass]
    public class AngleTests
    {
        [TestMethod]
        public void FromRadiansCreatesAngleCorrectly()
        {
            var angle = Angle.FromRadians(0.0);
            Assert.AreEqual(0.0, angle.ToRadians());

            angle = Angle.FromRadians(Math.PI);
            Assert.AreEqual(Math.PI, angle.ToRadians());

            angle = Angle.FromRadians(double.NaN);
            Assert.AreEqual(double.NaN, angle.ToRadians());
        }

        [TestMethod]
        public void FromDegreesConvertsToRadiansCorrectly()
        {
            var angle = Angle.FromDegrees(0.0);
            Assert.AreEqual(0.0, angle.ToRadians());

            angle = Angle.FromDegrees(45.0);
            Assert.AreEqual(Math.PI / 4.0, angle.ToRadians());

            angle = Angle.FromDegrees(90.0);
            Assert.AreEqual(Math.PI / 2.0, angle.ToRadians());

            angle = Angle.FromDegrees(180.0);
            Assert.AreEqual(Math.PI, angle.ToRadians());

            angle = Angle.FromDegrees(360.0);
            Assert.AreEqual(Math.PI * 2.0, angle.ToRadians());

            angle = Angle.FromDegrees(double.NaN);
            Assert.AreEqual(double.NaN, angle.ToRadians());
        }

        [TestMethod]
        public void ToDegreesConvertsFromRadiansCorrectly()
        {
            var angle = Angle.FromRadians(0.0);
            Assert.AreEqual(0.0, angle.ToDegrees());

            angle = Angle.FromRadians(Math.PI / 4.0);
            Assert.AreEqual(45.0, angle.ToDegrees());

            angle = Angle.FromRadians(Math.PI / 2.0);
            Assert.AreEqual(90.0, angle.ToDegrees());

            angle = Angle.FromRadians(Math.PI);
            Assert.AreEqual(180.0, angle.ToDegrees());

            angle = Angle.FromRadians(Math.PI * 2.0);
            Assert.AreEqual(360.0, angle.ToDegrees());

            angle = Angle.FromRadians(double.NaN);
            Assert.AreEqual(double.NaN, angle.ToDegrees());
        }

        [TestMethod]
        public void FromDegreesMinutesConvertsToRadiansCorrectly()
        {
            var angle = Angle.FromDegrees(0, 0.0);
            Assert.AreEqual(0.0, angle.ToRadians());

            angle = Angle.FromDegrees(40, 30.0);
            Assert.AreEqual(0.706858347, angle.ToRadians(), 0.000000001);

            angle = Angle.FromDegrees(-40, 30.0);
            Assert.AreEqual(-0.706858347, angle.ToRadians(), 0.000000001);
        }

        [TestMethod]
        public void ToDegreesMinutesConvertsFromRadiansCorrectly()
        {
            int degrees;
            double minutes;

            var angle = Angle.FromRadians(0.0);
            angle.ToDegrees(out degrees, out minutes);
            Assert.AreEqual(0, degrees);
            Assert.AreEqual(0.0, minutes, 0.000001);

            angle = Angle.FromRadians(0.706858347);
            angle.ToDegrees(out degrees, out minutes);
            Assert.AreEqual(40, degrees);
            Assert.AreEqual(30.0, minutes, 0.000001);

            angle = Angle.FromRadians(-0.706858347);
            angle.ToDegrees(out degrees, out minutes);
            Assert.AreEqual(-40, degrees);
            Assert.AreEqual(30.0, minutes, 0.000001);
        }

        [TestMethod]
        public void FromDegreesMinutesSecondsConvertsToRadiansCorrectly()
        {
            var angle = Angle.FromDegrees(0, 0, 0.0);
            Assert.AreEqual(0.0, angle.ToRadians());

            angle = Angle.FromDegrees(40, 30, 30.0);
            Assert.AreEqual(0.707003791, angle.ToRadians(), 0.000000001);

            angle = Angle.FromDegrees(-40, 30, 30.0);
            Assert.AreEqual(-0.707003791, angle.ToRadians(), 0.000000001);
        }

        [TestMethod]
        public void ToDegreesMinutesSecondsConvertsFromRadiansCorrectly()
        {
            int degrees;
            int minutes;
            double seconds;

            var angle = Angle.FromRadians(0.0);
            angle.ToDegrees(out degrees, out minutes, out seconds);
            Assert.AreEqual(0, degrees);
            Assert.AreEqual(0, minutes);
            Assert.AreEqual(0.0, seconds, 0.001);

            angle = Angle.FromRadians(0.707003791);
            angle.ToDegrees(out degrees, out minutes, out seconds);
            Assert.AreEqual(40, degrees);
            Assert.AreEqual(30, minutes);
            Assert.AreEqual(30.0, seconds, 0.001);

            angle = Angle.FromRadians(-0.707003791);
            angle.ToDegrees(out degrees, out minutes, out seconds);
            Assert.AreEqual(-40, degrees);
            Assert.AreEqual(30, minutes);
            Assert.AreEqual(30.0, seconds, 0.001);
        }

        [TestMethod]
        public void FromGradiansConvertsToRadiansCorrectly()
        {
            var angle = Angle.FromGradians(0.0);
            Assert.AreEqual(0.0, angle.ToRadians());

            angle = Angle.FromGradians(50.0);
            Assert.AreEqual(Math.PI / 4.0, angle.ToRadians());

            angle = Angle.FromGradians(100.0);
            Assert.AreEqual(Math.PI / 2.0, angle.ToRadians());

            angle = Angle.FromGradians(200.0);
            Assert.AreEqual(Math.PI, angle.ToRadians());

            angle = Angle.FromGradians(400.0);
            Assert.AreEqual(Math.PI * 2.0, angle.ToRadians());

            angle = Angle.FromGradians(double.NaN);
            Assert.AreEqual(double.NaN, angle.ToRadians());
        }

        [TestMethod]
        public void ToGradiansConvertsFromRadiansCorrectly()
        {
            var angle = Angle.FromRadians(0.0);
            Assert.AreEqual(0.0, angle.ToGradians());

            angle = Angle.FromRadians(Math.PI / 4.0);
            Assert.AreEqual(50.0, angle.ToGradians());

            angle = Angle.FromRadians(Math.PI / 2.0);
            Assert.AreEqual(100.0, angle.ToGradians());

            angle = Angle.FromRadians(Math.PI);
            Assert.AreEqual(200.0, angle.ToGradians());

            angle = Angle.FromRadians(Math.PI * 2.0);
            Assert.AreEqual(400.0, angle.ToGradians());

            angle = Angle.FromRadians(double.NaN);
            Assert.AreEqual(double.NaN, angle.ToGradians());
        }

        [TestMethod]
        public void ZeroAngleIsDefinedCorrectly()
        {
            var angle = Angle.Zero;
            Assert.AreEqual(0.0, angle.ToGradians());
            Assert.AreEqual(0.0, angle.ToDegrees());
            Assert.AreEqual(0.0, angle.ToGradians());
        }

        [TestMethod]
        public void RightAngleIsDefinedCorrectly()
        {
            var angle = Angle.Right;
            Assert.AreEqual(Math.PI / 2.0, angle.ToRadians());
            Assert.AreEqual(90.0, angle.ToDegrees());
            Assert.AreEqual(100.0, angle.ToGradians());
        }

        [TestMethod]
        public void StraightAngleIsDefinedCorrectly()
        {
            var angle = Angle.Straight;
            Assert.AreEqual(Math.PI, angle.ToRadians());
            Assert.AreEqual(180.0, angle.ToDegrees());
            Assert.AreEqual(200.0, angle.ToGradians());
        }

        [TestMethod]
        public void FullAngleIsDefinedCorrectly()
        {
            var angle = Angle.Full;
            Assert.AreEqual(Math.PI * 2.0, angle.ToRadians());
            Assert.AreEqual(360.0, angle.ToDegrees());
            Assert.AreEqual(400.0, angle.ToGradians());
        }

        [TestMethod]
        public void ObjectEquals()
        {
            Assert.IsFalse(Angle.Right.Equals(null));
            Assert.IsFalse(Angle.Right.Equals(90.0));
            Assert.IsFalse(Angle.Zero.Equals((object)Angle.Right));
            Assert.IsTrue(Angle.Right.Equals((object)Angle.Right));
        }

        [TestMethod]
        public void ObjectGetHashCode()
        {
            Assert.AreNotEqual(Angle.Zero.GetHashCode(), Angle.Right.GetHashCode());
            Assert.AreEqual(Angle.Right.GetHashCode(), Angle.Right.GetHashCode());
        }

        [TestMethod]
        public void EquatableEquals()
        {
            Assert.IsFalse(Angle.Zero.Equals(Angle.Right));
            Assert.IsTrue(Angle.Right.Equals(Angle.Right));
        }

        [TestMethod]
        public void OperatorEquality()
        {
            Assert.IsFalse(Angle.FromDegrees(0) == Angle.FromDegrees(90));
            Assert.IsTrue(Angle.FromDegrees(90) == Angle.FromDegrees(90));
        }

        [TestMethod]
        public void OperatorInequality()
        {
            Assert.IsTrue(Angle.FromDegrees(0) != Angle.FromDegrees(90));
            Assert.IsFalse(Angle.FromDegrees(90) != Angle.FromDegrees(90));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ComparableCompareToObjectThrowsExcetionOnNull()
        {
            Angle.Right.CompareTo(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ComparableCompareToObjectThrowsExcetionOnOtherType()
        {
            Angle.Right.CompareTo(90.0);
        }

        [TestMethod]
        public void ComparableCompareToObject()
        {
            Assert.AreEqual(-1, Angle.Right.CompareTo((object)Angle.Straight));
            Assert.AreEqual(0, Angle.Right.CompareTo((object)Angle.Right));
            Assert.AreEqual(1, Angle.Right.CompareTo((object)Angle.Zero));
        }

        [TestMethod]
        public void ComparableCompareToAngle()
        {
            Assert.AreEqual(-1, Angle.Right.CompareTo(Angle.Straight));
            Assert.AreEqual(0, Angle.Right.CompareTo(Angle.Right));
            Assert.AreEqual(1, Angle.Right.CompareTo(Angle.Zero));
        }

        [TestMethod]
        public void CompareTwoAngles()
        {
            Assert.AreEqual(-1, Angle.Compare(Angle.Right, Angle.Straight));
            Assert.AreEqual(0, Angle.Compare(Angle.Right, Angle.Right));
            Assert.AreEqual(1, Angle.Compare(Angle.Right, Angle.Zero));
            Assert.AreNotEqual(-1, Angle.Compare(Angle.Right + Angle.Full, Angle.Straight));
            Assert.AreNotEqual(0, Angle.Compare(Angle.Right, Angle.Right + Angle.Full));
            Assert.AreNotEqual(1, Angle.Compare(Angle.Right, Angle.Zero + Angle.Full));
        }

        [TestMethod]
        public void CompareReducedTwoAngles()
        {
            Assert.AreEqual(-1, Angle.CompareReduced(Angle.Right, Angle.Straight));
            Assert.AreEqual(0, Angle.CompareReduced(Angle.Right, Angle.Right));
            Assert.AreEqual(1, Angle.CompareReduced(Angle.Right, Angle.Zero));
            Assert.AreEqual(-1, Angle.CompareReduced(Angle.Right + Angle.Full, Angle.Straight));
            Assert.AreEqual(0, Angle.CompareReduced(Angle.Right, Angle.Right + Angle.Full));
            Assert.AreEqual(1, Angle.CompareReduced(Angle.Right, Angle.Zero + Angle.Full));
        }

        [TestMethod]
        public void LessThanOperator()
        {
            Assert.IsTrue(Angle.Zero < Angle.FromDegrees(90));
            Assert.IsFalse(Angle.FromDegrees(90) < Angle.FromDegrees(90));
            Assert.IsFalse(Angle.FromDegrees(180) < Angle.FromDegrees(90));
        }

        [TestMethod]
        public void LessThanOrEqualToOperator()
        {
            Assert.IsTrue(Angle.FromDegrees(0) <= Angle.FromDegrees(90));
            Assert.IsTrue(Angle.FromDegrees(90) <= Angle.FromDegrees(90));
            Assert.IsFalse(Angle.FromDegrees(180) <= Angle.FromDegrees(90));
        }

        [TestMethod]
        public void GreaterThanOperator()
        {
            Assert.IsFalse(Angle.FromDegrees(0) > Angle.FromDegrees(90));
            Assert.IsFalse(Angle.FromDegrees(90) > Angle.FromDegrees(90));
            Assert.IsTrue(Angle.FromDegrees(180) > Angle.FromDegrees(90));
        }

        [TestMethod]
        public void GreaterThanOrEqualToOperator()
        {
            Assert.IsFalse(Angle.FromDegrees(0) >= Angle.FromDegrees(90));
            Assert.IsTrue(Angle.FromDegrees(90) >= Angle.FromDegrees(90));
            Assert.IsTrue(Angle.FromDegrees(180) >= Angle.FromDegrees(90));
        }

        [TestMethod]
        public void ReduceIsDefinedCorrectly()
        {
            var delta = Angle.FromRadians(0.0000001);

            Assert.AreEqual(Angle.Zero, Angle.Reduce(Angle.Zero));
            Assert.AreEqual(Angle.FromDegrees(45), Angle.Reduce(Angle.FromDegrees(45)));
            Assert.AreEqual(Angle.Right, Angle.Reduce(Angle.Right));
            Assert.AreEqual(Angle.FromDegrees(135), Angle.Reduce(Angle.FromDegrees(135)));
            Assert.AreEqual(Angle.Straight, Angle.Reduce(Angle.Straight));

            Assert.AreEqual(Angle.Zero, Angle.Reduce(Angle.Full));
            Assert.AreEqual(Angle.FromDegrees(45), Angle.Reduce(Angle.FromDegrees(45) + Angle.Full));
            Assert.AreEqual(Angle.Right, Angle.Reduce(Angle.Right + Angle.Full));
            Assert.AreEqual(Angle.FromDegrees(135).ToRadians(), Angle.Reduce(Angle.FromDegrees(135) + Angle.Full).ToRadians(), 0.000001);
            Assert.AreEqual(Angle.Straight, Angle.Reduce(Angle.Straight + Angle.Full));

            Assert.AreEqual(Angle.Zero, Angle.Reduce(-Angle.Full));
            Assert.AreEqual(Angle.FromDegrees(315), Angle.Reduce(-Angle.FromDegrees(45)));
            Assert.AreEqual(Angle.FromDegrees(270), Angle.Reduce(-Angle.Right));
            Assert.AreEqual(Angle.Straight, Angle.Reduce(-Angle.Straight));
            Assert.AreEqual(Angle.Right, Angle.Reduce(-Angle.FromDegrees(270)));

        }

        [TestMethod]
        public void GetQuadrantIsDefinedCorrectly()
        {
            var delta = Angle.FromRadians(0.0000001);

            Assert.AreEqual(Angle.Quadrant.First, Angle.GetQuadrant(Angle.Zero));
            Assert.AreEqual(Angle.Quadrant.First, Angle.GetQuadrant(Angle.FromDegrees(45)));
            Assert.AreEqual(Angle.Quadrant.Second, Angle.GetQuadrant(Angle.Right));
            Assert.AreEqual(Angle.Quadrant.Second, Angle.GetQuadrant(Angle.FromDegrees(135)));
            Assert.AreEqual(Angle.Quadrant.Third, Angle.GetQuadrant(Angle.Straight));
            Assert.AreEqual(Angle.Quadrant.Third, Angle.GetQuadrant(Angle.FromDegrees(225)));
            Assert.AreEqual(Angle.Quadrant.Fourth, Angle.GetQuadrant(Angle.FromDegrees(270)));
            Assert.AreEqual(Angle.Quadrant.Fourth, Angle.GetQuadrant(Angle.FromDegrees(315)));

            Assert.AreEqual(Angle.Quadrant.First, Angle.GetQuadrant(Angle.Full));
            Assert.AreEqual(Angle.Quadrant.First, Angle.GetQuadrant(Angle.FromDegrees(45) + Angle.Full));
            Assert.AreEqual(Angle.Quadrant.Second, Angle.GetQuadrant(Angle.Right + Angle.Full));
            Assert.AreEqual(Angle.Quadrant.Second, Angle.GetQuadrant(Angle.FromDegrees(135) + Angle.Full));
            Assert.AreEqual(Angle.Quadrant.Third, Angle.GetQuadrant(Angle.Straight + Angle.Full));
            Assert.AreEqual(Angle.Quadrant.Third, Angle.GetQuadrant(Angle.FromDegrees(225) + Angle.Full));
            Assert.AreEqual(Angle.Quadrant.Fourth, Angle.GetQuadrant(Angle.FromDegrees(270) + Angle.Full));
            Assert.AreEqual(Angle.Quadrant.Fourth, Angle.GetQuadrant(Angle.FromDegrees(315) + Angle.Full));

        }

        [TestMethod]
        public void ReferenceIsDefinedCorrectly()
        {
            var delta = Angle.FromRadians(0.0000001);

            Assert.AreEqual(Angle.Zero, Angle.GetReference(Angle.Zero));
            Assert.AreEqual(Angle.FromDegrees(45), Angle.GetReference(Angle.FromDegrees(45)));
            Assert.AreEqual(Angle.Right, Angle.GetReference(Angle.Right));
            Assert.AreEqual(Angle.FromDegrees(45), Angle.GetReference(Angle.FromDegrees(135)));
            Assert.AreEqual(Angle.Zero, Angle.GetReference(Angle.Straight));
            Assert.AreEqual(Angle.FromDegrees(45), Angle.GetReference(Angle.FromDegrees(225)));
            Assert.AreEqual(Angle.Right, Angle.GetReference(Angle.FromDegrees(270)));
            Assert.AreEqual(Angle.FromDegrees(45), Angle.GetReference(Angle.FromDegrees(315)));
            Assert.AreEqual(Angle.Zero, Angle.GetReference(Angle.Full));

            Assert.AreEqual(Angle.FromDegrees(45), Angle.GetReference(Angle.FromDegrees(45) + Angle.Full));
            Assert.AreEqual(Angle.Right, Angle.GetReference(Angle.Right + Angle.Full));
            Assert.AreEqual(Angle.FromDegrees(45).ToRadians(), Angle.GetReference(Angle.FromDegrees(135) + Angle.Full).ToRadians(), 0.000001);

        }

        [TestMethod]
        public void IsAcuteIsDefinedCorrectly()
        {
            Assert.IsFalse(Angle.IsAcute(Angle.Zero));
            Assert.IsTrue(Angle.IsAcute(Angle.FromDegrees(45)));
            Assert.IsFalse(Angle.IsAcute(Angle.Right));
            Assert.IsFalse(Angle.IsAcute(Angle.FromDegrees(135)));
            Assert.IsFalse(Angle.IsAcute(Angle.Straight));
            Assert.IsFalse(Angle.IsAcute(Angle.FromDegrees(270)));
            Assert.IsFalse(Angle.IsAcute(Angle.Full));

            Assert.IsTrue(Angle.IsAcute(-Angle.FromDegrees(45)));
            Assert.IsFalse(Angle.IsAcute(-Angle.Right));
            Assert.IsFalse(Angle.IsAcute(-Angle.FromDegrees(135)));
            Assert.IsFalse(Angle.IsAcute(-Angle.Straight));
            Assert.IsFalse(Angle.IsAcute(-Angle.FromDegrees(270)));
            Assert.IsFalse(Angle.IsAcute(-Angle.Full));
        }

        [TestMethod]
        public void IsRightIsDefinedCorrectly()
        {
            Assert.IsFalse(Angle.IsRight(Angle.Zero));
            Assert.IsFalse(Angle.IsRight(Angle.FromDegrees(45)));
            Assert.IsTrue(Angle.IsRight(Angle.Right));
            Assert.IsFalse(Angle.IsRight(Angle.FromDegrees(135)));
            Assert.IsFalse(Angle.IsRight(Angle.Straight));
            Assert.IsFalse(Angle.IsRight(Angle.FromDegrees(270)));
            Assert.IsFalse(Angle.IsRight(Angle.Full));

            Assert.IsFalse(Angle.IsRight(-Angle.FromDegrees(45)));
            Assert.IsTrue(Angle.IsRight(-Angle.Right));
            Assert.IsFalse(Angle.IsRight(-Angle.FromDegrees(135)));
            Assert.IsFalse(Angle.IsRight(-Angle.Straight));
            Assert.IsFalse(Angle.IsRight(-Angle.FromDegrees(270)));
            Assert.IsFalse(Angle.IsRight(-Angle.Full));
        }

        [TestMethod]
        public void IsObtuseIsDefinedCorrectly()
        {
            Assert.IsFalse(Angle.IsObtuse(Angle.Zero));
            Assert.IsFalse(Angle.IsObtuse(Angle.FromDegrees(45)));
            Assert.IsFalse(Angle.IsObtuse(Angle.Right));
            Assert.IsTrue(Angle.IsObtuse(Angle.FromDegrees(135)));
            Assert.IsFalse(Angle.IsObtuse(Angle.Straight));
            Assert.IsFalse(Angle.IsObtuse(Angle.FromDegrees(270)));
            Assert.IsFalse(Angle.IsObtuse(Angle.Full));

            Assert.IsFalse(Angle.IsObtuse(-Angle.FromDegrees(45)));
            Assert.IsFalse(Angle.IsObtuse(-Angle.Right));
            Assert.IsTrue(Angle.IsObtuse(-Angle.FromDegrees(135)));
            Assert.IsFalse(Angle.IsObtuse(-Angle.Straight));
            Assert.IsFalse(Angle.IsObtuse(-Angle.FromDegrees(270)));
            Assert.IsFalse(Angle.IsObtuse(-Angle.Full));
        }

        [TestMethod]
        public void IsStraightIsDefinedCorrectly()
        {
            Assert.IsFalse(Angle.IsStraight(Angle.Zero));
            Assert.IsFalse(Angle.IsStraight(Angle.FromDegrees(45)));
            Assert.IsFalse(Angle.IsStraight(Angle.Right));
            Assert.IsFalse(Angle.IsStraight(Angle.FromDegrees(135)));
            Assert.IsTrue(Angle.IsStraight(Angle.Straight));
            Assert.IsFalse(Angle.IsStraight(Angle.FromDegrees(270)));
            Assert.IsFalse(Angle.IsStraight(Angle.Full));

            Assert.IsFalse(Angle.IsStraight(-Angle.FromDegrees(45)));
            Assert.IsFalse(Angle.IsStraight(-Angle.Right));
            Assert.IsFalse(Angle.IsStraight(-Angle.FromDegrees(135)));
            Assert.IsTrue(Angle.IsStraight(-Angle.Straight));
            Assert.IsFalse(Angle.IsStraight(-Angle.FromDegrees(270)));
            Assert.IsFalse(Angle.IsStraight(-Angle.Full));
        }

        [TestMethod]
        public void IsReflexIsDefinedCorrectly()
        {
            Assert.IsFalse(Angle.IsReflex(Angle.Zero));
            Assert.IsFalse(Angle.IsReflex(Angle.FromDegrees(45)));
            Assert.IsFalse(Angle.IsReflex(Angle.Right));
            Assert.IsFalse(Angle.IsReflex(Angle.FromDegrees(135)));
            Assert.IsFalse(Angle.IsReflex(Angle.Straight));
            Assert.IsTrue(Angle.IsReflex(Angle.FromDegrees(270)));
            Assert.IsFalse(Angle.IsReflex(Angle.Full));

            Assert.IsFalse(Angle.IsReflex(-Angle.FromDegrees(45)));
            Assert.IsFalse(Angle.IsReflex(-Angle.Right));
            Assert.IsFalse(Angle.IsReflex(-Angle.FromDegrees(135)));
            Assert.IsFalse(Angle.IsReflex(-Angle.Straight));
            Assert.IsTrue(Angle.IsReflex(-Angle.FromDegrees(270)));
            Assert.IsFalse(Angle.IsReflex(-Angle.Full));
        }

        [TestMethod]
        public void LerpIsDefinedCorrectly()
        {
            Assert.AreEqual(Angle.FromDegrees(0.0), Angle.Lerp(Angle.FromDegrees(45.0), Angle.FromDegrees(135.0), -0.5));
            Assert.AreEqual(Angle.FromDegrees(45.0), Angle.Lerp(Angle.FromDegrees(45.0), Angle.FromDegrees(135.0), 0.0));
            Assert.AreEqual(Angle.FromDegrees(90.0), Angle.Lerp(Angle.FromDegrees(45.0), Angle.FromDegrees(135.0), 0.5));
            Assert.AreEqual(Angle.FromDegrees(135.0), Angle.Lerp(Angle.FromDegrees(45.0), Angle.FromDegrees(135.0), 1.0));
            Assert.AreEqual(Angle.FromDegrees(180.0), Angle.Lerp(Angle.FromDegrees(45.0), Angle.FromDegrees(135.0), 1.5));

            Assert.AreEqual(Angle.FromDegrees(0.0), Angle.Lerp(Angle.FromDegrees(-45.0), Angle.FromDegrees(-135.0), -0.5));
            Assert.AreEqual(Angle.FromDegrees(-45.0), Angle.Lerp(Angle.FromDegrees(-45.0), Angle.FromDegrees(-135.0), 0.0));
            Assert.AreEqual(Angle.FromDegrees(-90.0), Angle.Lerp(Angle.FromDegrees(-45.0), Angle.FromDegrees(-135.0), 0.5));
            Assert.AreEqual(Angle.FromDegrees(-135.0), Angle.Lerp(Angle.FromDegrees(-45.0), Angle.FromDegrees(-135.0), 1.0));
            Assert.AreEqual(Angle.FromDegrees(-180.0), Angle.Lerp(Angle.FromDegrees(-45.0), Angle.FromDegrees(-135.0), 1.5));

            Assert.AreEqual(Angle.FromDegrees(180.0), Angle.Lerp(Angle.FromDegrees(135.0), Angle.FromDegrees(45.0), -0.5));
            Assert.AreEqual(Angle.FromDegrees(135.0), Angle.Lerp(Angle.FromDegrees(135.0), Angle.FromDegrees(45.0), 0.0));
            Assert.AreEqual(Angle.FromDegrees(90.0), Angle.Lerp(Angle.FromDegrees(135.0), Angle.FromDegrees(45.0), 0.5));
            Assert.AreEqual(Angle.FromDegrees(45.0), Angle.Lerp(Angle.FromDegrees(135.0), Angle.FromDegrees(45.0), 1.0));
            Assert.AreEqual(Angle.FromDegrees(0.0), Angle.Lerp(Angle.FromDegrees(135.0), Angle.FromDegrees(45.0), 1.5));
        }

        [TestMethod]
        public void ToStringIsDefinedCorrectly()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Assert.AreEqual("3.14159265358979", Angle.Straight.ToString());

            Assert.AreEqual("3.14159265358979", Angle.Straight.ToString("R"));
            Assert.AreEqual("180", Angle.Straight.ToString("D"));
            Assert.AreEqual("12° 34.56'", Angle.FromDegrees(12, 34.56).ToString("M"));
            Assert.AreEqual("12° 34' 56.7800000000018\"", Angle.FromDegrees(12, 34, 56.78).ToString("S"));
            Assert.AreEqual("200", Angle.Straight.ToString("G"));

            Assert.AreEqual("3,14159265358979", Angle.Straight.ToString("R", new CultureInfo("pt-PT")));
            Assert.AreEqual("180", Angle.Straight.ToString("D", new CultureInfo("pt-PT")));
            Assert.AreEqual("12° 34,56'", Angle.FromDegrees(12, 34.56).ToString("M", new CultureInfo("pt-PT")));
            Assert.AreEqual("12° 34' 56,7800000000018\"", Angle.FromDegrees(12, 34, 56.78).ToString("S", new CultureInfo("pt-PT")));
            Assert.AreEqual("200", Angle.Straight.ToString("G", new CultureInfo("pt-PT")));

            Assert.AreEqual("Radians: 3.14159265358979", String.Format("Radians: {0:R}", Angle.Straight));
            Assert.AreEqual("Degrees: 180", String.Format("Degrees: {0:D}", Angle.Straight));
            Assert.AreEqual("Degrees: 12° 34.56'", String.Format("Degrees: {0:M}", Angle.FromDegrees(12, 34.56)));
            Assert.AreEqual("Degrees: 12° 34' 56.7800000000018\"", String.Format("Degrees: {0:S}", Angle.FromDegrees(12, 34, 56.78)));
            Assert.AreEqual("Gradians: 200", String.Format("Gradians: {0:G}", Angle.Straight));

            Assert.AreEqual("3.14", Angle.Straight.ToString("R2"));
            Assert.AreEqual("180.00", Angle.Straight.ToString("D2"));
            Assert.AreEqual("12° 34.56'", Angle.FromDegrees(12, 34.56).ToString("M2"));
            Assert.AreEqual("12° 34' 56.78\"", Angle.FromDegrees(12, 34, 56.78).ToString("S2"));
            Assert.AreEqual("200.00", Angle.Straight.ToString("G2"));

            Assert.AreEqual("3,14", Angle.Straight.ToString("R2", new CultureInfo("pt-PT")));
            Assert.AreEqual("180,00", Angle.Straight.ToString("D2", new CultureInfo("pt-PT")));
            Assert.AreEqual("12° 34,56'", Angle.FromDegrees(12, 34.56).ToString("M2", new CultureInfo("pt-PT")));
            Assert.AreEqual("12° 34' 56,78\"", Angle.FromDegrees(12, 34, 56.78).ToString("S2", new CultureInfo("pt-PT")));
            Assert.AreEqual("200,00", Angle.Straight.ToString("G2", new CultureInfo("pt-PT")));

            Assert.AreEqual("Radians: 3,14", String.Format(new CultureInfo("pt-PT"), "Radians: {0:R2}", Angle.Straight));
            Assert.AreEqual("Degrees: 180,00", String.Format(new CultureInfo("pt-PT"), "Degrees: {0:D2}", Angle.Straight));
            Assert.AreEqual("Degrees: 12° 34,56'", String.Format(new CultureInfo("pt-PT"), "Degrees: {0:M2}", Angle.FromDegrees(12, 34.56)));
            Assert.AreEqual("Degrees: 12° 34' 56,78\"", String.Format(new CultureInfo("pt-PT"), "Degrees: {0:S2}", Angle.FromDegrees(12, 34, 56.78)));
            Assert.AreEqual("Gradians: 200,00", String.Format(new CultureInfo("pt-PT"), "Gradians: {0:G2}", Angle.Straight));

        }

    }
}
