using System.Security.Cryptography;
using System.Text;

namespace br.com.deveficiente.mercadolivre.Domain.ValueObjects
{
    public class Password
    {
        private readonly byte[] encryptionKey;

        public string EncryptedPassword { get; private set; }

        public Password(string passwordValue, string encryptionKey)
        {
            // Aplica uma função de hash à chave para obter um tamanho compatível
            using (SHA256 sha256 = SHA256.Create())
            {
                this.encryptionKey = sha256.ComputeHash(Encoding.UTF8.GetBytes(encryptionKey));
            }

            EncryptedPassword = Encrypt(passwordValue);
        }

        // Necessário para o EF Core poder instanciar a entidade
        private Password() { }

        // Método para criptografar a senha
        private string Encrypt(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = encryptionKey;
                aesAlg.IV = new byte[16]; // Aqui você pode definir um IV (Initialization Vector) mais seguro

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }
    }
}