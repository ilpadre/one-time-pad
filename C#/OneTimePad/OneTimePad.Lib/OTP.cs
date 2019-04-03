using System;
using System.Linq;
using System.Text;

namespace OneTimePad.Lib
{
    public class OTP
    {
        private static Random random = new Random();
        public string Generate(int keyLengthInBytes)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, keyLengthInBytes)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string Encrypt(string key, string message)
        {
            char[] cipherText = new Char[key.Length];

            for (int i = 0; i < key.Length; i++)
            {
                cipherText[i] = (char)(key[i] ^ message[i]);
            }
            return new string(cipherText);
        }

        public string Decrypt(string key, string cipherText)
        {
            char[] message = new Char[key.Length];

            for (int i = 0; i < key.Length; i++)
            {
                message[i] = (char)(key[i] ^ cipherText[i]);
            }
            return new string(message);
        }
    }
}




