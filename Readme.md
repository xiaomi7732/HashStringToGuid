# Hash a string into a GUID

Converts a string into a GUID.

## Usage

```csharp
Guid guidValue = await StringToGuid.Instance.GetGuid(originalString);
```

## Benchmark

Running on a ThinkPad P50s, 3 times just make a point that the default **XxHash128** is pretty effective:

Round #1

| Method                | Mean        | Error     | StdDev    |
|---------------------- |------------:|----------:|----------:|
| GetGuidUsingSHA256    | 2,270.69 ns | 24.586 ns | 21.795 ns |
| GetGuidUsingXxHash128 |    43.20 ns |  0.734 ns |  0.651 ns |

Round #2

| Method                | Mean        | Error     | StdDev    |
|---------------------- |------------:|----------:|----------:|
| GetGuidUsingSHA256    | 2,067.21 ns | 16.525 ns | 13.799 ns |
| GetGuidUsingXxHash128 |    40.32 ns |  0.518 ns |  0.433 ns |

Round #3

| Method                | Mean        | Error     | StdDev    |
|---------------------- |------------:|----------:|----------:|
| GetGuidUsingSHA256    | 2,168.84 ns | 37.780 ns | 33.491 ns |
| GetGuidUsingXxHash128 |    44.30 ns |  0.448 ns |  0.349 ns |

## Customization if you really need it

It uses XxHash128 by default. Switch the algorithm:

```csharp
StringToGuid.Instance.WithCustomHash(HashAlgorithm.SHA256);
```

Or supply your own hash method:

```csharp
StringToGuid.Instance.WithCustomHash((string) => {
    ... // Your algorithm here to return a hash    
});
```
