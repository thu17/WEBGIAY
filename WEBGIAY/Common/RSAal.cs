﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WEBGIAY.Common
{
    public static class RSAal
    {
        private static UnicodeEncoding encoder = new UnicodeEncoding();
        static public byte[] RSAEncryption(byte[] dt, RSAParameters RSAKey, bool DoPadding)
        {
            try
            {
            byte[] eData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
            RSA.ImportParameters(RSAKey); 
                eData = RSA.Encrypt(dt, DoPadding);    
            }   
            return eData;
            }
            catch (CryptographicException ex)
            {
            Console.WriteLine(ex.Message);
            return null;
            }
        }

        static public byte[] RSADecryption(byte[]Data, RSAParameters RSAKey, bool DoPadding)
        {
         try
         {
         byte[] dData;
         using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
             RSA.ImportParameters(RSAKey);
             dData = RSA.Decrypt(Data, DoPadding);
            }
         return dData;
         }
         catch (CryptographicException ex)
         {
         Console.WriteLine(ex.ToString());
         return null;
         }        
        }













        //public static string Decrypt(string data, string privateKey)
        //{
        //    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
           
        //    rsa.FromXmlString(privateKey);
        //    byte[] dataByte = Convert.FromBase64String(data);
        //    //GIẢI MÃ
        //    byte[] decryptedByte = rsa.Decrypt(dataByte, false);
        //    return Encoding.UTF8.GetString(decryptedByte);
        //}
        //public static string Encrypt(string data, string publicKey)
        //{
        //    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        //    rsa.FromXmlString(publicKey);
        //    byte[] dataToEncrypt = Encoding.UTF8.GetBytes(data);
        //    byte[] encryptedByteArray = rsa.Encrypt(dataToEncrypt, false);
            
        //    return Convert.ToBase64String(encryptedByteArray);
        //}

        //private static string Sign(RSACryptoServiceProvider privateKey, string content)
        //{
        //    SHA1Managed sha1 = new SHA1Managed();
        //    UnicodeEncoding encoding = new UnicodeEncoding();
        //    byte[] data = encoding.GetBytes(content);
        //    byte[] hash = sha1.ComputeHash(data);

        //    // Sign the hash
        //    var signature = privateKey.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
        //    return Convert.ToBase64String(signature);
        //}
       
        //public static string Encryption(string strText)
        //{
        //    var publicKey = "<RSAKeyValue><Modulus>21wEnTU+mcD2w0Lfo1Gv4rtcSWsQJQTNa6gio05AOkV/Er9w3Y13Ddo5wGtjJ19402S71HUeN0vbKILLJdRSES5MHSdJPSVrOqdrll/vLXxDxWs/U0UT1c8u6k/Ogx9hTtZxYwoeYqdhDblof3E75d9n2F0Zvf6iTb4cI7j6fMs=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        //    var testData = Encoding.UTF8.GetBytes(strText);

        //    using (var rsa = new RSACryptoServiceProvider(1024))
        //    {
        //        try
        //        {
        //            // client encrypting data with public key issued by server                    
        //            rsa.FromXmlString(publicKey.ToString());

        //            var encryptedData = rsa.Encrypt(testData, true);

        //            var base64Encrypted = Convert.ToBase64String(encryptedData);

        //            return base64Encrypted;
        //        }
        //        finally
        //        {
        //            rsa.PersistKeyInCsp = false;
        //        }
        //    }
        //}

        //public static string Decryption(string strText)
        //{
        //    var privateKey = "<RSAKeyValue><Modulus>21wEnTU+mcD2w0Lfo1Gv4rtcSWsQJQTNa6gio05AOkV/Er9w3Y13Ddo5wGtjJ19402S71HUeN0vbKILLJdRSES5MHSdJPSVrOqdrll/vLXxDxWs/U0UT1c8u6k/Ogx9hTtZxYwoeYqdhDblof3E75d9n2F0Zvf6iTb4cI7j6fMs=</Modulus><Exponent>AQAB</Exponent><P>/aULPE6jd5IkwtWXmReyMUhmI/nfwfkQSyl7tsg2PKdpcxk4mpPZUdEQhHQLvE84w2DhTyYkPHCtq/mMKE3MHw==</P><Q>3WV46X9Arg2l9cxb67KVlNVXyCqc/w+LWt/tbhLJvV2xCF/0rWKPsBJ9MC6cquaqNPxWWEav8RAVbmmGrJt51Q==</Q><DP>8TuZFgBMpBoQcGUoS2goB4st6aVq1FcG0hVgHhUI0GMAfYFNPmbDV3cY2IBt8Oj/uYJYhyhlaj5YTqmGTYbATQ==</DP><DQ>FIoVbZQgrAUYIHWVEYi/187zFd7eMct/Yi7kGBImJStMATrluDAspGkStCWe4zwDDmdam1XzfKnBUzz3AYxrAQ==</DQ><InverseQ>QPU3Tmt8nznSgYZ+5jUo9E0SfjiTu435ihANiHqqjasaUNvOHKumqzuBZ8NRtkUhS6dsOEb8A2ODvy7KswUxyA==</InverseQ><D>cgoRoAUpSVfHMdYXW9nA3dfX75dIamZnwPtFHq80ttagbIe4ToYYCcyUz5NElhiNQSESgS5uCgNWqWXt5PnPu4XmCXx6utco1UVH8HGLahzbAnSy6Cj3iUIQ7Gj+9gQ7PkC434HTtHazmxVgIR5l56ZjoQ8yGNCPZnsdYEmhJWk=</D></RSAKeyValue>";

        //    var testData = Encoding.UTF8.GetBytes(strText);

        //    using (var rsa = new RSACryptoServiceProvider(1024))
        //    {
        //        try
        //        {
        //            var base64Encrypted = strText;

        //            // server decrypting data with private key                    
        //            rsa.FromXmlString(privateKey);

        //            var resultBytes = Convert.FromBase64String(base64Encrypted);
        //            var decryptedBytes = rsa.Decrypt(resultBytes, true);
        //            var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
        //            return decryptedData.ToString();
        //        }
        //        finally
        //        {
        //            rsa.PersistKeyInCsp = false;
        //        }
        //    }
        //}

    //    static public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
    //    {
    //        try
    //        {
    //            byte[] encryptedData;
    //            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
    //            {
    //                RSA.ImportParameters(RSAKey); encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
    //            } return encryptedData;
    //        }
    //        catch (CryptographicException e)
    //        {
    //            Console.WriteLine(e.Message);
    //            return null;
    //        }
    //    }

    //    static public byte[] Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
    //    {
    //        try
    //        {
    //            byte[] decryptedData;
    //            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
    //            {
    //                RSA.ImportParameters(RSAKey);
    //                decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
    //            }
    //            return decryptedData;
    //        }
    //        catch (CryptographicException e)
    //        {
    //            Console.WriteLine(e.ToString());
    //            return null;
    //        }
    //    }
    }
}