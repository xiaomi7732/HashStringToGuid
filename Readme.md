# Hash/Convert any string to a guid

Sometimes, you may encounter a situation where you require a GUID-formatted key but only have a loose string at hand. In such cases, this simple solution can prove to be quite effective.

## Usage

```csharp
Guid guidValue = await StringToGuid.Instance.GetGuidAsync(originalString, cancellationToken: default);
```
