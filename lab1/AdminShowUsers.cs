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
    public partial class AdminShowUsers : Form
    {
        AdminPage form;
        public AdminShowUsers(AdminPage form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++) //если были изменения, нужно перезаписать файл
            {
                Program.myList[i].username = dataGridView1.Rows[i].Cells[0].Value.ToString();
                Program.myList[i].password = dataGridView1.Rows[i].Cells[1].Value.ToString();
                Program.myList[i].name = dataGridView1.Rows[i].Cells[2].Value.ToString();
                Program.myList[i].surname = dataGridView1.Rows[i].Cells[3].Value.ToString();
                Program.myList[i].city = dataGridView1.Rows[i].Cells[4].Value.ToString();
                Program.myList[i].status = dataGridView1.Rows[i].Cells[5].Value.ToString();
                Program.myList[i].block = dataGridView1.Rows[i].Cells[6].Value.ToString();
            }
            
            try
            {
                StreamWriter sw = new StreamWriter("DB_Decrypt.txt");
                sw.WriteLine(Program.myList.Count);
                for (int i = 0; i < Program.myList.Count; i++)
                    //sw.WriteLine(Program.myList[i].name + "," + Program.myList[i].password + ",");
                    sw.WriteLine(Program.myList[i].username + "," + Program.myList[i].password + "," +
                            Program.myList[i].name + "," + Program.myList[i].surname + "," + Program.myList[i].city + "," +
                            Program.myList[i].status + "," + Program.myList[i].block + ",");
                sw.Close();
            }
            catch { MessageBox.Show("Ошибка сохранения настроек"); }
            MessageBox.Show("Data Export");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear(); //очищаем таблицу перед запуском формы

            int n = Program.myList.Count();
            dataGridView1.ColumnCount = 7; // кол-во столбиков

            for (int i = 0; i < n; i++) //выгружаем все в таблицу
            {
                dataGridView1.Rows.Add(Program.myList[i].username, Program.myList[i].password,
                            Program.myList[i].name, Program.myList[i].surname, Program.myList[i].city, 
                            Program.myList[i].status, Program.myList[i].block);
            }
            
        }

        private void AdminPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
