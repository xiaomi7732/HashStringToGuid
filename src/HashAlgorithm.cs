using System.Security.Cryptography;
using System.Text;

namespace HashStringToGuid;

public static class HashAlgorithm
{
    private static byte[] GetStringBytes(string input) => Encoding.UTF8.GetBytes(input);

    public static Func<string, byte[]> SHA256Hash { get; } = (buffer) =>
    {
        using SHA256 mySHA256 = SHA256.Create();
        byte[] hashed = mySHA256.ComputeHash(GetStringBytes(buffer));
        return hashed;
    };

    public static Func<string, byte[]> XxHash128 { get; } = (buffer) =>
    {
        return System.IO.Hashing.XxHash128.Hash(GetStringBytes(buffer));
    };
}