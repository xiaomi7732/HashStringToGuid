# Hash a string into a GUID

Converts a string into a GUID.

## Usage

```csharp
Guid guidValue = await StringToGuid.Instance.GetGuid(originalString);
```

## Benchmark

Running on a ThinkPad P50s, 3 times just make a point that the default **XxHash128** is pretty effective:

| Method                | Mean        | Error     | StdDev     | Median      | Allocated |
|---------------------- |------------:|----------:|-----------:|------------:|----------:|
| GetGuidUsingXxHash128 |    65.38 ns |  2.250 ns |   6.309 ns |    63.84 ns |      80 B |
| GetGuidUsingSHA256    | 3,104.90 ns | 73.492 ns | 206.081 ns | 3,060.30 ns |     288 B |
| GetGuidUsingSHA1      | 2,979.74 ns | 88.966 ns | 255.259 ns | 2,905.02 ns |     272 B |
| GetGuidUsingMD5       | 1,810.37 ns | 57.097 ns | 163.822 ns | 1,790.75 ns |     256 B |

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
