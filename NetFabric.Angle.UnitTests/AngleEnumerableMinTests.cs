using NUnit.Framework;
using System;
using System.Globalization;
using System.Linq;

namespace NetFabric.UnitTests
{
    [TestFixture]
    public class AngleEnumerableMinTests
    {
        [Test]
        public void Min_Of_EmptyAngleSequence_Should_ReturnNull()
        {
            Assert.That(Enumerable.Empty<Angle>().Min(), Is.Null);
        }

        [Test]
        public void Min_Of_AngleSequence_Should_ReturnMinValue()
        {
            Assert.That(new Angle[] { Angle.Zero, -Angle.Right, Angle.Full, Angle.Right }.Min(), Is.EqualTo(-Angle.Right));
        }

        [Test]
        public void Min_Of_EmptyNullableAngleSequence_Should_ReturnNull()
        {
            Assert.That(Enumerable.Empty<Angle?>().Min(), Is.Null);
        }

        [Test]
        public void Min_Of_SequenceOfNulls_Should_ReturnNull()
        {
            Assert.That(Enumerable.Repeat<Angle?>(null, 10).Min(), Is.Null);
        }

        [Test]
        public void Min_Of_NullableAngleSequence_Should_ReturnMinValue()
        {
            Assert.That(new Angle?[] { null, Angle.Zero, -Angle.Right, null, Angle.Full, Angle.Right }.Min(), Is.EqualTo(-Angle.Right));
        }
    }
}
