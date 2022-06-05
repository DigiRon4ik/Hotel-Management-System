﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using ServiceStack.OrmLite;
using Hotel_Management_System.DataBase.Models;

namespace Hotel_Management_System.Forms
{
    public partial class fMain : Form
    {
        private fLogin fl = new fLogin();
        private fUser fu;

        private bool isSidebarOpened;
        private int sidebarWithOpen = 180; public int sidebarWithClose = 50;
        private User account;
        private IEnumerable<User> users;

        public fMain()
        {
            InitializeComponent();
            FormDock.SubscribeControlToDragEvents(lblTitle, true);

            if (fl.ShowDialog() == DialogResult.Yes)
                account = fl.account;
            else
                Environment.Exit(0);

            if (pnlSidebar.Width >= sidebarWithOpen)
            {
                pctrSidebar.Image = Properties.Resources.Hide_Sidepanel_32;
                isSidebarOpened = true;
            }
            else if (pnlSidebar.Width <= sidebarWithClose)
            {
                pctrSidebar.Image = Properties.Resources.Show_Sidepanel_32;
                isSidebarOpened = false;
            }

            InitUser();
            PageUsers_Load();
        }

        #region Кнопка Закрытия
        private void btnImgTitleClose_Click(object sender, EventArgs e) =>
           Application.Exit();

        private void btnImgTitleClose_MouseEnter(object sender, EventArgs e) =>
            btnImgTitleClose.BringToFront();
        #endregion

        #region Кнопка Увеличения Окна
        private void btnImgTitleMaximaze_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                FormDock.SubscribeControlToDragEvents(lblTitle, true);
                FormDock.SubscribeControlToDragEvents(pnlTitle, true);
            }
            else
            {
                FormDock.UnsubscribeControlToDragEvents(lblTitle, true);
                FormDock.UnsubscribeControlToDragEvents(pnlTitle, true);
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnImgTitleMaximaze_MouseEnter(object sender, EventArgs e) =>
            btnImgTitleMaximaze.BringToFront();
        #endregion

        #region Кнопка Сворачивания Окна
        private void btnImgTitleMinimaze_Click(object sender, EventArgs e) =>
            this.WindowState = FormWindowState.Minimized;

        private void btnImgTitleMinimaze_MouseEnter(object sender, EventArgs e) =>
            btnImgTitleMinimaze.BringToFront();
        #endregion

        #region Кнопка Бокового Меню
        private void pctrSidebar_Click(object sender, EventArgs e)
        {
            if (pnlSidebar.Width >= sidebarWithOpen)
            {
                pnlSidebar.Width = sidebarWithClose;
                isSidebarOpened = false;
            }
            else if (pnlSidebar.Width <= sidebarWithClose)
            {
                pnlSidebar.Width = sidebarWithOpen;
                isSidebarOpened = true;
            }
        }

        private void pctrSidebar_MouseMove(object sender, MouseEventArgs e) =>
            SetImageSidebar(true);

        private void pctrSidebar_MouseLeave(object sender, EventArgs e) =>
            SetImageSidebar(false);

        private void SetImageSidebar(bool isMoved)
        {
            switch (isMoved)
            {
                case true:
                    if (isSidebarOpened)
                        pctrSidebar.Image = Properties.Resources.Hide_Sidepanel_Primary_32;
                    else
                        pctrSidebar.Image = Properties.Resources.Show_Sidepanel_Primary_32;
                    break;

                case false:
                    if (isSidebarOpened)
                        pctrSidebar.Image = Properties.Resources.Hide_Sidepanel_32;
                    else
                        pctrSidebar.Image = Properties.Resources.Show_Sidepanel_32;
                    break;
            }
        }
        #endregion

        #region Кнопка выхода и Изображения
        private void bnfUserPicture_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (fl.ShowDialog() == DialogResult.Yes)
            {
                account = fl.account;
                InitUser();
                this.Show();
            }
            else
                Environment.Exit(0);
        }

        private void bnfUserPicture_MouseMove(object sender, MouseEventArgs e) =>
            bnfUserPicture.Image = Properties.Resources.Logout_512;

        private void bnfUserPicture_MouseLeave(object sender, EventArgs e) =>
            bnfUserPicture.Image = GetImageFromBytes(account.Photo);
        #endregion

        #region Кнопки Переключения Страниц
        private void btnPageHome_Enter(object sender, EventArgs e) =>
            bnfPages.SetPage("Home");

        private void btnPageRooms_Enter(object sender, EventArgs e) =>
            bnfPages.SetPage("Rooms");

        private void btnPageCustomers_Enter(object sender, EventArgs e) =>
            bnfPages.SetPage("Customers");

        private void btnPageCategories_Enter(object sender, EventArgs e) =>
            bnfPages.SetPage("Categories");

        private void btnPageUsers_Enter(object sender, EventArgs e) =>
            bnfPages.SetPage("Users");

