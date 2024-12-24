using System.Security.Cryptography;
using System.Text;

namespace Cw17.Models.Security;

public static class SecurityHelper
{
    public static string EncryptString(this string originalText, string key)
    {
        byte[] results;
        var UTF8 = new UTF8Encoding();
        var HashProvider = new MD5CryptoServiceProvider();
        var TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(key));
        var TDESAlgorithm = new TripleDESCryptoServiceProvider();
        TDESAlgorithm.Key = TDESKey;
        TDESAlgorithm.Mode = CipherMode.ECB;
        TDESAlgorithm.Padding = PaddingMode.PKCS7;
        var DataToEncrypt = UTF8.GetBytes(originalText);
        try
        {
            var Encryptor = TDESAlgorithm.CreateEncryptor();
            results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
        }
        finally
        {
            TDESAlgorithm.Clear();
            HashProvider.Clear();
        }

        return Convert.ToBase64String(results);
    }

    public static string DecryptString(this string encryptedText, string key, bool hashedKey = true)
    {
        try
        {
            encryptedText = encryptedText.Replace(' ', '+');

            byte[] results;
            var UTF8 = new UTF8Encoding();
            var HashProvider = new MD5CryptoServiceProvider();
            var TDESKey = hashedKey ? HashProvider.ComputeHash(UTF8.GetBytes(key)) : UTF8.GetBytes(key);
            var TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            var DataToDecrypt = Convert.FromBase64String(encryptedText);
            try
            {
                var Decryptor = TDESAlgorithm.CreateDecryptor();
                results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            return UTF8.GetString(results);
        }
        catch (Exception e)
        {
            return "";
        }
    }
}