![GitHub last commit (develop)](https://img.shields.io/github/last-commit/NetFabric/NetFabric.Angle/develop.svg?logo=github&logoColor=lightgray&style=popout-square)
[![Build](https://img.shields.io/azure-devops/build/aalmada/4c56c20d-da8b-4a12-89ec-5b57e6ed8fec/7/develop.svg?style=popout-square&logo=data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIxMiIgaGVpZ2h0PSIxMiI+PGcgZmlsbD0iIzlmOWY5ZiIgZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiPjxwYXRoIGQ9Ik0wIDloMXYyaDJ2MUgwek0uNjY3IDRoMy4wNjhMNi4yMDMuNDQ0QzYuMzkuMTY3IDYuNzAxIDAgNy4wMzUgMEgxMS41YS41LjUgMCAwIDEgLjUuNXY0LjQ2NWExIDEgMCAwIDEtLjQ0NS44MzJMOCA4LjI2NXYzLjA2OGEuNjY3LjY2NyAwIDAgMS0uNjY3LjY2N0g1bC0xLTEgMS4yNS0xLjI1LTEtMUwzIDEwIDIgOWwxLjI1LTEuMjUtMS0xTDEgOCAwIDdWNC42NjdDMCA0LjI5OS4yOTggNCAuNjY3IDR6TTEwLjUgM2ExLjUgMS41IDAgMSAxLTMgMCAxLjUgMS41IDAgMCAxIDMgMHoiLz48L2c+PC9zdmc+)](https://dev.azure.com/aalmada/NetFabric.Angle/)
[![Unit Tests](https://img.shields.io/azure-devops/tests/aalmada/4c56c20d-da8b-4a12-89ec-5b57e6ed8fec/7/develop.svg?style=popout-square&logo=data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIxMiIgaGVpZ2h0PSIxMiI+PGcgZmlsbD0iIzlmOWY5ZiIgZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiPjxwYXRoIGQ9Ik0wIDloMXYyaDJ2MUgwek0uNjY3IDRoMy4wNjhMNi4yMDMuNDQ0QzYuMzkuMTY3IDYuNzAxIDAgNy4wMzUgMEgxMS41YS41LjUgMCAwIDEgLjUuNXY0LjQ2NWExIDEgMCAwIDEtLjQ0NS44MzJMOCA4LjI2NXYzLjA2OGEuNjY3LjY2NyAwIDAgMS0uNjY3LjY2N0g1bC0xLTEgMS4yNS0xLjI1LTEtMUwzIDEwIDIgOWwxLjI1LTEuMjUtMS0xTDEgOCAwIDdWNC42NjdDMCA0LjI5OS4yOTggNCAuNjY3IDR6TTEwLjUgM2ExLjUgMS41IDAgMSAxLTMgMCAxLjUgMS41IDAgMCAxIDMgMHoiLz48L2c+PC9zdmc+)](https://dev.azure.com/aalmada/NetFabric.Angle/)
[![Coverage](https://img.shields.io/azure-devops/coverage/aalmada/4c56c20d-da8b-4a12-89ec-5b57e6ed8fec/7/develop.svg?style=popout-square&logo=data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIxMiIgaGVpZ2h0PSIxMiI+PGcgZmlsbD0iIzlmOWY5ZiIgZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiPjxwYXRoIGQ9Ik0wIDloMXYyaDJ2MUgwek0uNjY3IDRoMy4wNjhMNi4yMDMuNDQ0QzYuMzkuMTY3IDYuNzAxIDAgNy4wMzUgMEgxMS41YS41LjUgMCAwIDEgLjUuNXY0LjQ2NWExIDEgMCAwIDEtLjQ0NS44MzJMOCA4LjI2NXYzLjA2OGEuNjY3LjY2NyAwIDAgMS0uNjY3LjY2N0g1bC0xLTEgMS4yNS0xLjI1LTEtMUwzIDEwIDIgOWwxLjI1LTEuMjUtMS0xTDEgOCAwIDdWNC42NjdDMCA0LjI5OS4yOTggNCAuNjY3IDR6TTEwLjUgM2ExLjUgMS41IDAgMSAxLTMgMCAxLjUgMS41IDAgMCAxIDMgMHoiLz48L2c+PC9zdmc+)](https://dev.azure.com/aalmada/NetFabric.Angle/)
[![NuGet Version](https://img.shields.io/nuget/v/NetFabric.Angle.svg?style=popout-square&logoColor=lightgray&logo=nuget)](https://www.nuget.org/packages/NetFabric.Angle/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/NetFabric.Angle.svg?style=popout-square&logoColor=lightgray&logo=nuget)](https://www.nuget.org/packages/NetFabric.Angle/)


NetFabric.Angle
===============

Implements a structure representing an angle.

The angle is represented internaly in radians but can be created and read in radians, degrees and gradians. Also supports arcminutes and arcseconds, useful for GPS coordinates.

The explicit declaration of the units in creation and reading methods reduces the usual units confusion when dealing with angles.

Includes lerp, reduction, reference angle, comparison, classification and trigonometry operations. 

# Usage:

### Adding to your project

NetFabric.Angle is available as a [NuGet package](https://www.nuget.org/packages/NetFabric.Angle/). Use the NuGet Package Manager in Visual Studio or in Xamarin Studio to easily add it to you project. The package contains support for .NET 3.5, .NET 4.5, .NET 4.6, .NET 4.7 and .NET Standard 1.0.

For Unity, download the .unitypackage from [latest release](https://github.com/aalmada/NetFabric.Angle/releases) and import it into your project.

### Creation of the angle:

Use the methods for the units you are working with:

```csharp
var right0 = Angle.FromRadian(Math.PI / 2.0);
var right1 = Angle.FromDegrees(90.0);
var right2 = Angle.FromGradian(100.0);
```

Arcminutes and arcseconds have to be values in the interval [0.0, 60.0[

```csharp
var right3 = Angle.FromDegrees(90, 0.0); // degrees and arcminutes
var right4 = Angle.FromDegrees(-90, 0, 0.0); // degrees, arcminutes and arcseconds
```

You can use the predefined angles:

```csharp
var zero = Angle.Zero;          // 0 degrees
var right = Angle.Right;        // 90 degrees
var straight = Angle.Straight;  // 180 degrees
var full = Angle.Full;          // 360 degrees
```

### Reading the angle:

```csharp
var radians = angle0.ToRadians();
var degrees = angle0.ToDegrees();
var gradians = angle0.ToGradians();
```

The angle can also be converted to DMS notation. This can be done using either *out* arguments:  
```csharp
int degrees0;
double minute0;
angle.ToDegrees(out degrees0, out minutes0);
    
int degrees1;
int minute1;
double seconds1;
angle.ToDegrees(out degrees1, out minutes1, out seconds1);
```

*out* arguments with C# 7 syntax:

```csharp
angle.ToDegrees(out int degrees0, out double minutes0);
angle.ToDegrees(out int degrees1, out int minutes1, out double seconds1);
```

using Tuples (not supported in .NET 3.5):

```csharp
(int degrees0, double minutes0) = angle.ToDegreesMinutes();
(int degrees1, int minutes1, double seconds1) = angle.ToDegreesMinutesSeconds();
```

### Reduction and reference

The angle can be reduced to a coterminal angle in the range [0.0, 360.0[ degrees:
​    
```csharp
var angle = Angle.Reduce(Angle.Right + Angle.Full); // result is Angle.Right
```

Getting the reference angle (the smallest angle with the x-axis):

```csharp
var angle = Angle.GetReference(Angle.Right + Angle.FromDegrees(45.0)); // result is an angle with 45 degrees
```

### Math operations

Math operators are defined allowing calculations with angles. (For performance reasons the results are not reduced)
​    
```csharp
var angle0 = -Angle.Right; 
var angle1 = Angle.Straight + Angle.FromDegrees(45.0);
var angle2 = 2.0 * Angle.FromDegrees(30.0);
var angle3 = Angle.FromDegrees(30.0) / 2.0;
```

Equivalent methods are also defined so they can be used for languages that do not support operators.

```csharp
var angle0 = Angle.Negate(Angle.Right); 
var angle1 = Angle.Add(Angle.Straight, Angle.FromDegrees(45.0));
var angle2 = Angle.Multiply(2.0, Angle.FromDegrees(30.0));
var angle3 = Angle.Divide(Angle.FromDegrees(30.0), 2.0);
```

### Comparison

Comparison operatores can be used to compare two angles:
​    
```csharp
if(angle0 > angle1 || angle0 == angle2) {
    ...
}
```

For languages that do not support operators use the static Compare() method:
​    
```csharp
if(Angle.Compare(angle0, angle1) <= 0) { // less or equal to
    ...
}
```

For performance reasons, the values compared are not reduced. You'll have to explicitly reduce both angles before comparing:
​    
```csharp
if(Angle.Reduce(angle0) > Angle.Reduce(angle1)) {
    ...
}
```

or use the static CompareReduced() method:

```csharp
if(Angle.CompareReduced(angle0, angle1) > 0) {
    ...
}
```

### Trigonometry

The usual trigonometry operations (sin, cos, tan, asin, acos, atan, sinh and cosh) are available as static methods:

```csharp
double value = Angle.Sin(angle);
Angle angle = Angle.Asin(value);
```

### Classification

You can get the quadrante of the angle

```csharp
var quad0 = Angle.GetQuadrant(Angle.FromDegrees(45.0)); // Angle.Quadrant.First
var quad1 = Angle.GetQuadrant(Angle.FromDegrees(220.0)); // Angle.Quadrant.Third
var quad2 = Angle.GetQuadrant(Angle.FromDegrees(-45.0)); // Angle.Quadrant.Fourth
```

and can check if an angle is acute, right, obtuse, straight or reflex:

```csharp
var isAcute = Angle.IsAcute(Angle.Right); // false
var isAcute = Angle.IsAcute(Angle.FromDegrees(45.0)); // true
var isRight = Angle.IsRight(Angle.Right); // true
```

Classification considers the reduced positive equivalent of the angle so:

```csharp
var isAcute = Angle.IsAcute(Angle.FromDegrees(45.0)); // true
var isAcute = Angle.IsAcute(Angle.FromDegrees(-45.0)); // true
var isAcute = Angle.IsAcute(Angle.FromDegrees(315.0)); // false
```

### String format

The ToString() method supports the following formats:

```csharp
Angle.FromDegrees(45.0).ToString(); // 0.785398163397448
Angle.FromDegrees(45.0).ToString("R"); // 0.785398163397448
Angle.FromDegrees(45.0).ToString("D"); // 45
Angle.FromDegrees(45.0).ToString("M"); // 45° 0'
Angle.FromDegrees(45.0).ToString("S"); // 45° 0' 0"
Angle.FromDegrees(45.0).ToString("G"); // 50
```

Supports the number of decimal places:

```csharp
Angle.FromDegrees(45.0).ToString("R3"); // 0.785
Angle.FromDegrees(45.0).ToString("D3"); // 45.000
Angle.FromDegrees(45.0).ToString("M3"); // 45° 0.000'
Angle.FromDegrees(45.0).ToString("S3"); // 45° 0' 0.000"
Angle.FromDegrees(45.0).ToString("G3"); // 50.000
```

Supports culture:

```csharp
Angle.FromDegrees(45.0).ToString("R3", new CultureInfo("pt-PT")); // 0,785
Angle.FromDegrees(45.0).ToString("D3", new CultureInfo("pt-PT")); // 45,000
Angle.FromDegrees(45.0).ToString("M3", new CultureInfo("pt-PT")); // 45° 0,000'
Angle.FromDegrees(45.0).ToString("S3", new CultureInfo("pt-PT")); // 45° 0' 0,000"
Angle.FromDegrees(45.0).ToString("G3", new CultureInfo("pt-PT")); // 50,000
```

These formats can also be used in String.Format():

```csharp
String.Format("Radians: {0:R3}", Angle.FromDegrees(45.0)); // Radians: 0.785
String.Format("Degrees: {0:S3}", Angle.FromDegrees(45.0)); // Degrees: 45° 0' 0.000"
String.Format(new CultureInfo("pt-PT"), "Degrees: {0:S3}", Angle.FromDegrees(45.0)); // Degrees: 45° 0' 0,000"
```

### IEnumerable extensions

The library contains extensions to easily perform operations on sequences of Angle. It currently supports **Min**, **Max**, **Sum** and **Range**.

```csharp
new Angle[] { Angle.Zero, -Angle.Right, Angle.Full }.Min(); // -Angle.Right
// supports nullables
new Angle?[] { Angle.Zero, -Angle.Right, null, Angle.Full }.Min() // -Angle.Right
```

Range() returns a tuple containing the minimum and maximum performing only one sequence iteration:

```csharp
var range0 = new[] { Angle.Zero, -Angle.Full, Angle.Right }.Range(); // (-Angle.Full, Angle.Right)
var range1 = new[] { Angle.Zero, Angle.Full, Angle.Right }.Range(); // (Angle.Zero, Angle.Full)
// supports range of ranges
var rangeOfRanges = new[] { range1, range0 }.Range(); // (-Angle.Full, Angle.Full)
```

# Credits

The following open-source projects are used to build and test this project:

- [.NET](https://github.com/dotnet)
- [BenchmarkDotNet](https://benchmarkdotnet.org/)
- [coverlet](https://github.com/tonerdo/coverlet)
- [Fluent Assertions](https://fluentassertions.com/)
- [UnityAssemblies](https://github.com/DerploidEntertainment/UnityAssemblies)
- [xUnit.net](https://xunit.net/)