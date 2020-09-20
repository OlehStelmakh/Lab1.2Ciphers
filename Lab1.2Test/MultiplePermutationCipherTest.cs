using System;
using System.Collections.Generic;
using Lab1._2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab1._2Test
{
    [TestClass]
    public class MultiplePermutationCipherTest
    {
        [TestMethod]
        public void MultiplePermutationCipherShouldWorkCorrectlyForSmallPhrases()
        {
            string text = "Рядки тастовбці";
            var multiplePermutationCipher = new MultiplePermutationCipher();
            int amountOfColumns = 4;
            Table table = new Table(text, amountOfColumns);
            var key = new Tuple<List<int>, List<int>>(new List<int>() { 3, 0, 1, 2 }, new List<int>() { 2, 0, 3, 1 });
            var encryptedText = multiplePermutationCipher.Encrypt(table, key);
            table = new Table(encryptedText, amountOfColumns);
            var decryptedText = multiplePermutationCipher.Decrypt(table, key);

            Assert.AreEqual(encryptedText, " аиттвсоц біякРд");
            Assert.AreEqual(decryptedText.Substring(0, text.Length), text);
        }

        [TestMethod]
        public void MultiplePermutationCipherShouldWorkCorrectlyForHugePhrases()
        {
            //first
            string text = "SP.NET Core определяется кроссплатформенностью, то есть он" +
                " работает на Mac OS X, так же как на Linux и Windows. ";
            var multiplePermutationCipher = new MultiplePermutationCipher();
            int amountOfColumns = 8;
            Table table = new Table(text, amountOfColumns);
            var key = multiplePermutationCipher.CreatePermutationNumbers(table);
            var encryptedText = multiplePermutationCipher.Encrypt(table, key);
            table = new Table(encryptedText, amountOfColumns);
            var decryptedText = multiplePermutationCipher.Decrypt(table, key);

            Assert.AreEqual(decryptedText.Substring(0, text.Length), text);

            //second 
            text = "Это позволит вам запускать команды, включая dotnet restore и любые " +
                "другие команды, определенные в project.json, а также пользовательские " +
                "задачи из .vscode/tasks.json, напрямую из Visual Studio Code.";
            amountOfColumns = 12;
            table = new Table(text, amountOfColumns);
            key = multiplePermutationCipher.CreatePermutationNumbers(table);
            encryptedText = multiplePermutationCipher.Encrypt(table, key);
            table = new Table(encryptedText, amountOfColumns);
            decryptedText = multiplePermutationCipher.Decrypt(table, key);

            Assert.AreEqual(decryptedText.Substring(0, text.Length), text);

            //third 
            text = "В терминале/командной строке запустите dotnet restore, чтобы " +
                "восстановить зависимости проекта. Как вариант, вы можете нажать " +
                "command shift p в Visual Studio Code, а затем набрать dot";
            amountOfColumns = 15;
            table = new Table(text, amountOfColumns);
            key = multiplePermutationCipher.CreatePermutationNumbers(table);
            encryptedText = multiplePermutationCipher.Encrypt(table, key);
            table = new Table(encryptedText, amountOfColumns);
            decryptedText = multiplePermutationCipher.Decrypt(table, key);

            Assert.AreEqual(decryptedText.Substring(0, text.Length), text);
        }

        [TestMethod]
        public void PermutationTableShouldWorkCorrectly()
        {
            string text = "Рядки тастовбці";
            int amountOfColumns = 4;
            Table table = new Table(text, amountOfColumns);

            char[,] expectedTable = new char[,]
            {
                {'Р', 'я', 'д', 'к' },
                {'и', ' ', 'т', 'а' },
                {'с', 'т', 'о', 'в' },
                {'б', 'ц', 'і', ' ' }
            };

            for (int i = 0; i< table.AmountOfRows; i++)
            {
                for (int j = 0; j< table.AmountOfColumns; j++)
                {
                    Assert.AreEqual(expectedTable[i, j], table.CreatedTable[i, j]);
                }
            }
        }
    }
}
