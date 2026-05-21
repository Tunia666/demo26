using System;
using System.Drawing;
using System.Windows.Forms;

namespace demo26
{
    public partial class OrderCard : UserControl
    {
        private Order _order;

        public event EventHandler<Order> OrderClicked;

        private Label lArticle;
        private Label lStatus;
        private Label lPickupPoint;
        private Label lOrderDate;
        private Label lDeliveryDate;

        public OrderCard()
        {
            InitializeComponent();

            Click += Card_Click;
            SubscribeClicks(this);
        }

        public void SetData(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            _order = order;

            //lblTitle.Text = $"Заказ №{order.Id}";
            lArticle.Text = $"Артикул: {order.Article}";
            lStatus.Text = $"Статус: {order.Status}";
            lPickupPoint.Text = $"Пункт выдачи: {order.PickupPointAddress}";
            lOrderDate.Text = $"Дата заказа: {order.OrderDate:dd.MM.yyyy}";
            lDeliveryDate.Text = $"Дата выдачи: {order.DeliveryDate:dd.MM.yyyy}";

            if (order.Status == "Отменён")
                BackColor = Color.LightCoral;
            else if (order.Status == "Выдан")
                BackColor = Color.LightGray;
            else if (order.Status == "Готов к выдаче")
                BackColor = Color.LightGreen;
            else
                BackColor = Color.White;

            Cursor = Cursors.Hand;
        }

        private void Card_Click(object sender, EventArgs e)
        {
            if (_order != null)
                OrderClicked?.Invoke(this, _order);
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
    }
}