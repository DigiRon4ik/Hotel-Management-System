namespace Hotel_Management_System.Forms
{
    partial class fUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fUser));
            this.pnlTitle = new Bunifu.UI.WinForms.BunifuPanel();
            this.pctrIcon = new System.Windows.Forms.PictureBox();
            this.btnImgTitleClose = new Bunifu.UI.WinForms.BunifuImageButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlForm = new Bunifu.UI.WinForms.BunifuPanel();
            this.ElipseFormUser = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.FormDock = new Bunifu.UI.WinForms.BunifuFormDock();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.pnlTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTitle.BackgroundImage")));
            this.pnlTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTitle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.pnlTitle.BorderRadius = 0;
            this.pnlTitle.BorderThickness = 0;
            this.pnlTitle.Controls.Add(this.pctrIcon);
            this.pnlTitle.Controls.Add(this.btnImgTitleClose);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.ShowBorders = true;
            this.pnlTitle.Size = new System.Drawing.Size(800, 36);
            this.pnlTitle.TabIndex = 0;
            // 
            // pctrIcon
            // 
            this.pctrIcon.BackColor = System.Drawing.Color.Transparent;
            this.pctrIcon.Cursor = System.Windows.Forms.Cursors.Default;
            this.pctrIcon.Image = global::Hotel_Management_System.Properties.Resources.Hide_Sidepanel_32;
            this.pctrIcon.Location = new System.Drawing.Point(9, 2);
            this.pctrIcon.Name = "pctrIcon";
            this.pctrIcon.Size = new System.Drawing.Size(32, 32);
            this.pctrIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctrIcon.TabIndex = 1;
            this.pctrIcon.TabStop = false;
            // 
            // btnImgTitleClose
            // 
            this.btnImgTitleClose.ActiveImage = global::Hotel_Management_System.Properties.Resources.Close_Window_Red_32;
            this.btnImgTitleClose.AllowAnimations = true;
            this.btnImgTitleClose.AllowBuffering = true;
            this.btnImgTitleClose.AllowToggling = false;
            this.btnImgTitleClose.AllowZooming = true;
            this.btnImgTitleClose.AllowZoomingOnFocus = false;
            this.btnImgTitleClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImgTitleClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.btnImgTitleClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnImgTitleClose.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnImgTitleClose.ErrorImage")));
            this.btnImgTitleClose.FadeWhenInactive = false;
            this.btnImgTitleClose.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnImgTitleClose.Image = global::Hotel_Management_System.Properties.Resources.Close_Window_32;
            this.btnImgTitleClose.ImageActive = global::Hotel_Management_System.Properties.Resources.Close_Window_Red_32;
            this.btnImgTitleClose.ImageLocation = null;
            this.btnImgTitleClose.ImageMargin = 10;
            this.btnImgTitleClose.ImageSize = new System.Drawing.Size(24, 24);
            this.btnImgTitleClose.ImageZoomSize = new System.Drawing.Size(34, 34);
            this.btnImgTitleClose.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnImgTitleClose.InitialImage")));
            this.btnImgTitleClose.Location = new System.Drawing.Point(765, 1);
            this.btnImgTitleClose.Name = "btnImgTitleClose";
            this.btnImgTitleClose.Rotation = 0;
            this.btnImgTitleClose.ShowActiveImage = true;
            this.btnImgTitleClose.ShowCursorChanges = true;
            this.btnImgTitleClose.ShowImageBorders = false;
            this.btnImgTitleClose.ShowSizeMarkers = false;
            this.btnImgTitleClose.Size = new System.Drawing.Size(34, 34);
            this.btnImgTitleClose.TabIndex = 0;
            this.btnImgTitleClose.TabStop = false;
            this.btnImgTitleClose.ToolTipText = "";
            this.btnImgTitleClose.WaitOnLoad = false;
            this.btnImgTitleClose.Zoom = 10;
            this.btnImgTitleClose.ZoomSpeed = 10;
            this.btnImgTitleClose.Click += new System.EventHandler(this.btnImgTitleClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Tektur Med", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(46, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(204, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Д/И Пользователя";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlForm
            // 
            this.pnlForm.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(17)))), ((int)(((byte)(37)))));
            this.pnlForm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlForm.BackgroundImage")));
            this.pnlForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlForm.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(17)))), ((int)(((byte)(37)))));
            this.pnlForm.BorderRadius = 0;
            this.pnlForm.BorderThickness = 0;
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 36);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.ShowBorders = true;
            this.pnlForm.Size = new System.Drawing.Size(800, 414);
            this.pnlForm.TabIndex = 2;
            // 
            // ElipseFormUser
            // 
            this.ElipseFormUser.ElipseRadius = 5;
            this.ElipseFormUser.TargetControl = this;
            // 
            // FormDock
            // 
            this.FormDock.AllowFormDragging = false;
            this.FormDock.AllowFormDropShadow = true;
            this.FormDock.AllowFormResizing = false;
            this.FormDock.AllowHidingBottomRegion = true;
            this.FormDock.AllowOpacityChangesWhileDragging = true;
            this.FormDock.BorderOptions.BottomBorder.BorderColor = System.Drawing.Color.Silver;
            this.FormDock.BorderOptions.BottomBorder.BorderThickness = 1;
            this.FormDock.BorderOptions.BottomBorder.ShowBorder = true;
            this.FormDock.BorderOptions.LeftBorder.BorderColor = System.Drawing.Color.Silver;
            this.FormDock.BorderOptions.LeftBorder.BorderThickness = 1;
            this.FormDock.BorderOptions.LeftBorder.ShowBorder = true;
            this.FormDock.BorderOptions.RightBorder.BorderColor = System.Drawing.Color.Silver;
            this.FormDock.BorderOptions.RightBorder.BorderThickness = 1;
            this.FormDock.BorderOptions.RightBorder.ShowBorder = true;
            this.FormDock.BorderOptions.TopBorder.BorderColor = System.Drawing.Color.Silver;
            this.FormDock.BorderOptions.TopBorder.BorderThickness = 1;
            this.FormDock.BorderOptions.TopBorder.ShowBorder = true;
            this.FormDock.ContainerControl = this;
            this.FormDock.DockingIndicatorsColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(215)))), ((int)(((byte)(233)))));
            this.FormDock.DockingIndicatorsOpacity = 0.5D;
            this.FormDock.DockingOptions.DockAll = false;
            this.FormDock.DockingOptions.DockBottomLeft = false;
            this.FormDock.DockingOptions.DockBottomRight = false;
            this.FormDock.DockingOptions.DockFullScreen = false;
            this.FormDock.DockingOptions.DockLeft = false;
            this.FormDock.DockingOptions.DockRight = false;
            this.FormDock.DockingOptions.DockTopLeft = false;
            this.FormDock.DockingOptions.DockTopRight = false;
            this.FormDock.FormDraggingOpacity = 0.95D;
            this.FormDock.ParentForm = this;
            this.FormDock.ShowCursorChanges = false;
            this.FormDock.ShowDockingIndicators = true;
            this.FormDock.TitleBarOptions.AllowFormDragging = true;
            this.FormDock.TitleBarOptions.BunifuFormDock = this.FormDock;
            this.FormDock.TitleBarOptions.DoubleClickToExpandWindow = false;
            this.FormDock.TitleBarOptions.TitleBarControl = this.pnlTitle;
            this.FormDock.TitleBarOptions.UseBackColorOnDockingIndicators = false;
            // 
            // fUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(28)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlTitle);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Д/И Пользователя";
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel pnlTitle;
        private System.Windows.Forms.PictureBox pctrIcon;
        private Bunifu.UI.WinForms.BunifuImageButton btnImgTitleClose;
        private System.Windows.Forms.Label lblTitle;
        private Bunifu.UI.WinForms.BunifuPanel pnlForm;
        private Bunifu.Framework.UI.BunifuElipse ElipseFormUser;
        private Bunifu.UI.WinForms.BunifuFormDock FormDock;
    }
}