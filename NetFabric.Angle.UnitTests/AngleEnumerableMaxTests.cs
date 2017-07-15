using NUnit.Framework;
using System;
using System.Globalization;
using System.Linq;

namespace NetFabric.UnitTests
{
    [TestFixture]
    public class AngleEnumerableMaxTests
    {
        [Test]
        public void Max_Of_EmptyAngleSequence_Should_ReturnNull()
        {
            Assert.That(Enumerable.Empty<Angle>().Max(), Is.Null);
        }

        [Test]
        public void Max_Of_AngleSequence_Should_ReturnMaxValue()
        {
            Assert.That(new Angle[] { Angle.Zero, -Angle.Right, Angle.Full, Angle.Right }.Max(), Is.EqualTo(Angle.Full));
        }

        [Test]
        public void Max_Of_EmptyNullableAngleSequence_Should_ReturnNull()
        {
            Assert.That(Enumerable.Empty<Angle?>().Max(), Is.Null);
        }

        [Test]
        public void Max_Of_SequenceOfNulls_Should_ReturnNull()
        {
            Assert.That(Enumerable.Repeat<Angle?>(null, 10).Max(), Is.Null);
        }

        [Test]
        public void Max_Of_NullableAngleSequence_Should_ReturnMaxValue()
        {
            Assert.That(new Angle?[] { null, Angle.Zero, -Angle.Right, null, Angle.Full, Angle.Right }.Max(), Is.EqualTo(Angle.Full));
        }
    }
}
