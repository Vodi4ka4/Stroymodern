namespace Stroymodern
{
    partial class Order
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order));
            this.flowLayoutPanel_Product = new System.Windows.Forms.FlowLayoutPanel();
            this.button_order = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_total = new System.Windows.Forms.Label();
            this.label_login = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanel_Product
            // 
            this.flowLayoutPanel_Product.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel_Product.Name = "flowLayoutPanel_Product";
            this.flowLayoutPanel_Product.Size = new System.Drawing.Size(755, 389);
            this.flowLayoutPanel_Product.TabIndex = 1;
            // 
            // button_order
            // 
            this.button_order.Location = new System.Drawing.Point(659, 407);
            this.button_order.Name = "button_order";
            this.button_order.Size = new System.Drawing.Size(108, 23);
            this.button_order.TabIndex = 2;
            this.button_order.Text = "Оформить заказ";
            this.button_order.UseVisualStyleBackColor = true;
            this.button_order.Click += new System.EventHandler(this.button_order_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(12, 407);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Итого";
            // 
            // label_total
            // 
            this.label_total.AutoSize = true;
            this.label_total.ForeColor = System.Drawing.Color.Gold;
            this.label_total.Location = new System.Drawing.Point(53, 407);
            this.label_total.Name = "label_total";
            this.label_total.Size = new System.Drawing.Size(35, 13);
            this.label_total.TabIndex = 1;
            this.label_total.Text = "label2";
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.ForeColor = System.Drawing.Color.Gold;
            this.label_login.Location = new System.Drawing.Point(780, 12);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(35, 13);
            this.label_login.TabIndex = 3;
            this.label_login.Text = "label2";
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.ClientSize = new System.Drawing.Size(847, 450);
            this.Controls.Add(this.label_login);
            this.Controls.Add(this.label_total);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_order);
            this.Controls.Add(this.flowLayoutPanel_Product);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Order";
            this.Text = "Заказ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Product;
        private System.Windows.Forms.Button button_order;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_total;
        private System.Windows.Forms.Label label_login;
    }
}