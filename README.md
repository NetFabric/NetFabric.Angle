NetFabric.Angle
===============

An immutable angle implementation inspired by System.TimeSpan. The angle is represented internaly in radians but can be created and read in radians, degrees and gradians.

### Usage:

Creation of the angle:

var angle0 = Angle.FromRadian(Math.PI);
var angle1 = Angle.FromDegrees(45.0);
var angle2 = Angle.FromRadian(Math.PI);

Reading the angle:

var radians = angle0.TotalRadians;
var degrees = angle0.TotalDegrees;
var gradians = angle0.TotalGradians;


