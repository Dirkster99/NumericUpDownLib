[![Build status](https://img.shields.io/appveyor/ci/Dirkster99/NumericUpDownLib.svg)](https://ci.appveyor.com/project/Dirkster99/NumericUpDownLib)
[![Release](https://img.shields.io/github/release/Dirkster99/NumericUpDownLib.svg)](https://github.com/Dirkster99/NumericUpDownLib/releases/latest)
[![NuGet](https://img.shields.io/nuget/dt/Dirkster.NumericUpDownLib.svg)](http://nuget.org/packages/Dirkster.NumericUpDownLib)
# Overview

This library implements a numeric up down WPF control that can be used to edit integer values:
- with a textbox or
- up/down arrow (repeat) buttons

There is a demo application that shows the usage of the control (LIght/Black themes enabled) and documents the features, such as, the ability to configure a minimum and maximum value that can be used to keep the resulting value within a given bound.

## Theming

Load *Light* or *Dark* brush resources in you resource dictionary to take advantage of existing definitions.

```XAML
    <ResourceDictionary.MergedDictionaries>
        <ResourceDictionary Source="/NumericUpDownLib;component/Themes/DarkBrushs.xaml" />
    </ResourceDictionary.MergedDictionaries>
```

```XAML
    <ResourceDictionary.MergedDictionaries>
        <ResourceDictionary Source="/NumericUpDownLib;component/Themes/LightBrushs.xaml" />
    </ResourceDictionary.MergedDictionaries>
```

These definitions do not theme all controls used within this library. You should use a standard theming library, such as:
- [MahApps.Metro](https://github.com/MahApps/MahApps.Metro),
- [MLib](https://github.com/Dirkster99/MLib), or
- [MUI](https://github.com/firstfloorsoftware/mui)

to also theme standard elements, such as, button and textblock etc.
