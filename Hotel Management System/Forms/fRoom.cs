using Bunifu.UI.WinForms;
using Hotel_Management_System.DataBase.Models;
using ServiceStack.OrmLite;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_Management_System.Forms
{
    public partial class fRoom : Form
    {
        private int updateId = 0;
        private int salary = 0;
        private int arenda = 0;

        private Category category;
        private Customer customer;

        public fRoom(bool isAdd = true, Room room = null)
        {
            InitializeComponent();
            FormDock.SubscribeControlToDragEvents(lblTitle, true);
            if (room != null)
                updateId = room.Id;

            bnfDateUntil.MinDate = DateTime.Now.AddDays(1);

            if (isAdd)
            {
                SetDataForm("Добавить Комнату", 0, 2, imgList.Images[2], Color.Lime, Color.Green);
                SetValueFromRoom();

                bnfDateFrom.Value = DateTime.Now;
                bnfDateUntil.Value = bnfDateFrom.Value.AddDays(1);
                bnfDateFrom.Enabled = false;
                bnfDateUntil.Enabled = false;
                lblSalary.Visible = false;
                lblArenda.Visible = false;
            }
            else
            {
                SetDataForm("Изменить Комнату", 1, 4, imgList.Images[4], Color.Yellow, Color.Olive);
                txtNumber.Text = room.Number.ToString();
                txtPrice.Text = room.Price.ToString();

                if (room.CustomerId == 0)
                {
                    bnfDateFrom.Value = DateTime.Now;
                    bnfDateUntil.Value = bnfDateFrom.Value.AddDays(1);
                    bnfDateFrom.Enabled = false;
                    bnfDateUntil.Enabled = false;
                    lblSalary.Visible = false;
                    lblArenda.Visible = false;
                }
                else
                {
                    bnfDateFrom.Value = room.From;
                    bnfDateUntil.Value = room.Until;
                    SetLblPriceAndArenda();
                }
            }
        }

        #region Кнопка Закрытия
        private void btnImgTitleClose_Click(object sender, EventArgs e) =>
            this.Close();
        #endregion

        #region Установка Конечной суммы и Аренды
        private void SetLblPriceAndArenda()
        {
            arenda = (int)((bnfDateUntil.Value - bnfDateFrom.Value).TotalDays);
            lblArenda.Text = $"Аренда на: {arenda}Д";
            if (txtPrice.Text.Length > 0)
                salary = (int)(Int32.Parse(txtPrice.Text) * arenda);
            lblSalary.Text = $"Итоговая Цена: {salary}₽";
        }

        private void bnfDateFrom_ValueChanged(object sender, EventArgs e) =>
            SetLblPriceAndArenda();

        private void bnfDateUntil_ValueChanged(object sender, EventArgs e) =>
            SetLblPriceAndArenda();
        #endregion

        #region Блокировка/Разблокировка DatePickers
        private void bnfDropdownCustomer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (bnfDropdownCustomer.SelectedItem.ToString() == "Нет")
            {
                bnfDateFrom.Enabled = false;
                bnfDateUntil.Enabled = false;
                lblSalary.Visible = false;
                lblArenda.Visible = false;
            }
            else
            {
                bnfDateFrom.Enabled = true;
                bnfDateUntil.Enabled = true;
                lblSalary.Visible = true;
                lblArenda.Visible = true;
                SetLblPriceAndArenda();
            }
        }
        #endregion

        #region Кнопка Добавления/Изменения
        private string _category, _customer;

        private void SetValueFromRoom()
        {
            try
            {
                _category = bnfDropdownCategory.SelectedItem.ToString();
            }
            catch (Exception)
            {
                if (string.IsNullOrEmpty(_category))
                    _category = "";
            }

            try
            {
                _customer = bnfDropdownCustomer.SelectedItem.ToString();
            }
            catch (Exception)
            {
                if (string.IsNullOrEmpty(_customer))
                    _customer = "Нет";
            }
        }

        private void CallWarning(string text)
        {
            skbarValidation.Show(this, text, BunifuSnackbar.MessageTypes.Warning,
                3000, "", BunifuSnackbar.Positions.BottomCenter,
                BunifuSnackbar.Hosts.FormOwner);
        }

        private void btnAddOrChange_Click(object sender, EventArgs e)
        {
            SetValueFromRoom();
            if (txtNumber.Text.Length < 1 || txtPrice.Text.Length < 1 || _category == "")
            {
                CallWarning("Заполните все поля!");
                return;
            }

            if (_customer != "Нет" && arenda <= 0)
            {
                CallWarning("Начальная дата не может быть больше конечной!");
                return;
            }

            Room room;
            using (var db = DataBase.ApplicationContext.GetDbConnection())
            {
                category = db.Single<Category>(x => x.Title == _category);
                if (_customer != "Нет")
                    customer = db.Single<Customer>(x => x.FullName == _customer);

                room = new Room
                {
                    isFree = _customer == "Нет" ? true : false,
                    CategoryId = category.Id,
                    Number = Int32.Parse(txtNumber.Text),
                    Price = Int32.Parse(txtPrice.Text),
                    CustomerId = _customer == "Нет" ? 0 : customer.Id,
                    From = _customer == "Нет" ? new DateTime() : bnfDateFrom.Value,
                    Until = _customer == "Нет" ? new DateTime() : bnfDateUntil.Value,
                };

                if (db.Exists<Room>(x => x.Number == room.Number))
                {
                    CallWarning("Такой НОМЕР уже существует!");
                    return;
                }

                if (updateId == 0)
                    db.Save(room);
                else
                {
                    room.Id = updateId;
                    room.CreatedAt = DateTime.Now;
                    db.Update(room);
                }

                if (_customer != "Нет")
                    db.Save<Salary>(new Salary { salary = salary });
            }


            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        #endregion

        #region Метод для Настройки Формы
        private void SetDataForm(string text, int iconIndex, int imageIndex, Image img, Color hover, Color pressed)
        {
            this.Text = text;
            var thumb = (Bitmap)imgList.Images[iconIndex].GetThumbnailImage(64, 64, null, IntPtr.Zero);
            thumb.MakeTransparent();
            this.Icon = Icon.FromHandle(thumb.GetHicon());
            lblTitle.Text = text;
            pctrIcon.Image = img;

            btnAddOrChange.Text = text.Split(' ')[0].ToUpper();
            btnAddOrChange.IdleIconLeftImage = imgList.Images[imageIndex];
            btnAddOrChange.IdleIconRightImage = imgList.Images[imageIndex];
            btnAddOrChange.onHoverState.IconLeftImage = imgList.Images[imageIndex + 1];
            btnAddOrChange.onHoverState.IconRightImage = imgList.Images[imageIndex + 1];
            btnAddOrChange.OnPressedState.IconLeftImage = imgList.Images[imageIndex + 1];
            btnAddOrChange.OnPressedState.IconRightImage = imgList.Images[imageIndex + 1];

            btnAddOrChange.onHoverState.BorderColor = hover;
            btnAddOrChange.onHoverState.ForeColor = hover;
            btnAddOrChange.OnPressedState.BorderColor = pressed;
            btnAddOrChange.OnPressedState.ForeColor = pressed;

            using (var db = DataBase.ApplicationContext.GetDbConnection())
            {
                bnfDropdownCategory.Items.AddRange(db.Column<string>("SELECT Title FROM categories ORDER BY Title").ToArray());
                bnfDropdownCustomer.Items.Add("Нет");
                bnfDropdownCustomer.Items.AddRange(db.Column<string>("SELECT FullName FROM customers ORDER BY FullName").ToArray());
            }
        }
        #endregion

        #region События для ограничения ввода под цифры
        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
                e.Handled = true;

            if (txtNumber.Text.Length > 4)
                e.Handled = true;

            if (txtNumber.Text.Length == 5 && ch == 8)
                e.Handled = false;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
                e.Handled = true;
        }
        #endregion
    }
}
