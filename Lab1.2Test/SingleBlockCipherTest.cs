using System.Collections.Generic;
using Lab1._2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab1._2Test
{
    [TestClass]
    public class SingleBlockCipherTest
    {
        [TestMethod]
        public void SingleBlockCipherShouldWorkCorreclyForHugePhrases()
        {
            string text = "Also feel free to tell me why doing it this way is a horrible idea.";
            var singleBlockCipher = new SingleBlockCipher();
            var key = new List<int>() { 1, 3, 0, 2, 5, 9, 4, 8, 6, 7 };
            var encryptedText = singleBlockCipher.Encrypt(text.ToLower(), key);
            var decryptedText = singleBlockCipher.Decrypt(encryptedText, key);
            Assert.AreEqual(encryptedText, "loasf  leerefete to lml   eywhondi tg iti hsaswiy ah  rlobri deia e . ");
            Assert.AreEqual(decryptedText.Substring(0, text.Length), text.ToLower());

            text = "Инициализирует новый экземпляр класса String значением, " +
                "определенным указателем на массив 8-разрядных целых чисел со знаком.";
            key = new List<int>() { 6, 4, 0, 2, 3, 1, 5 };
            encryptedText = singleBlockCipher.Encrypt(text.ToLower(), key);
            decryptedText = singleBlockCipher.Decrypt(encryptedText, key);
            Assert.AreEqual(encryptedText, "лииицнатуиирзе ы овнйлмэзекпсля краitс sаrчнn зgа меиен," +
                "лдорепеуменын лткзааемае нм 8васис др-азрялцнх ыееиы чхсн лсо з .аомк ");
            Assert.AreEqual(decryptedText.Substring(0, text.Length), text.ToLower());

            text = "The code above uses the much criticised System.Random method to " +
                "select swap candidates. It's fast but not as random as it should be.";
            key = new List<int>() { 7, 10, 2, 3, 5, 8, 0, 1, 9, 4, 6 };
            encryptedText = singleBlockCipher.Encrypt(text.ToLower(), key);
            decryptedText = singleBlockCipher.Decrypt(encryptedText, key);
            Assert.AreEqual(encryptedText, "ebe o thacdshe s ovtuectmuhre ic stisdyicse om.rnmem " +
                "adoeho  etsdtacctsple  we diasan.dtsb'sftit  aar ntsut o stdo  anima .holb seud");
            Assert.AreEqual(decryptedText.Substring(0, text.Length), text.ToLower());
        }

        [TestMethod]
        public void SingleBlockCipherShouldWorkCorreclyForSmallPhrases()
        {
            string text = "Пароль";
            var singleBlockCipher = new SingleBlockCipher();
            var key = new List<int>() { 1, 3, 2, 0};
            var encryptedText = singleBlockCipher.Encrypt(text.ToLower(), key);
            Assert.AreEqual(encryptedText, "аорпь  л");
            var decryptedText = singleBlockCipher.Decrypt(encryptedText, key);
            Assert.AreEqual(decryptedText.Substring(0, text.Length), text.ToLower());
        }
    }
}
