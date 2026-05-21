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
    public partial class OrderEditForm : Form
    {
        private readonly OrderRepository _repo = new OrderRepository();
        private readonly Order _editingOrder;
        private readonly bool _isEditMode;
        public OrderEditForm()
        {
            _isEditMode = false;
            InitializeComponent();
            Text = "Добавление заказа";
            LoadDataToControls();
        }

        public OrderEditForm(Order order)
        {
            _editingOrder = order;
            _isEditMode = true;
            InitializeComponent();
            Text = "Редактирование заказа";
            LoadDataToControls();
            FillOrderData();
        }
        private bool IsAdmin => LoginClass.Role == LoginClass.UserRole.Admin;
        private void OrderEditForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadDataToControls()
        {
            cbStatus.Items.Clear();

            foreach (var status in _repo.GetStatuses())
                cbStatus.Items.Add(status);

            if (cbStatus.Items.Count > 0)
                cbStatus.SelectedIndex = 0;

            cbPickupPoint.DataSource = _repo.GetPickupPoints();
            cbPickupPoint.DisplayMember = "Address";
            cbPickupPoint.ValueMember = "Id";

            dtpOrderDate.Value = DateTime.Today;
            dtpDeliveryDate.Value = DateTime.Today;
        }

        private void FillOrderData()
        {
            if (_editingOrder == null)
                return;

            txtArticle.Text = _editingOrder.Article;

            if (cbStatus.Items.Contains(_editingOrder.Status))
                cbStatus.SelectedItem = _editingOrder.Status;

            cbPickupPoint.SelectedValue = _editingOrder.PickupPointId;

            dtpOrderDate.Value = _editingOrder.OrderDate;
            dtpDeliveryDate.Value = _editingOrder.DeliveryDate;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show(
                    "Сохранение заказа доступно только администратору.",
                    "Доступ запрещён",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm())
                return;

            try
            {
                var order = new Order
                {
                    Id = _isEditMode ? _editingOrder.Id : 0,
                    Article = txtArticle.Text.Trim(),
                    Status = cbStatus.SelectedItem.ToString(),
                    PickupPointId = Convert.ToInt32(cbPickupPoint.SelectedValue),
                    OrderDate = dtpOrderDate.Value.Date,
                    DeliveryDate = dtpDeliveryDate.Value.Date
                };

                if (_isEditMode)
                    _repo.Update(order);
                else
                    _repo.Add(order);

                MessageBox.Show(
                    "Данные заказа сохранены.",
                    "Успешно",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка при сохранении заказа:\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show(
                    "Удаление заказа доступно только администратору.",
                    "Доступ запрещён",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!_isEditMode || _editingOrder == null)
                return;

            var result = MessageBox.Show(
                "Вы действительно хотите удалить заказ?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                _repo.Delete(_editingOrder.Id);

                MessageBox.Show(
                    "Заказ удалён.",
                    "Успешно",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка при удалении заказа:\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtArticle.Text))
            {
                MessageBox.Show(
                    "Введите артикул товара.",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtArticle.Focus();
                return false;
            }

            if (cbStatus.SelectedItem == null)
            {
                MessageBox.Show(
                    "Выберите статус заказа.",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cbStatus.Focus();
                return false;
            }

            if (cbPickupPoint.SelectedItem == null)
            {
                MessageBox.Show(
                    "Выберите пункт выдачи.",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cbPickupPoint.Focus();
                return false;
            }

            if (dtpDeliveryDate.Value.Date < dtpOrderDate.Value.Date)
            {
                MessageBox.Show(
                    "Дата выдачи не может быть раньше даты заказа.",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                dtpDeliveryDate.Focus();
                return false;
            }

            return true;
        }
    }
}
