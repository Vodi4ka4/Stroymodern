using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Stroymodern
{
    public partial class Admin : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Stroymodern";
        public Admin(string login)
        {
            InitializeComponent();
            label_login.Text = login;
        }
        private void Form_Load()
        {  
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                // Открываем подключение
                connection.Open();

                // Напишем SQL-запрос для выборки данных
                string sql = "SELECT * FROM " + SelectedIndex();

                // Создаем объект адаптера данных
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sql, connection))
                {
                    // Создаем объект DataTable для хранения данных
                    DataTable dataTable = new DataTable();

                    // Заполняем DataTable данными из базы данных
                    adapter.Fill(dataTable);

                    // Привязываем DataTable к DataGridView
                    dataGridView_table.DataSource = dataTable;
                }
            }
            dataGridView_table.AllowUserToAddRows = true;
            dataGridView_table.ReadOnly = false;
        }

        private void dataGridView_table_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dataTable = (DataTable)dataGridView_table.DataSource;
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT * FROM " + SelectedIndex(), connection))
                {
                    new NpgsqlCommandBuilder(adapter);
                    adapter.UpdateCommand = new NpgsqlCommandBuilder(adapter).GetUpdateCommand();
                    adapter.Update(dataTable);
                }
            }
        }

        private void dataGridView_table_RowDeleted(object sender, DataGridViewRowEventArgs e)
        {
            DataTable dataTable = (DataTable)dataGridView_table.DataSource;
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT * FROM " + SelectedIndex(), connection))
                {
                    new NpgsqlCommandBuilder(adapter);
                    adapter.DeleteCommand = new NpgsqlCommandBuilder(adapter).GetDeleteCommand();
                    adapter.Update(dataTable);
                }
            }
        }
        private string SelectedIndex()
        {
            if(comboBox_table.SelectedIndex == 0)
            {
                string text = "order_";
                return text;
            }
            else if(comboBox_table.SelectedIndex == 1)
            {
                string text = "product";
                return text;
            }
            else if(comboBox_table.SelectedIndex == 2)
            {
                string text = "role";
                return text;
            }
            else if(comboBox_table.SelectedIndex == 3)
            {
                string text = "users";
                return text;
            }
            else if(comboBox_table.SelectedIndex == 4)
            {
                string text = "type";
                return text;
            }
            string result = "order_";
            return result;
        }
        private void comboBox_table_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form_Load();
            SelectedIndex();
        }

        private void button_spam_Click(object sender, EventArgs e)
        {
            using (MailMessage message = new MailMessage("kolya.hrenov2018@mail.ru", "kolya.hrenov2018@mail.ru"))
            {
                message.Subject = "Акция на нашем магазине!";
                message.Body = "Уважаемый клиент! Только 24 февраля вся продукция со скидкой – 20%, при указании кодового слова «Дэмоэкзамен 2023».";

                using (SmtpClient smtpClient = new SmtpClient("smtp.mail.ru", 587))
                {
                    smtpClient.Credentials = new NetworkCredential("kolya.hrenov2018@mail.ru", "KgttJpk6YaSJDCumReAT");
                    smtpClient.EnableSsl = true;

                    try
                    {
                        smtpClient.Send(message);
                        MessageBox.Show("Письмо успешно отправлено.");
                    }
                    catch (SmtpException ex)
                    {
                        MessageBox.Show($"Ошибка при отправке письма: {ex.Message}. Код ошибки: {ex.StatusCode}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла ошибка: {ex.Message}");
                    }
                }
            }
        }
    }
}
