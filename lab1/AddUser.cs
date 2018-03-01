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
    public partial class AddUser : Form
    {
        AdminPage form;
        public AddUser(AdminPage form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (oneUser DB in Program.myList) //проверка, есть ли пользователь в базе
                if (DB.username == txtUserNameNew.Text)
                {
                    MessageBox.Show("Already existing user");
                    txtUserNameNew.Text = null;
                    return;
                }

            oneUser newUser = new oneUser(); //если все окей, добавляем пустого пользователя
            newUser.username = txtUserNameNew.Text;
            newUser.password = "";
            newUser.name = "";
            newUser.surname = "";
            newUser.city = "";
            newUser.status = "user";
            newUser.block = "no";
            Program.myList.Add(newUser);
            try
            {
                StreamWriter sw = new StreamWriter("DB_Decrypt.txt"); //перезаписываем файл с новым пользователем
                sw.WriteLine(Program.myList.Count);
                for (int i = 0; i < Program.myList.Count; i++)
                    sw.WriteLine(Program.myList[i].username + "," + Program.myList[i].password + "," +
                        Program.myList[i].name + "," + Program.myList[i].surname + "," + Program.myList[i].city + "," +
                        Program.myList[i].status + "," + Program.myList[i].block + ",");
                sw.Close();
            }
            catch { MessageBox.Show("Ошибка сохранения настроек"); }
            MessageBox.Show("Data Export");
            txtUserNameNew.Text = null;
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void AddUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
        }
    }
}
