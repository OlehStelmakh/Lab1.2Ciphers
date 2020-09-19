using System;
using System.Collections.Generic;

namespace Lab1._2
{
    public class SingleBlockCipher : ICryptographicCipher<string, List<int>>
    {
        public string Encrypt(string text, List<int> key)
        {
            int lengthOfBlock = key.Count;
            int remainder = 0;
            if (text.Length % lengthOfBlock != 0)
            {
                remainder = lengthOfBlock - (text.Length % lengthOfBlock);
            }
            string localText = text + new string(' ', remainder);

            string decryptedText = string.Empty;
            for (int i = 0; i < localText.Length / lengthOfBlock; i++)
            {
                for (int j = 0; j < lengthOfBlock; j++)
                {
                    int position = key[j];
                    decryptedText += localText[i * lengthOfBlock + position];
                }
            }

            return decryptedText;
        }

        public string Decrypt(string encryptedText, List<int> key)
        {
            int lengthOfBlock = key.Count;
            string decryptedText = string.Empty;
            for (int i = 0; i < encryptedText.Length / lengthOfBlock; i++)
            {
                for (int j = 0; j < lengthOfBlock; j++)
                {
                    int position = key.IndexOf(j);
                    decryptedText += encryptedText[i * lengthOfBlock + position];
                }
            }

            return decryptedText;
        }

        public List<int> CreateKey(int lengthOfBlock)
        {
            List<int> key = new List<int>(lengthOfBlock);
            for (int i = 0; i < lengthOfBlock; i++)
            {
                key.Add(i);
            }
            key.Shuffle();
            return key;
        }
    }
}
