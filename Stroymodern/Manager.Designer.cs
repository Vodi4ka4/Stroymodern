namespace Stroymodern
{
    partial class Manager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manager));
            this.flowLayoutPanel_Product = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBox_filtration = new System.Windows.Forms.ComboBox();
            this.comboBox_Sorting = new System.Windows.Forms.ComboBox();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel_Pagination = new System.Windows.Forms.FlowLayoutPanel();
            this.label_login = new System.Windows.Forms.Label();
            this.button_order = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanel_Product
            // 
            this.flowLayoutPanel_Product.AutoScroll = true;
            this.flowLayoutPanel_Product.Location = new System.Drawing.Point(12, 41);
            this.flowLayoutPanel_Product.Name = "flowLayoutPanel_Product";
            this.flowLayoutPanel_Product.Size = new System.Drawing.Size(766, 394);
            this.flowLayoutPanel_Product.TabIndex = 9;
            // 
            // comboBox_filtration
            // 
            this.comboBox_filtration.FormattingEnabled = true;
            this.comboBox_filtration.Items.AddRange(new object[] {
            "Все типы",
            "Арки",
            "Двери",
            "Диваны",
            "Обои",
            "Фрески",
            "Цемент",
            "Заглушка"});
            this.comboBox_filtration.Location = new System.Drawing.Point(579, 14);
            this.comboBox_filtration.Name = "comboBox_filtration";
            this.comboBox_filtration.Size = new System.Drawing.Size(157, 22);
            this.comboBox_filtration.TabIndex = 8;
            this.comboBox_filtration.Text = "Фильтрация";
            this.comboBox_filtration.SelectedIndexChanged += new System.EventHandler(this.comboBox_filtration_SelectedIndexChanged);
            // 
            // comboBox_Sorting
            // 
            this.comboBox_Sorting.FormattingEnabled = true;
            this.comboBox_Sorting.Items.AddRange(new object[] {
            "Без сортировки",
            "По возрастанию цены",
            "По убыванию цены",
            "По названию от а до я",
            "По названию от я до а"});
            this.comboBox_Sorting.Location = new System.Drawing.Point(398, 14);
            this.comboBox_Sorting.Name = "comboBox_Sorting";
            this.comboBox_Sorting.Size = new System.Drawing.Size(175, 22);
            this.comboBox_Sorting.TabIndex = 7;
            this.comboBox_Sorting.Text = "Сортировка";
            this.comboBox_Sorting.SelectedIndexChanged += new System.EventHandler(this.comboBox_Sorting_SelectedIndexChanged);
            // 
            // textBox_search
            // 
            this.textBox_search.Location = new System.Drawing.Point(12, 15);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(380, 20);
            this.textBox_search.TabIndex = 6;
            this.textBox_search.TextChanged += new System.EventHandler(this.textBox_search_TextChanged);
            // 
            // flowLayoutPanel_Pagination
            // 
            this.flowLayoutPanel_Pagination.Location = new System.Drawing.Point(620, 441);
            this.flowLayoutPanel_Pagination.Name = "flowLayoutPanel_Pagination";
            this.flowLayoutPanel_Pagination.Size = new System.Drawing.Size(158, 31);
            this.flowLayoutPanel_Pagination.TabIndex = 5;
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_login.ForeColor = System.Drawing.Color.Gold;
            this.label_login.Location = new System.Drawing.Point(744, 14);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(0, 15);
            this.label_login.TabIndex = 10;
            // 
            // button_order
            // 
            this.button_order.Location = new System.Drawing.Point(12, 441);
            this.button_order.Name = "button_order";
            this.button_order.Size = new System.Drawing.Size(75, 23);
            this.button_order.TabIndex = 0;
            this.button_order.Text = "Корзина";
            this.button_order.UseVisualStyleBackColor = true;
            this.button_order.Click += new System.EventHandler(this.button_order_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(12, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "Введите для поиска";
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.ClientSize = new System.Drawing.Size(804, 485);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_order);
            this.Controls.Add(this.label_login);
            this.Controls.Add(this.flowLayoutPanel_Pagination);
            this.Controls.Add(this.flowLayoutPanel_Product);
            this.Controls.Add(this.comboBox_filtration);
            this.Controls.Add(this.comboBox_Sorting);
            this.Controls.Add(this.textBox_search);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Manager";
            this.Text = "Manager";
            this.Load += new System.EventHandler(this.Manager_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Product;
        private System.Windows.Forms.ComboBox comboBox_filtration;
        private System.Windows.Forms.ComboBox comboBox_Sorting;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Pagination;
        private System.Windows.Forms.Label label_login;
        private System.Windows.Forms.Button button_order;
        private System.Windows.Forms.Label label1;
    }
}