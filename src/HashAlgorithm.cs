using System.Security.Cryptography;
using System.Text;

namespace HashStringToGuid;

public static class HashAlgorithm
{
    public static Func<string, byte[]> XxHash128 { get; } = (buffer) =>
    {
        return System.IO.Hashing.XxHash128.Hash(GetStringBytes(buffer));
    };

    public static Func<string, byte[]> SHA256Hash { get; } = (buffer) =>
    {
        using SHA256 mySHA256 = SHA256.Create();
        byte[] hashed = mySHA256.ComputeHash(GetStringBytes(buffer));
        return hashed;
    };

    public static Func<string, byte[]> SHA1Hash { get; } = (buffer) =>
    {
        using SHA1 mySha1 = SHA1.Create();
        byte[] hashed = mySha1.ComputeHash(GetStringBytes(buffer));
        return hashed;
    };


    public static Func<string, byte[]> MD5Hash { get; } = (buffer) =>
    {
        using MD5 myMD5 = MD5.Create();
        byte[] hashed = myMD5.ComputeHash(GetStringBytes(buffer));
        return hashed;
    };

    private static byte[] GetStringBytes(string input) => Encoding.UTF8.GetBytes(input);
}