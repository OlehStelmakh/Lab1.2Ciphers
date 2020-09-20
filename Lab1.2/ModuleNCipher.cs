using System;
using System.Collections.Generic;

namespace Lab1._2
{
    public class ModuleNCipher : ICryptographicCipher<string, string>
    {
        private readonly List<char> _selectedAlphabet;
        public ModuleNCipher(List<char> alphabet) 
        {
            _selectedAlphabet = alphabet;
        }

        public string Encrypt(string text, string key)
        {
            string result = string.Empty;
            int j = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (_selectedAlphabet.IndexOf(text[i]) != -1)
                {
                    char symbol = key[j % key.Length];
                    if (_selectedAlphabet.IndexOf(symbol) != -1)
                    {
                        int index = _selectedAlphabet.IndexOf(symbol) + _selectedAlphabet.IndexOf(text[i]);
                        int position = index % _selectedAlphabet.Count;
                        result += _selectedAlphabet[position];
                    }
                    else
                    {
                        result += _selectedAlphabet[_selectedAlphabet.IndexOf(text[i])];
                    }
                    j += 1;
                }
            }
            return result;
        }

        public string Decrypt(string encryptedText, string key)
        {
            string result = string.Empty;
            for (int i = 0; i < encryptedText.Length; i++)
            {
                if (_selectedAlphabet.IndexOf(encryptedText[i]) != -1)
                {
                    char c = key[i % key.Length];
                    if (_selectedAlphabet.IndexOf(c) != -1)
                    {
                        int difference = _selectedAlphabet.IndexOf(encryptedText[i]) - _selectedAlphabet.IndexOf(c);
                        if (difference < 0)
                        {
                            int firstIndex = _selectedAlphabet.IndexOf(encryptedText[i]);
                            int secondIndex = _selectedAlphabet.Count - _selectedAlphabet.IndexOf(c);
                            int position = (firstIndex + secondIndex) % _selectedAlphabet.Count;
                            result += _selectedAlphabet[position];
                        }
                        else
                        {
                            result += _selectedAlphabet[difference];
                        }
                    }
                    else
                    {
                        result += _selectedAlphabet[_selectedAlphabet.IndexOf(encryptedText[i])];
                    }
                }
            }
            return result;
        }
    }
}
