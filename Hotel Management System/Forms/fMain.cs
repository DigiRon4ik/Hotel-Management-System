using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using ServiceStack.OrmLite;

namespace Hotel_Management_System.Forms
{
    public partial class fMain : Form
    {
        private fLogin fl = new fLogin();

        public bool isSidebarOpened;
        public int sidebarWithOpen = 180; public int sidebarWithClose = 50;
        public DataBase.Models.User account;

        public fMain()
        {
            InitializeComponent();
            FormDock.SubscribeControlToDragEvents(lblTitle, true);

            if (fl.ShowDialog() == DialogResult.Yes)
                account = fl.account;
            else
                Environment.Exit(0);

            InitUser();

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

        #region Кнопка Бокового Меню и Таймер
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

        #region Изображения и Кнопка выхода
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
            bnfUserPicture.Image = Properties.Resources.Contact_512;
        #endregion

        #region Инициализация Пользователя
        private void InitUser()
        {
            lblUserName.Text = $"{account.Name.ToString()} {account.Surname.ToString()}";
            lblUserRole.Text = account.Role.ToString();

            if (account.Role.ToString() == "Support")
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
    }
}