        private void btnPageSettings_Enter(object sender, EventArgs e) =>
            bnfPages.SetPage("Settings");
        #endregion

        #region Инициализация Пользователя
        private void InitUser()
        {
            lblUserName.Text = account.FullName;
            lblUserRole.Text = account.Role;

            if (account.Role == "Support")
            {
                btnPageUsers.Visible = true;
                btnPageUsers.Enabled = true;
            }
            else
            {
                btnPageUsers.Visible = false;
                btnPageUsers.Enabled = false;
            }
        }

        #endregion

        #region Функция Возвращающая Изображение в двух видах
        public static byte[] GetImageFromBytes(string path)
        {
            return File.ReadAllBytes(path);
        }

        public static byte[] GetImageFromBytes(Bitmap bitmap)
        {
            return (byte[])new ImageConverter().ConvertTo(bitmap, typeof(byte[]));
        }

        public static Image GetImageFromBytes(byte[] imageBytes)
        {
            return (Bitmap)new ImageConverter().ConvertFrom(imageBytes);
        }
        #endregion

        #region Page_Users Загрузка Страницы
        private void PageUsers_Load()
        {
            bnfVScrollBarUsers.BindTo(gridUsers, true);
            LoadUsers();
            FillGridUsers();
        }
        #endregion

        #region Page_Users Загрузить из БД
        private void LoadUsers()
        {
            using (var db = DataBase.ApplicationContext.GetDbConnection())
            {
                users = db.Select<User>();
                bnfDropdownUsers.Items.Clear();
                bnfDropdownUsers.Items.Add("Все Роли");
                bnfDropdownUsers.Items.AddRange(db.Column<string>("SELECT Role FROM users GROUP BY Role").ToArray());
            }
        }
        #endregion

        #region Page_Users События для Поиска
        private void txtSearchUsers_TextChange(object sender, EventArgs e)
        {
            try
            {
                FillGridUsers(txtSearchUsers.Text.Trim().ToLower(), bnfDropdownUsers.SelectedItem.ToString());
            }
            catch (Exception)
            {
                FillGridUsers(txtSearchUsers.Text.Trim().ToLower());
            }
        }
        private void bnfDropdownUsers_SelectionChangeCommitted(object sender, EventArgs e) =>
            FillGridUsers(txtSearchUsers.Text.Trim().ToLower(), bnfDropdownUsers.SelectedItem.ToString());
        #endregion

        #region Page_Users Заполнение Таблицы
        private void FillGridUsers(string userName = "", string userRole = "Все Роли")
        {
            gridUsers.Rows.Clear();

            foreach (var user in users)
            {
                if (user.FullName.ToLower().Contains(userName) && user.Role.Contains(userRole == "Все Роли" ? "" : userRole))
                    gridUsers.Rows.Add(new object[] {
                        user.Photo,
                        user.FullName,
                        user.Role,
                        user.Phone,
                        user.Login,
                        user.CreatedAt }
                    );
            }
        }
        #endregion

        #region Page_Users Обновление Таблицы
        private void UpdateGridUsers()
        {
            string role;
            try
            {
                role = bnfDropdownUsers.SelectedItem.ToString();
            }
            catch (Exception)
            {

                role = "Все Роли";
            }
            
            LoadUsers();
            FillGridUsers(txtSearchUsers.Text.Trim().ToLower(), role);
        }
        #endregion

        #region Page_Users Кнопки для Редактирования БД
        private void btnRowAddUser_Click(object sender, EventArgs e)
        {
            OpenFormUser(true);
            UpdateGridUsers();
        }

        private void btnRowEditUser_Click(object sender, EventArgs e)
        {
            OpenFormUser(false);
            UpdateGridUsers();
        }

        private void btnRowDeleteUser_Click(object sender, EventArgs e)
        {
            if (fu == null || fu.IsDisposed)
            {
                using (var db = DataBase.ApplicationContext.GetDbConnection())
                    db.Delete<User>(x => x.FullName == gridUsers[1, gridUsers.CurrentRow.Index].Value.ToString());
                UpdateGridUsers();
            }
            else
                skbarValidation.Show(this, "Открыто окно Добавления/Изменения Пользователя!",
                                         BunifuSnackbar.MessageTypes.Warning,
                                         3000, "",
                                         BunifuSnackbar.Positions.BottomCenter,
                                         BunifuSnackbar.Hosts.FormOwner);
        }

        private void OpenFormUser(bool isAdd = true)
        {
            if (fu == null || fu.IsDisposed)
                fu = new fUser(isAdd);
            else
                skbarValidation.Show(this, "Окно уже открыто!",
                                         BunifuSnackbar.MessageTypes.Warning,
                                         2000, "",
                                         BunifuSnackbar.Positions.BottomCenter,
                                         BunifuSnackbar.Hosts.FormOwner);

            fu.Show();
        }
        #endregion
    }
}
