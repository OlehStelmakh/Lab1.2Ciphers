namespace Lab1._2
{
    public interface ICryptographicCipher<T, K>
    {
        T Encrypt(T text, K key);
        T Decrypt(T encryptedText, K key);
    }
}
