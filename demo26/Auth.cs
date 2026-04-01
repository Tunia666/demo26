using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;


namespace demo26
{
    public partial class Auth : Form
    {
        Tovar tovar = new Tovar();
        
        public Auth()
        {
            InitializeComponent();
        }
        static string connectString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Demo26.2;Integrated Security=true";
        SqlConnection myConnection = new SqlConnection(connectString);
        private void Auth_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = textBoxPassword.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();

                    string sql = @"
                        SELECT TOP 1
                            [Роль сотрудника] AS RoleName,
                            LTRIM(RTRIM(ISNULL([Фамилия],''))) + ' ' +
                            LTRIM(RTRIM(ISNULL([Имя],''))) + ' ' +
                            LTRIM(RTRIM(ISNULL([Отчество],''))) AS FIO
                        FROM [Пользователи]
                        WHERE [Логин] = @login AND [Пароль] = @password";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (var r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                string roleName = Convert.ToString(r["RoleName"]);
                                string fio = Convert.ToString(r["FIO"]);
                                LoginClass.UserName = string.IsNullOrWhiteSpace(fio) ? login : fio;
                                LoginClass.Role = ParseRole(roleName);
                                MessageBox.Show("Успешно вошли", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                var tovar = new Tovar();
                                tovar.Show();

                                this.Hide(); // или this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения/запроса:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private LoginClass.UserRole ParseRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return LoginClass.UserRole.Guest;

            roleName = roleName.Trim().ToLower();
            if (roleName.Contains("админ")) return LoginClass.UserRole.Admin;
            if (roleName.Contains("менедж")) return LoginClass.UserRole.Manager;
            if (roleName.Contains("клиент")) return LoginClass.UserRole.Client;

            return LoginClass.UserRole.Guest;
        }


        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {


        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tovar.Show();
        }

    }
}

