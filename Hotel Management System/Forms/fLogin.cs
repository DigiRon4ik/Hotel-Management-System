﻿using Hotel_Management_System.DataBase.Models;
using ServiceStack.OrmLite;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_Management_System.Forms
{
    public partial class fLogin : Form
    {
        public User account;

        public fLogin()
        {
            InitializeComponent();
            byte[] dfImage = fMain.GetImageFromBytes((Bitmap)imgLst.Images[0]);
            DataBase.ApplicationContext.InitDB(dfImage);

            using (var db = DataBase.ApplicationContext.GetDbConnection())
                lblSupport.Text = "Тех. Поддержка: " + db.SingleById<User>(1).Phone.ToString();
        }

        #region Кнопка Закрытия
        private void btnImgTitleClose_Click(object sender, EventArgs e) =>
            Environment.Exit(0);
        #endregion

        #region Выделения Текста в txtBox's
        private void txtLogin_Enter(object sender, EventArgs e)
        {
            if (txtLogin.Text.Length > 0)
                txtLogin.SelectAll();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length > 0)
                txtPassword.SelectAll();

        }
        #endregion

        #region Кнопка Входа
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Length == 0 || txtPassword.Text.Length == 0)
            {
                skbarValidation.Show(this, "Заполните поля!",
                                     Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning,
                                     2000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomCenter,
                                     Bunifu.UI.WinForms.BunifuSnackbar.Hosts.FormOwner);
                return;
            }

            using (var db = DataBase.ApplicationContext.GetDbConnection())
            {
                account = db.Select<User>(x =>
                                x.Login.ToString() == txtLogin.Text &&
                                x.Password.ToString() == txtPassword.Text).FirstOrDefault();
            }

            if (account == null)
            {
                skbarValidation.Show(this, "Неверный Логин или Пароль.",
                                     Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error,
                                     2000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomCenter,
                                     Bunifu.UI.WinForms.BunifuSnackbar.Hosts.FormOwner);
                return;
            }


            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        #endregion
    }
}
