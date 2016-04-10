using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.IsFalse(Angle.Zero == Angle.Right);
            Assert.IsTrue(Angle.Right == Angle.Right);
        }

        [TestMethod]
        public void OperatorInequality()
        {
            Assert.IsTrue(Angle.Zero != Angle.Right);
            Assert.IsFalse(Angle.Right != Angle.Right);
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
        public void LessThanOperator()
        {
            Assert.IsTrue(Angle.Zero < Angle.Right);
            Assert.IsFalse(Angle.Right < Angle.Right);
            Assert.IsFalse(Angle.Straight < Angle.Right);
        }

        [TestMethod]
        public void LessThanOrEqualToOperator()
        {
            Assert.IsTrue(Angle.Zero <= Angle.Right);
            Assert.IsTrue(Angle.Right <= Angle.Right);
            Assert.IsFalse(Angle.Straight <= Angle.Right);
        }

        [TestMethod]
        public void GreaterThanOperator()
        {
            Assert.IsFalse(Angle.Zero > Angle.Right);
            Assert.IsFalse(Angle.Right > Angle.Right);
            Assert.IsTrue(Angle.Straight > Angle.Right);
        }

        [TestMethod]
        public void GreaterThanOrEqualToOperator()
        {
            Assert.IsFalse(Angle.Zero >= Angle.Right);
            Assert.IsTrue(Angle.Right >= Angle.Right);
            Assert.IsTrue(Angle.Straight >= Angle.Right);
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

        }

        [TestMethod]
        public void ReferenceIsDefinedCorrectly()
        {
            var delta = Angle.FromRadians(0.0000001);

            Assert.AreEqual(Angle.Zero, Angle.Reference(Angle.Zero));
            Assert.AreEqual(Angle.FromDegrees(45), Angle.Reference(Angle.FromDegrees(45)));
            Assert.AreEqual(Angle.Right, Angle.Reference(Angle.Right));
            Assert.AreEqual(Angle.FromDegrees(45), Angle.Reference(Angle.FromDegrees(135)));
            Assert.AreEqual(Angle.Zero, Angle.Reference(Angle.Straight));
            Assert.AreEqual(Angle.FromDegrees(45), Angle.Reference(Angle.FromDegrees(225)));
            Assert.AreEqual(Angle.Right, Angle.Reference(Angle.FromDegrees(270)));
            Assert.AreEqual(Angle.FromDegrees(45), Angle.Reference(Angle.FromDegrees(315)));
            Assert.AreEqual(Angle.Zero, Angle.Reference(Angle.Full));

            Assert.AreEqual(Angle.FromDegrees(45), Angle.Reference(Angle.FromDegrees(45) + Angle.Full));
            Assert.AreEqual(Angle.Right, Angle.Reference(Angle.Right + Angle.Full));
            Assert.AreEqual(Angle.FromDegrees(45).ToRadians(), Angle.Reference(Angle.FromDegrees(135) + Angle.Full).ToRadians(), 0.000001);

        }






    }
}
