﻿using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel_Management_System.DataBase.Models;
using Hotel_Management_System.Forms;
using ServiceStack.OrmLite;

namespace Hotel_Management_System.Forms
{
    public partial class fUser : Form
    {
        public fUser(bool isAdd = true)
        {
            InitializeComponent();
            FormDock.SubscribeControlToDragEvents(lblTitle, true);

            if (isAdd)
                SetDataForm("Добавить Пользователя", 0, 2, imgList.Images[2], Color.Lime, Color.Green);
            else
                SetDataForm("Изменить Пользователя", 1, 4, imgList.Images[4], Color.Yellow, Color.Olive);
        }

        #region Кнопка Закрытия
        private void btnImgTitleClose_Click(object sender, EventArgs e) =>
            this.Close();
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

        private void btnAddOrChange_Click(object sender, EventArgs e)
        {
            if (txtFullName.TextLength < 10 || txtPhone.TextLength < 17 ||
                txtRole.TextLength < 4 || txtLogin.TextLength < 6 || txtPassword.TextLength < 8)
            {
                skbarValidation.Show(this, "Заполните все поля!",
                                         BunifuSnackbar.MessageTypes.Warning,
                                         3000, "",
                                         BunifuSnackbar.Positions.BottomCenter,
                                         BunifuSnackbar.Hosts.FormOwner);
                return;
            }

            User user = new User { 
                FullName = txtFullName.Text,
                Phone = txtPhone.Text,
                Role = txtRole.Text,
                Login = txtLogin.Text, 
                Password = txtPassword.Text,
                Photo = fMain.GetImageFromBytes((Bitmap)bnfUserImage.Image) };

            using (var db = DataBase.ApplicationContext.GetDbConnection())
                db.Save(user);

            this.Close();
        }

        private void bnfUserImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                bnfUserImage.Image = Image.FromFile(openFileDialog.FileName);
        }
    }
}
