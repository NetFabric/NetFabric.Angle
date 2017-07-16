using FluentAssertions;
using System.Linq;
using Xunit;

namespace NetFabric.UnitTests
{
    public class AngleEnumerableMinTests
    {
        [Fact]
        public void EmptyAngleSequence_Should_ReturnNull()
        {
            Enumerable.Empty<Angle>()
                .Min()
                .Should()
                .BeNull();
        }

        [Fact]
        public void AngleSequence_Should_ReturnMinValue()
        {
            new Angle[] { Angle.Zero, -Angle.Right, Angle.Full, Angle.Right }
                .Min()
                .Should()
                .Be(-Angle.Right);
        }

        [Fact]
        public void EmptyNullableAngleSequence_Should_ReturnNull()
        {
            Enumerable.Empty<Angle?>()
                .Min()
                .Should()
                .BeNull();
        }

        [Fact]
        public void SequenceOfNulls_Should_ReturnNull()
        {
            Enumerable.Repeat<Angle?>(null, 10)
                .Min()
                .Should()
                .BeNull();
        }

        [Fact]
        public void NullableAngleSequence_Should_ReturnMinValue()
        {
            new Angle?[] { null, Angle.Zero, -Angle.Right, null, Angle.Full, Angle.Right }
                .Min()
                .Should()
                .Be(-Angle.Right);
        }
    }
}
