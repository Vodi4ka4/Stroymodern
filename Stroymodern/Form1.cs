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
using Npgsql;

namespace Stroymodern
{
    public partial class Form_Entry : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Stroymodern";
        public Form_Entry()
        {
            InitializeComponent();
        }
        private (int id, int type) Check_user(string login, string password)
        {
            int id = 0;
            int type = 0;
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT id, type FROM users where login = @login AND password = @password";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = reader.GetInt32(0);
                            type = reader.GetInt32(1);
                        }
                    }
                }
            }
            return (id, type);
        }
        int count = 0;
        private void button_enter_Click(object sender, EventArgs e)
        {
            if (textBox_capch.Text == label_capch.Text)
            {
                if (Check_user(textBox_login.Text, textBox_password.Text).type == 1)
                {
                    Admin admin = new Admin(textBox_login.Text);
                    admin.FormClosed += (s, args) => Close();
                    admin.Show();
                }
                else if (Check_user(textBox_login.Text, textBox_password.Text).type == 2)
                {
                    Manager manager = new Manager(textBox_login.Text, Check_user(textBox_login.Text, textBox_password.Text).id);
                    manager.FormClosed += (s, args) => Close();
                    manager.Show();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль!");
                    count++;
                    if (count == 3)
                    {
                        label_timer.Visible = true;
                        timer = new Timer();
                        timer.Interval = 1000; // 1 секунда
                        timer.Tick += Timer_Tick;
                        button_enter.Visible = false;
                        timer.Start();
                    }
                    if (count == 4)
                    {
                        this.Close();
                    }
                }
            }
            else 
            { 
                this.Close(); 
            }

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            remainingSeconds--; // Уменьшаем количество оставшихся секунд
            if (remainingSeconds <= 0)
            {
                timer.Stop(); // Остановить таймер, если время истекло
                label_timer.Visible = false;
                button_enter.Visible = true;
                label_capch.Visible = true;
                textBox_capch.Visible = true;
                Capch();
            }
            else
            {
                label_timer.Text = $"Осталось времени: {remainingSeconds} секунд"; // Обновляем текст Label
            }
        }
        private Timer timer;
        private int remainingSeconds = 30;
        private void Capch()
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < 5; i++)
            {
                label_capch.Text = label_capch.Text + Convert.ToString(chars[random.Next(chars.Length)]);
            }
            for (int i = 0; i < 5; i++)
            {
                label_capch.Text = label_capch.Text + Convert.ToString(random.Next(10)); // Добавляем случайную цифру от 0 до 9
            }
        }

    }
}
