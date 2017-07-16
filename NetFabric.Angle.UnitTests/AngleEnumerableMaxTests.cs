using FluentAssertions;
using System.Linq;
using Xunit;

namespace NetFabric.UnitTests
{
    public class AngleEnumerableMaxTests
    {
        [Fact]
        public void EmptyAngleSequence_Should_ReturnNull()
        {
            Enumerable.Empty<Angle>()
                .Max()
                .Should().BeNull();
        }

        [Fact]
        public void AngleSequence_Should_ReturnMaxValue()
        {
            new Angle[] { Angle.Zero, -Angle.Right, Angle.Full, Angle.Right }
                .Max()
                .Should()
                .Be(Angle.Full);
        }

        [Fact]
        public void EmptyNullableAngleSequence_Should_ReturnNull()
        {
            Enumerable.Empty<Angle?>().Max()
                .Should()
                .BeNull();
        }

        [Fact]
        public void SequenceOfNulls_Should_ReturnNull()
        {
            Enumerable.Repeat<Angle?>(null, 10)
                .Max()
                .Should()
                .BeNull();
        }

        [Fact]
        public void NullableAngleSequence_Should_ReturnMaxValue()
        {
            new Angle?[] { null, Angle.Zero, -Angle.Right, null, Angle.Full, Angle.Right }
                .Max()
                .Should()
                .Be(Angle.Full);
        }
    }
}
