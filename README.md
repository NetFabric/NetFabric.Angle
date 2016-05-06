NetFabric.Angle
===============

[![Join the chat at https://gitter.im/aalmada/NetFabric.Angle](https://badges.gitter.im/aalmada/NetFabric.Angle.svg)](https://gitter.im/aalmada/NetFabric.Angle?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge) [![Build status](https://ci.appveyor.com/api/projects/status/6lfc5ymh0wip5msi?svg=true)](https://ci.appveyor.com/project/AntaoAlmada/netfabric-angle/) [![Nuget Badge](https://buildstats.info/nuget/NetFabric.Angle)](https://www.nuget.org/packages/NetFabric.Angle/)

Implements a structure representing an angle.

The angle is represented internaly in radians but can be created and read in radians, degrees and gradians. Also supports arcminutes and arcseconds, useful for GPS coordinates.

The explicit declaration of the units in creation and reading methods reduces the usual units confusion when dealing with angles.

Includes lerp, reduction, reference angle, comparison, classification and trigonometry operations. 

# Usage:

### Adding to your project

NetFabric.Angle is available as a [NuGet package](https://www.nuget.org/packages/NetFabric.Angle/). Use the NuGet Package Manager in Visual Studio or in Xamarin Studio to easily add it to you project.

The package contains a portable library that can be added to almost any type of .NET project (.NET 3.5, .NET 4.5, ASP.NET Core 1.0, Windows 8, Xamarin.Android, Xamarin.iOS, Windows Phone 8.1 and .NET Micro Framework 4.4).

For Unity, download the .unitypackage from [latest release](https://github.com/aalmada/NetFabric.Angle/releases) and import it into your project.

### Creation of the angle:

Use the methods for the units you are working with:

```csharp
var right0 = Angle.FromRadian(Math.PI / 2.0);
var right1 = Angle.FromDegrees(90.0);
var right2 = Angle.FromGradian(50.0);
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
    
Retrieving arcminutes and arcseconds uses a different sintax:
    
```csharp
int degrees0;
double minute0;
angle.ToDegrees(out degrees0, out minutes0);
    
int degrees1;
int minute1;
double seconds1;
angle.ToDegrees(out degrees1, out minutes1, out seconds1);
```

### Reduction and reference

The angle can be reduced to a coterminal angle in the range [0.0, 360.0[ degrees:
    
```csharp
var angle = Angle.Reduce(Angle.Right + Angle.Full); // result is Angle.Right
```
    
Getting the reference angle:

```csharp
var angle = Angle.GetReference(Angle.Right + Angle.FromDegrees(45.0)); // result is an angle with 45 degrees
```
    
### Math operations

Math operators are defined allowing calculations with angles. For performance reasons the results are not reduced.
    
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
    
```csharp
if(angle0 > angle1 || angle0 == angle2) {
    ...
}
```
    
For languages that do not support operators use the static Compare() method:
    
```csharp
if(Angle.Compare(angle0, angle1) <= 0) { // less or equal to
    ...
}
```
    
For performance reasons, the values compared are not reduced. You'll have to explicitly reduce both angles before comparing:
    
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
var value = Angle.Sin(angle);
var angle = Angle.Asin(value);
```

### Classification

You can get the quadrante of the angle

```csharp
var quad0 = Angle.GetQuadrant(Angle.FromDegrees(45.0)); // Angle.Quadrant.First
var quad1 = Angle.GetQuadrant(Angle.FromDegrees(22.0)); // Angle.Quadrant.Third
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

Supports culture (except for .NET Micro Framework):

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

