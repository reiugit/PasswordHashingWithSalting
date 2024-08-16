using System.Security.Cryptography;

namespace PasswordHashingWithSalting;

public class PasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 100000;
    private static readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA512;

    private static byte[] _salt = [];
    private static string _hashedPassword = string.Empty;

    public string Hash(string password)
    {
        _salt = RandomNumberGenerator.GetBytes(SaltSize);
        _hashedPassword = GetHashedPassword(password);
        
        return _hashedPassword;
    }

    public bool Verify(string password)
    {
        return GetHashedPassword(password) == _hashedPassword;
    }

    private static string GetHashedPassword(string password)
    {
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, _salt, Iterations, _hashAlgorithmName, HashSize);

        return Convert.ToHexString(hash);
    }
}
