namespace HashStringToGuid.Tests;

public class ConflictTest
{
    [Theory()]
    [InlineData(2000000)]
    public async Task NoConflicts(int iterations)
    {
        Dictionary<string, Guid> results = new Dictionary<string, Guid>();

        for (int i = 0; i < iterations; i++)
        {
            string randomString = Path.GetRandomFileName();
            results.TryAdd(randomString, await StringToGuid.Instance.GetGuidAsync(randomString, default).ConfigureAwait(false));
        }

        int itemCount = results.Count;
        int deDupeCount = results.Values.Distinct().Count();

        // All items are unique
        Assert.Equal(itemCount, deDupeCount);
    }
}