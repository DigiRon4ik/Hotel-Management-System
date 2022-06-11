using System;
using System.Windows.Forms;

namespace Hotel_Management_System.Forms
{
    public partial class fDeletionWarning : Form
    {
        public fDeletionWarning()
        {
            InitializeComponent();
        }

        #region Кнопки
        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnImgTitleClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        #endregion
    }
}
