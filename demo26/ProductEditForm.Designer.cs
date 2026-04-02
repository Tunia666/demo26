namespace demo26
{
    partial class ProductEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductEditForm));
            this.Article = new System.Windows.Forms.Label();
            this.txtArticle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numStockQty = new System.Windows.Forms.NumericUpDown();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.numDiscount = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.btnLoadPhoto = new System.Windows.Forms.Button();
            this.txtCategory = new System.Windows.Forms.ComboBox();
            this.txtManufacturer = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numStockQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // Article
            // 
            this.Article.AutoSize = true;
            this.Article.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Article.Location = new System.Drawing.Point(33, 26);
            this.Article.Name = "Article";
            this.Article.Size = new System.Drawing.Size(141, 39);
            this.Article.TabIndex = 0;
            this.Article.Text = "Артикул";
            // 
            // txtArticle
            // 
            this.txtArticle.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.txtArticle.Location = new System.Drawing.Point(282, 33);
            this.txtArticle.Name = "txtArticle";
            this.txtArticle.Size = new System.Drawing.Size(246, 29);
            this.txtArticle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(33, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Название";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.txtName.Location = new System.Drawing.Point(282, 82);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(246, 29);
            this.txtName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(33, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 39);
            this.label2.TabIndex = 4;
            this.label2.Text = "Категория";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(33, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 39);
            this.label3.TabIndex = 6;
            this.label3.Text = "Описание";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.txtDescription.Location = new System.Drawing.Point(282, 193);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(246, 29);
            this.txtDescription.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(33, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 39);
            this.label4.TabIndex = 8;
            this.label4.Text = "Производитель";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(33, 305);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 39);
            this.label5.TabIndex = 10;
            this.label5.Text = "Поставщик";
            // 
            // txtSupplier
            // 
            this.txtSupplier.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.txtSupplier.Location = new System.Drawing.Point(282, 305);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(246, 29);
            this.txtSupplier.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(33, 368);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 39);
            this.label6.TabIndex = 12;
            this.label6.Text = "Количество";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(33, 431);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 39);
            this.label7.TabIndex = 14;
            this.label7.Text = "Цена";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(33, 495);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 39);
            this.label8.TabIndex = 16;
            this.label8.Text = "Скидка";
            // 
            // numStockQty
            // 
            this.numStockQty.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.numStockQty.Location = new System.Drawing.Point(282, 368);
            this.numStockQty.Name = "numStockQty";
            this.numStockQty.Size = new System.Drawing.Size(246, 29);
            this.numStockQty.TabIndex = 18;
            // 
            // numPrice
            // 
            this.numPrice.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(282, 431);
            this.numPrice.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(246, 29);
            this.numPrice.TabIndex = 19;
            // 
            // numDiscount
            // 
            this.numDiscount.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.numDiscount.Location = new System.Drawing.Point(282, 495);
            this.numDiscount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numDiscount.Name = "numDiscount";
            this.numDiscount.Size = new System.Drawing.Size(246, 29);
            this.numDiscount.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 431);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 25);
            this.label9.TabIndex = 21;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnSave.Location = new System.Drawing.Point(602, 475);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(161, 57);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pbPhoto
            // 
            this.pbPhoto.InitialImage = global::demo26.Properties.Resources.picture;
            this.pbPhoto.Location = new System.Drawing.Point(588, 34);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(174, 188);
            this.pbPhoto.TabIndex = 23;
            this.pbPhoto.TabStop = false;
            // 
            // btnLoadPhoto
            // 
            this.btnLoadPhoto.Location = new System.Drawing.Point(602, 368);
            this.btnLoadPhoto.Name = "btnLoadPhoto";
            this.btnLoadPhoto.Size = new System.Drawing.Size(160, 80);
            this.btnLoadPhoto.TabIndex = 24;
            this.btnLoadPhoto.Text = "Добавить изображение";
            this.btnLoadPhoto.UseVisualStyleBackColor = true;
            this.btnLoadPhoto.Click += new System.EventHandler(this.btnLoadPhoto_Click);
            // 
            // txtCategory
            // 
            this.txtCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCategory.FormattingEnabled = true;
            this.txtCategory.Location = new System.Drawing.Point(282, 133);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(244, 32);
            this.txtCategory.TabIndex = 25;
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtManufacturer.FormattingEnabled = true;
            this.txtManufacturer.Location = new System.Drawing.Point(282, 252);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(247, 32);
            this.txtManufacturer.TabIndex = 26;
            // 
            // ProductEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 571);
            this.Controls.Add(this.txtManufacturer);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.btnLoadPhoto);
            this.Controls.Add(this.pbPhoto);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numDiscount);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.numStockQty);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtArticle);
            this.Controls.Add(this.Article);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProductEditForm";
            this.Load += new System.EventHandler(this.ProductEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numStockQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Article;
        private System.Windows.Forms.TextBox txtArticle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numStockQty;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.NumericUpDown numDiscount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.Button btnLoadPhoto;
        private System.Windows.Forms.ComboBox txtCategory;
        private System.Windows.Forms.ComboBox txtManufacturer;
    }
}