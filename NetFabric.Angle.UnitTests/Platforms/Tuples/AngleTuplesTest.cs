using FluentAssertions;
using Xunit;

namespace NetFabric.UnitTests
{
    public class AngleTuplesTests
    {
        [Fact]
        public void ToTupleDegreesMinutesConvertsFromRadiansCorrectly()
        {

            var angle = Angle.FromRadians(0.0);
            (int degrees, double minutes) = angle.ToDegreesMinutes();
            degrees.Should().Be(0);
            minutes.Should().BeApproximately(0.0, 0.000001);

            angle = Angle.FromRadians(0.706858347);
            (int degrees1, double minutes1) = angle.ToDegreesMinutes();
            degrees1.Should().Be(40);
            minutes1.Should().BeApproximately(30.0, 0.000001);

            angle = Angle.FromRadians(-0.706858347);
            (int degrees2, double minutes2) = angle.ToDegreesMinutes();
            degrees2.Should().Be(-40);
            minutes2.Should().BeApproximately(30.0, 0.000001);
        }

        [Fact]
        public void ToTupleDegreesMinutesSecondsConvertsFromRadiansCorrectly()
        {

            var angle = Angle.FromRadians(0.0);
            (int degrees, int minutes, double seconds) = angle.ToDegreesMinutesSeconds();
            degrees.Should().Be(0);
            minutes.Should().Be(0);
            seconds.Should().BeApproximately(0, 0.001);

            angle = Angle.FromRadians(0.707003791);
            (int degrees1, int minutes1, double seconds1) = angle.ToDegreesMinutesSeconds();
            degrees1.Should().Be(40);
            minutes1.Should().Be(30);
            seconds1.Should().BeApproximately(30.0, 0.001);

            angle = Angle.FromRadians(-0.707003791);
            (int degrees2, int minutes2, double seconds2) = angle.ToDegreesMinutesSeconds();
            degrees2.Should().Be(-40);
            minutes2.Should().Be(30);
            seconds2.Should().BeApproximately(30.0, 0.001);
        }

    }
}
