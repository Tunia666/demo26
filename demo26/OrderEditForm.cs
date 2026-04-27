using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace demo26
{
    public class OrderEditForm : Form
    {
        private readonly OrderRepository _repo = new OrderRepository();
        private readonly Order _editingOrder;
        private readonly bool _isEditMode;

        private TextBox txtArticle;
        private ComboBox cbStatus;
        private ComboBox cbPickupPoint;
        private DateTimePicker dtpOrderDate;
        private DateTimePicker dtpDeliveryDate;
        private Button btnSave;
        private Button btnDelete;
        private Button btnCancel;

        private bool IsAdmin => LoginClass.Role == LoginClass.UserRole.Admin;

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

        private void InitializeComponent()
        {
            Width = 520;
            Height = 420;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            var lblArticle = new Label
            {
                Text = "Артикул:",
                Location = new Point(30, 35),
                AutoSize = true
            };

            txtArticle = new TextBox
            {
                Location = new Point(220, 32),
                Width = 220
            };

            var lblStatus = new Label
            {
                Text = "Статус заказа:",
                Location = new Point(30, 85),
                AutoSize = true
            };

            cbStatus = new ComboBox
            {
                Location = new Point(220, 82),
                Width = 220,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            var lblPickupPoint = new Label
            {
                Text = "Адрес пункта выдачи:",
                Location = new Point(30, 135),
                AutoSize = true
            };

            cbPickupPoint = new ComboBox
            {
                Location = new Point(220, 132),
                Width = 220,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            var lblOrderDate = new Label
            {
                Text = "Дата заказа:",
                Location = new Point(30, 185),
                AutoSize = true
            };

            dtpOrderDate = new DateTimePicker
            {
                Location = new Point(220, 182),
                Width = 220,
                Format = DateTimePickerFormat.Short
            };

            var lblDeliveryDate = new Label
            {
                Text = "Дата выдачи:",
                Location = new Point(30, 235),
                AutoSize = true
            };

            dtpDeliveryDate = new DateTimePicker
            {
                Location = new Point(220, 232),
                Width = 220,
                Format = DateTimePickerFormat.Short
            };

            btnSave = new Button
            {
                Text = "Сохранить",
                Location = new Point(30, 300),
                Width = 120,
                Height = 35
            };
            btnSave.Click += btnSave_Click;

            btnDelete = new Button
            {
                Text = "Удалить",
                Location = new Point(180, 300),
                Width = 120,
                Height = 35,
                BackColor = Color.LightCoral,
                Visible = _isEditMode && IsAdmin
            };
            btnDelete.Click += btnDelete_Click;

            btnCancel = new Button
            {
                Text = "Отмена",
                Location = new Point(330, 300),
                Width = 120,
                Height = 35
            };
            btnCancel.Click += (s, e) => Close();

            Controls.Add(lblArticle);
            Controls.Add(txtArticle);
            Controls.Add(lblStatus);
            Controls.Add(cbStatus);
            Controls.Add(lblPickupPoint);
            Controls.Add(cbPickupPoint);
            Controls.Add(lblOrderDate);
            Controls.Add(dtpOrderDate);
            Controls.Add(lblDeliveryDate);
            Controls.Add(dtpDeliveryDate);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(btnCancel);
        }

        private void LoadDataToControls()
        {
            cbStatus.Items.Clear();

            foreach (var status in _repo.GetStatuses())
                cbStatus.Items.Add(status);

            if (cbStatus.Items.Count > 0)
                cbStatus.SelectedIndex = 0;

            cbPickupPoint.Items.Clear();

            foreach (var point in _repo.GetPickupPoints())
                cbPickupPoint.Items.Add(point);

            if (cbPickupPoint.Items.Count > 0)
                cbPickupPoint.SelectedIndex = 0;

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

            if (cbPickupPoint.Items.Contains(_editingOrder.PickupPointId))
                cbPickupPoint.SelectedItem = _editingOrder.PickupPointId;

            dtpOrderDate.Value = _editingOrder.OrderDate;
            dtpDeliveryDate.Value = _editingOrder.DeliveryDate;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                var order = new Order
                {
                    Id = _isEditMode ? _editingOrder.Id : 0,
                    Article = txtArticle.Text.Trim(),
                    Status = cbStatus.SelectedItem.ToString(),
                    PickupPointId = Convert.ToInt32(cbPickupPoint.SelectedItem),
                    OrderDate = dtpOrderDate.Value.Date,
                    DeliveryDate = dtpDeliveryDate.Value.Date
                };

                if (_isEditMode)
                    _repo.Update(order);
                else
                    _repo.Add(order);

                MessageBox.Show("Данные заказа сохранены.",
                    "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении заказа:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show("Удаление заказа доступно только администратору.",
                    "Доступ запрещён", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                MessageBox.Show("Заказ удалён.",
                    "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении заказа:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtArticle.Text))
            {
                MessageBox.Show("Введите артикул товара.");
                txtArticle.Focus();
                return false;
            }

            if (cbStatus.SelectedItem == null)
            {
                MessageBox.Show("Выберите статус заказа.");
                cbStatus.Focus();
                return false;
            }

            if (cbPickupPoint.SelectedItem == null)
            {
                MessageBox.Show("Выберите пункт выдачи.");
                cbPickupPoint.Focus();
                return false;
            }

            if (dtpDeliveryDate.Value.Date < dtpOrderDate.Value.Date)
            {
                MessageBox.Show("Дата выдачи не может быть раньше даты заказа.");
                dtpDeliveryDate.Focus();
                return false;
            }

            return true;
        }
    }
}