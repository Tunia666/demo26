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
    public partial class Tovar : Form
    {
        public Tovar()
        {
            InitializeComponent();
            this.Load += Tovar_Load;
        }
        static string conn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Demo26.2;Integrated Security=true";
        SqlConnection con = new SqlConnection(conn);
        private readonly ProductRepository _repo = new ProductRepository();
        private List<Product> _allProducts = new List<Product>();
        private void Tovar_Load(object sender, EventArgs e)
        {
            // ФИО в шапку
            lblUserName.Text = LoginClass.UserName;

            // права доступа
            ApplyRoleUi();

            // сортировка по остатку 
            cbSortQty.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSortQty.Items.Clear();
            cbSortQty.Items.Add("Без сортировки");
            cbSortQty.Items.Add("По возрастанию");
            cbSortQty.Items.Add("По убыванию");
            cbSortQty.SelectedIndex = 0;

            // сортировка по поставщику
            cbSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSupplier.Items.Clear();
            cbSupplier.Items.Add("Без сортировки");
            cbSupplier.Items.Add("Поставщик А-Я");
            cbSupplier.Items.Add("Поставщик Я-А");
            cbSupplier.SelectedIndex = 0;

            cbSortQty.SelectedIndexChanged += (s, ev) => ApplySearchAndSort();
            cbSupplier.SelectedIndexChanged += (s, ev) => ApplySearchAndSort();

            // обработчик поиска
            txtSearch.TextChanged += (s, ev) => ApplySearchAndSort();

            // Загрузка товаров
            ReloadProducts();
        }
        private void ReloadProducts()
        {
            _allProducts = _repo.GetAll();
            ApplySearchAndSort(); // покажет сразу (и с учетом текста в поиске, если он есть)
        }

        //метод фильтрации
        private void ApplySearchAndSort()
        {
            IEnumerable<Product> query = _allProducts;

            // ПОИСК
            string text = (txtSearch.Text ?? "").Trim();

            if (!string.IsNullOrWhiteSpace(text))
            {
                var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                query = query.Where(p => tokens.All(t => ContainsInAnyTextField(p, t)));
            }

            bool ordered = false;
            IOrderedEnumerable<Product> orderedQuery = null;

            // СОРТИРОВКА ПО ПОСТАВЩИКУ 
            string supplierSort = cbSupplier.SelectedItem?.ToString() ?? "Без сортировки";

            if (supplierSort.Contains("А-Я"))
            {
                orderedQuery = query.OrderBy(p => p.Supplier);
                ordered = true;
            }
            else if (supplierSort.Contains("Я-А"))
            {
                orderedQuery = query.OrderByDescending(p => p.Supplier);
                ordered = true;
            }

            // СОРТИРОВКА ПО ОСТАТКУ 
            string qtySort = cbSortQty.SelectedItem?.ToString() ?? "Без сортировки";

            if (qtySort.Contains("возрастан"))
            {
                orderedQuery = ordered
                    ? orderedQuery.ThenBy(p => p.StockQty)
                    : query.OrderBy(p => p.StockQty);
                ordered = true;
            }
            else if (qtySort.Contains("убыван"))
            {
                orderedQuery = ordered
                    ? orderedQuery.ThenByDescending(p => p.StockQty)
                    : query.OrderByDescending(p => p.StockQty);
                ordered = true;
            }

            ShowProducts((ordered ? orderedQuery : query).ToList());
        }

        private bool ContainsInAnyTextField(Product p, string token)
        {
            return Contains(p.Article, token)
                || Contains(p.Name, token)
                || Contains(p.Category, token)
                || Contains(p.Description, token)
                || Contains(p.Manufacturer, token)
                || Contains(p.Supplier, token)
                || Contains(p.Unit, token);
        }

        private bool Contains(string value, string token)
        {
            if (string.IsNullOrEmpty(value)) return false;
            return value.IndexOf(token, StringComparison.OrdinalIgnoreCase) >= 0;
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

            using (var con = new SqlConnection(conn))
            using (var cmd = new SqlCommand(@"
        SELECT DISTINCT [Поставщик]
        FROM [dbo].[Товар]
        WHERE [Поставщик] IS NOT NULL AND [Поставщик] <> ''
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
            Auth auth = new Auth();
            auth.Show();
            this.Hide();
        }
    }
}


