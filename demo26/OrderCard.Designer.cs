namespace demo26
{
    partial class OrderCard
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lable1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lArticle = new System.Windows.Forms.Label();
            this.lStatus = new System.Windows.Forms.Label();
            this.lPickupPoint = new System.Windows.Forms.Label();
            this.lOrderDate = new System.Windows.Forms.Label();
            this.lDeliveryDate = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lOrderDate);
            this.panel1.Controls.Add(this.lPickupPoint);
            this.panel1.Controls.Add(this.lStatus);
            this.panel1.Controls.Add(this.lArticle);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lable1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(728, 250);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.lDeliveryDate);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(727, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(249, 250);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Location = new System.Drawing.Point(61, 26);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(90, 25);
            this.lable1.TabIndex = 0;
            this.lable1.Text = "Артикул";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Статус";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Адрес пункта выдачи";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Дата заказа";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Дата поставки";
            // 
            // lArticle
            // 
            this.lArticle.AutoSize = true;
            this.lArticle.Location = new System.Drawing.Point(314, 26);
            this.lArticle.Name = "lArticle";
            this.lArticle.Size = new System.Drawing.Size(90, 25);
            this.lArticle.TabIndex = 4;
            this.lArticle.Text = "Артикул";
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Location = new System.Drawing.Point(314, 84);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(78, 25);
            this.lStatus.TabIndex = 5;
            this.lStatus.Text = "Статус";
            // 
            // lPickupPoint
            // 
            this.lPickupPoint.AutoSize = true;
            this.lPickupPoint.Location = new System.Drawing.Point(314, 140);
            this.lPickupPoint.Name = "lPickupPoint";
            this.lPickupPoint.Size = new System.Drawing.Size(210, 25);
            this.lPickupPoint.TabIndex = 6;
            this.lPickupPoint.Text = "Адрес пункта выдачи";
            // 
            // lOrderDate
            // 
            this.lOrderDate.AutoSize = true;
            this.lOrderDate.Location = new System.Drawing.Point(314, 186);
            this.lOrderDate.Name = "lOrderDate";
            this.lOrderDate.Size = new System.Drawing.Size(128, 25);
            this.lOrderDate.TabIndex = 7;
            this.lOrderDate.Text = "Дата заказа";
            // 
            // lDeliveryDate
            // 
            this.lDeliveryDate.AutoSize = true;
            this.lDeliveryDate.Location = new System.Drawing.Point(3, 25);
            this.lDeliveryDate.Name = "lDeliveryDate";
            this.lDeliveryDate.Size = new System.Drawing.Size(151, 25);
            this.lDeliveryDate.TabIndex = 6;
            this.lDeliveryDate.Text = "Дата поставки";
            // 
            // OrderCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "OrderCard";
            this.Size = new System.Drawing.Size(976, 250);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblArticle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblPickupPoint;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDeliveryDate;
    }
}
