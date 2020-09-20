using System;
using System.Collections.Generic;

namespace Lab1._2
{
    public class Module2Cipher : ICryptographicCipher<string, List<int>>
    {

        public string Encrypt(string text, List<int> key)
        {
            return CreateOutputResult(text, key);
        }

        public string Decrypt(string encryptedText, List<int> key)
        {
            return CreateOutputResult(encryptedText, key);
        }

        private string CreateOutputResult(string text, List<int> key)
        {
            string result = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                result += (char)(key[i % key.Count] ^ text[i]);
            }

            return result;
        }

        public List<int> CreateRandomKey(int size)
        {
            Random random = new Random();
            List<int> futureKey = new List<int>(size);
            for (int i = 0; i< size; i++)
            {
                futureKey.Add(random.Next(32, 1251));
            }
            futureKey.Shuffle();
            return futureKey;
        }
    }
}
