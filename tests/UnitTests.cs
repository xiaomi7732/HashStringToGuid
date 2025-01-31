namespace HashStringToGuid.Tests;

public class ConflictTest
{
    [Theory()]
    [InlineData(2000000)]
    public void NoConflicts(int iterations)
    {
        Dictionary<string, Guid> results = new Dictionary<string, Guid>();

        for (int i = 0; i < iterations; i++)
        {
            string randomString = Path.GetRandomFileName();
            results.TryAdd(randomString, StringToGuid.Instance.GetGuid(randomString));
        }

        int itemCount = results.Count;
        int deDupeCount = results.Values.Distinct().Count();

        // All items are unique
        Assert.Equal(itemCount, deDupeCount);
    }
}