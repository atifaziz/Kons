# Kons

[![Build Status][build-badge]][builds]
[![NuGet][nuget-badge]][nuget-pkg]
[![MyGet][myget-badge]][edge-pkgs]

Kons is a .NET Standard Library that provides a simple implementation of a
list of (cons) cells.


## Usage

Assume the following local functions:

```c#
// Helper local functions

string Format<T>(ConsList<T> lst) =>
    "[" + string.Join(", ", lst) + "]";

void Print<T>(ConsList<T> lst) =>
    Console.WriteLine($"List = [{Format(lst)}]");
```

Creation:

```c#
var list = ConsList.Cons(1, 2, 3, 4, 5);
```

Get the element count:

```c#    
Console.WriteLine($"List element count = {list.Count}");
// => List element count = 5
```

Check for emptiness:

```c#    
Console.WriteLine($"Is the list empty? {list.IsEmpty}");
// => Is the list empty? False
```

Prepend an item:

```c#
Print(list.Prepend(0));
// => List = [0, 1, 2, 3, 4, 5]
```

Append or concatenate another list:

```c#
Print(list.Concat(list));
// => List = [1, 2, 3, 4, 5, 1, 2, 3, 4, 5]
```

Use `Car` to get the first element and `Cdr` to get a list of all element
except the first:

```c#
Console.WriteLine($"Head = {list.Car}");
// => Head = 1

Console.WriteLine($"Tail = {Format(list.Cdr)}");
// => Tail = [2, 3, 4, 5]
```

Check for (deep) equality of lists:

```c#
Console.WriteLine($"Equal to self? {list.Equals(list)}");
// => Equal to self? True

Console.WriteLine($"Equal to tail? {list.Equals(list.Cdr)}");
// => Equal to tail? False
```

Standard iteration:

```c#
foreach (var n in list)
    Console.WriteLine(n);
// => 1
// => 2
// => 3
// => 4
// => 5
```

Conversion to array:

```c#
var array = list.ToArray();
Console.WriteLine($"Array = [{string.Join(", ", array)}]");
// => Array = [1, 2, 3, 4, 5]
```

Deconstruction:

```c#
var (head, tail, _) = list;
Console.WriteLine($"Head = {head}; Tail = {Format(tail)}");
// => Head = 1; Tail = [2, 3, 4, 5]

var (fst, snd, rest, _) = list;
Console.WriteLine($"First = {fst}; Second = {fst}; Rest = {Format(rest)}");
// => First = 1; Second = 1; Rest = [3, 4, 5]
```

Note that deconstruction returns `Count` as the last element (discarded
above). When the list contains fewer elements than requested for
deconstruction then the corresponding items of the tuple will be initialized
to their default value. The count can then be helpful for validation as shown
here:

```c#
var (x, y, _, count) = ConsList.Cons(42);
if (count < 2)
    throw new Exception("Not enough elements in list.");
```

Folding:

```c#
Console.WriteLine(list.Cadr((a, b, _) => $"A = {a}; B = {b}; ... = {Format(_)}"));
// => A = 1; B = 2; ... = [3, 4, 5]
```

Folding throws an `InvalidOperationException` if the list has fewer than
requested elements.

Partitioning into two lists (matching and unmatching, respectively) based on
whether elements satisfy a condition or not:

```c#
var (evens, odds) = list.Partition(x => x % 2 == 0);
Console.WriteLine($"Evens = {Format(evens)}; Odds = {Format(odds)}");
// => Evens = [2, 4]; Odds = [1, 3, 5]
```


## Building

To build just the binaries on Windows, run:

    .\build.cmd

On Linux or macOS, run instead:

    ./build.sh

To build the binaries and the NuGet packages on Windows, run:

    .\pack.cmd

On Linux or macOS, run instead:

    ./pack.sh


  [build-badge]: https://img.shields.io/appveyor/ci/raboof/kons.svg
  [myget-badge]: https://img.shields.io/myget/raboof/v/Kons.svg?label=myget
  [edge-pkgs]: https://www.myget.org/feed/raboof/package/nuget/Kons
  [nuget-badge]: https://img.shields.io/nuget/v/Kons.svg
  [nuget-pkg]: https://www.nuget.org/packages/Kons
  [builds]: https://ci.appveyor.com/project/raboof/kons
