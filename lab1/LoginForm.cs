using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace lab1
{
    public partial class LoginForm : Form
    {
        int WrongLoginCounter = 0;
        
        public LoginForm()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            bool flag = false;
            foreach (oneUser DB in Program.myList)
            {
                if (txtUsername.Text == DB.username && txtPassword.Text == DB.password)
                {
                   flag = true;
                   if (DB.status == "admin")
                   {
                       this.Hide();
                       AdminPage ap = new AdminPage(txtUsername.Text, this);
                       ap.Show();
                       txtUsername.Text = null;
                       txtPassword.Text = null;
                       WrongLoginCounter = 0;
                   }
                   else if (DB.status == "user" && DB.block == "no")
                   {
                       this.Hide();
                       UserPanel up = new UserPanel(DB.username,DB.password,DB.name,DB.surname,DB.city,this);
                       up.Show();
                       txtUsername.Text = null;
                       txtPassword.Text = null;
                       WrongLoginCounter = 0;
                   }
                   else if (DB.status == "user" && DB.block == "yes")
                   {
                       MessageBox.Show("You are blocked. Sorry, my friend!");
                       txtUsername.Text = null;
                       txtPassword.Text = null;
                       WrongLoginCounter = 0;
                       return;
                   }
                }
            }
            if (!flag) // flag = false
            {
                WrongLoginCounter++;
                if(WrongLoginCounter < 3)
                    MessageBox.Show("Please, check your login and password! You have "+(3 - WrongLoginCounter)+" attempt(s)");

                if(WrongLoginCounter == 3)
                {
                    MessageBox.Show("You do not have more attempts left. Goodbye my love, goodbye my friend!");
                    Application.Exit();
                }
                txtUsername.Text = null;
                txtPassword.Text = null;
            }
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration f = new Registration(this);
            f.Show();
        }

        static public bool GetReg() //hashing, 
        {
            string UserName, ComputerName, PathToOS, PathToSpecFileOS, MouseButtonCount,
                ScreenWidth;

            MD5 md5 = new MD5CryptoServiceProvider();
            // username
            byte[] checkSum1 = md5.ComputeHash(Encoding.UTF8.GetBytes(SystemInformation.UserName));
            UserName = BitConverter.ToString(checkSum1).Replace("-", String.Empty);
            // computer name
            byte[] checkSum2 = md5.ComputeHash(Encoding.UTF8.GetBytes(SystemInformation.UserDomainName));
            ComputerName = BitConverter.ToString(checkSum2).Replace("-", String.Empty);
            // path to direct windows//
            byte[] checkSum3 = md5.ComputeHash(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("windir")));//
            PathToOS = BitConverter.ToString(checkSum3).Replace("-", String.Empty);
            // path to system32
            byte[] checkSum4 = md5.ComputeHash(Encoding.UTF8.GetBytes(Environment.SystemDirectory.ToString()));
            PathToSpecFileOS = BitConverter.ToString(checkSum4).Replace("-", String.Empty);
            // mouse button count
            byte[] checkSum5 = md5.ComputeHash(Encoding.UTF8.GetBytes(Convert.ToString(SystemInformation.MouseButtons)));
            MouseButtonCount = BitConverter.ToString(checkSum5).Replace("-", String.Empty);
            // screen width
            byte[] checkSum6 = md5.ComputeHash(Encoding.UTF8.GetBytes(SystemInformation.WorkingArea.Width.ToString()));
            ScreenWidth = BitConverter.ToString(checkSum6).Replace("-", String.Empty);
            
            string UN, CN, PTOS, PTSFOS, MBC, SW; //берем данные с реестра
            RegistryKey readKey = Registry.CurrentUser.OpenSubKey("Sydorchuk");
            UN = (string)readKey.GetValue("UserName");
            CN = (string)readKey.GetValue("ComputerName");
            PTOS = (string)readKey.GetValue("PathToOS");
            PTSFOS = (string)readKey.GetValue("PathToSpecFileOS");
            MBC = (string)readKey.GetValue("MouseButtonCount");
            SW = (string)readKey.GetValue("ScreenWidth");
            readKey.Close();

            bool UserNameCheck = false, ComputerNameCheck = false, PathToOSCheck = false,
                PathToSpecFileOSCheck = false, MouseButtonCountCheck = false, ScreenWidthCheck = false;

            if (UserName == UN)
                UserNameCheck = true;
            if (ComputerName == CN)
                ComputerNameCheck = true;
            if (PathToOS == PTOS)
                PathToOSCheck = true;
            if (PathToSpecFileOS == PTSFOS)
                PathToSpecFileOSCheck = true;
            if (MouseButtonCount == MBC)
                MouseButtonCountCheck = true;
            if (ScreenWidth == SW)
                ScreenWidthCheck = true;

            return UserNameCheck && ComputerNameCheck && PathToOSCheck &&
                PathToSpecFileOSCheck && MouseButtonCountCheck && ScreenWidthCheck;
        }
        /*
        private static bool Signatura()
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            //Signature
            string Signature = SystemInformation.UserName + SystemInformation.UserDomainName +
                Environment.GetEnvironmentVariable("windir") + Environment.SystemDirectory.ToString() +
                    Convert.ToString(SystemInformation.MouseButtons) + SystemInformation.WorkingArea.Width.ToString();

            byte[] signature = md5.ComputeHash(Encoding.UTF8.GetBytes(Signature));
            string signatureReg = BitConverter.ToString(signature).Replace("-", String.Empty);

            string sigReg;
            RegistryKey readKey = Registry.CurrentUser.OpenSubKey("Sydorchuk");
            sigReg = readKey.GetValue("Signature").ToString();

            if (signatureReg != sigReg)
                return false;
            else
                return true;
        }
        */
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Добро пожаловать в программу Login Form!");
            /* If file not exists, create encrypt file with data about 'admin' */
            if (!File.Exists("DB_Encrypt.txt"))
            {
                Crypt.AddToReg();
                StreamWriter sw = new StreamWriter("DB_Encrypt.txt");
                sw.WriteLine(Crypt.Encrypt("1"));
                sw.WriteLine(Crypt.Encrypt("admin,,Vlad,Sydorchuk,Kyiv,admin,no,"));
                sw.Close();
            }

            /* Create StreamReader and reading info from DB_Encrypt and then write 
             * it to temporary file DB_Decrypt */
            StreamReader sr = new StreamReader("DB_Encrypt.txt");
            StreamWriter sw1 = new StreamWriter("DB_Decrypt.txt");
            int n = Convert.ToInt32(Crypt.Decrypt(sr.ReadLine()));
            sw1.WriteLine(n);
            for (int i = 0; i < n; i++)
                sw1.WriteLine(Crypt.Decrypt(sr.ReadLine()));
            sw1.Close();
            sr.Close();
            
            /* Write info from file to Program.myList */
            StreamReader sr1 = new StreamReader("DB_Decrypt.txt");
            int n1 = Convert.ToInt32(sr1.ReadLine());
            try
            {
                for (int i = 0; i < n1; i++)
                {
                    oneUser ddbb = new oneUser();
                    String Line = sr1.ReadLine();
                    int sep = Line.IndexOf(",");
                    ddbb.username = Line.Substring(0, sep);
                    Line = Line.Substring(sep + 1);
                    sep = Line.IndexOf(",");
                    ddbb.password = Line.Substring(0, sep);
                    Line = Line.Substring(sep + 1);
                    sep = Line.IndexOf(",");
                    ddbb.name = Line.Substring(0, sep);
                    Line = Line.Substring(sep + 1);
                    sep = Line.IndexOf(",");
                    ddbb.surname = Line.Substring(0, sep);
                    Line = Line.Substring(sep + 1);
                    sep = Line.IndexOf(",");
                    ddbb.city = Line.Substring(0, sep);
                    Line = Line.Substring(sep + 1);
                    sep = Line.IndexOf(",");
                    ddbb.status = Line.Substring(0, sep);
                    Line = Line.Substring(sep + 1);
                    sep = Line.IndexOf(",");
                    ddbb.block = Line.Substring(0, sep);
                    Program.myList.Add(ddbb);
                }
            }
            catch { MessageBox.Show("File has problem"); }
            sr1.Close();
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            /* Where main form will closed -> delete temporary file DB_Decrypt*/
            //if (Signatura())
            //{
                Crypt.AddToReg();
                StreamWriter sw = new StreamWriter("DB_Encrypt.txt");
                int count = Program.myList.Count;
                sw.WriteLine(Crypt.Encrypt(count.ToString()));
                for (int i = 0; i < Program.myList.Count; i++)
                    sw.WriteLine(Crypt.Encrypt(
                        Program.myList[i].username + "," 
                        + Program.myList[i].password + ","
                        + Program.myList[i].name + ","
                        + Program.myList[i].surname + ","
                        + Program.myList[i].city + "," +
                        Program.myList[i].status + ","
                        + Program.myList[i].block + ","));
                sw.Close();
                File.Delete("DB_Decrypt.txt");
            //}
        }
    }
}