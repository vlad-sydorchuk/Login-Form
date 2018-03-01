using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab1
{
    public partial class ChangePassword : Form
    {
        string Username;
        public ChangePassword(string Username)
        {
            InitializeComponent();
            this.Username = Username;
        }

        public static Boolean CheckPasswordRules(String password) //метод для проверки пароля
        {
            Boolean flag = false;
            char[] passarr = password.ToCharArray();
            for (int i = 0; i < passarr.Length; i++)
                for (int j = 0; j < passarr.Length; j++)
                    if (i == j)
                    { }
                    else if (passarr[i] == passarr[j])
                    {
                        flag = true;
                        break;
                    }
            return flag;
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(Username);
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            foreach (oneUser DB in Program.myList)
                if (DB.username == Username)
                {
                    if (DB.password == txtOldPass.Text)
                    {
                        //MessageBox.Show("True");
                        bool passCheck = CheckPasswordRules(txtNewPass1.Text); // проверка пароля
                        //MessageBox.Show("Ans: " + passCheck);
                        if (passCheck)
                        {
                            MessageBox.Show("Please, don't use same symbols!");
                            return;
                        }

                        if (txtNewPass1.Text != txtNewPass2.Text)
                        {
                            MessageBox.Show("Passes are not same");
                            return;
                        }
                        else
                        {
                            try
                            {
                                StreamWriter sw = new StreamWriter("DB_Decrypt.txt");
                                sw.WriteLine(Program.myList.Count); // записываем кол-во строк в листе 
                                Program.myList[Program.myList.IndexOf(DB)].password = txtNewPass1.Text;
                                for (int i = 0; i < Program.myList.Count; i++)
                                    sw.WriteLine(Program.myList[i].username + "," + Program.myList[i].password + "," +
                                        Program.myList[i].name + "," + Program.myList[i].surname + "," + Program.myList[i].city + "," +
                                        Program.myList[i].status + "," + Program.myList[i].block + ",");
                                sw.Close();
                            }
                            catch { MessageBox.Show("Ошибка сохранения настроек"); }
                            MessageBox.Show("Data Export");
                            this.Hide();
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error, check your old password!");
                        return;
                    }
                }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
