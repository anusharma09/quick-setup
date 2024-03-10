using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;


namespace JCCBusinessLayer
{
   public  class Encryption
    {


        public static string Encrypt(string plainText)
        {

            string passPhrase = "anything";
            string saltValue = "anything";
            string hashAlgorithm = "SHA1";
            int passwordIterations = 1;
            string initVector = "@1B2c3D4e5F6g7H8";
            int keySize = 256;
            byte[] initVectorBytes;
            byte[] saltValueBytes;
            byte[] plainTextBytes;
            byte[] keyBytes;

            initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            PasswordDeriveBytes password = new PasswordDeriveBytes(
                                           passPhrase,
                                           saltValueBytes,
                                           hashAlgorithm,
                                           passwordIterations);




            keyBytes = password.GetBytes(keySize / 8);

            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;

            ICryptoTransform encryptor;
            encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

            MemoryStream memoryStream = new MemoryStream();

            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                         encryptor,
                                         CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

            cryptoStream.FlushFinalBlock();

            byte[] cipherTextBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();

            return Convert.ToBase64String(cipherTextBytes);


        }



        public static string Decrypt(string cipherText)
        {

            string passPhrase = "anything";
            string saltValue = "anything";
            string hashAlgorithm = "SHA1";
            int passwordIterations = 1;
            string initVector = "@1B2c3D4e5F6g7H8";
            int keySize = 256;
            byte[] initVectorBytes;
            byte[] saltValueBytes;
            byte[] cipherTextBytes;
            byte[] keyBytes;




            initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            cipherTextBytes = Convert.FromBase64String(cipherText);

            PasswordDeriveBytes password = new PasswordDeriveBytes(
                                           passPhrase,
                                           saltValueBytes,
                                           hashAlgorithm,
                                           passwordIterations);

            keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;

            ICryptoTransform decryptor;
            decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                         decryptor,
                                         CryptoStreamMode.Read);




            byte[] plainTextBytes = new byte[cipherTextBytes.Length];



            int decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                               0,
                                               plainTextBytes.Length);

            memoryStream.Close();
            cryptoStream.Close();

            return Encoding.UTF8.GetString(plainTextBytes,
                                             0,
                                             decryptedByteCount);





        }
    }

}

