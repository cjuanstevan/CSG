using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSG
{

    public partial class PruebaEncriptar : Form
    {
        //Create a UnicodeEncoder to convert between byte array and string.
        UnicodeEncoding ByteConverter = new UnicodeEncoding();
       

        //Create byte arrays to hold original, encrypted, and decrypted data.
        private byte[] dataToEncrypt;
        byte[] encryptedData;
        byte[] decryptedData;
        public PruebaEncriptar()
        {
            InitializeComponent();
        }

        private void BtnEncriptar_Click(object sender, EventArgs e)
        {
            //dataToEncrypt = ByteConverter.GetBytes(txtencriptar.Text);
            ////dataToEncrypt = Encoding.Unicode.GetBytes(txtencriptar.Text);

            //using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            //{
            //    var rsa = new cryptography.SystemSupportRSA();
            //    //Pass the data to ENCRYPT, the public key information 
            //    //(using RSACryptoServiceProvider.ExportParameters(false),
            //    //and a boolean flag specifying no OAEP padding.
            //    encryptedData = rsa.RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);
            //    decryptedData = rsa.RSADecrypt(encryptedData, RSA.ExportParameters(true), false);
            //    //Display the decrypted plaintext to the console. 
            //    Console.WriteLine("Encrypted plaintext: {0}", ByteConverter.GetString(encryptedData));
            //    Console.WriteLine("Decrypted plaintext: {0}", ByteConverter.GetString(decryptedData));
            //}.

            string original = txtencriptar.Text;

            // Create a new instance of the AesManaged
            // class.  This generates a new key and initialization
            // vector (IV).
            using (AesManaged myAes = new AesManaged())
            {
                var rsa = new cryptography.SystemSupportRSA();
                // Encrypt the string to an array of bytes.
                byte[] encrypted = rsa.EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);
                Console.WriteLine("Encrypted: {0}", ByteConverter.GetString(encrypted));
                // Decrypt the bytes to a string.
                string roundtrip = rsa.DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);

                //Display the original data and the decrypted data.
                Console.WriteLine("Original:   {0}", original);
                Console.WriteLine("Round Trip: {0}", roundtrip);
                //Console.WriteLine("Encrypted: {0}",ByteConverter.GetString(encrypted));

                MD5 md5Hash = MD5.Create();
                string source = txtencriptar.Text;
                string hash = GetMd5Hash(md5Hash, source);
                string base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(hash));
                var base64EncodedBytes = System.Convert.FromBase64String(base64);
                string Decodificado = Encoding.UTF8.GetString(base64EncodedBytes);
                Console.WriteLine("MD5 hash: {0} | Texto: {1} | base64: {2} | Decodificado: {3}",hash, source,base64, Decodificado);
            }

        }


        private void BtnDesencriptar_Click(object sender, EventArgs e)
        {
            //var plainTextBytes = Encoding.UTF8.GetBytes("Robinhood*123");
            //string  plainTextString = Convert.ToBase64String(plainTextBytes);
            //Console.WriteLine("Encode: " + plainTextString);
            //var base64EncodedBytes = System.Convert.FromBase64String(plainTextString);
            //string Decodificado = Encoding.UTF8.GetString(base64EncodedBytes);
            //Console.WriteLine("Decode: " + Decodificado);
        }
        
        

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
