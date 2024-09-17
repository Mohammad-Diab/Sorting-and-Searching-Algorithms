# Sorting and Searching Algorithms

A small Windows app that fills an array with random numbers and times the classic sorting and searching algorithms on it. Written in C# with WPF on .NET Framework 4.0, with an Arabic and an English interface.

## Features

- **Generate Random Number** fills the array with the count you type, taken from the number domain set in **Setting** (0 to 1,000,000,000 by default).
- Sorting algorithms: **Selection Sort**, **Bubble Sort**, **Insertion Sort**, **Merge Sort** and **Quick Sort**, plus **Build-in Sort** (.NET `List.Sort`) to compare against. Each one reports how many milliseconds it took.
- Searching algorithms: **Linear Search** and **Binary Search** for the number in the **Look for** box, with the position and the time. Binary search needs the numbers sorted first.
- **View Numbers** shows the array in a list next to the buttons.
- **Setting**: the number domain (From / To), the language (Arabic or English), and an option to save the unsorted and sorted numbers to text files. **Default** restores the original settings.
- **Help** opens `Help.ppsx`, an Arabic slideshow that explains each algorithm with its C++ code and walks through the program.

## Requirements

Windows with .NET Framework 4.0 or later. Windows 8, 10 and 11 already include it. The help slideshow needs PowerPoint or another app that opens `.ppsx` files.

## Usage

Download the latest `Sorting-and-Searching-Algorithms-v<version>.7z` from [Releases](https://github.com/Mohammad-Diab/Sorting-and-Searching-Algorithms/releases), extract it, and run `Sorting & Searching Algorithms.exe`. Keep `Help.ppsx` in the same folder. There is no installer.

The exe is not signed, so Windows SmartScreen may warn the first time you run it: click **More info**, then **Run anyway**.

## Building

```
git clone https://github.com/Mohammad-Diab/Sorting-and-Searching-Algorithms.git
```

Open `Sorting.sln` in Visual Studio and build, or run:

```
MSBuild Sorting.sln /p:Configuration=Release /p:Platform=x86
```

The exe is written to `Sorting\bin\Release`.

The project targets .NET Framework 4.0. Recent Visual Studio versions don't ship its reference assemblies; if the build stops with `MSB3644`, extract the [Microsoft.NETFramework.ReferenceAssemblies.net40](https://www.nuget.org/packages/Microsoft.NETFramework.ReferenceAssemblies.net40) NuGet package and point MSBuild at its `build` folder:

```
MSBuild Sorting.sln /p:Configuration=Release /p:Platform=x86 /p:TargetFrameworkRootPath=<package>\build
```

## Author

Mohammad Diab

## License

[Apache 2.0](LICENSE)
