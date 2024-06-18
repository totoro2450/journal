using System.Text;
using System.Security.Cryptography;

namespace Journal.Shared.Helpers
{
    public static class EncryptionHelper
    {
        private const int KeySize = 256;

        private const int DerivationIterations = 100;

        public static string Encrypt(string? text, string key)
        {
            if (string.IsNullOrEmpty(key)) return "";
            if (string.IsNullOrEmpty(text)) return "";

            var saltStringBytes = Generate128BitsOfRandomEntropy();
            var ivStringBytes = Generate128BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(text);

            using var password = new Rfc2898DeriveBytes(key, saltStringBytes, DerivationIterations, HashAlgorithmName.SHA256);
            var keyBytes = password.GetBytes(KeySize / 8);

            using var symmetricKey = Aes.Create();
            symmetricKey.BlockSize = 128;
            symmetricKey.Mode = CipherMode.CBC;
            symmetricKey.Padding = PaddingMode.PKCS7;

            using var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes);
            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            var cipherTextBytes = saltStringBytes;
            cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
            cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string Decrypt(string? text, string key)
        {
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(text!);
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(KeySize / 16).ToArray();
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(KeySize / 16).Take(KeySize / 16).ToArray();
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((KeySize / 16) * 2)
                .Take(cipherTextBytesWithSaltAndIv.Length - ((KeySize / 16) * 2)).ToArray();

            using var password = new Rfc2898DeriveBytes(key, saltStringBytes, DerivationIterations, HashAlgorithmName.SHA256);
            var keyBytes = password.GetBytes(KeySize / 8);
            using var symmetricKey = Aes.Create();
            symmetricKey.BlockSize = 128;
            symmetricKey.Mode = CipherMode.CBC;
            symmetricKey.Padding = PaddingMode.PKCS7;
            using var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes);
            using var memoryStream = new MemoryStream(cipherTextBytes);
            using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            using var streamReader = new StreamReader(cryptoStream, Encoding.UTF8);
            return streamReader.ReadToEnd();
        }

        private static byte[] Generate128BitsOfRandomEntropy()
        {
            var randomBytes = new byte[16];
            using var rngCsp = RandomNumberGenerator.Create();
            rngCsp.GetBytes(randomBytes);
            return randomBytes;
        }
    }
}
