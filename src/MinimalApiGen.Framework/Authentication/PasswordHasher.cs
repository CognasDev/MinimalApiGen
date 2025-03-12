using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace MinimalApiGen.Framework.Authentication;

/// <summary>
/// 
/// </summary>
public sealed class PasswordHasher : IPasswordHasher
{
    #region Field Declarations

    private const int _saltSize = 16;
    private const int _hashSize = 32;
    private const int _iterations = 100000;
    private static readonly HashAlgorithmName _algorithm = HashAlgorithmName.SHA512;

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    public string Hash(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(_saltSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, _iterations, _algorithm, _hashSize);
        return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="password"></param>
    /// <param name="passwordHash"></param>
    /// <returns></returns>
    public bool Verify(string password, string passwordHash)
    {
        string[] parts = passwordHash.Split('-');
        byte[] hash = Convert.FromHexString(parts[0]);
        byte[] salt = Convert.FromHexString(parts[1]);
        byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, _iterations, _algorithm, _hashSize);
        return CryptographicOperations.FixedTimeEquals(hash, inputHash);
    }

    #endregion
}