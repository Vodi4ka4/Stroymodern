using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stroymodern
{
    public partial class Manager : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Stroymodern";
        List<string> stringArray = new List<string>();
        int user_id = 0;
        public Manager(string login, int id)
        {
            InitializeComponent();
            label_login.Text = login;
            user_id = id;
        }
        private void populateItems(int filtrarion = 0, string searchTerm = "", string sortingCriteria = "", int offset = 0)
        {
            flowLayoutPanel_Product.Controls.Clear();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT article, title, cost, image FROM product";
                    if (filtrarion > 0)
                    {
                        sql += " WHERE type = " + filtrarion;
                        if (!string.IsNullOrEmpty(searchTerm))
                        {
                            sql += " AND Lower(title) LIKE Lower('%" + searchTerm + "%')";
                        }
                    }
                    else if (!string.IsNullOrEmpty(searchTerm))
                    {
                        sql += " WHERE Lower(title) LIKE Lower('%" + searchTerm + "%')";
                    }
                    if (sortingCriteria != "")
                    {
                        sql += " " + sortingCriteria + ", " + " article LIMIT " + itemsPerPage + " OFFSET " + offset;
                    }
                    else
                    {
                        sql += " ORDER BY article LIMIT " + itemsPerPage + " OFFSET " + offset;
                    }

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ListItem listItem = new ListItem();
                                listItem.Article = Convert.ToString(reader.GetString(0));
                                listItem.Name_product = reader.GetString(1);
                                listItem.Coust = Convert.ToString(reader.GetDecimal(2)) + "₽";
                                if (!reader.IsDBNull(3))
                                {
                                    string path = reader.GetString(3);
                                    listItem.Icon = Image.FromFile(path);
                                }
                                flowLayoutPanel_Product.Controls.Add(listItem);
                                listItem.MouseClick += (sender, e) =>
                                {
                                    if (e.Button == MouseButtons.Right)
                                    {
                                        // Создаем контекстное меню
                                        ContextMenu contextMenu = new ContextMenu();

                                        // Добавляем пункт меню "Добавить в заказ"
                                        MenuItem menuItem = new MenuItem("Добавить в заказ");
                                        menuItem.Click += (s, args) =>
                                        {
                                            stringArray.Add(listItem.Article);
                                        };
                                        contextMenu.MenuItems.Add(menuItem);

                                        // Привязываем контекстное меню к элементу ListItem и отображаем его
                                        listItem.ContextMenu = contextMenu;
                                    }
                                    else
                                    {
                                        DrawBarcode(listItem.Article);
                                        CreateBarCode(DrawBarcode(listItem.Article), listItem.Article);
                                    }
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении данных из базы данных: " + ex.Message);
            }
        }
        private void PopulatePage(int pageNumber)
        {
            int offset = (pageNumber - 1) * itemsPerPage;
            string sortingCriteria = GetSortingCriteria();
            populateItems(comboBox_filtration.SelectedIndex, textBox_search.Text, sortingCriteria, offset);
        }
        private string GetSortingCriteria()
        {
            string sortingCriteria = "";
            switch (comboBox_Sorting.SelectedIndex)
            {
                case 1:
                    sortingCriteria = "ORDER BY cost ASC";
                    break;
                case 2:
                    sortingCriteria = "ORDER BY cost DESC";
                    break;
                case 3:
                    sortingCriteria = "ORDER BY title ASC";
                    break;
                case 4:
                    sortingCriteria = "ORDER BY title DESC";
                    break;
            }
            return sortingCriteria;
        }

        private void comboBox_filtration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_filtration.SelectedIndex == 0)
            {
                populateItems();
            }
            else
            {
                populateItems(comboBox_filtration.SelectedIndex);
            }
        }

        private void comboBox_Sorting_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sortingCriteria = "";
            switch (comboBox_Sorting.SelectedIndex)
            {
                case 0:
                    sortingCriteria = ""; // По умолчанию сортировка отсутствует
                    break;
                case 1:
                    sortingCriteria = "ORDER BY cost ASC";
                    break;
                case 2:
                    sortingCriteria = "ORDER BY cost DESC";
                    break;
                case 3:
                    sortingCriteria = "ORDER BY title ASC";
                    break;
                case 4:
                    sortingCriteria = "ORDER BY title DESC";
                    break;
            }

            if (comboBox_filtration.SelectedIndex != 0)
            {
                populateItems(comboBox_filtration.SelectedIndex, textBox_search.Text, sortingCriteria);
            }
            else
            {
                populateItems(0, textBox_search.Text, sortingCriteria);
            }
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            populateItems(comboBox_filtration.SelectedIndex, textBox_search.Text);

        }
        private int currentPage = 1;
        private int totalPages;
        private const int itemsPerPage = 5;
        private void DisplayPagination()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string countSql = "SELECT COUNT(*) FROM product";
                    using (NpgsqlCommand countCommand = new NpgsqlCommand(countSql, connection))
                    {
                        int totalProducts = Convert.ToInt32(countCommand.ExecuteScalar());
                        totalPages = (int)Math.Ceiling((double)totalProducts / itemsPerPage);
                    }
                }

                flowLayoutPanel_Pagination.Controls.Clear(); // Очищаем предыдущие элементы

                // Добавляем кнопку "<" для перехода к предыдущей странице
                AddPageButton("<", currentPage - 1);

                // Добавляем кнопки для каждой страницы
                for (int i = 1; i <= totalPages; i++)
                {
                    Label pageButton = new Label
                    {
                        Text = i.ToString(),
                        Width = 20,
                        Height = 20,
                        Margin = new Padding(5),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Cursor = Cursors.Hand
                    };

                    if (i == currentPage)
                    {
                        pageButton.Font = new System.Drawing.Font(pageButton.Font, FontStyle.Bold | FontStyle.Underline);
                    }

                    // Обработчик клика для перехода на выбранную страницу
                    pageButton.Click += (sender, e) =>
                    {
                        currentPage = int.Parse(((Label)sender).Text);
                        PopulatePage(currentPage);
                    };

                    flowLayoutPanel_Pagination.Controls.Add(pageButton);
                }

                // Добавляем кнопку ">" для перехода к следующей странице
                AddPageButton(">", currentPage + 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении данных из базы данных: " + ex.Message);
            }
        }

        private void AddPageButton(string buttonText, int targetPage)
        {
            // Создаем элемент Label для кнопки страницы
            Label pageButton = new Label
            {
                Text = buttonText,
                Width = 15,
                Height = 15,
                Margin = new Padding(5),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };

            // Обработчик клика для перехода на выбранную страницу
            pageButton.Click += (sender, e) =>
            {
                if (targetPage > 0 && targetPage <= totalPages)
                {
                    currentPage = targetPage;
                    PopulatePage(currentPage);
                }
            };

            // Добавляем кнопку в панель пагинации
            flowLayoutPanel_Pagination.Controls.Add(pageButton);
        }

        private Image DrawBarcode(string code, int resolution = 20)
        {
            int numberCount = 13; // количество цифр
            float height = 25.93f * resolution; // высота штрих кода
            float lineHeight = 22.85f * resolution; // высота штриха
            float leftOffset = 3.63f * resolution; // свободная зона слева
            float rightOffset = 2.31f * resolution; // свободная зона справа
                                                    //штрихи, которые образуют правый и левый ограничивающие знаки,
                                                    //а также центральный ограничивающий знак должны быть удлинены вниз на 1,65мм
            float longLineHeight = lineHeight + 1.65f * resolution;
            float fontHeight = 2.75f * resolution; // высота цифр
            float lineToFontOffset = 0.165f * resolution; // минимальный размер от верхнего края цифр до нижнего края штрихов
            float lineWidthDelta = 0.15f * resolution; // ширина 0.15*{цифра}
            float lineWidthFull = 1.35f * resolution; // ширина белой полоски при 0 или 0.15*9
            float lineOffset = 0.2f * resolution; // между штрихами должно быть расстояние в 0.2мм

            float width = leftOffset + rightOffset + 6 * (lineWidthDelta + lineOffset) + numberCount * (lineWidthFull + lineOffset); // ширина штрих-кода

            Bitmap bitmap = new Bitmap((int)width, (int)height); // создание картинки нужных размеров

            using (Graphics g = Graphics.FromImage(bitmap)) // создание графики
            {
                Font font = new Font("Arial", fontHeight, FontStyle.Regular, GraphicsUnit.Pixel); // создание шрифта

                StringFormat fontFormat = new StringFormat(); // Центрирование текста
                fontFormat.Alignment = StringAlignment.Center;
                fontFormat.LineAlignment = StringAlignment.Center;

                float x = leftOffset; // позиция рисования по x
                for (int i = 0; i < numberCount; i++)
                {
                    if (i >= code.Length) // проверка выхода за пределы массива
                        break;

                    int number = Convert.ToInt32(code[i].ToString()); // число из кода
                    if (number != 0)
                    {
                        g.FillRectangle(Brushes.Black, x, 0, number * lineWidthDelta, lineHeight); // рисуем штрих
                    }
                    RectangleF fontRect = new RectangleF(x, lineHeight + lineToFontOffset, lineWidthFull, fontHeight); // рамки для буквы
                    g.DrawString(code[i].ToString(), font, Brushes.Black, fontRect, fontFormat); // рисуем букву
                    x += lineWidthFull + lineOffset; // смещаем позицию рисования по x

                    if (i == 0 || i == numberCount / 2 || i == numberCount - 1) // если это начало, середина или конец кода рисуем разделители
                    {
                        for (int j = 0; j < 2; j++) // рисуем 2 линии разделителя
                        {
                            g.FillRectangle(Brushes.Black, x, 0, lineWidthDelta, longLineHeight); // рисуем длинный штрих
                            x += lineWidthDelta + lineOffset; // смещаем позицию рисования по x
                        }
                    }
                }
            }
            return bitmap;
        }
        private void CreateBarCode(Image img, string code)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = code + ".pdf";
            saveFileDialog.Filter = "PDF файлы (.pdf)|.pdf";

            string filePath;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
            }
            else
            {
                return;
            }

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (s, e) =>
            {
                RectangleF imageRect = new RectangleF(100, 100, 200, 150);
                e.Graphics.DrawImage(img, imageRect);
            };

            printDocument.PrinterSettings.PrintToFile = true;
            printDocument.PrinterSettings.PrintFileName = filePath;
            printDocument.Print();
        }

        private void Manager_Load_1(object sender, EventArgs e)
        {
            DisplayPagination();
            PopulatePage(1);
        }

        private void button_order_Click(object sender, EventArgs e)
        {
            Order order = new Order(label_login.Text, user_id);
            order.SetSelectedArticle(stringArray);
            order.FormClosed += (s, args) => Close();
            order.Show();
        }
    }
}
