namespace demo26
{
    partial class Auth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Auth));
            this.buttonAuth = new System.Windows.Forms.Button();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelLog = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.PictureBox();
            this.bindingSourceBD = new System.Windows.Forms.BindingSource(this.components);
            this._Demo26_2DataSet = new demo26._Demo26_2DataSet();
            this.button1 = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._Demo26_2DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAuth
            // 
            this.buttonAuth.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.buttonAuth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonAuth.Location = new System.Drawing.Point(298, 306);
            this.buttonAuth.Name = "buttonAuth";
            this.buttonAuth.Size = new System.Drawing.Size(110, 38);
            this.buttonAuth.TabIndex = 0;
            this.buttonAuth.Text = "Войти";
            this.buttonAuth.UseVisualStyleBackColor = false;
            this.buttonAuth.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.textBoxLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLogin.Location = new System.Drawing.Point(298, 193);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(223, 26);
            this.textBoxLogin.TabIndex = 1;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassword.Location = new System.Drawing.Point(298, 245);
            this.textBoxPassword.MaxLength = 255;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(223, 26);
            this.textBoxPassword.TabIndex = 2;
            // 
            // labelLog
            // 
            this.labelLog.AutoSize = true;
            this.labelLog.Location = new System.Drawing.Point(175, 196);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(52, 19);
            this.labelLog.TabIndex = 3;
            this.labelLog.Text = "Логин";
            this.labelLog.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(175, 248);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(58, 19);
            this.labelPass.TabIndex = 4;
            this.labelPass.Text = "Пароль";
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(39, 24);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(138, 120);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 5;
            this.logo.TabStop = false;
            // 
            // bindingSourceBD
            // 
            this.bindingSourceBD.DataSource = this._Demo26_2DataSet;
            this.bindingSourceBD.Position = 0;
            this.bindingSourceBD.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // _Demo26_2DataSet
            // 
            this._Demo26_2DataSet.DataSetName = "_Demo26_2DataSet";
            this._Demo26_2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.button1.Location = new System.Drawing.Point(414, 306);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "Гость";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(257, 98);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(323, 55);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "ООО «Обувь» ";
            this.labelName.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 428);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.labelLog);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.buttonAuth);
            this.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Auth";
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.Auth_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._Demo26_2DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAuth;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.BindingSource bindingSourceBD;
        private _Demo26_2DataSet _Demo26_2DataSet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelName;
    }
}

