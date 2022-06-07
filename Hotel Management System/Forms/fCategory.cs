using Bunifu.UI.WinForms;
using Hotel_Management_System.DataBase.Models;
using ServiceStack.OrmLite;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_Management_System.Forms
{
    public partial class fCategory : Form
    {
        private int updateId = 0;
        public fCategory(bool isAdd = true, Category category = null)
        {
            InitializeComponent();
            FormDock.SubscribeControlToDragEvents(lblTitle, true);
            if (category != null)
                updateId = category.Id;

            if (isAdd)
                SetDataForm("Добавить Категорию", 0, 2, imgList.Images[2], Color.Lime, Color.Green);
            else
            {
                SetDataForm("Изменить Категорию", 1, 4, imgList.Images[4], Color.Yellow, Color.Olive);
                txtTitle.Text = category.Title;
                txtCountRooms.Text = category.CountRooms.ToString();
                txtForPeople.Text = category.ForPeople.ToString();
                txtDescription.Text = category.Description;

                bnfCBisWiFi.Checked = category.isWIFI;
                bnfCBisTV.Checked = category.isTV;
            }
        }

        #region Кнопка Закрытия
        private void btnImgTitleClose_Click(object sender, EventArgs e) =>
            this.Close();
        #endregion

        #region Кнопка Добавления/Изменения
        private void btnAddOrChange_Click(object sender, EventArgs e)
        {
            if (txtTitle.TextLength < 2 || txtCountRooms.TextLength < 1 || txtForPeople.TextLength < 1)
            {
                skbarValidation.Show(this, "Заполните все поля!", BunifuSnackbar.MessageTypes.Warning,
                                         3000, "", BunifuSnackbar.Positions.BottomCenter,
                                         BunifuSnackbar.Hosts.FormOwner);
                return;
            }

            Category category = new Category
            {
                Title = txtTitle.Text,
                CountRooms = Int32.Parse(txtCountRooms.Text),
                ForPeople = Int32.Parse(txtForPeople.Text),
                Description = txtDescription.Text,
                isWIFI = bnfCBisWiFi.Checked,
                isTV = bnfCBisTV.Checked,
            };

            using (var db = DataBase.ApplicationContext.GetDbConnection())
            {
                if (updateId == 0)
                    db.Save(category);
                else
                {
                    category.Id = updateId;
                    category.CreatedAt = DateTime.Now;
                    db.Update(category);
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
        private void txtCountRooms_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
                e.Handled = true;

            if (txtCountRooms.Text.Length > 1)
                e.Handled = true;

            if (txtCountRooms.Text.Length == 2 && ch == 8)
                e.Handled = false;
        }

        private void txtForPeople_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
                e.Handled = true;

            if (txtForPeople.Text.Length > 1)
                e.Handled = true;

            if (txtForPeople.Text.Length == 2 && ch == 8)
                e.Handled = false;
        }
        #endregion
    }
}
