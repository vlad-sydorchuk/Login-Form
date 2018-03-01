using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class UserPanel : Form
    {
        LoginForm form;
        string Username, Password, Name, Surname, City;
        public UserPanel(string Username, string Password, string Name,
            string Surname, string City, LoginForm form)
        {
            InitializeComponent();
            this.form = form;
            this.Username = Username;
            this.Password = Password;
            this.Name = Name;
            this.Surname = Surname;
            this.City = City;
        }

        private void UserPanel_Load(object sender, EventArgs e)
        {
            txtLogin.Text = Username;
            txtName.Text = Name;
            txtSurname.Text = Surname;
            txtCity.Text = City;
            label5.Text = "Welcome, " + Name + " " + Surname + "!";
        }

        private void UserPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword(Username);
            cp.ShowDialog();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В пароле не должно быть символов, которые повторяются.");
        }

        private void разработчикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Влад Сидорчук и Виктор Яструб, ИМ-21");
        }
    }
}
