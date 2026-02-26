using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using demo26;   

namespace demo26 
{
    public partial class ProductCard : UserControl
    {
        public int ProductId { get; private set; }

        public ProductCard()
        {
            InitializeComponent();
        }

        public void SetData(Product p)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));
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
        }

        private Image LoadPhotoOrStub(string path)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(path))
                {
                    var full = System.IO.Path.IsPathRooted(path)
                        ? path
                        : System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

                    if (System.IO.File.Exists(full))
                    {
                        using (var fs = new System.IO.FileStream(full, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        {
           
                            using (var img = Image.FromStream(fs))
                            {
                                return new Bitmap(img);
                            }
                        }
                    }
                }
            }
            catch
            {
                // игнор — заглушку
            }

            return Properties.Resources.picture; // заглушка из ресурсов
        }

        private void tip_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
