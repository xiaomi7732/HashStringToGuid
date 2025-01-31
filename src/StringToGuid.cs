using System.Security.Cryptography;
using System.Text;

namespace HashStringToGuid;

/// <summary>
/// Hashes a string, and return the result of a guid.
/// </summary>
public sealed class StringToGuid
{
    private Func<byte[], byte[]>? _customHash;
    private StringToGuid()
    {
    }
    public static StringToGuid Instance { get; } = new StringToGuid();

    public StringToGuid WithCustomHash(Func<byte[], byte[]> hashAlgorithm)
    {
        _customHash = hashAlgorithm;
        return this;
    }

    public Guid GetGuid(string value)
    {
        _customHash ??= (buffer =>
        {
            using SHA256 mySHA256 = SHA256.Create();
            byte[] hashed = mySHA256.ComputeHash(buffer);
            return hashed;
        });
        
        
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException($"'{nameof(value)}' cannot be null or empty.", nameof(value));
        }


        byte[] stringBytes = Encoding.UTF8.GetBytes(value);
        byte[] hashed = _customHash(stringBytes);
        
        // Truncate 32 bits to 16 bits.
        byte[] hashed16 = hashed.Take(16).ToArray();
        return new Guid(hashed16);
    }
}