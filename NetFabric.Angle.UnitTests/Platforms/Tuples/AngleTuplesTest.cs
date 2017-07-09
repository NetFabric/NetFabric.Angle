using NUnit.Framework;

namespace NetFabric.UnitTests
{
    [TestFixture]
    public class AngleTuplesTests
    {
        [Test]
        public void ToTupleDegreesMinutesConvertsFromRadiansCorrectly()
        {

            var angle = Angle.FromRadians(0.0);
            (int degrees, double minutes) = angle.ToDegreesMinutes();
            Assert.That(degrees, Is.Zero);
            Assert.That(minutes, Is.Zero.Within(0.000001));

            angle = Angle.FromRadians(0.706858347);
            (int degrees1, double minutes1) = angle.ToDegreesMinutes();
            Assert.That(degrees1, Is.EqualTo(40));
            Assert.That(minutes1, Is.EqualTo(30.0).Within(0.000001));

            angle = Angle.FromRadians(-0.706858347);
            (int degrees2, double minutes2) = angle.ToDegreesMinutes();
            Assert.That(degrees2, Is.EqualTo(-40));
            Assert.That(minutes2, Is.EqualTo(30.0).Within(0.000001));
        }

        [Test]
        public void ToTupleDegreesMinutesSecondsConvertsFromRadiansCorrectly()
        {

            var angle = Angle.FromRadians(0.0);
            (int degrees, int minutes, double seconds) = angle.ToDegreesMinutesSeconds();
            Assert.That(degrees, Is.Zero);
            Assert.That(minutes, Is.Zero);
            Assert.That(seconds, Is.Zero.Within(0.001));

            angle = Angle.FromRadians(0.707003791);
            (int degrees1, int minutes1, double seconds1) = angle.ToDegreesMinutesSeconds();
            Assert.That(degrees1, Is.EqualTo(40));
            Assert.That(minutes1, Is.EqualTo(30));
            Assert.That(seconds1, Is.EqualTo(30.0).Within(0.001));

            angle = Angle.FromRadians(-0.707003791);
            (int degrees2, int minutes2, double seconds2) = angle.ToDegreesMinutesSeconds();
            Assert.That(degrees2, Is.EqualTo(-40));
            Assert.That(minutes2, Is.EqualTo(30));
            Assert.That(seconds2, Is.EqualTo(30.0).Within(0.001));
        }

    }
}
