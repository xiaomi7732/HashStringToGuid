using System.Security.Cryptography;
using System.Text;

namespace HashStringToGuid;

/// <summary>
/// Hashes a string, and return the result of a guid.
/// </summary>
public sealed class StringToGuid
{
    private StringToGuid()
    {
    }
    public static StringToGuid Instance{get;} = new StringToGuid();

    public async Task<Guid> GetGuidAsync(string value, CancellationToken cancellationToken)
    {
        await Task.Yield();
        
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException($"'{nameof(value)}' cannot be null or empty.", nameof(value));
        }


        using Stream input = new MemoryStream(Encoding.UTF8.GetBytes(value));
        using SHA256 mySHA256 = SHA256.Create();

    #if NET6_0_OR_GREATER
        byte[] hashed = await mySHA256.ComputeHashAsync(input, cancellationToken).ConfigureAwait(false);
    #else
        byte[] hashed = mySHA256.ComputeHash(input);
    #endif

        // Truncate 32 bits to 16 bits.
        byte[] hashed16 = hashed.Take(16).ToArray();
        return new Guid(hashed16);
    }
}