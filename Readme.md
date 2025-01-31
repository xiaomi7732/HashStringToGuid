# Hash a string into a GUID

Converts a string into a GUID.

## Usage

```csharp
Guid guidValue = await StringToGuid.Instance.GetGuid(originalString);
```

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
