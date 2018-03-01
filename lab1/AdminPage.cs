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
    public partial class AdminPage : Form
    {
        LoginForm form;
        string Username;
        public AdminPage(string Username, LoginForm form)
        {
            InitializeComponent();
            this.Username = Username;
            this.form = form;
            label1.Text = "Hello, " + Username + "!";
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(Username);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminShowUsers asu = new AdminShowUsers(this);
            asu.Show();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddUser au = new AddUser(this);
            au.Show();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword(Username);
            cp.ShowDialog();
        }

        private void AdminPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
        }
    }
}
