using System;
using System.Collections.Generic;

namespace Lab1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string text = "The code above uses the much criticised System.Random method to " +
                "select swap candidates. It's fast but not as random as it should be.";
            var singleBlockCipher = new SingleBlockCipher();
            var key = singleBlockCipher.CreateKey(10);
            var encryptedText = singleBlockCipher.Encrypt(text.ToLower(), key);
            var decryptedText = singleBlockCipher.Decrypt(encryptedText, key);
            Console.WriteLine(encryptedText);
            Console.WriteLine(decryptedText);*/

            /*string text = "Виходячи із смертельної небезпеки, яка нависла була над " +
                "Україною в зв'язку з державним переворотом в СРСР 19 серпня 1991 року...";
            string key = "24 серпня 1991 рік";
            var moduleNCipher = new ModuleNCipher(AlphabetManager.FullMixedAlphabetList);
            var encryptedText = moduleNCipher.Encrypt(text, key);
            var decryptedText = moduleNCipher.Decrypt(encryptedText, key);
            Console.WriteLine(encryptedText);
            Console.WriteLine(decryptedText);*/

            /*string text = "United States Declaration of Independence";
            var module2Cipher = new Module2Cipher();
            var key = module2Cipher.CreateRandomKey(5);
            var encryptedText = module2Cipher.Encrypt(text, key);
            var decryptedText = module2Cipher.Decrypt(encryptedText, key);
            Console.WriteLine(encryptedText);
            Console.WriteLine(decryptedText);*/

            string text = "Рядки тастовбці";
            var multiplePermutationCipher = new MultiplePermutationCipher();
            int amountOfColumns = 4;
            Table table = new Table(text, amountOfColumns);
            table.PrintTable();
            var keyNumbers = multiplePermutationCipher.CreatePermutationNumbers(table);
            //var key = new Tuple<List<int>, List<int>>(new List<int>() { 3, 0, 1, 2 }, new List<int>() { 2, 0, 3, 1 });
            var encryptedText = multiplePermutationCipher.Encrypt(table, keyNumbers);
            table = new Table(encryptedText, amountOfColumns);
            var decryptedText = multiplePermutationCipher.Decrypt(table, keyNumbers);
            Console.WriteLine(encryptedText);
            Console.WriteLine(decryptedText);
        }
    }

    public class AlphabetManager
    {

        public static HashSet<char> FullMixedAlphabet = new HashSet<char>()
        {
            'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E', 'e', 'F', 'f', 'G', 'g', 'H', 'h', 'I', 'i', 'J', 'j',
            'K', 'k', 'L', 'l', 'M', 'm', 'N', 'n', 'O', 'o', 'P', 'p', 'Q', 'q', 'R', 'r', 'S', 's', 'T', 't',
            'U', 'u', 'V', 'v', 'W', 'w', 'X', 'x', 'Y', 'y', 'Z', 'z',
            'А', 'а', 'Б', 'б', 'В', 'в', 'Г', 'г', 'Д', 'д', 'Е', 'е', 'Є', 'є', 'Ж', 'ж', 'З', 'з', 'И', 'и',
            'І', 'і', 'Ї', 'ї', 'Й', 'й', 'К', 'к', 'Л', 'л', 'М', 'м', 'Н', 'н', 'О', 'о', 'П', 'п', 'Р', 'р',
            'С', 'с', 'Т', 'т', 'У', 'у', 'Ф', 'ф', 'Х', 'х', 'Ц', 'ц', 'Ч', 'ч', 'Ш', 'ш', 'Щ', 'щ', 'Ь', 'ь',
            'Ю', 'ю', 'Я', 'я',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', '.', '?', '!', ':', ';', '\'', '"', '-', '/',
            '\\', '*', '=', '(', ')', '[', ']', ' ',
        };

        public static List<char> FullMixedAlphabetList = new List<char>()
        {
            'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E', 'e', 'F', 'f', 'G', 'g', 'H', 'h', 'I', 'i', 'J', 'j',
            'K', 'k', 'L', 'l', 'M', 'm', 'N', 'n', 'O', 'o', 'P', 'p', 'Q', 'q', 'R', 'r', 'S', 's', 'T', 't',
            'U', 'u', 'V', 'v', 'W', 'w', 'X', 'x', 'Y', 'y', 'Z', 'z',
            'А', 'а', 'Б', 'б', 'В', 'в', 'Г', 'г', 'Д', 'д', 'Е', 'е', 'Є', 'є', 'Ж', 'ж', 'З', 'з', 'И', 'и',
            'І', 'і', 'Ї', 'ї', 'Й', 'й', 'К', 'к', 'Л', 'л', 'М', 'м', 'Н', 'н', 'О', 'о', 'П', 'п', 'Р', 'р',
            'С', 'с', 'Т', 'т', 'У', 'у', 'Ф', 'ф', 'Х', 'х', 'Ц', 'ц', 'Ч', 'ч', 'Ш', 'ш', 'Щ', 'щ', 'Ь', 'ь',
            'Ю', 'ю', 'Я', 'я',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', '.', '?', '!', ':', ';', '\'', '"', '-', '/',
            '\\', '*', '=', '(', ')', '[', ']', ' ',
        };

        public static HashSet<char> UkrainianAlphabet = new HashSet<char>()
        {
            ' ', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Є', 'Ж', 'З', 'И', 'І', 'Ї', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р',
            'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ю', 'Я'
        };

        public static HashSet<char> EnglishAphabet = new HashSet<char>()
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O',
            'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        public static HashSet<char> MixedAlphabet = new HashSet<char>()
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O',
            'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Є', 'Ж', 'З', 'И', 'І', 'Ї', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р',
            'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ю', 'Я'
        };
    }
}
