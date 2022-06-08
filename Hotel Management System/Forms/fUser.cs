using Bunifu.UI.WinForms;
using Hotel_Management_System.DataBase.Models;
using ServiceStack.OrmLite;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_Management_System.Forms
{
    public partial class fUser : Form
    {
        private int updateId = 0;
        public fUser(bool isAdd = true, User user = null)
        {
            InitializeComponent();
            FormDock.SubscribeControlToDragEvents(lblTitle, true);
            if (user != null)
                updateId = user.Id;

            if (isAdd)
                SetDataForm("Добавить Пользователя", 0, 2, imgList.Images[2], Color.Lime, Color.Green);
            else
            {
                SetDataForm("Изменить Пользователя", 1, 4, imgList.Images[4], Color.Yellow, Color.Olive);
                txtFullName.Text = user.FullName;
                txtPhone.Text = user.Phone;
                txtRole.Text = user.Role;
                txtLogin.Text = user.Login;
                txtPassword.Text = user.Password;
            }
        }

        #region Кнопка Закрытия
        private void btnImgTitleClose_Click(object sender, EventArgs e) =>
            this.Close();
        #endregion

        #region Кнопка Изменения Изображения
        private void bnfUserImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                bnfUserImage.Image = Image.FromFile(openFileDialog.FileName);
        }
        #endregion

        #region Кнопка Добавления/Изменения
        private void CallWarning(string text)
        {
            skbarValidation.Show(this, text, BunifuSnackbar.MessageTypes.Warning,
                3000, "", BunifuSnackbar.Positions.BottomCenter,
                BunifuSnackbar.Hosts.FormOwner);
        }

        private void btnAddOrChange_Click(object sender, EventArgs e)
        {
            if (txtFullName.TextLength < 10 || txtPhone.TextLength < 11 ||
                txtRole.TextLength < 4 || txtLogin.TextLength < 4 || txtPassword.TextLength < 8)
            {
                CallWarning("Заполните все поля!");
                return;
            }

            User user = new User
            {
                FullName = txtFullName.Text,
                Phone = txtPhone.Text,
                Role = txtRole.Text,
                Login = txtLogin.Text,
                Password = txtPassword.Text,
                Photo = fMain.GetImageFromBytes((Bitmap)bnfUserImage.Image)
            };

            using (var db = DataBase.ApplicationContext.GetDbConnection())
            {
                if (db.Exists<User>(x => x.Login == user.Login))
                {
                    CallWarning("Такой ЛОГИН уже существует!");
                    return;
                }
                else if (db.Exists<User>(x => x.Phone == user.Phone))
                {
                    CallWarning("Такой ТЕЛЕФОН уже существует!");
                    return;
                }

                if (updateId == 0)
                    db.Save(user);
                else
                {
                    user.Id = updateId;
                    user.CreatedAt = DateTime.Now;
                    db.Update(user);
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
        #endregion
    }
}
