using System;
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
        private fLogin flogin = new fLogin();
        private fUser fuser;
        private fCustomer fcustomer;
        private fCategory fcategory;

        private bool isSidebarOpened;
        private int sidebarWithOpen = 180; public int sidebarWithClose = 50;
        private User account;

        private IEnumerable<User> users;
        private IEnumerable<Customer> customers;
        private IEnumerable<Category> categories;

        public static byte[] defaultImage;
        
        public fMain()
        {
            InitializeComponent();
            FormDock.SubscribeControlToDragEvents(lblTitle, true);

            if (flogin.ShowDialog() == DialogResult.Yes)
                account = flogin.account;
            else
                Environment.Exit(0);
            
            if (pnlSidebar.Width >= sidebarWithOpen)
            {
                pctrSidebar.Image = imgListFromSidebar.Images[0];
                isSidebarOpened = true;
            }
            else if (pnlSidebar.Width <= sidebarWithClose)
            {
                pctrSidebar.Image = imgListFromSidebar.Images[2];
                isSidebarOpened = false;
            }

            InitUser();
            PageUsers_Load();
            PageCategories_Load();
            PageCustomers_Load();
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
                        pctrSidebar.Image = imgListFromSidebar.Images[1];
                    else
                        pctrSidebar.Image = imgListFromSidebar.Images[3];
                    break;

                case false:
                    if (isSidebarOpened)
                        pctrSidebar.Image = imgListFromSidebar.Images[0];
                    else
                        pctrSidebar.Image = imgListFromSidebar.Images[2];
                    break;
            }
        }
        #endregion

        #region Кнопка выхода и Изображения
        private void bnfUserPicture_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (flogin.ShowDialog() == DialogResult.Yes)
            {
                account = flogin.account;
                InitUser();
                this.Show();
            }
            else
                Environment.Exit(0);
        }

        private void bnfUserPicture_MouseMove(object sender, MouseEventArgs e) =>
            bnfUserPicture.Image = imgListFromSidebar.Images[4];

        private void bnfUserPicture_MouseLeave(object sender, EventArgs e) =>
            bnfUserPicture.Image = GetImageFromBytes(account.Photo);
        #endregion

        #region Кнопки Переключения Страниц
        private void btnPageHome_Enter(object sender, EventArgs e) =>
            bnfVScrollBarRooms.SetPage("Home");

        private void btnPageRooms_Enter(object sender, EventArgs e) =>
            bnfVScrollBarRooms.SetPage("Rooms");

        private void btnPageCustomers_Enter(object sender, EventArgs e) =>
            bnfVScrollBarRooms.SetPage("Customers");

        private void btnPageCategories_Enter(object sender, EventArgs e) =>
            bnfVScrollBarRooms.SetPage("Categories");

        private void btnPageUsers_Enter(object sender, EventArgs e) =>
            bnfVScrollBarRooms.SetPage("Users");

        private void btnPageSettings_Enter(object sender, EventArgs e) =>
            bnfVScrollBarRooms.SetPage("Settings");
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



        #region Page_Users

        #region Загрузка Страницы
        private void PageUsers_Load()
        {
            bnfVScrollBarUsers.BindTo(gridUsers, true);
            LoadUsers();
            FillGridUsers();
        }
        #endregion

        #region Загрузить из БД
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

        #region События для Поиска
        private void txtSearchUsers_TextChange(object sender, EventArgs e)
        {
            string text = txtSearchUsers.Text.ToLower().Trim();

            if (text.Length > 0)
                try
                {
                    FillGridUsers(text, bnfDropdownUsers.SelectedItem.ToString());
                }
                catch (Exception)
                {
                    FillGridUsers(text);
                }
        }
        private void bnfDropdownUsers_SelectionChangeCommitted(object sender, EventArgs e) =>
            FillGridUsers(txtSearchUsers.Text.Trim().ToLower(), bnfDropdownUsers.SelectedItem.ToString());
        #endregion

        #region Заполнение Таблицы
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

        #region Обновление Таблицы
        public void UpdateGridUsers()
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

        #region Кнопки для Редактирования БД
        private void btnRowAddUser_Click(object sender, EventArgs e)
        {
            fuser = new fUser(true);
            if (fuser.ShowDialog() == DialogResult.Yes)
            {
                skbarValidation.Show(this, "Добавлено!", BunifuSnackbar.MessageTypes.Success,
                                         2500, "", BunifuSnackbar.Positions.BottomCenter,
                                         BunifuSnackbar.Hosts.FormOwner);
                UpdateGridUsers();
            }
        }

        private void btnRowEditUser_Click(object sender, EventArgs e)
        {
            User currentUser;
            using (var db = DataBase.ApplicationContext.GetDbConnection())
                currentUser = db.Single<User>(x => x.Login == gridUsers[4, gridUsers.CurrentRow.Index].Value.ToString());

            fuser = new fUser(false, currentUser);
            if (fuser.ShowDialog() == DialogResult.Yes)
            {
                skbarValidation.Show(this, "Изменено!", BunifuSnackbar.MessageTypes.Success,
                                         2500, "", BunifuSnackbar.Positions.BottomCenter,
                                         BunifuSnackbar.Hosts.FormOwner);
                UpdateGridUsers();
            }
        }

        private void btnRowDeleteUser_Click(object sender, EventArgs e)
        {
            using (var db = DataBase.ApplicationContext.GetDbConnection())
                db.Delete<User>(x => x.Login == gridUsers[4, gridUsers.CurrentRow.Index].Value.ToString());
            UpdateGridUsers();
        }
        #endregion

        #endregion



        #region Page_Category
        private string cr, fp;

        #region Загрузка Страницы
        private void PageCategories_Load()
        {
            bnfVScrollBarCategories.BindTo(gridCategories, true);
            LoadCategories();
            FillGridCategories();
        }
        #endregion

        #region Загрузить из БД
        private void LoadCategories()
        {
            using (var db = DataBase.ApplicationContext.GetDbConnection())
            {
                categories = db.Select<Category>();
                bnfDropdownCategoriesCountRooms.Items.Clear();
                bnfDropdownCategoriesCountRooms.Items.Add("Все Комнаты");
                bnfDropdownCategoriesCountRooms.Items.AddRange(db.Column<string>("SELECT CountRooms FROM categories GROUP BY CountRooms").ToArray());
                bnfDropdownCategoriesForPeople.Items.Clear();
                bnfDropdownCategoriesForPeople.Items.Add("Все Люди");
                bnfDropdownCategoriesForPeople.Items.AddRange(db.Column<string>("SELECT ForPeople FROM categories GROUP BY ForPeople").ToArray());
            }
        }
        #endregion

        #region События для Поиска
        private void SetValueFromDropDowns()
        {
            try
            {
                cr = bnfDropdownCategoriesCountRooms.SelectedItem.ToString();
            }
            catch (Exception)
            {
                if (string.IsNullOrEmpty(cr))
                    cr = "Все Комнаты";
            }

            try
            {
                fp = bnfDropdownCategoriesForPeople.SelectedItem.ToString();
            }
            catch (Exception)
            {
                if (string.IsNullOrEmpty(fp))
                    fp = "Все Люди";
            }
        }

        private void bnfDropdownCategoriesCountRooms_SelectionChangeCommitted(object sender, EventArgs e) =>
            UpdateGridCategories(true);

        private void bnfDropdownCategoriesForPeople_SelectionChangeCommitted(object sender, EventArgs e) =>
            UpdateGridCategories(true);

        private void bnfCheckBoxWiFi_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e) =>
            UpdateGridCategories(true);

        private void bnfCheckBoxTV_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e) =>
            UpdateGridCategories(true);
        #endregion

        #region Заполнение Таблицы
        private void FillGridCategories(string categoryCountRooms = "Все Комнаты", string categoryForPeople = "Все Люди",
                                        bool withWIFI = false, bool withTV = false)
        {
            gridCategories.Rows.Clear();

            foreach (var category in categories)
            {
                if (category.CountRooms.ToString().Contains(categoryCountRooms == "Все Комнаты" ? "" : categoryCountRooms) &&
                    category.ForPeople.ToString().Contains(categoryForPeople == "Все Люди" ? "" : categoryForPeople) &&
                    (withWIFI ? category.isWIFI : true) && (withTV ? category.isTV : true))
                    gridCategories.Rows.Add(new object[] {
                        category.Title,
                        category.CountRooms,
                        category.ForPeople,
                        category.isWIFI ? imgMarks.Images[1] : imgMarks.Images[0],
                        category.isTV ? imgMarks.Images[1] : imgMarks.Images[0],
                        category.CreatedAt }
                    );
            }
        }
        #endregion

        #region Обновление Таблицы
        public void UpdateGridCategories(bool filtered = false)
        {
            SetValueFromDropDowns();
            if (!filtered)
                LoadCategories();
            FillGridCategories(cr, fp, bnfCheckBoxWiFi.Checked, bnfCheckBoxTV.Checked);
        }

        #endregion

        #region Кнопки для Редактирования БД
        private void btnRowAddCategory_Click(object sender, EventArgs e)
        {
            fcategory = new fCategory(true);
            if (fcategory.ShowDialog() == DialogResult.Yes)
            {
                skbarValidation.Show(this, "Добавлено!", BunifuSnackbar.MessageTypes.Success,
                                         2500, "", BunifuSnackbar.Positions.BottomCenter,
                                         BunifuSnackbar.Hosts.FormOwner);
                UpdateGridCategories();
            }
        }

        private void btnRowEditCategory_Click(object sender, EventArgs e)
        {
            Category currentCategory;
            using (var db = DataBase.ApplicationContext.GetDbConnection())
                currentCategory = db.Single<Category>(x => x.Title == gridCategories[0, gridCategories.CurrentRow.Index].Value.ToString());

            fcategory = new fCategory(false, currentCategory);
            if (fcategory.ShowDialog() == DialogResult.Yes)
            {
                skbarValidation.Show(this, "Изменено!", BunifuSnackbar.MessageTypes.Success,
                                         2500, "", BunifuSnackbar.Positions.BottomCenter,
                                         BunifuSnackbar.Hosts.FormOwner);
                UpdateGridCategories();
            }
        }

        private void btnRowDeleteCategory_Click(object sender, EventArgs e)
        {
            using (var db = DataBase.ApplicationContext.GetDbConnection())
                db.Delete<Category>(x => x.Title == gridCategories[0, gridCategories.CurrentRow.Index].Value.ToString());
            UpdateGridCategories();
        }
        #endregion

        #endregion



        #region Page_Customers

        #region Загрузка Страницы
        private void PageCustomers_Load()
        {
            bnfVScrollBarCustomers.BindTo(gridCustomers, true);
            LoadCustomers();
            FillGridCustomers();
        }
        #endregion

        #region Загрузить из БД
        private void LoadCustomers()
        {
            using (var db = DataBase.ApplicationContext.GetDbConnection())
            {
                customers = db.Select<Customer>();
                bnfDropdownCustomers.Items.Clear();
                bnfDropdownCustomers.Items.Add("Все Страны");
                bnfDropdownCustomers.Items.AddRange(db.Column<string>("SELECT Country FROM customers GROUP BY Country").ToArray());
            }
        }
        #endregion

        #region События для Поиска
        private void txtSearchCustomers_TextChange(object sender, EventArgs e)
        {
            string text = txtSearchCustomers.Text.ToLower().Trim();

            if (text.Length > 0)
                try
                {
                    FillGridCustomers(text, bnfDropdownCustomers.SelectedItem.ToString());
                }
                catch (Exception)
                {
                    FillGridCustomers(text);
                }
        }
        private void bnfDropdownCustomers_SelectionChangeCommitted(object sender, EventArgs e) =>
            FillGridCustomers(txtSearchCustomers.Text.Trim().ToLower(), bnfDropdownCustomers.SelectedItem.ToString());
        #endregion

        #region Заполнение Таблицы
        private void FillGridCustomers(string сustomerName = "", string сustomerCountry = "Все Страны")
        {
            gridCustomers.Rows.Clear();

            foreach (var сustomer in customers)
            {
                if (сustomer.FullName.ToLower().Contains(сustomerName) && сustomer.Country.Contains(сustomerCountry == "Все Страны" ? "" : сustomerCountry))
                    gridCustomers.Rows.Add(new object[] {
                        сustomer.Photo,
                        сustomer.FullName,
                        сustomer.Country,
                        сustomer.Passport,
                        сustomer.Phone,
                        сustomer.CreatedAt }
                    );
            }
        }
        #endregion

        #region Обновление Таблицы
        public void UpdateGridCustomers()
        {
            string country;
            try
            {
                country = bnfDropdownCustomers.SelectedItem.ToString();
            }
            catch (Exception)
            {

                country = "Все Страны";
            }

            LoadCustomers();
            FillGridCustomers(txtSearchCustomers.Text.Trim().ToLower(), country);
        }
        #endregion

        #region Кнопки для Редактирования БД
        private void btnRowAddCustomer_Click(object sender, EventArgs e)
        {
            fcustomer = new fCustomer(true);
            if (fcustomer.ShowDialog() == DialogResult.Yes)
            {
                skbarValidation.Show(this, "Добавлено!", BunifuSnackbar.MessageTypes.Success,
                                         2500, "", BunifuSnackbar.Positions.BottomCenter,
                                         BunifuSnackbar.Hosts.FormOwner);
                UpdateGridCustomers();
            }
        }

        private void btnRowEditCustomer_Click(object sender, EventArgs e)
        {
            Customer currentCustomer;
            using (var db = DataBase.ApplicationContext.GetDbConnection())
                currentCustomer = db.Single<Customer>(x => x.Passport == gridCustomers[3, gridCustomers.CurrentRow.Index].Value.ToString());

            fcustomer = new fCustomer(false, currentCustomer);
            if (fcustomer.ShowDialog() == DialogResult.Yes)
            {
                skbarValidation.Show(this, "Изменено!", BunifuSnackbar.MessageTypes.Success,
                                         2500, "", BunifuSnackbar.Positions.BottomCenter,
                                         BunifuSnackbar.Hosts.FormOwner);
                UpdateGridCustomers();
            }
        }

        private void btnRowDeleteCustomer_Click(object sender, EventArgs e)
        {
            using (var db = DataBase.ApplicationContext.GetDbConnection())
                db.Delete<Customer>(x => x.Passport == gridCustomers[3, gridCustomers.CurrentRow.Index].Value.ToString());
            UpdateGridCustomers();
        }
        #endregion

        #endregion
    }
}
