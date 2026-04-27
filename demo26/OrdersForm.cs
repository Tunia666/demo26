using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace demo26
{
    public class OrdersForm : Form
    {
        private readonly OrderRepository _repo = new OrderRepository();
        private List<Order> _orders = new List<Order>();

        private DataGridView dgvOrders;
        private Button btnAddOrder;
        private Button btnRefresh;
        private Button btnBack;

        private bool IsAdmin => LoginClass.Role == LoginClass.UserRole.Admin;

        public OrdersForm()
        {
            InitializeComponent();
            Load += OrdersForm_Load;
        }

        private void InitializeComponent()
        {
            Text = "Список заказов";
            Width = 1000;
            Height = 600;
            StartPosition = FormStartPosition.CenterScreen;

            var topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60
            };

            var title = new Label
            {
                Text = "Список заказов",
                Font = new Font("Times New Roman", 20),
                AutoSize = true,
                Location = new Point(15, 12)
            };

            btnAddOrder = new Button
            {
                Text = "Добавить заказ",
                Width = 150,
                Height = 30,
                Location = new Point(500, 15)
            };
            btnAddOrder.Click += btnAddOrder_Click;

            btnRefresh = new Button
            {
                Text = "Обновить",
                Width = 120,
                Height = 30,
                Location = new Point(660, 15)
            };
            btnRefresh.Click += (s, e) => ReloadOrders();

            btnBack = new Button
            {
                Text = "Назад",
                Width = 100,
                Height = 30,
                Location = new Point(790, 15)
            };
            btnBack.Click += btnBack_Click;

            topPanel.Controls.Add(title);
            topPanel.Controls.Add(btnAddOrder);
            topPanel.Controls.Add(btnRefresh);
            topPanel.Controls.Add(btnBack);

            dgvOrders = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };

            dgvOrders.CellDoubleClick += dgvOrders_CellDoubleClick;

            Controls.Add(dgvOrders);
            Controls.Add(topPanel);
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            ReloadOrders();
        }

        private void ReloadOrders()
        {
            _orders = _repo.GetAll();

            dgvOrders.DataSource = null;
            dgvOrders.DataSource = _orders;

            if (dgvOrders.Columns["Id"] != null)
                dgvOrders.Columns["Id"].HeaderText = "Номер заказа";

            if (dgvOrders.Columns["Article"] != null)
                dgvOrders.Columns["Article"].HeaderText = "Артикул";

            if (dgvOrders.Columns["Status"] != null)
                dgvOrders.Columns["Status"].HeaderText = "Статус заказа";

            if (dgvOrders.Columns["PickupPointId"] != null)
                dgvOrders.Columns["PickupPointId"].HeaderText = "Адрес пункта выдачи";

            if (dgvOrders.Columns["OrderDate"] != null)
                dgvOrders.Columns["OrderDate"].HeaderText = "Дата заказа";

            if (dgvOrders.Columns["DeliveryDate"] != null)
                dgvOrders.Columns["DeliveryDate"].HeaderText = "Дата выдачи";
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var order = dgvOrders.Rows[e.RowIndex].DataBoundItem as Order;

            if (order == null)
                return;

            using (var form = new OrderEditForm(order))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    ReloadOrders();
            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            using (var form = new OrderEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                    ReloadOrders();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var tovar = new Tovar();
            tovar.Show();
            Hide();
        }
    }
}