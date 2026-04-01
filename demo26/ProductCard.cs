using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace demo26
{
    public partial class ProductCard : UserControl
    {
        public int ProductId { get; private set; }

        // Храним весь объект товара
        private Product _product;

        // Событие для формы списка
        public event EventHandler<Product> ProductClicked;

        public ProductCard()
        {
            InitializeComponent();

            // Клик по самой карточке
            this.Click += Card_Click;

            // Клик по всем вложенным элементам
            SubscribeClicks(this);
        }

        public void SetData(Product p)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));

            _product = p;
            ProductId = p.Id;

            // шапка
            lblHeader.Text = $"{p.Category} | {p.Name}";

            // поля
            lblDescValue.Text = p.Description;
            lblManufacturerValue.Text = p.Manufacturer;
            lblSupplierValue.Text = p.Supplier;
            lblUnitValue.Text = p.Unit;
            lblQtyValue.Text = p.StockQty.ToString();
            lblDiscountValue.Text = $"{p.DiscountPercent:0.#}%";

            // фото + заглушка
            pbPhoto.Image = LoadPhotoOrStub(p.ImagePath);

            // цена со скидкой
            if (p.DiscountPercent > 0)
            {
                lblOldPrice.Visible = true;
                lblOldPrice.Text = $"{p.Price:0.00} ₽";
                lblOldPrice.ForeColor = Color.Red;
                lblOldPrice.Font = new Font(lblOldPrice.Font, FontStyle.Strikeout);

                var newPrice = p.Price * (1 - p.DiscountPercent / 100m);
                lblNewPrice.Visible = true;
                lblNewPrice.Text = $"{newPrice:0.00} ₽";
                lblNewPrice.ForeColor = Color.Black;
            }
            else
            {
                lblOldPrice.Visible = false;
                lblNewPrice.Visible = true;
                lblNewPrice.Text = $"{p.Price:0.00} ₽";
                lblNewPrice.ForeColor = Color.Black;
            }

            // цвет карточки
            if (p.StockQty <= 0)
                BackColor = Color.LightSkyBlue;
            else if (p.DiscountPercent > 15)
                BackColor = ColorTranslator.FromHtml("#2E8B57");
            else
                BackColor = Color.White;

            // чтобы было визуально понятно, что элемент можно нажимать
            this.Cursor = Cursors.Hand;
        }

        private void Card_Click(object sender, EventArgs e)
        {
            if (_product != null)
                ProductClicked?.Invoke(this, _product);
        }

        private void SubscribeClicks(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.Click += Card_Click;

                if (ctrl.HasChildren)
                    SubscribeClicks(ctrl);
            }
        }

        private Image LoadPhotoOrStub(string path)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(path))
                {
                    string baseDir = AppDomain.CurrentDomain.BaseDirectory;

                    string full = Path.IsPathRooted(path)
                        ? path
                        : Path.Combine(baseDir, path);

                    if (!File.Exists(full))
                        full = Path.Combine(baseDir, "Resources", "images", path);

                    if (!File.Exists(full))
                        full = Path.Combine(baseDir, "images", path);

                    if (File.Exists(full))
                    {
                        using (var fs = new FileStream(full, FileMode.Open, FileAccess.Read))
                        using (var img = Image.FromStream(fs))
                            return new Bitmap(img);
                    }
                }
            }
            catch { }

            return Properties.Resources.picture;
        }

        private void tip_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}