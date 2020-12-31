using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.PassSield.AutoSize = false;
            this.PassSield.Size = new Size(this.PassSield.Size.Width, 45 );
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//Нажали на кнопку
        {
            String login = LoginField.Text;//Получили логин от пользователя
            String pass = PassSield.Text;//Получили пароль от пользователя

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`= @ul AND `pass` = @up", db.GetConnection());//db-к какой базе данных подключаемся
            //запросы к базе данных sql
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@up", MySqlDbType.VarChar).Value = pass;

            adapter.SelectCommand = command;//Тут мы указываем, какую команду выполнять
            adapter.Fill(table);//Все данные мы трансформируем в обьект тэйбл

            if (table.Rows.Count > 0)//Считаем сколько рядов. Если хотя бы 1 пара лог+пар совпадают, то успех
                MessageBox.Show("Nice");//всплывающее окно
            else
                MessageBox.Show("False");
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PassSield_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.LightGray;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.White;
        }

        Point lastPoint;
        private void LoginForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }//На какую кнопку мы нажали
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void PassSield_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);//начинаем отсчет зажатой левой кнопки мышки
        }
    }
}
