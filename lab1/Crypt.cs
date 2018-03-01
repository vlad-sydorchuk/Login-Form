using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;

namespace lab1
{
    public class Crypt
    {
        //private static string Key = "0123456789012345qwedasdf"; //ключ
        private static string Key = RandomKey();//рандомный ключ 32 символа
        private static string IV = "0123456789012345"; //входной вектор

        /*Записываем сгенерированный ключ в реест, чтобы при следующем запуске
         программы мы смогли использовать этот ключ*/
        public static void AddToReg()
        {
            RegistryKey saveKey = Registry.CurrentUser.CreateSubKey("Yastryb");
            saveKey.SetValue("GenKey", Key);
            saveKey.Close();
        }

        /*Делаем сеансовый ключ*/
        private static string RandomKey()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < 32; i++)
            {
                //Генерируем число являющееся латинским символом в юникоде
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                //Конструируем строку со случайно сгенерированными символами
                builder.Append(ch);
            }
            //MessageBox.Show(builder.ToString());
            return builder.ToString();
        }

        /*Шифруем данные*/
        public static string Encrypt(string text)
        {
            //MessageBox.Show("Encrypt Key: " + Key);
            byte[] plaintextbytes = System.Text.ASCIIEncoding.ASCII.GetBytes(text);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(Key);
            aes.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;

            ICryptoTransform crypto = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] encrypted = crypto.TransformFinalBlock(plaintextbytes, 0, plaintextbytes.Length);
            crypto.Dispose();
            return Convert.ToBase64String(encrypted);
        }

        /*Расшифровываем данные*/
        public static string Decrypt(string encrypted)
        {
            RegistryKey readKey = Registry.CurrentUser.OpenSubKey("Yastryb");
            string KeyReg = (string)readKey.GetValue("GenKey");
            readKey.Close();

            //MessageBox.Show("Decrypt Key: " + KeyReg);

            byte[] encryptedbytes = Convert.FromBase64String(encrypted);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(KeyReg);
            aes.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;

            ICryptoTransform crypto = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] secret = crypto.TransformFinalBlock(encryptedbytes, 0, encryptedbytes.Length);
            crypto.Dispose();
            return System.Text.ASCIIEncoding.ASCII.GetString(secret);
        }
    }
}
