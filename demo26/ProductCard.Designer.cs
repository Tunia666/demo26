namespace demo26
{
    partial class ProductCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductCard));
            this.pOuter = new System.Windows.Forms.Panel();
            this.pCenter = new System.Windows.Forms.Panel();
            this.tip = new System.Windows.Forms.TableLayoutPanel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblDescValue = new System.Windows.Forms.Label();
            this.lblManufacturerValue = new System.Windows.Forms.Label();
            this.lblSupplierValue = new System.Windows.Forms.Label();
            this.flpPrice = new System.Windows.Forms.FlowLayoutPanel();
            this.lblOldPrice = new System.Windows.Forms.Label();
            this.lblNewPrice = new System.Windows.Forms.Label();
            this.lblUnitValue = new System.Windows.Forms.Label();
            this.lblQtyValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pRight = new System.Windows.Forms.Panel();
            this.lblDiscountValue = new System.Windows.Forms.Label();
            this.lblDiscountTitle = new System.Windows.Forms.Label();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.pOuter.SuspendLayout();
            this.pCenter.SuspendLayout();
            this.tip.SuspendLayout();
            this.flpPrice.SuspendLayout();
            this.pRight.SuspendLayout();
            this.pLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pOuter
            // 
            this.pOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pOuter.Controls.Add(this.pCenter);
            this.pOuter.Controls.Add(this.pRight);
            this.pOuter.Controls.Add(this.pLeft);
            this.pOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pOuter.Location = new System.Drawing.Point(0, 0);
            this.pOuter.Name = "pOuter";
            this.pOuter.Size = new System.Drawing.Size(617, 201);
            this.pOuter.TabIndex = 0;
            // 
            // pCenter
            // 
            this.pCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCenter.Controls.Add(this.tip);
            this.pCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pCenter.Location = new System.Drawing.Point(140, 0);
            this.pCenter.Name = "pCenter";
            this.pCenter.Size = new System.Drawing.Size(325, 199);
            this.pCenter.TabIndex = 2;
            // 
            // tip
            // 
            this.tip.ColumnCount = 2;
            this.tip.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tip.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tip.Controls.Add(this.lblHeader, 0, 0);
            this.tip.Controls.Add(this.lblDescValue, 1, 1);
            this.tip.Controls.Add(this.lblManufacturerValue, 1, 2);
            this.tip.Controls.Add(this.lblSupplierValue, 1, 3);
            this.tip.Controls.Add(this.flpPrice, 1, 4);
            this.tip.Controls.Add(this.lblUnitValue, 1, 5);
            this.tip.Controls.Add(this.lblQtyValue, 1, 6);
            this.tip.Controls.Add(this.label1, 0, 1);
            this.tip.Controls.Add(this.label2, 0, 2);
            this.tip.Controls.Add(this.label3, 0, 3);
            this.tip.Controls.Add(this.label4, 0, 4);
            this.tip.Controls.Add(this.label5, 0, 5);
            this.tip.Controls.Add(this.label6, 0, 6);
            this.tip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tip.Location = new System.Drawing.Point(0, 0);
            this.tip.Name = "tip";
            this.tip.RowCount = 7;
            this.tip.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tip.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tip.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tip.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tip.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tip.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tip.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tip.Size = new System.Drawing.Size(323, 197);
            this.tip.TabIndex = 0;
            this.tip.Paint += new System.Windows.Forms.PaintEventHandler(this.tip_Paint);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHeader.Location = new System.Drawing.Point(3, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(117, 38);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Категория | Наименование";
            // 
            // lblDescValue
            // 
            this.lblDescValue.AutoSize = true;
            this.lblDescValue.Location = new System.Drawing.Point(164, 48);
            this.lblDescValue.Name = "lblDescValue";
            this.lblDescValue.Size = new System.Drawing.Size(0, 20);
            this.lblDescValue.TabIndex = 1;
            // 
            // lblManufacturerValue
            // 
            this.lblManufacturerValue.AutoSize = true;
            this.lblManufacturerValue.Location = new System.Drawing.Point(164, 96);
            this.lblManufacturerValue.Name = "lblManufacturerValue";
            this.lblManufacturerValue.Size = new System.Drawing.Size(0, 20);
            this.lblManufacturerValue.TabIndex = 2;
            // 
            // lblSupplierValue
            // 
            this.lblSupplierValue.AutoSize = true;
            this.lblSupplierValue.Location = new System.Drawing.Point(164, 116);
            this.lblSupplierValue.Name = "lblSupplierValue";
            this.lblSupplierValue.Size = new System.Drawing.Size(0, 20);
            this.lblSupplierValue.TabIndex = 3;
            // 
            // flpPrice
            // 
            this.flpPrice.Controls.Add(this.lblOldPrice);
            this.flpPrice.Controls.Add(this.lblNewPrice);
            this.flpPrice.Location = new System.Drawing.Point(164, 139);
            this.flpPrice.Name = "flpPrice";
            this.flpPrice.Size = new System.Drawing.Size(107, 14);
            this.flpPrice.TabIndex = 4;
            // 
            // lblOldPrice
            // 
            this.lblOldPrice.AutoSize = true;
            this.lblOldPrice.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblOldPrice.ForeColor = System.Drawing.Color.Red;
            this.lblOldPrice.Location = new System.Drawing.Point(3, 0);
            this.lblOldPrice.Name = "lblOldPrice";
            this.lblOldPrice.Size = new System.Drawing.Size(0, 19);
            this.lblOldPrice.TabIndex = 0;
            // 
            // lblNewPrice
            // 
            this.lblNewPrice.AutoSize = true;
            this.lblNewPrice.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNewPrice.Location = new System.Drawing.Point(9, 0);
            this.lblNewPrice.Name = "lblNewPrice";
            this.lblNewPrice.Size = new System.Drawing.Size(0, 19);
            this.lblNewPrice.TabIndex = 1;
            // 
            // lblUnitValue
            // 
            this.lblUnitValue.AutoSize = true;
            this.lblUnitValue.Location = new System.Drawing.Point(164, 156);
            this.lblUnitValue.Name = "lblUnitValue";
            this.lblUnitValue.Size = new System.Drawing.Size(0, 20);
            this.lblUnitValue.TabIndex = 5;
            // 
            // lblQtyValue
            // 
            this.lblQtyValue.AutoSize = true;
            this.lblQtyValue.Location = new System.Drawing.Point(164, 176);
            this.lblQtyValue.Name = "lblQtyValue";
            this.lblQtyValue.Size = new System.Drawing.Size(0, 20);
            this.lblQtyValue.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Описание";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Производитель";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Поставщик";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Цена";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Единица измерения";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Количество";
            // 
            // pRight
            // 
            this.pRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRight.Controls.Add(this.lblDiscountValue);
            this.pRight.Controls.Add(this.lblDiscountTitle);
            this.pRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pRight.Location = new System.Drawing.Point(465, 0);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(150, 199);
            this.pRight.TabIndex = 1;
            // 
            // lblDiscountValue
            // 
            this.lblDiscountValue.AutoSize = true;
            this.lblDiscountValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiscountValue.Location = new System.Drawing.Point(0, 0);
            this.lblDiscountValue.Name = "lblDiscountValue";
            this.lblDiscountValue.Size = new System.Drawing.Size(51, 20);
            this.lblDiscountValue.TabIndex = 1;
            this.lblDiscountValue.Text = "label1";
            this.lblDiscountValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDiscountTitle
            // 
            this.lblDiscountTitle.AutoSize = true;
            this.lblDiscountTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiscountTitle.Location = new System.Drawing.Point(0, 0);
            this.lblDiscountTitle.Name = "lblDiscountTitle";
            this.lblDiscountTitle.Size = new System.Drawing.Size(172, 20);
            this.lblDiscountTitle.TabIndex = 0;
            this.lblDiscountTitle.Text = "Действующая скидка";
            this.lblDiscountTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pLeft
            // 
            this.pLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLeft.Controls.Add(this.pbPhoto);
            this.pLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(140, 199);
            this.pLeft.TabIndex = 0;
            // 
            // pbPhoto
            // 
            this.pbPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPhoto.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbPhoto.ErrorImage")));
            this.pbPhoto.Location = new System.Drawing.Point(0, 0);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(138, 197);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPhoto.TabIndex = 0;
            this.pbPhoto.TabStop = false;
            // 
            // ProductCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pOuter);
            this.Name = "ProductCard";
            this.Size = new System.Drawing.Size(617, 201);
            this.pOuter.ResumeLayout(false);
            this.pCenter.ResumeLayout(false);
            this.tip.ResumeLayout(false);
            this.tip.PerformLayout();
            this.flpPrice.ResumeLayout(false);
            this.flpPrice.PerformLayout();
            this.pRight.ResumeLayout(false);
            this.pRight.PerformLayout();
            this.pLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pOuter;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Label lblDiscountValue;
        private System.Windows.Forms.Label lblDiscountTitle;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.Panel pCenter;
        private System.Windows.Forms.TableLayoutPanel tip;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblDescValue;
        private System.Windows.Forms.Label lblManufacturerValue;
        private System.Windows.Forms.Label lblSupplierValue;
        private System.Windows.Forms.FlowLayoutPanel flpPrice;
        private System.Windows.Forms.Label lblOldPrice;
        private System.Windows.Forms.Label lblNewPrice;
        private System.Windows.Forms.Label lblUnitValue;
        private System.Windows.Forms.Label lblQtyValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
