![GitHub last commit (develop)](https://img.shields.io/github/last-commit/NetFabric/NetFabric.Angle/master)
![GitHub Workflow Status (branch)](https://img.shields.io/github/workflow/status/NetFabric/NetFabric.Angle/.NET%20Core/master)
[![NuGet Version](https://img.shields.io/nuget/v/NetFabric.Angle.svg)](https://www.nuget.org/packages/NetFabric.Angle/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/NetFabric.Angle.svg)](https://www.nuget.org/packages/NetFabric.Angle/)

NetFabric.Angle
===============

Implements a structure representing an angle.

The angle is stored in memory in the angle measurement unit it was originally defined, with double precision, allowing fine control over conversions and reducing rounding errors. All operations are strongly-typed.

Includes angle operations like lerp, reduction, reference angle, comparison, classification and trigonometry. 

# Usage:

### Adding to your project

NetFabric.Angle is available as a [NuGet package](https://www.nuget.org/packages/NetFabric.Angle/) and as a [Unity package](https://github.com/NetFabric/NetFabric.Angle/releases).

### Creation of the angle:

Use the methods for the measurement units you are working with:

``` csharp
var right0 = Angle.FromRadian(Math.PI / 2.0);
var right1 = Angle.FromDegrees(90.0);
var right3 = Angle.FromGradian(100.0);
```

When using DMS format, arcminutes and arcseconds have to be values in the interval [0.0, 60.0[

``` csharp
var right3 = Angle.FromDegrees(90, 59.9); // degrees and arcminutes
var right4 = Angle.FromDegrees(-90, 59, 59.9); // degrees, arcminutes and arcseconds
```

You can use the predefined angles in any measuring unit:

``` csharp
var zero = AngleDegrees.Zero;          // 0 degrees
var right = AngleDegrees.Right;        // 90 degrees
var straight = AngleDegrees.Straight;  // 180 degrees
var full = AngleDegrees.Full;          // 360 degrees
```

``` csharp
var zero = AngleRadians.Zero;          // 0 radians
var right = AngleRadians.Right;        // PI/2 radians
var straight = AngleRadians.Straight;  // PI radians
var full = AngleRadians.Full;          // 2 * PI radians
```

### Converting the angle:

Use the `static` methods to convert any angle:

``` csharp
var radians = Angle.ToRadians(angle);
```

Angles are strongly typed so it knows what measuring unit is converting from. 

**Note:** If required, the results have to be explicitly reduced.

### Reading the angle:

Use the property named after the measuring unit (to be explicit):

``` csharp
var radians = angleRadians.Radians;
var degrees = angleDegrees.Degrees;
var gradians = angleGradians.Gradians;
```

An angle in degrees can be deconstructed into DMS notation. This can be done using either *out* arguments:

``` csharp
int degrees0;
double minute0;
angleDegrees.Deconstruct(out degrees0, out minutes0);

int degrees1;
int minute1;
double seconds1;
angleDegrees.Deconstruct(out degrees1, out minutes1, out seconds1);
```

*out* arguments with C# 7 syntax:

``` csharp
angleDegrees.Deconstruct(out var degrees0, out var minutes0);
angleDegrees.Deconstruct(out var degrees1, out var minutes1, out var seconds1);
```

or using C# 7 deconstructors:

``` csharp
var (degrees0, minutes0) = angleDegrees;
var (degrees1, minutes1, seconds1) = angleDegrees;
```

### Reduction and reference

The angle can be reduced to a coterminal angle in the range [0.0, 360.0[ degrees:
​
``` csharp
var angle = Angle.Reduce(AngleDegrees.Right + AngleDegrees.Full); // result is AngleDegrees.Right
```

Getting the reference angle (the smallest angle with the x-axis):

``` csharp
var angle = Angle.GetReference(AngleDegrees.Right + AngleDegrees.FromDegrees(45.0)); // result is an angle with 45 degrees
```

### Math operations

Math operators are defined allowing calculations with angles.
​
``` csharp
var angle0 = -AngleDegrees.Right;
var angle1 = AngleDegrees.Straight + Angle.FromDegrees(45.0);
var angle2 = 2.0 * Angle.FromDegrees(30.0);
var angle3 = Angle.FromDegrees(30.0) / 2.0;
```

**Note:** If required, the results have to be explicitly reduced.

Equivalent methods are also defined so they can be used for languages that do not support operators.

``` csharp
var angle0 = Angle.Negate(AngleDegrees.Right);
var angle1 = Angle.Add(AngleDegrees.Straight, Angle.FromDegrees(45.0));
var angle2 = Angle.Multiply(2.0, Angle.FromDegrees(30.0));
var angle3 = Angle.Divide(Angle.FromDegrees(30.0), 2.0);
```

### Comparison

Comparison operatores can be used to compare two angles:
​
``` csharp
if(angle0 > angle1 || angle0 == angle2) {
    ...
}
```

For languages that do not support operators use the static Compare() method:
​
``` csharp
if(Angle.Compare(angle0, angle1) <= 0) { // less or equal to
    ...
}
```

For performance reasons, the values compared are not reduced. If required, they have to be explicitly reduced:
​
``` csharp
if(Angle.Reduce(angle0) > Angle.Reduce(angle1)) {
    ...
}
```

or use the static CompareReduced() method:

``` csharp
if(Angle.CompareReduced(angle0, angle1) > 0) {
    ...
}
```

### Trigonometry

The usual trigonometry operations (sin, cos, tan, asin, acos, atan, sinh and cosh) are available as static methods but only for angles in radians:

``` csharp
double value0 = Angle.Sin(angleRadians);
AngleRadians angle0 = Angle.Asin(value0);
```

Angles not in radians have to be converted:

``` csharp
double value1 = Angle.Sin(Angle.ToRadians(angleDegrees));
AngleDegrees angle1 = Angle.ToDegrees(Angle.Asin(value1));
```

### Classification

You can get the quadrante of the angle

``` csharp
var quad0 = Angle.GetQuadrant(Angle.FromDegrees(45.0)); // Angle.Quadrant.First
var quad1 = Angle.GetQuadrant(Angle.FromDegrees(220.0)); // Angle.Quadrant.Third
var quad2 = Angle.GetQuadrant(Angle.FromDegrees(-45.0)); // Angle.Quadrant.Fourth
```

and can check if an angle is acute, right, obtuse, straight or reflex:

``` csharp
var isAcute = Angle.IsAcute(AngleDegrees.Right); // false
var isAcute = Angle.IsAcute(Angle.FromDegrees(45.0)); // true
var isRight = Angle.IsRight(AngleDegrees.Right); // true
```

Classification considers the reduced positive equivalent of the angle so:

``` csharp
var isAcute = Angle.IsAcute(Angle.FromDegrees(45.0)); // true
var isAcute = Angle.IsAcute(Angle.FromDegrees(-45.0)); // true
var isAcute = Angle.IsAcute(Angle.FromDegrees(315.0)); // false
```
