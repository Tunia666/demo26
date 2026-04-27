using System.IO;
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
        private string _imagePath = "";
        private Button btnDelete;
        public ProductEditForm()
        {
            InitializeComponent();
            CreateDeleteButton();
            _isEditMode = false;
            Text = "Добавление товара";
            
        }

        public ProductEditForm(Product product)
        {
            InitializeComponent();
            CreateDeleteButton();
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
            numPrice.Value = _editingProduct.Price < 0 ? 0 : _editingProduct.Price;
            numStockQty.Value = _editingProduct.StockQty < 0 ? 0 : _editingProduct.StockQty;
            numDiscount.Value = _editingProduct.DiscountPercent < 0 ? 0 : _editingProduct.DiscountPercent;

            if (!string.IsNullOrWhiteSpace(_editingProduct.ImagePath) && File.Exists(_editingProduct.ImagePath))
                pbPhoto.Image = Image.FromFile(_editingProduct.ImagePath);
            else
                pbPhoto.Image = Properties.Resources.picture;
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
                    Unit = string.IsNullOrWhiteSpace(_editingProduct?.Unit) ? "шт." : _editingProduct.Unit,
                    Price = numPrice.Value,
                    StockQty = (int)numStockQty.Value,
                    DiscountPercent = numDiscount.Value,
                    ImagePath = string.IsNullOrWhiteSpace(_imagePath) ? _editingProduct?.ImagePath : _imagePath
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
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите наименование товара.");
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Выберите категорию товара.");
                txtCategory.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtManufacturer.Text))
            {
                MessageBox.Show("Выберите производителя.");
                txtManufacturer.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSupplier.Text))
            {
                MessageBox.Show("Введите поставщика.");
                txtSupplier.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtArticle.Text))
            {
                MessageBox.Show("Введите артикул товара.");
                txtArticle.Focus();
                return false;
            }

            if (numPrice.Value < 0)
            {
                MessageBox.Show("Цена не может быть отрицательной.");
                numPrice.Focus();
                return false;
            }

            if (numStockQty.Value < 0)
            {
                MessageBox.Show("Количество на складе не может быть отрицательным.");
                numStockQty.Focus();
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

        private void btnLoadPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _imagePath = ofd.FileName;
                    pbPhoto.Image = Image.FromFile(_imagePath);
                }
            }
        }
        private void CreateDeleteButton()
        {
            btnDelete = new Button();
            btnDelete.Text = "Удалить";
            btnDelete.BackColor = Color.LightCoral;
            btnDelete.Location = new Point(602, 538);
            btnDelete.Size = new Size(161, 45);
            btnDelete.Visible = _isEditMode;
            btnDelete.Click += btnDelete_Click;

            Controls.Add(btnDelete);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_isEditMode || _editingProduct == null)
                return;

            var result = MessageBox.Show(
                "Вы действительно хотите удалить этот товар?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                _repo.Delete(_editingProduct.Id);

                MessageBox.Show("Товар удалён.",
                    "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message,
                    "Удаление невозможно", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении товара:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*private void label1_Click(object sender, EventArgs e)
        {

        }*/
    }
}
