using HashStringToGuid;

string originalString = "Hello";
Console.WriteLine(await StringToGuid.Instance.GetGuidAsync(originalString, cancellationToken: default));