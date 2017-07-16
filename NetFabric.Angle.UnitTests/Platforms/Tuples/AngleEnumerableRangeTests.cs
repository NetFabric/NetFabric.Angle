using FluentAssertions;
using System.Linq;
using Xunit;

namespace NetFabric.UnitTests
{
    public class AngleEnumerableRangeTests
    {
        [Fact]
        public void EmptyAngleSequence_Should_ReturnNull()
        {
            Enumerable.Empty<Angle>()
                .Range()
                .Should()
                .BeNull();
        }

        [Fact]
        public void AngleSequenceWithOneItem_Should_ReturnRangeWithSameValues()
        {
            new Angle[] { -Angle.Right }
                .Range()
                .Should()
                .Be((-Angle.Right, -Angle.Right));
        }

        [Fact]
        public void AngleSequence_Should_ReturnRangeValue()
        {
            new Angle[] { Angle.Zero, -Angle.Right, Angle.Full, Angle.Right }
                .Range()
                .Should()
                .Be((-Angle.Right, Angle.Full));
        }

        [Fact]
        public void EmptyNullableAngleSequence_Should_ReturnNull()
        {
            Enumerable.Empty<Angle?>()
                .Range()
                .Should()
                .BeNull();
        }

        [Fact]
        public void NullableAngleSequenceOfNulls_Should_ReturnNull()
        {
            Enumerable.Repeat<Angle?>(null, 10)
                .Range()
                .Should()
                .BeNull();
        }

        [Fact]
        public void NullableAngleSequenceWithOneNotNullItem_Should_ReturnRangeWithSameValues()
        {
            new Angle?[] { null, -Angle.Right, null }
                .Range()
                .Should()
                .Be((-Angle.Right, -Angle.Right));
        }

        [Fact]
        public void NullableAngleSequence_Should_ReturnRangeValue()
        {
            new Angle?[] { null, Angle.Zero, -Angle.Right, null, Angle.Full, Angle.Right }
                .Range()
                .Should()
                .Be((-Angle.Right, Angle.Full));
        }

        [Fact]
        public void EmptyAngleRangeSequence_Should_ReturnNull()
        {
            Enumerable.Empty<(Angle, Angle)>()
                .Range()
                .Should()
                .BeNull();
        }

        [Fact]
        public void AngleRangeSequenceWithOneItem_Should_ReturnTheItem()
        {
            new (Angle, Angle)[] { (-Angle.Right, Angle.Full) }
                .Range()
                .Should()
                .Be((-Angle.Right, Angle.Full));
        }

        [Fact]
        public void AngleRangeSequence_Should_ReturnRangeValue()
        {
            new (Angle, Angle)[] { (-Angle.Right, Angle.Zero), (Angle.Right, Angle.Full) }
                .Range()
                .Should()
                .Be((-Angle.Right, Angle.Full));
        }

        [Fact]
        public void EmptyNullableAngleRangeSequence_Should_ReturnNull()
        {
            Enumerable.Empty<(Angle, Angle)?>()
                .Range()
                .Should()
                .BeNull();
        }

        [Fact]
        public void NullableAngleRangeSequenceWithSequenceOfNulls_Should_ReturnNull()
        {
            Enumerable.Repeat<(Angle, Angle)?>(null, 10)
                .Range()
                .Should()
                .BeNull();
        }

        [Fact]
        public void NullableAngleRangeSequenceWithOneNotNullItem_Should_ReturnRangeWithSameValues()
        {
            new(Angle, Angle)?[] { null, (-Angle.Right, Angle.Full), null }
                .Range()
                .Should()
                .Be((-Angle.Right, Angle.Full));
        }

        [Fact]
        public void NullableAngleRangeSequence_Should_ReturnRangeValue()
        {
            new(Angle, Angle)?[] { null, (-Angle.Right, Angle.Zero), null, (Angle.Right, Angle.Full), null }
                .Range()
                .Should()
                .Be((-Angle.Right, Angle.Full));
        }

    }
}
