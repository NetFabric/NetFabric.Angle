NetFabric.Angle
===============

[![Build status](https://ci.appveyor.com/api/projects/status/6lfc5ymh0wip5msi?svg=true)](https://ci.appveyor.com/project/AntaoAlmada/netfabric-angle/)

The angle is represented internaly in radians but can be created and read in radians, degrees and gradians.

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

    var radians = angle0.ToRadians();
    var degrees = angle0.ToDegrees();
    var gradians = angle0.ToGradians();
    
    int degrees0;
    double minute0;
    angle0.ToDegrees(out degrees0, out minutes0);
    
    int degrees1;
    int minute1;
    double seconds1;
    angle0.ToDegrees(out degrees1, out minutes1, out seconds1);

