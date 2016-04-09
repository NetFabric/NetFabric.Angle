NetFabric.Angle
===============

An immutable angle implementation inspired by System.TimeSpan. The angle is represented internaly in radians but can be created and read in radians, degrees and gradians.

# Usage:

### Creation of the angle:

    var angle0 = Angle.FromRadian(Math.PI / 2.0);
    var angle1 = Angle.FromDegrees(90.0);
    var angle2 = Angle.FromRadian(50.0);
    var angle3 = Angle.Zero;     // 0 degrees
    var angle4 = Angle.Right;    // 90 degrees
    var angle5 = Angle.Straight; // 180 degrees
    var angle6 = Angle.Full;     // 360 degrees

### Reading the angle:

    var radians = angle0.TotalRadians;
    var degrees = angle0.TotalDegrees;
    var gradians = angle0.TotalGradians;


