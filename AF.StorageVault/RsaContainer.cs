using System.Security.Cryptography;

namespace AF.StorageVault
{
    public class RsaContainer
    {
        public void Save(string containerName, string xmlString)
        {
            var parameters = new CspParameters
            {
                KeyContainerName = containerName
            };

            using var rsa = new RSACryptoServiceProvider(parameters);
            rsa.FromXmlString(xmlString);
        }

        public string GetPrivateKey(string containerName)
        {
            var parameters = new CspParameters
            {
                KeyContainerName = containerName
            };

            using var rsa = new RSACryptoServiceProvider(parameters);
            return rsa.ToXmlString(true);
        }

        public string GetPublicKey(string containerName)
        {
            var parameters = new CspParameters
            {
                KeyContainerName = containerName
            };

            using var rsa = new RSACryptoServiceProvider(parameters);
            return rsa.ToXmlString(false);
        }

        public void DeleteKey(string containerName)
        {
            var parameters = new CspParameters
            {
                KeyContainerName = containerName
            };

            using var rsa = new RSACryptoServiceProvider(parameters)
            {
                PersistKeyInCsp = false
            };

            rsa.Clear();
        }

    }
}
