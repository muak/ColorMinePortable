# ColorMinePortable

This is the library that it made ColorMine(https://github.com/THEjoezack/ColorMine)  correspond to portable class library.

This program uses the following munsell data.

http://www.rit.edu/cos/colorscience/rc_munsell_renotation.php real.dat

## Nuget Installation

```bash
Install-Package ColorMinePortable
```

## Difference form original

* Add ColorSpace
    * Munsell(approximate)
    * Hex
* not supported CMYK profiles
* changed HSL value range 0 to 1
* changed HSV and HSB algorithm


## Munsell Conversion

```csharp
var munsell = new Munsell("5R 4/10");	//Chromatic color
var rgb = munsell.To<Rgb>();
var str = munsell.ToString(); // return "5R 4/10"
var retmunsell = rgb.To<Munsell>();	// approximate.  Not Equal "5R 4/10".

var munsell2 = new Munsell("N7.5"); //Achromatic color
var rgb2 = munsell2.To<Rgb>();
```


## Hex Conversion

```csharp
var hex  = new Hex("#FFFFFF");
var hex2 = new Hex("FFFFFF");	//  # none OK
var hex3 = new Hex("FFF");		// Triplet OK

var rgb = hex.To<Rgb>();
var code = hex.Code;	// return "#FFFFFF"
var rethex = rgb.To<Hex>();	// "#FFFFFF"
```


# ColorMine

MIT Licensed .Net library that makes converting between color spaces and comparing colors easy.


## Getting Started

ColorMine is available as a [nuget package](https://www.nuget.org/packages/ColorMinePortable/) so you can install by searching for "ColorMinePortable" in the "Manage Nuget Packages" menu, or run the following command in the Package Manager Console:

*PM> Install-Package ColorMinePortable*

## Color Conversions

You can convert between any supported color spaces via generic methods like so:


```c#
var myRgb = new Rgb { R = 149, G = 13, B = 12 }
var myCmy = myRgb.To<Cmy>();
```


```c#
var myXyz = new Xyz { X = .44, Y = .7, Z = .99 }
var myLab = myXyz.To<Lab>();
```

```c#
var myYxy = new Xyz { Y1 = .1124, X = .22, Y2 = .14 }
var myHsl = myYxy.To<Hsl>();
```

Cmyk conversion also supports profiles
```c#
var myCmyk = myRgb
    .WithProfile("~/JapanWebCoated.icc")
    .To<Cmyk>();
var myHunterLab = myCmyk
    .WithProfile("~/JapanWebCoated.icc")
    .To<HunterLab>();
```

Online example at http://colormine.org/color-converter


## Delta-E

Delta-E calculations take and compare colors in any of the supported formats.

### [CIE76](http://colormine.org/delta-e-calculator/)
```c#
double deltaE = myRgb.Compare(myCmy,new Cie1976Comparison());
```

### [CMC l:C](http://colormine.org/delta-e-calculator/cmc)
```c#
double deltaE = myXyz.Compare(myLab,new CmcComparison(lightness: 2, chroma: 1));
```

### [CIE94](http://colormine.org/delta-e-calculator/cie94)
```c#
double deltaE = myYxy.Compare(myHsl,new Cie94(Cie94Comparison.Application.GraphicArts));
```

### [CIE2000](http://colormine.org/delta-e-calculator/cie2000)
```c#
double deltaE = myHunterLab.Compare(myLuv, new CieDe2000());
```

*Huge thanks to Jonathan Hofinger for correct implementation of CieDe2000 and to Gaurav Sharma for test data.*

Note: Delta-e calculations are [quasimetric](http://en.wikipedia.org/wiki/Quasimetric#Quasimetrics), the result of comparing color a to b isn't always equal to comparing color b to a...but it will probably be pretty close!

***

## Currently Supported Color Spaces
* CMY
* CMYK
* HSL
* HSB
* HSV
* CIE L*AB
* Hunter LAB
* LCH
* LUV
* RGB
* XYZ
* YXY

## Currently Supported Comparisons
* CIE76
* CMC l:c
* CIE94
* CIE2000
