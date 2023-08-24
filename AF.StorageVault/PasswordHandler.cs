using AF.StorageVault.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AF.StorageVault
{
    public class PasswordHandler
    {
        private RsaContainer rsaContainer;
        private AppSettings appSettings;

        /// <summary>
        /// RSA encrypted AES key
        /// To decrypt Use: rsa.Decrypt(Key, RSAEncryptionPadding.Pkcs1)
        /// </summary>
        public byte[]? Key { get; private set; }

        /// <summary>
        /// RSA encrypted AES IV
        /// To decrypt Use: rsa.Decrypt(IV, RSAEncryptionPadding.Pkcs1)
        /// </summary>
        public byte[]? IV { get; private set; }

        public PasswordHandler(RsaContainer rsaContainer, AppSettings appSettings)
        {
            this.rsaContainer = rsaContainer;
            this.appSettings = appSettings;
        }

        public void Encrypt(string password)
        {
            try
            {
                using (RSA rsa = RSA.Create())
                using (FileStream fileStream = new FileStream(appSettings.PasswordFilePath, FileMode.OpenOrCreate))
                using (Aes aes = Aes.Create())
                using (CryptoStream cryptoStream = new CryptoStream(
                    fileStream,
                    aes.CreateEncryptor(),
                    CryptoStreamMode.Write))
                using (StreamWriter encryptWriter = new StreamWriter(cryptoStream, Encoding.UTF8))
                {
                    rsaContainer.Save(appSettings.RsaContainerName, rsa.ToXmlString(true));

                    Key = aes.Key;
                    IV = aes.IV;
                    byte[] key = rsa.Encrypt(aes.Key, RSAEncryptionPadding.Pkcs1);
                    byte[] iv = rsa.Encrypt(aes.IV, RSAEncryptionPadding.Pkcs1);

                    var keyLength = BitConverter.GetBytes(key.Length);
                    fileStream.Write(keyLength, 0, keyLength.Length);
                    fileStream.Write(key, 0, key.Length);

                    var ivLength = BitConverter.GetBytes(iv.Length);
                    fileStream.Write(ivLength, 0, ivLength.Length);
                    fileStream.Write(iv, 0, iv.Length);

                    encryptWriter.Write(SecurePasswordHasher.Hash(password));
                }
            }
            catch (Exception) { }
        }

        public string Decrypt()
        {
            try
            {
                using (RSA rsa = RSA.Create())
                using (FileStream fileStream = new FileStream(appSettings.PasswordFilePath, FileMode.Open))
                using (Aes aes = Aes.Create())
                {
                    rsa.FromXmlString(rsaContainer.GetPrivateKey(appSettings.RsaContainerName));

                    byte[] buffer = new byte[2048];
                    int numBytesRead = 0;

                    fileStream.Read(buffer, numBytesRead, 4);
                    int keyLength = BitConverter.ToInt32(buffer, 0);
                    byte[] key = new byte[keyLength];
                    fileStream.Read(key, numBytesRead, keyLength);
                    aes.Key = rsa.Decrypt(key, RSAEncryptionPadding.Pkcs1);

                    fileStream.Read(buffer, numBytesRead, 4);
                    int ivLength = BitConverter.ToInt32(buffer, 0);
                    byte[] iv = new byte[ivLength];
                    fileStream.Read(iv, numBytesRead, ivLength);
                    aes.IV = rsa.Decrypt(iv, RSAEncryptionPadding.Pkcs1);

                    Key = aes.Key;
                    IV = aes.IV;

                    using (CryptoStream cryptoStream = new CryptoStream(
                        fileStream,
                        aes.CreateDecryptor(),
                        CryptoStreamMode.Read))
                    using (StreamReader decryptReader = new StreamReader(cryptoStream, Encoding.UTF8))
                    {
                        return decryptReader.ReadToEnd();
                    }
                }
            }
            catch (Exception) { }

            throw new Exception();
        }

        public void EncryptStorage(IEnumerable<StorageItem> storageItems)
        {
            try
            {
                using (FileStream fileStream = new FileStream(appSettings.StorageFilePath, FileMode.Create))
                using (Aes aes = Aes.Create())
                {
                    aes.Key = this.Key ?? new byte[0];
                    aes.IV = this.IV ?? new byte[0];

                    using (CryptoStream cryptoStream = new CryptoStream(
                        fileStream,
                        aes.CreateEncryptor(),
                        CryptoStreamMode.Write))
                    using (StreamWriter encryptWriter = new StreamWriter(cryptoStream, Encoding.UTF8))
                    {
                        var json = DynamicJsonConverter.Serialize(storageItems);
                        encryptWriter.Write(json);
                    }
                }
            }
            catch (Exception) { }
        }

        public IEnumerable<StorageItem> DecryptStorage()
        {
            try
            {
                using (FileStream fileStream = new FileStream(appSettings.StorageFilePath, FileMode.Open))
                using (Aes aes = Aes.Create())
                {
                    aes.Key = this.Key ?? new byte[0];
                    aes.IV = this.IV ?? new byte[0];

                    using (CryptoStream cryptoStream = new CryptoStream(
                        fileStream,
                        aes.CreateDecryptor(),
                        CryptoStreamMode.Read))
                    using (StreamReader decryptReader = new StreamReader(cryptoStream, Encoding.UTF8))
                    {
                        var json = decryptReader.ReadToEnd();
                        return DynamicJsonConverter.DeserializeArray(json);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                return Enumerable.Empty<StorageItem>();
            }
            catch (Exception) { }

            throw new Exception();
        }

        public void Delete()
        {
            rsaContainer.DeleteKey(appSettings.RsaContainerName);
            File.Delete(appSettings.PasswordFilePath);
        }

        public bool FileExists()
            => File.Exists(appSettings.PasswordFilePath);
    }
}
