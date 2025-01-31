using System.Security.Cryptography;
using System.Text;

namespace HashStringToGuid;

/// <summary>
/// Hashes a string, and return the result of a guid.
/// </summary>
public sealed class StringToGuid
{
    private Func<string, byte[]>? _hash;
    private StringToGuid()
    {
    }
    public static StringToGuid Instance { get; } = new StringToGuid();

    public StringToGuid WithCustomHash(Func<string, byte[]> hashAlgorithm)
    {
        _hash = hashAlgorithm;
        return this;
    }

    public Guid GetGuid(string value)
    {
        byte[] hashed = GetHash(value);
        // Truncate 32 bits to 16 bits.
        byte[] hashed16 = hashed.Take(16).ToArray();
        return new Guid(hashed16);
    }

    public byte[] GetHash(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException($"'{nameof(value)}' cannot be null or empty.", nameof(value));
        }

        _hash ??= HashAlgorithm.XxHash128;
        return _hash(value);
    }
}