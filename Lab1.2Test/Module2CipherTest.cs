using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab1._2;
using System.Collections.Generic;

namespace Lab1._2Test
{
    [TestClass]
    public class Module2CipherTest
    {
        [TestMethod]
        public void Module2CipherShouldWorkCorrectlyForHugePhrases()
        {
            //first
            string text = "United States Declaration of Independence";
            var module2Cipher = new Module2Cipher();
            var key = new List<int>() { 561, 1160, 790, 149, 1205 };
            var encryptedText = module2Cipher.Encrypt(text, key);
            var decryptedText = module2Cipher.Decrypt(encryptedText, key);

            Assert.AreEqual(decryptedText, text);

            //second
            text = "This has been called \"one of the best-known sentences in the English language\"";
            key = new List<int>() { 838, 315, 962, 828, 730, 1205, 330 };
            encryptedText = module2Cipher.Encrypt(text, key);
            decryptedText = module2Cipher.Decrypt(encryptedText, key);

            Assert.AreEqual(decryptedText, text);

            //third
            text = "П'ятдесят шість делегатів зрештою підписали Декларацію";
            key = new List<int>() { 1142, 560, 914, 564, 1163 };
            encryptedText = module2Cipher.Encrypt(text, key);
            decryptedText = module2Cipher.Decrypt(encryptedText, key);

            Assert.AreEqual(decryptedText, text);
        }
    }
}
