NetFabric.Angle
===============

[![Join the chat at https://gitter.im/aalmada/NetFabric.Angle](https://badges.gitter.im/aalmada/NetFabric.Angle.svg)](https://gitter.im/aalmada/NetFabric.Angle?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

[![Build status](https://ci.appveyor.com/api/projects/status/6lfc5ymh0wip5msi?svg=true)](https://ci.appveyor.com/project/AntaoAlmada/netfabric-angle/) [![Nuget Badge](https://buildstats.info/nuget/NetFabric.Angle)](https://www.nuget.org/packages/NetFabric.Angle/)

Implements a structure representing an angle.

The angle is represented internaly in radians but can be created and read in radians, degrees and gradians. Also supports arcminutes and arcseconds, useful for GPS coordinates.

The explicit declaration of the units in creation and reading methods reduces the tipical confusion when dealing with angles.

Includes reduction, reference angle, comparison, classification and trigonometry operations. 

# Usage:

### Adding to your project

NetFabric.Angle is [published as a NuGet package](https://www.nuget.org/packages/NetFabric.Angle/). Use the NuGet Package Manager in Visual Studio or in Xamarin Studio to easily add it to you project.

The package contains a portable library that can be added to almost any type of .NET project (.NET 4.5, ASP.NET Core 1.0, Windows 8, Xamarin.Android, Xamarin.iOS, Windows Phone 8.1).

### Creation of the angle:

Use the methods for the units you are working with:
    
    var angle0 = Angle.FromRadian(Math.PI / 2.0);
    var angle1 = Angle.FromDegrees(90.0);
    var angle4 = Angle.FromGradian(50.0);

Arcminutes and arcseconds have to be values in the range [0.0, 60.0[

    var angle2 = Angle.FromDegrees(90, 0.0); // degrees and arcminutes
    var angle3 = Angle.FromDegrees(-90, 0, 0.0); // degrees, arcminutes and arcseconds

You can use the predefined angles:

    var angle3 = Angle.Zero;     // 0 degrees
    var angle4 = Angle.Right;    // 90 degrees
    var angle5 = Angle.Straight; // 180 degrees
    var angle6 = Angle.Full;     // 360 degrees

### Reading the angle:

    var radians = angle0.ToRadians();
    var degrees = angle0.ToDegrees();
    var gradians = angle0.ToGradians();
    
Retrieving arcminutes and arcseconds uses a different sintax:
    
    int degrees0;
    double minute0;
    angle0.ToDegrees(out degrees0, out minutes0);
    
    int degrees1;
    int minute1;
    double seconds1;
    angle0.ToDegrees(out degrees1, out minutes1, out seconds1);

### Reduction and reference

The angle can be reduced to a coterminal angle in the range [0.0, 360.0[ degrees:
    
    var angle = Math.Reduce(Angle.Right + Angle.Full); // result is Angle.Right
    
Getting the reference angle:

    var angle = Math.GetReference(Angle.Right + Angle.FromDegrees(45.0)); // result is an angle with 45 degrees
    
### Math operations

Math operators are defined allowing calculations with angles. For performance reasons the results are not reduced.
    
    var angle0 = -Angle.Right; 
    var angle1 = Angle.Straight + Angle.FromDegrees(45.0);
    var angle2 = 2.0 * Angle.FromDegrees(30.0);
    var angle3 = Angle.FromDegrees(30.0) / 2.0;
    
Equivalent methods are also defined so they can be used for languages that do not support operators.

    var angle0 = Angle.Negate(Angle.Right); 
    var angle1 = Angle.Add(Angle.Straight, Angle.FromDegrees(45.0));
    var angle2 = Angle.Multiply(2.0, Angle.FromDegrees(30.0));
    var angle3 = Angle.Divide(Angle.FromDegrees(30.0), 2.0);
    
### Comparison

Comparison operatores can be used to compare two angles:
    
    if(angle0 > angle1 || angle0 == angle2) {
        ...
    }
    
For languages that do not support operators use the static Compare() method:
    
    if(Angle.Compare(angle0, angle1) <= 0) { // less or equal to
        ...
    }
    
For performance reasons, the values compared are not reduced. You have to explicitly reduce both angles before comparing:
    
    if(Math.Reduce(angle0) > Math.Reduce(angle1)) {
        ...
    }
    
or use the static CompareReduced() method:

    if(Math.CompareReduced(angle0, angle1) > 0) {
        ...
    }

### Trigonometry

The usual trigonometry sin, cos, tan, asin, acos, atan, sinh, cosh,  operations are available:

    var value = Angle.Sin(angle);
    var angle = Angle.Asin(value);

### Classification

You can get the quadrante of the angle

    var quad0 = Angle.GetQuadrant(Angle.FromDegrees(45.0)); // Quadrant.First
    var quad1 = Angle.GetQuadrant(Angle.FromDegrees(22.0)); // Quadrant.Third
    var quad2 = Angle.GetQuadrant(Angle.FromDegrees(-45.0)); // Quadrant.Fourth

and can check if an angle is acute, right, obtuse, straight or reflex:

    var acute = Angle.IsAcute(Angle.Right); // false
    var acute = Angle.IsAcute(Angle.FromDegrees(45.0)); // true
    var right = Angle.IsRight(Angle.Right); // true
    
Classification considers the reduced positive equivalent of the angle so:

    var acute = Angle.IsAcute(Angle.FromDegrees(-45.0)); // true
    var acute = Angle.IsAcute(Angle.FromDegrees(315.0)); // false
