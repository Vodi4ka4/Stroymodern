namespace Stroymodern
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.dataGridView_table = new System.Windows.Forms.DataGridView();
            this.comboBox_table = new System.Windows.Forms.ComboBox();
            this.button_spam = new System.Windows.Forms.Button();
            this.label_login = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_table)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_table
            // 
            this.dataGridView_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_table.Location = new System.Drawing.Point(12, 41);
            this.dataGridView_table.Name = "dataGridView_table";
            this.dataGridView_table.Size = new System.Drawing.Size(776, 397);
            this.dataGridView_table.TabIndex = 0;
            // 
            // comboBox_table
            // 
            this.comboBox_table.FormattingEnabled = true;
            this.comboBox_table.Items.AddRange(new object[] {
            "Заказы",
            "Товары",
            "Роли",
            "Пользователи",
            "Типы товаров"});
            this.comboBox_table.Location = new System.Drawing.Point(12, 14);
            this.comboBox_table.Name = "comboBox_table";
            this.comboBox_table.Size = new System.Drawing.Size(121, 21);
            this.comboBox_table.TabIndex = 1;
            this.comboBox_table.SelectedIndexChanged += new System.EventHandler(this.comboBox_table_SelectedIndexChanged);
            // 
            // button_spam
            // 
            this.button_spam.Location = new System.Drawing.Point(693, 12);
            this.button_spam.Name = "button_spam";
            this.button_spam.Size = new System.Drawing.Size(95, 23);
            this.button_spam.TabIndex = 2;
            this.button_spam.Text = "Спам рассылка";
            this.button_spam.UseVisualStyleBackColor = true;
            this.button_spam.Click += new System.EventHandler(this.button_spam_Click);
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.ForeColor = System.Drawing.Color.Gold;
            this.label_login.Location = new System.Drawing.Point(599, 17);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(35, 13);
            this.label_login.TabIndex = 3;
            this.label_login.Text = "label1";
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_login);
            this.Controls.Add(this.button_spam);
            this.Controls.Add(this.comboBox_table);
            this.Controls.Add(this.dataGridView_table);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Admin";
            this.Text = "Admin";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_table;
        private System.Windows.Forms.ComboBox comboBox_table;
        private System.Windows.Forms.Button button_spam;
        private System.Windows.Forms.Label label_login;
    }
}