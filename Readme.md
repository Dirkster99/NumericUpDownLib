[![Build status](https://img.shields.io/appveyor/ci/Dirkster99/NumericUpDownLib.svg)](https://ci.appveyor.com/project/Dirkster99/NumericUpDownLib)
[![Release](https://img.shields.io/github/release/Dirkster99/NumericUpDownLib.svg)](https://github.com/Dirkster99/NumericUpDownLib/releases/latest)
[![NuGet](https://img.shields.io/nuget/dt/Dirkster.NumericUpDownLib.svg)](http://nuget.org/packages/Dirkster.NumericUpDownLib)

![Net4](https://badgen.net/badge/Framework/.Net&nbsp;4/blue) ![NetCore3](https://badgen.net/badge/Framework/NetCore&nbsp;3/blue)

# Overview

This library implements numeric up down WPF controls to edit a value:
- by dragging the mouse vertically/horizontally (see recording below) or
- by clicking up/down arrow (repeat) buttons or
- up/down or left right cursor keys or
- spinning mousewheel up down on mouseover or
- editing a textbox

Each control implementation is specific for a certain .Net data type:

| Data Type | Control              |
| :---      | :---                 |
| byte      | ByteUpDown    control|
| decimal   | DecimalUpDown control|
| double    | DoubleUpDown  control|
| float     | FloatUpDown   control|
| integer   | IntegerUpDown control|
| long      | LongUpDown    control|
| sbyte     | SbyteUpDown   control|
| short     | ShortUpDown   control|
| ushort    | UshortUpDown  control|
| uint      | UintUpDown    control|
| ulong     | UlongUpDown   control|

Percentages can be edit at [0-100] while backend viewmodels handles [0-1] values,
see FactorToDoubleConverter and PercentageUpDownDemo in demo clients at project site.

Controls are fully themeable. Project site contains demos for:
- Dark/Light theme and
- Generics theme
test clients.

More Features:
- Small Increments and Decrements can be configured to be 1 or any greater value than 1.
- Large Small Increments and Decrements can be configured to be 10 or any other value greater 1.
- The width of the control can be configured to be fixed (textbox will scroll inside when text is too large)
- Up/Down button is disabled when min or max limit is already reached
- Up/Down button can be configured to be invisible
- Mouse drag mode for editing value can be enabled/disabled
- SelectAll on GotFocus of TextBox
- IsReadOnly property disables the textbox portion but leaves all other funtions for Increment/Decrement available

# LargeStepSize and StepSize
There are mouse and keyboard input methods that support 2 different configurable increment/decrement values.

## Mouse Drag Mode

The user can hover the mouse over the textbox portion of the control and:
- left click/drag vertically or
- left click/drag horizontally

to change the current value with the size configured in *StepSize* or *LargeStepSize* dependency property.

## Mouse Wheel

The user can hover the mouse over the textbox portion and spin the mouse wheel with:
- no modifier key pressed or
- a modifier key pressed

to change the current value with the size configured in *StepSize* or *LargeStepSize* dependency property.

The modifier key for changing the value with *LargeStepSize* can be configured in the
*MouseWheelAccelaratorKey* dependency property.

## Cursor Keys

The user can click into the textbox portion of the control and:
- press cursor left or right or
- press cursor up and down

to change the current value with the size configured in *StepSize* or *LargeStepSize* dependency property.

# Demo Applications

There is a demo application that shows the usage of the control (Light/Black themes enabled) and documents the features,
such as, the ability to configure a minimum and maximum value that can be used to keep the resulting
value within a given bound.

![screenshot](https://raw.githubusercontent.com/Dirkster99/Docu/master/numericupdown/V2_2/MouseDrag.gif)
![screenshot](https://raw.githubusercontent.com/Dirkster99/Docu/master/numericupdown/02_00/DarkByteDemo.png)
![screenshot](https://raw.githubusercontent.com/Dirkster99/Docu/master/numericupdown/02_00/LightIntegerDemo.png)
![screenshot](https://raw.githubusercontent.com/Dirkster99/Docu/master/numericupdown/02_00/PercentageDemo.png)

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

Visit the project's [Wiki](https://github.com/Dirkster99/NumericUpDownLib/wiki) for mode details.
