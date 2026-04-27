using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

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
        private ProductEditForm _openedEditForm;

        private bool IsAdmin => LoginClass.Role == LoginClass.UserRole.Admin;

        private void Tovar_Load(object sender, EventArgs e)
        {
            lblUserName.Text = LoginClass.UserName;

            ApplyRoleUi();

            cbSortQty.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSortQty.Items.Clear();
            cbSortQty.Items.Add("Без сортировки");
            cbSortQty.Items.Add("По возрастанию");
            cbSortQty.Items.Add("По убыванию");
            cbSortQty.SelectedIndex = 0;

            cbSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSupplier.Items.Clear();
            cbSupplier.Items.Add("Без сортировки");
            cbSupplier.Items.Add("Поставщик А-Я");
            cbSupplier.Items.Add("Поставщик Я-А");
            cbSupplier.SelectedIndex = 0;

            cbSortQty.SelectedIndexChanged += (s, ev) => ApplySearchAndSort();
            cbSupplier.SelectedIndexChanged += (s, ev) => ApplySearchAndSort();
            txtSearch.TextChanged += (s, ev) => ApplySearchAndSort();

            ReloadProducts();
        }

        private void ReloadProducts()
        {
            _allProducts = _repo.GetAll();
            ApplySearchAndSort();
        }

        private void ApplySearchAndSort()
        {
            IEnumerable<Product> query = _allProducts;

            string text = (txtSearch.Text ?? "").Trim();

            if (!string.IsNullOrWhiteSpace(text))
            {
                var tokens = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                query = query.Where(p => tokens.All(t => ContainsInAnyTextField(p, t)));
            }

            bool ordered = false;
            IOrderedEnumerable<Product> orderedQuery = null;

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
        private void OpenProductForm(Product product)
        {
            if (_openedEditForm != null && !_openedEditForm.IsDisposed)
            {
                _openedEditForm.Activate();
                MessageBox.Show("Уже открыто окно добавления или редактирования товара.",
                    "Окно уже открыто", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _openedEditForm = product == null
                ? new ProductEditForm()
                : new ProductEditForm(product);

            try
            {
                if (_openedEditForm.ShowDialog() == DialogResult.OK)
                {
                    ReloadProducts();
                }
            }
            finally
            {
                _openedEditForm.Dispose();
                _openedEditForm = null;
            }
        }
        private void ShowProducts(List<Product> items)
        {
            flpProducts.SuspendLayout();
            flpProducts.Controls.Clear();

            foreach (var p in items)
            {
                var card = new ProductCard();
                card.SetData(p);

                // редактирование по нажатию на карточку — только администратор
                if (IsAdmin)
                {
                    card.Cursor = Cursors.Hand;
                    card.ProductClicked += Card_ProductClicked;
                }

                flpProducts.Controls.Add(card);
            }

            flpProducts.ResumeLayout();
        }

        private void Card_ProductClicked(object sender, Product product)
        {
            if (!IsAdmin)
            {
                MessageBox.Show("Редактирование доступно только администратору.",
                    "Доступ запрещён", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenProductForm(product);
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

        private void ApplyRoleUi()
        {
            // поиск и сортировку можно оставить всем
            pTools.Visible = true;

            // кнопку добавления видит только администратор
            btnAddProduct.Visible = IsAdmin;
            btnAddProduct.Enabled = IsAdmin;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show("Добавление товара доступно только администратору.",
                    "Доступ запрещён", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenProductForm(null);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Hide();
        }
        private void btnOrders_Click(object sender, EventArgs e)
        {
            OrdersForm ordersForm = new OrdersForm();
            ordersForm.Show();
            this.Hide();
        }
    }
}