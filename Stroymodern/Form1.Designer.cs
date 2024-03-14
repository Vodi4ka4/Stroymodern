namespace Stroymodern
{
    partial class Form_Entry
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Entry));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_capch = new System.Windows.Forms.Label();
            this.textBox_login = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_capch = new System.Windows.Forms.TextBox();
            this.button_enter = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_timer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SaddleBrown;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(29, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Авторизация";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(21, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Логин";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(21, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Пароль";
            // 
            // label_capch
            // 
            this.label_capch.AutoSize = true;
            this.label_capch.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_capch.ForeColor = System.Drawing.Color.Gold;
            this.label_capch.Location = new System.Drawing.Point(29, 142);
            this.label_capch.Name = "label_capch";
            this.label_capch.Size = new System.Drawing.Size(0, 21);
            this.label_capch.TabIndex = 3;
            this.label_capch.Visible = false;
            // 
            // textBox_login
            // 
            this.textBox_login.Location = new System.Drawing.Point(24, 52);
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.Size = new System.Drawing.Size(129, 20);
            this.textBox_login.TabIndex = 4;
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(24, 92);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(129, 20);
            this.textBox_password.TabIndex = 5;
            // 
            // textBox_capch
            // 
            this.textBox_capch.Location = new System.Drawing.Point(24, 166);
            this.textBox_capch.Name = "textBox_capch";
            this.textBox_capch.Size = new System.Drawing.Size(129, 20);
            this.textBox_capch.TabIndex = 6;
            this.textBox_capch.Visible = false;
            // 
            // button_enter
            // 
            this.button_enter.ForeColor = System.Drawing.Color.Black;
            this.button_enter.Location = new System.Drawing.Point(42, 192);
            this.button_enter.Name = "button_enter";
            this.button_enter.Size = new System.Drawing.Size(91, 29);
            this.button_enter.TabIndex = 7;
            this.button_enter.Text = "Войти";
            this.button_enter.UseVisualStyleBackColor = true;
            this.button_enter.Click += new System.EventHandler(this.button_enter_Click);
            // 
            // label_timer
            // 
            this.label_timer.AutoSize = true;
            this.label_timer.ForeColor = System.Drawing.Color.Gold;
            this.label_timer.Location = new System.Drawing.Point(21, 115);
            this.label_timer.Name = "label_timer";
            this.label_timer.Size = new System.Drawing.Size(112, 14);
            this.label_timer.TabIndex = 9;
            this.label_timer.Text = "Осталось времени: 30";
            this.label_timer.Visible = false;
            // 
            // Form_Entry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.ClientSize = new System.Drawing.Size(175, 249);
            this.Controls.Add(this.label_timer);
            this.Controls.Add(this.button_enter);
            this.Controls.Add(this.textBox_capch);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_login);
            this.Controls.Add(this.label_capch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Entry";
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_capch;
        private System.Windows.Forms.TextBox textBox_login;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_capch;
        private System.Windows.Forms.Button button_enter;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_timer;
    }
}

