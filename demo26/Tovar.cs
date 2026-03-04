using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using demo26;

namespace demo26
{
    public partial class Tovar: Form
    {
        public Tovar()
        {
            InitializeComponent();
            this.Load += Tovar_Load;
        }
        static string conn = @"Data Source=(localdb)\test;Initial Catalog=Demo26.2;Integrated Security=true";
        SqlConnection con = new SqlConnection(conn);
        private readonly ProductRepository _repo = new ProductRepository();
        private void Tovar_Load(object sender, EventArgs e)
        {
            // ФИО в шапку
            lblUserName.Text = LoginClass.UserName;

            // права доступа
            ApplyRoleUi();

            // Загрузка товаров
            ReloadProducts();
        
        }
        private void ReloadProducts()
        {
            var items = _repo.GetAll();
            ShowProducts(items); // добавляет ProductCard в flpProducts
        }
        public List<Product> GetAll()
        {
            var list = new List<Product>();
           
            //using (var con = new SqlConnection(DbConfig.ConnectionString))
            using (var cmd = new SqlCommand(@"
        SELECT
            [id товара] AS Id,
            [Артикул] AS Article,
            [Наименование товара] AS Name,
            [Категория товара] AS Category,
            [Описание товара] AS Description,
            [Производитель] AS Manufacturer,
            [Поставщик] AS Supplier,
            CAST([Цена] AS decimal(18,2)) AS Price,
            [Единица измерения] AS Unit,
            [Кол-во на складе] AS StockQty,
            CAST(ISNULL([Действующая скидка],0) AS decimal(18,2)) AS DiscountPercent,
            [Фото] AS ImagePath
        FROM [dbo].[Товар]
    ", con))
            {
                con.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Product
                        {
                            Id = r.GetInt32(0),
                            Article = r.GetString(1),
                            Name = r.GetString(2),
                            Unit = r.GetString(8),
                            Supplier = r.GetString(6),
                            Manufacturer = r.GetString(5),
                            Category = r.GetString(3),
                            StockQty = r.GetInt32(9),
                            Price = r.GetDecimal(7),
                            DiscountPercent = r.GetDecimal(10),
                            Description = r.IsDBNull(4) ? "" : r.GetString(4),
                            ImagePath = r["ImagePath"] == DBNull.Value ? "" : Convert.ToString(r["ImagePath"])
                            //ImagePath = r.IsDBNull(11) ? "" : r.GetString(11),
                            //ImageBytes = r.IsDBNull(11) ? null : (byte[])r.GetValue(11),
                        });
                    }
                }
            }

            return list;
        }

        private void ShowProducts(List<Product> items)
        {
            flpProducts.SuspendLayout();
            flpProducts.Controls.Clear();

            foreach (var p in items)
            {
                var card = new ProductCard();
                card.SetData(p);     
                flpProducts.Controls.Add(card);
            }

            flpProducts.ResumeLayout();
        }
        public List<string> GetSuppliers()
        {
            var res = new List<string> { "Все поставщики" };

            using (var cmd = new SqlCommand(@"
                SELECT DISTINCT [Поставщик]
                FROM [dbo].[Товар]
                ORDER BY [Поставщик]
            ", con))
            {
                con.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                        res.Add(r.GetString(0));
                }
            }

            return res;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void ApplyRoleUi()
        {
            bool allowed = LoginClass.Role == LoginClass.UserRole.Admin
                           || LoginClass.Role == LoginClass.UserRole.Manager;

           
            pTools.Visible = allowed;   // панель поиска/поставщик/остаток

            // если нужно ещё что-то закрывать 
            // txtSearch.Visible = allowed;
            // cbSupplier.Visible = allowed;
            // cbSortQty.Visible = allowed;

            // если место оставить, но не давать нажать:
            // pTools.Enabled = allowed;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }
    }
}

