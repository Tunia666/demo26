using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo26
{
    public partial class OrderForm : Form
    {
        private readonly OrderRepository _repo = new OrderRepository();
        private List<Order> _orders = new List<Order>();
        public OrderForm()
        {
            InitializeComponent();
            Load += OrderForm_Load;
        }
        private OrderEditForm _openedEditForm;

        private bool IsAdmin => LoginClass.Role == LoginClass.UserRole.Admin;

        private bool CanViewOrders =>
            LoginClass.Role == LoginClass.UserRole.Manager ||
            LoginClass.Role == LoginClass.UserRole.Admin;
        private void OrderForm_Load(object sender, EventArgs e)
        {
            ReloadOrders();
        }
        private void ReloadOrders()
        {
            try
            {
                _orders = _repo.GetAll();
                ShowOrders(_orders);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка при загрузке заказов:\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ShowOrders(List<Order> orders)
        {
            flpOrders.SuspendLayout();
            flpOrders.Controls.Clear();

            foreach (var order in orders)
            {
                var card = new OrderCard();
                card.SetData(order);

                if (IsAdmin)
                {
                    card.OrderClicked += Card_OrderClicked;
                }
                else
                {
                    card.Cursor = Cursors.Default;
                }

                flpOrders.Controls.Add(card);
            }

            flpOrders.ResumeLayout();
        }

        private void Card_OrderClicked(object sender, Order order)
        {
            if (!IsAdmin)
            {
                MessageBox.Show(
                    "Редактирование заказов доступно только администратору.",
                    "Доступ запрещён",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            OpenOrderForm(order);
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show(
                    "Добавление заказов доступно только администратору.",
                    "Доступ запрещён",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            OpenOrderForm(null);
        }

        private void OpenOrderForm(Order order)
        {
            if (_openedEditForm != null && !_openedEditForm.IsDisposed)
            {
                _openedEditForm.Activate();
                MessageBox.Show(
                    "Уже открыто окно добавления или редактирования заказа.",
                    "Окно уже открыто",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            _openedEditForm = order == null
                ? new OrderEditForm()
                : new OrderEditForm(order);

            try
            {
                if (_openedEditForm.ShowDialog() == DialogResult.OK)
                {
                    ReloadOrders();
                }
            }
            finally
            {
                _openedEditForm.Dispose();
                _openedEditForm = null;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Tovar tovar = new Tovar();
            tovar.Show();
            Hide();
        }
    }
}

