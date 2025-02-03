using BenchmarkDotNet.Attributes;
using HashStringToGuid;
public class HashAlgorithms
{
    private string data = null!;

    [GlobalSetup]
    public void Setup()
    {
        data = Path.GetRandomFileName();
    }

    [Benchmark]
    public byte[] GetGuidUsingSHA256()
    {
        return HashAlgorithm.SHA256Hash.Invoke(data);
    }

    [Benchmark]
    public byte[] GetGuidUsingXxHash128(){
        return HashAlgorithm.XxHash128.Invoke(data);
    }
}