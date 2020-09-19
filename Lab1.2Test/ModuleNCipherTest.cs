using Lab1._2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab1._2Test
{
    [TestClass]
    public class ModuleNCipherTest
    {
        [TestMethod]
        public void ModuleNCipherShouldWorkCorrectlyForHugePhrases()
        {
            //first
            string text = "The code above uses the much criticised System.Random method to " +
                "select swap candidates. It's fast but not as random as it should be.";
            string key = "password";
            var moduleNCipher = new ModuleNCipher(AlphabetManager.FullMixedAlphabetList);
            var encryptedText = moduleNCipher.Encrypt(text, key);
            var decryptedText = moduleNCipher.Decrypt(encryptedText, key);

            Assert.AreEqual(encryptedText, "зIXSZГVIPBUЖПTRYЗFЇSНWWDВVVАWRИMИJVБМTVDжZЇЙББJuQOW" +
                "ЖИOДIИIЖWWЗЄDЗFДXZЗRWЙBЗSZPЕHYETЙБЖJDxUmЇWUSWИAUКНOЕSИATЇWЄSRTPЕSXЖRMИAЇАЇИГHPCXK");
            Assert.AreEqual(decryptedText, text);

            //second
            text = "Donald John Trump (born June 14, 1946) is the 45th and current president " +
                "of the United States. Before entering politics, he was a businessman and television personality.";
            key = "Hillary Diane Rodham Clinton";

            encryptedText = moduleNCipher.Encrypt(text, key);
            decryptedText = moduleNCipher.Decrypt(encryptedText, key);

            Assert.AreEqual(encryptedText, "KXZMMVYirQONxRїБTH)OOtZIwЛВSg- cAEP3?gAWX]іWIH5BTjLJБXOQ" +
                "бАГQOЇYPuNTWIEдЗDWGMTjQIжЖXЖlMLгUSПEvAAoJFеЄIHFАTgГRБАOГvUUЕJUО9cQFNБAиOEHCЖSkZNЄЙБOuIMZERПEoNWWXIеВDXFДSqZJZВЗЙ[");
            Assert.AreEqual(decryptedText, text);

            //third
            text = "Виходячи із смертельної небезпеки, яка нависла була над " +
                "Україною в зв'язку з державним переворотом в СРСР 19 серпня 1991 року...";
            key = "24 серпня 1991 рік";

            encryptedText = moduleNCipher.Encrypt(text, key);
            decryptedText = moduleNCipher.Decrypt(encryptedText, key);

            Assert.AreEqual(encryptedText, "PxХS8ЕZGЯІV8ЇВЕTM]боНS=РPCNЕVИWАИіІZаo]R0CIRАА0SКБАРH'r3тO" +
                "FAKNГЮ0T8VВкWCаі]JЕEEQTАPЖАВ]S\\NsqОUDVQMЯВ0іиєпРXД1зЕUEQДНП8ФФ8ЄОNNЕхц");
            Assert.AreEqual(decryptedText, text);
        }
    }
}
