using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demo26
{
    public partial class ProductEditForm : Form
    {
        private readonly ProductRepository _repo = new ProductRepository();
        private readonly Product _editingProduct;
        private readonly bool _isEditMode;

        public ProductEditForm()
        {
            InitializeComponent();
            _isEditMode = false;
            Text = "Добавление товара";
        }

        public ProductEditForm(Product product)
        {
            InitializeComponent();

            _editingProduct = product;
            _isEditMode = true;
            Text = "Редактирование товара";

            LoadProductData();
        }

        private void LoadProductData()
        {
            if (_editingProduct == null) return;

            txtArticle.Text = _editingProduct.Article;
            txtName.Text = _editingProduct.Name;
            txtCategory.Text = _editingProduct.Category;
            txtDescription.Text = _editingProduct.Description;
            txtManufacturer.Text = _editingProduct.Manufacturer;
            txtSupplier.Text = _editingProduct.Supplier;
            numPrice.Value = Convert.ToDecimal(_editingProduct.Price);
            numDiscount.Value = Convert.ToDecimal(_editingProduct.DiscountPercent);
            numStockQty.Value = _editingProduct.StockQty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                var product = new Product
                {
                    Id = _isEditMode ? _editingProduct.Id : 0,
                    Article = txtArticle.Text.Trim(),
                    Name = txtName.Text.Trim(),
                    Category = txtCategory.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    Manufacturer = txtManufacturer.Text.Trim(),
                    Supplier = txtSupplier.Text.Trim(),
                    Unit = numStockQty.Text.Trim(),
                    Price = Convert.ToDecimal(numPrice.Value),
                    DiscountPercent = Convert.ToDecimal(numDiscount.Value),
                    StockQty = Convert.ToInt32(numStockQty.Value)
                };

                if (_isEditMode)
                    _repo.Update(product);
                else
                    _repo.Add(product);

                MessageBox.Show("Данные товара сохранены.",
                    "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении товара:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtArticle.Text))
            {
                MessageBox.Show("Введите артикул.");
                txtArticle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите наименование товара.");
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSupplier.Text))
            {
                MessageBox.Show("Введите поставщика.");
                txtSupplier.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProductEditForm_Load(object sender, EventArgs e)
        {

        }

        /*private void label1_Click(object sender, EventArgs e)
        {

        }*/
    }
}
