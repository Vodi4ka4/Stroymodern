using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stroymodern
{
    public partial class Order : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Stroymodern";
        int id_user = 0;
        ListItem listItem = new ListItem();
        public Order(string login, int user_id)
        {
            InitializeComponent();
            id_user = user_id;
            label_login.Text = login;
        }
        public List <string> stringArray { get; set; }
        public void SetSelectedArticle(List <string> stringArray)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                // Создаем копию списка stringArray
                List<string> stringArrayCopy = new List<string>(stringArray);
                foreach (string article in stringArrayCopy)
                {
                    string sql = "SELECT article, title, cost, image FROM product WHERE article = '" + article + "'";
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ListItem listItem = new ListItem(); // Создаем новый экземпляр ListItem для каждого элемента
                                listItem.Article = Convert.ToString(reader.GetString(0));
                                listItem.Name_product = reader.GetString(1);
                                listItem.Coust = Convert.ToString(reader.GetDecimal(2)) + "₽";
                                if (!reader.IsDBNull(3))
                                {
                                    string path = reader.GetString(3);
                                    listItem.Icon = Image.FromFile(path);
                                }

                                // Создаем и добавляем элементы управления для выбора количества
                                AddQuantityControls(listItem);

                                flowLayoutPanel_Product.Controls.Add(listItem);
                            }
                        }
                    }
                    // Удаляем обработанный элемент из оригинальной коллекции
                    stringArray.Remove(article);
                    label_total.Text = Convert.ToString(CalculateTotalPrice());
                }
            }
        }
        private void AddQuantityControls(ListItem listItem)
        {
            // Определяем размер и расположение элементов управления
            int textBoxWidth = 50;
            int buttonWidth = 30;
            int buttonHeight = 20;
            int spacing = 5;
            int shiftLeft = 10; // сдвигаем на 10 пикселей влево

            // Создаем элементы управления для выбора количества
            TextBox quantityTextBox = new TextBox();
            quantityTextBox.Text = "1";
            quantityTextBox.Name = "quantityTextBox"; // Даем имя элементу управления
            quantityTextBox.Location = new Point(listItem.Width - textBoxWidth - spacing - shiftLeft, listItem.Height - buttonHeight - spacing);
            quantityTextBox.Size = new Size(textBoxWidth, buttonHeight);

            Button plusButton = new Button();
            plusButton.Text = "+";
            plusButton.Location = new Point(quantityTextBox.Location.X - buttonWidth - spacing - shiftLeft, quantityTextBox.Location.Y);
            plusButton.Size = new Size(buttonWidth, buttonHeight);

            Button minusButton = new Button();
            minusButton.Text = "-";
            minusButton.Location = new Point(plusButton.Location.X - buttonWidth - spacing, plusButton.Location.Y);
            minusButton.Size = new Size(buttonWidth, buttonHeight);

            Button deleteButton = new Button();
            deleteButton.Text = "Удалить";
            deleteButton.Location = new Point(minusButton.Location.X - buttonWidth - spacing - shiftLeft - 10, minusButton.Location.Y);
            deleteButton.Size = new Size(buttonWidth * 2, buttonHeight);
            // Добавляем обработчики событий для кнопок "+" и "-"
            plusButton.Click += (sender, e) =>
            {
                int quantity = int.Parse(quantityTextBox.Text);
                quantity++;
                quantityTextBox.Text = quantity.ToString();
                label_total.Text = Convert.ToString(CalculateTotalPrice());
            };

            minusButton.Click += (sender, e) =>
            {
                int quantity = int.Parse(quantityTextBox.Text);
                if (quantity > 0)
                {
                    quantity--;
                    quantityTextBox.Text = quantity.ToString();
                }
                label_total.Text = Convert.ToString(CalculateTotalPrice());
            };

            deleteButton.Click += (sender, e) =>
            {
                flowLayoutPanel_Product.Controls.Remove(listItem);
                label_total.Text = Convert.ToString(CalculateTotalPrice());
            };

            // Добавляем элементы управления к ListItem
            listItem.Controls.Add(quantityTextBox);
            listItem.Controls.Add(plusButton);
            listItem.Controls.Add(minusButton);
            listItem.Controls.Add(deleteButton);
        }
        private decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            foreach (var listItem in flowLayoutPanel_Product.Controls.OfType<ListItem>())
            {
                int quantity = int.Parse(listItem.Controls["quantityTextBox"].Text); // Получаем количество товара из TextBox
                decimal pricePerItem = decimal.Parse(listItem.Coust.Replace("₽", "")); // Получаем цену товара из свойства Coust

                totalPrice += quantity * pricePerItem;
            }

            return totalPrice;
        }
        int orderId = 0;
        private void button_order_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // Prepare the SQL command outside the loop
                string sql = "INSERT INTO order_ (user_id, cost) VALUES (@user_id, @cost)";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    // Add parameters to the command
                    command.Parameters.Add("@user_id", NpgsqlDbType.Integer);
                    command.Parameters.Add("@cost", NpgsqlDbType.Numeric);
                    // Set parameter values
                    command.Parameters["@user_id"].Value = id_user;
                    command.Parameters["@cost"].Value = CalculateTotalPrice();

                    // Execute the command
                    command.ExecuteNonQuery();
                }
            }

            // Get the orderId
            int orderId = GetOrderId();

            // Print the page
            PrintPage();
        }
        private int GetOrderId()
        {

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // Prepare the SQL command outside the loop
                string sql = "SELECT id FROM order_ WHERE user_id = @user_id AND cost = @cost::money";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@user_id", id_user);
                    command.Parameters.AddWithValue("@cost", Convert.ToDecimal(CalculateTotalPrice()));

                    // Execute the command
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orderId = reader.GetInt32(0); // Assuming id is of type integer
                        }
                    }
                }
            }

            return orderId;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label_total.Text = Convert.ToString(CalculateTotalPrice());
        }

        private void PrintPage()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Чек №" + orderId;
            saveFileDialog.Filter = "PDF файлы (*.pdf)|*.pdf";

            string path;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog.FileName;
            }
            else
            {
                return;
            }
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (s, printPageEventArgs) =>
            {
                Graphics graphics = printPageEventArgs.Graphics;
                Font font = new Font("Times New Roman", 12);
                Font titleFont = new Font("Times New Roman", 16);
                float fontHeight = font.GetHeight();

                float startX = 10;
                float startY = 10;
                float offset = 40;

                graphics.DrawString("Компания ООО", titleFont, Brushes.Black, printPageEventArgs.PageBounds.Width - graphics.MeasureString("Компания ООО", font).Width - 100, startY);
                startY += offset;
                graphics.DrawString("\"СтройМодерн\"", titleFont, Brushes.Black, printPageEventArgs.PageBounds.Width - graphics.MeasureString("\"СтройМодерн\"", font).Width - 100, startY);
                startY += offset;
                graphics.DrawString("Чек №" + orderId, titleFont, Brushes.Black, (printPageEventArgs.PageBounds.Width - graphics.MeasureString("Чек №" + orderId, font).Width) / 2, startY);
                startY += offset;

                Pen pen = new Pen(Color.Black, 1);

                // Рисуем заголовки столбцов
                float currentX = startX;
                graphics.DrawLine(pen, startX, startY, startX + 400, startY);
                graphics.DrawString("Название товара", font, Brushes.Black, startX, startY);
                currentX += 150;
                graphics.DrawLine(pen, currentX, startY, currentX, startY + offset);
                graphics.DrawString("Количество", font, Brushes.Black, currentX, startY);
                currentX += 100;
                graphics.DrawLine(pen, currentX, startY, currentX, startY + offset);
                graphics.DrawString("Цена", font, Brushes.Black, currentX, startY);
                currentX += 100;
                graphics.DrawLine(pen, currentX, startY, currentX, startY + offset);
                graphics.DrawString("Итоговая сумма", font, Brushes.Black, currentX, startY);
                startY += offset;

                // Наполняем данными
                foreach (ListItem listItem in flowLayoutPanel_Product.Controls)
                {
                    int quantity = int.Parse(listItem.Controls["quantityTextBox"].Text);
                    decimal pricePerItem = decimal.Parse(listItem.Coust.Replace("₽", ""));
                    decimal totalPrice = quantity * pricePerItem;

                    currentX = startX;
                    graphics.DrawLine(pen, startX, startY, startX + 400, startY);
                    graphics.DrawString(listItem.Name_product, font, Brushes.Black, startX, startY);
                    currentX += 150;
                    graphics.DrawLine(pen, currentX, startY, currentX, startY + offset);
                    graphics.DrawString(quantity.ToString(), font, Brushes.Black, currentX, startY);
                    currentX += 100;
                    graphics.DrawLine(pen, currentX, startY, currentX, startY + offset);
                    graphics.DrawString(pricePerItem.ToString() + "₽", font, Brushes.Black, currentX, startY);
                    currentX += 100;
                    graphics.DrawLine(pen, currentX, startY, currentX, startY + offset);
                    graphics.DrawString(totalPrice.ToString() + "₽", font, Brushes.Black, currentX, startY);
                    startY += offset;
                }
            };
            printDocument.PrinterSettings.PrintToFile = true;
            printDocument.PrinterSettings.PrintFileName = path;
            printDocument.Print();

        }
    }

}

