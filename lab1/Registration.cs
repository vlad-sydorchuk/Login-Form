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
    public partial class Registration : Form
    {
        LoginForm form;
        
        public Registration(LoginForm form)
        {
            this.form = form;
            InitializeComponent();
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

        private void btnRReg_Click(object sender, EventArgs e)
        {
            foreach (oneUser DB in Program.myList)
                if (DB.username == txtRUser.Text) // проверка, есть ли пользователь
                { 
                    MessageBox.Show("Already existing user.");
                    return;
                }

            bool passCheck = CheckPasswordRules(txtRPassword.Text); // проверка пароля на символы
            if (passCheck)
            {
                MessageBox.Show("Please don't use same symbols!");
                return;
            }

            if (txtRPassword.Text != txtRRPassword.Text) // проверка пароля на совпадения 
            {
                MessageBox.Show("Passes not the same");
                return;
            }
                oneUser ddbb = new oneUser();
                ddbb.username = txtRUser.Text;
                ddbb.password = txtRPassword.Text;
                ddbb.name = txtName.Text;
                ddbb.surname = txtSurName.Text;
                ddbb.city = txtCity.Text;
                ddbb.status = "user"; 
                ddbb.block = "no";
                Program.myList.Add(ddbb);
                try
                {
                    StreamWriter sw = new StreamWriter("DB_Decrypt.txt");
                    sw.WriteLine(Program.myList.Count);
                    for (int i = 0; i < Program.myList.Count; i++)
                        sw.WriteLine(Program.myList[i].username + "," + Program.myList[i].password + "," + 
                            Program.myList[i].name + "," + Program.myList[i].surname + "," + Program.myList[i].city + "," +
                            Program.myList[i].status + "," + Program.myList[i].block + ",");
                    sw.Close();
                }
                catch { MessageBox.Show("Ошибка сохранения настроек"); }
                MessageBox.Show("Data Export");
                this.Hide();
                form.Show();
        }

        private void Registration_Load(object sender, EventArgs e)
        {            

        }

        private void Registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
