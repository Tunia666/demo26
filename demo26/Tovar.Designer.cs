namespace demo26
{
    partial class Tovar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tovar));
            this.pTop = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pTools = new System.Windows.Forms.Panel();
            this.cbSortQty = new System.Windows.Forms.ComboBox();
            this.ostatok = new System.Windows.Forms.Label();
            this.cbSupplier = new System.Windows.Forms.ComboBox();
            this.postavshick = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.poisk = new System.Windows.Forms.Label();
            this.flpProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pTop.SuspendLayout();
            this.pTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // pTop
            // 
            this.pTop.Controls.Add(this.lblUserName);
            this.pTop.Controls.Add(this.btnLogout);
            this.pTop.Controls.Add(this.lblUser);
            this.pTop.Controls.Add(this.lblTitle);
            this.pTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTop.Location = new System.Drawing.Point(0, 0);
            this.pTop.Name = "pTop";
            this.pTop.Size = new System.Drawing.Size(1380, 70);
            this.pTop.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Location = new System.Drawing.Point(1284, 41);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Выйти";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(1162, 9);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(108, 19);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Пользователь: ";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(343, 55);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Список товаров";
            // 
            // pTools
            // 
            this.pTools.Controls.Add(this.cbSortQty);
            this.pTools.Controls.Add(this.ostatok);
            this.pTools.Controls.Add(this.cbSupplier);
            this.pTools.Controls.Add(this.postavshick);
            this.pTools.Controls.Add(this.txtSearch);
            this.pTools.Controls.Add(this.poisk);
            this.pTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTools.Location = new System.Drawing.Point(0, 70);
            this.pTools.Name = "pTools";
            this.pTools.Size = new System.Drawing.Size(1380, 70);
            this.pTools.TabIndex = 1;
            // 
            // cbSortQty
            // 
            this.cbSortQty.FormattingEnabled = true;
            this.cbSortQty.Location = new System.Drawing.Point(862, 25);
            this.cbSortQty.Name = "cbSortQty";
            this.cbSortQty.Size = new System.Drawing.Size(121, 27);
            this.cbSortQty.TabIndex = 5;
            this.cbSortQty.Text = "Без сортировки/ По возр./По убыв.";
            // 
            // ostatok
            // 
            this.ostatok.AutoSize = true;
            this.ostatok.Location = new System.Drawing.Point(768, 28);
            this.ostatok.Name = "ostatok";
            this.ostatok.Size = new System.Drawing.Size(64, 19);
            this.ostatok.TabIndex = 4;
            this.ostatok.Text = "Остаток";
            // 
            // cbSupplier
            // 
            this.cbSupplier.FormattingEnabled = true;
            this.cbSupplier.Location = new System.Drawing.Point(554, 25);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(165, 27);
            this.cbSupplier.TabIndex = 3;
            // 
            // postavshick
            // 
            this.postavshick.AutoSize = true;
            this.postavshick.Location = new System.Drawing.Point(449, 28);
            this.postavshick.Name = "postavshick";
            this.postavshick.Size = new System.Drawing.Size(84, 19);
            this.postavshick.TabIndex = 2;
            this.postavshick.Text = "Поставщик";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(99, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(315, 26);
            this.txtSearch.TabIndex = 1;
            // 
            // poisk
            // 
            this.poisk.AutoSize = true;
            this.poisk.Location = new System.Drawing.Point(18, 23);
            this.poisk.Name = "poisk";
            this.poisk.Size = new System.Drawing.Size(51, 19);
            this.poisk.TabIndex = 0;
            this.poisk.Text = "Поиск";
            this.poisk.Click += new System.EventHandler(this.label1_Click);
            // 
            // flpProducts
            // 
            this.flpProducts.AutoScroll = true;
            this.flpProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProducts.Location = new System.Drawing.Point(0, 140);
            this.flpProducts.Name = "flpProducts";
            this.flpProducts.Size = new System.Drawing.Size(1380, 617);
            this.flpProducts.TabIndex = 2;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(1277, 7);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(0, 19);
            this.lblUserName.TabIndex = 3;
            // 
            // Tovar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1380, 757);
            this.Controls.Add(this.flpProducts);
            this.Controls.Add(this.pTools);
            this.Controls.Add(this.pTop);
            this.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Tovar";
            this.Text = "Список товаров";
            this.Load += new System.EventHandler(this.Tovar_Load);
            this.pTop.ResumeLayout(false);
            this.pTop.PerformLayout();
            this.pTools.ResumeLayout(false);
            this.pTools.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pTop;
        private System.Windows.Forms.Panel pTools;
        private System.Windows.Forms.FlowLayoutPanel flpProducts;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label poisk;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbSortQty;
        private System.Windows.Forms.Label ostatok;
        private System.Windows.Forms.ComboBox cbSupplier;
        private System.Windows.Forms.Label postavshick;
        private System.Windows.Forms.Label lblUserName;
    }
}