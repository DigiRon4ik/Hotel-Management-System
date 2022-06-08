using Bunifu.UI.WinForms;
using Hotel_Management_System.DataBase.Models;
using ServiceStack.OrmLite;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_Management_System.Forms
{
    public partial class fCustomer : Form
    {
        private int updateId = 0;

        public fCustomer(bool isAdd = true, Customer customer = null)
        {
            InitializeComponent();
            FormDock.SubscribeControlToDragEvents(lblTitle, true);
            if (customer != null)
                updateId = customer.Id;

            if (isAdd)
                SetDataForm("Добавить Клиента", 0, 2, imgList.Images[2], Color.Lime, Color.Green);
            else
            {
                SetDataForm("Изменить Клиента", 1, 4, imgList.Images[4], Color.Yellow, Color.Olive);
                txtFullName.Text = customer.FullName;
                txtPhone.Text = customer.Phone;
                txtCountry.Text = customer.Country;
                txtPassport.Text = customer.Passport;
            }
        }

        #region Кнопка Закрытия
        private void btnImgTitleClose_Click(object sender, EventArgs e) =>
            this.Close();
        #endregion

        #region Кнопка Изменения Изображения
        private void bnfCustomerImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                bnfCustomerImage.Image = Image.FromFile(openFileDialog.FileName);
        }
        #endregion

        #region Кнопка Добавления/Изменения
        private void btnAddOrChange_Click(object sender, EventArgs e)
        {
            if (txtFullName.TextLength < 10 || txtPhone.TextLength < 11 ||
                txtCountry.TextLength < 3 || txtPassport.TextLength < 6)
            {
                skbarValidation.Show(this, "Заполните все поля!", BunifuSnackbar.MessageTypes.Warning,
                                         3000, "", BunifuSnackbar.Positions.BottomCenter,
                                         BunifuSnackbar.Hosts.FormOwner);
                return;
            }

            Customer customer = new Customer
            {
                FullName = txtFullName.Text,
                Phone = txtPhone.Text,
                Country = txtCountry.Text,
                Passport = txtPassport.Text,
                Photo = fMain.GetImageFromBytes((Bitmap)bnfCustomerImage.Image)
            };

            using (var db = DataBase.ApplicationContext.GetDbConnection())
            {
                if (updateId == 0)
                    db.Save(customer);
                else
                {
                    customer.Id = updateId;
                    customer.CreatedAt = DateTime.Now;
                    db.Update(customer);
                }
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
        }
        #endregion

        #region События для ограничения ввода под цифры
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 40 && ch != 41 && ch != 45)
                e.Handled = true;
        }

        private void txtPassport_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 32)
                e.Handled = true;
        }
        #endregion
    }
}
