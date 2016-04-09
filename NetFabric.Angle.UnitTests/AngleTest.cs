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
            Assert.AreEqual(0.0, angle.TotalRadians);

            angle = Angle.FromRadians(Math.PI);
            Assert.AreEqual(Math.PI, angle.TotalRadians);

            angle = Angle.FromRadians(double.NaN);
            Assert.AreEqual(double.NaN, angle.TotalRadians);
        }

        [TestMethod]
        public void FromDegreesConvertsToRadiansCorrectly()
        {
            var angle = Angle.FromDegrees(0.0);
            Assert.AreEqual(0.0, angle.TotalRadians);

            angle = Angle.FromDegrees(45.0);
            Assert.AreEqual(Math.PI / 4.0, angle.TotalRadians);

            angle = Angle.FromDegrees(90.0);
            Assert.AreEqual(Math.PI / 2.0, angle.TotalRadians);

            angle = Angle.FromDegrees(180.0);
            Assert.AreEqual(Math.PI, angle.TotalRadians);

            angle = Angle.FromDegrees(360.0);
            Assert.AreEqual(Math.PI * 2.0, angle.TotalRadians);

            angle = Angle.FromDegrees(double.NaN);
            Assert.AreEqual(double.NaN, angle.TotalRadians);
        }

        [TestMethod]
        public void TotalDegreesConvertsFromRadiansCorrectly()
        {
            var angle = Angle.FromRadians(0.0);
            Assert.AreEqual(0.0, angle.TotalDegrees);

            angle = Angle.FromRadians(Math.PI / 4.0);
            Assert.AreEqual(45.0, angle.TotalDegrees);

            angle = Angle.FromRadians(Math.PI / 2.0);
            Assert.AreEqual(90.0, angle.TotalDegrees);

            angle = Angle.FromRadians(Math.PI);
            Assert.AreEqual(180.0, angle.TotalDegrees);

            angle = Angle.FromRadians(Math.PI * 2.0);
            Assert.AreEqual(360.0, angle.TotalDegrees);

            angle = Angle.FromRadians(double.NaN);
            Assert.AreEqual(double.NaN, angle.TotalDegrees);
        }


        [TestMethod]
        public void FromGradiansConvertsToRadiansCorrectly()
        {
            var angle = Angle.FromGradians(0.0);
            Assert.AreEqual(0.0, angle.TotalRadians);

            angle = Angle.FromGradians(50.0);
            Assert.AreEqual(Math.PI / 4.0, angle.TotalRadians);

            angle = Angle.FromGradians(100.0);
            Assert.AreEqual(Math.PI / 2.0, angle.TotalRadians);

            angle = Angle.FromGradians(200.0);
            Assert.AreEqual(Math.PI, angle.TotalRadians);

            angle = Angle.FromGradians(400.0);
            Assert.AreEqual(Math.PI * 2.0, angle.TotalRadians);

            angle = Angle.FromGradians(double.NaN);
            Assert.AreEqual(double.NaN, angle.TotalRadians);
        }

        [TestMethod]
        public void TotalGradiansConvertsFromRadiansCorrectly()
        {
            var angle = Angle.FromRadians(0.0);
            Assert.AreEqual(0.0, angle.TotalGradians);

            angle = Angle.FromRadians(Math.PI / 4.0);
            Assert.AreEqual(50.0, angle.TotalGradians);

            angle = Angle.FromRadians(Math.PI / 2.0);
            Assert.AreEqual(100.0, angle.TotalGradians);

            angle = Angle.FromRadians(Math.PI);
            Assert.AreEqual(200.0, angle.TotalGradians);

            angle = Angle.FromRadians(Math.PI * 2.0);
            Assert.AreEqual(400.0, angle.TotalGradians);

            angle = Angle.FromRadians(double.NaN);
            Assert.AreEqual(double.NaN, angle.TotalGradians);
        }

        [TestMethod]
        public void ZeroAngleIsDefinedCorrectly()
        {
            var angle = Angle.Zero;
            Assert.AreEqual(0.0, angle.TotalGradians);
            Assert.AreEqual(0.0, angle.TotalDegrees);
            Assert.AreEqual(0.0, angle.TotalGradians);
        }

        [TestMethod]
        public void RightAngleIsDefinedCorrectly()
        {
            var angle = Angle.Right;
            Assert.AreEqual(Math.PI / 2.0, angle.TotalRadians);
            Assert.AreEqual(90.0, angle.TotalDegrees);
            Assert.AreEqual(100.0, angle.TotalGradians);
        }

        [TestMethod]
        public void StraightAngleIsDefinedCorrectly()
        {
            var angle = Angle.Straight;
            Assert.AreEqual(Math.PI, angle.TotalRadians);
            Assert.AreEqual(180.0, angle.TotalDegrees);
            Assert.AreEqual(200.0, angle.TotalGradians);
        }

        [TestMethod]
        public void FullAngleIsDefinedCorrectly()
        {
            var angle = Angle.Full;
            Assert.AreEqual(Math.PI * 2.0, angle.TotalRadians);
            Assert.AreEqual(360.0, angle.TotalDegrees);
            Assert.AreEqual(400.0, angle.TotalGradians);
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






    }
}
