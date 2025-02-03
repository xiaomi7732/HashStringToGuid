using BenchmarkDotNet.Attributes;
using HashStringToGuid;

[MemoryDiagnoser(displayGenColumns: false)]
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
    public byte[] GetGuidUsingXxHash128()
    {
        return HashAlgorithm.XxHash128.Invoke(data);
    }

    [Benchmark]
    public byte[] GetGuidUsingSHA1()
    {
        return HashAlgorithm.SHA1Hash.Invoke(data);
    }


    [Benchmark]
    public byte[] GetGuidUsingMD5()
    {
        return HashAlgorithm.MD5Hash.Invoke(data);
    }
}