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
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.pnlTitle = new Bunifu.UI.WinForms.BunifuPanel();
            this.pctrIcon = new System.Windows.Forms.PictureBox();
            this.btnImgTitleClose = new Bunifu.UI.WinForms.BunifuImageButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlForm = new Bunifu.UI.WinForms.BunifuPanel();
            this.ElipseFormUser = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.FormDock = new Bunifu.UI.WinForms.BunifuFormDock();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.btnAddOrChange = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.bnfUserImage = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.txtLogin = new Bunifu.UI.WinForms.BunifuTextBox();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrIcon)).BeginInit();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnfUserImage)).BeginInit();
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
            this.pnlTitle.Size = new System.Drawing.Size(500, 36);
            this.pnlTitle.TabIndex = 0;
            // 
            // pctrIcon
            // 
            this.pctrIcon.BackColor = System.Drawing.Color.Transparent;
            this.pctrIcon.Cursor = System.Windows.Forms.Cursors.Default;
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
            this.btnImgTitleClose.Location = new System.Drawing.Point(465, 1);
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
            this.pnlForm.Controls.Add(this.txtLogin);
            this.pnlForm.Controls.Add(this.bnfUserImage);
            this.pnlForm.Controls.Add(this.btnAddOrChange);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 36);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.ShowBorders = true;
            this.pnlForm.Size = new System.Drawing.Size(500, 564);
            this.pnlForm.TabIndex = 0;
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
            // imgList
            // 
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnAddOrChange
            // 
            this.btnAddOrChange.AllowAnimations = true;
            this.btnAddOrChange.AllowMouseEffects = true;
            this.btnAddOrChange.AllowToggling = false;
            this.btnAddOrChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddOrChange.AnimationSpeed = 200;
            this.btnAddOrChange.AutoGenerateColors = false;
            this.btnAddOrChange.AutoRoundBorders = false;
            this.btnAddOrChange.AutoSizeLeftIcon = true;
            this.btnAddOrChange.AutoSizeRightIcon = true;
            this.btnAddOrChange.BackColor = System.Drawing.Color.Transparent;
            this.btnAddOrChange.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(17)))), ((int)(((byte)(37)))));
            this.btnAddOrChange.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddOrChange.BackgroundImage")));
            this.btnAddOrChange.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Dash;
            this.btnAddOrChange.ButtonText = "ДОБАВИТЬ/ИЗМЕНИТЬ";
            this.btnAddOrChange.ButtonTextMarginLeft = 0;
            this.btnAddOrChange.ColorContrastOnClick = 45;
            this.btnAddOrChange.ColorContrastOnHover = 45;
            this.btnAddOrChange.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnAddOrChange.CustomizableEdges = borderEdges1;
            this.btnAddOrChange.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddOrChange.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAddOrChange.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddOrChange.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAddOrChange.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
            this.btnAddOrChange.Font = new System.Drawing.Font("Leto Text Sans Defect", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddOrChange.ForeColor = System.Drawing.Color.White;
            this.btnAddOrChange.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddOrChange.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddOrChange.IconLeftPadding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnAddOrChange.IconMarginLeft = 11;
            this.btnAddOrChange.IconPadding = 6;
            this.btnAddOrChange.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddOrChange.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddOrChange.IconRightPadding = new System.Windows.Forms.Padding(0, 0, 18, 0);
            this.btnAddOrChange.IconSize = 32;
            this.btnAddOrChange.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(120)))), ((int)(((byte)(170)))));
            this.btnAddOrChange.IdleBorderRadius = 20;
            this.btnAddOrChange.IdleBorderThickness = 2;
            this.btnAddOrChange.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(17)))), ((int)(((byte)(37)))));
            this.btnAddOrChange.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnAddOrChange.IdleIconLeftImage")));
            this.btnAddOrChange.IdleIconRightImage = ((System.Drawing.Image)(resources.GetObject("btnAddOrChange.IdleIconRightImage")));
            this.btnAddOrChange.IndicateFocus = false;
            this.btnAddOrChange.Location = new System.Drawing.Point(10, 514);
            this.btnAddOrChange.Name = "btnAddOrChange";
            this.btnAddOrChange.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAddOrChange.OnDisabledState.BorderRadius = 20;
            this.btnAddOrChange.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAddOrChange.OnDisabledState.BorderThickness = 2;
            this.btnAddOrChange.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddOrChange.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAddOrChange.OnDisabledState.IconLeftImage = null;
            this.btnAddOrChange.OnDisabledState.IconRightImage = null;
            this.btnAddOrChange.onHoverState.BorderColor = System.Drawing.Color.Lime;
            this.btnAddOrChange.onHoverState.BorderRadius = 20;
            this.btnAddOrChange.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Dash;
            this.btnAddOrChange.onHoverState.BorderThickness = 2;
            this.btnAddOrChange.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(17)))), ((int)(((byte)(37)))));
            this.btnAddOrChange.onHoverState.ForeColor = System.Drawing.Color.Lime;
            this.btnAddOrChange.onHoverState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("resource.IconLeftImage")));
            this.btnAddOrChange.onHoverState.IconRightImage = ((System.Drawing.Image)(resources.GetObject("resource.IconRightImage")));
            this.btnAddOrChange.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(120)))), ((int)(((byte)(170)))));
            this.btnAddOrChange.OnIdleState.BorderRadius = 20;
            this.btnAddOrChange.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Dash;
            this.btnAddOrChange.OnIdleState.BorderThickness = 2;
            this.btnAddOrChange.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(17)))), ((int)(((byte)(37)))));
            this.btnAddOrChange.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnAddOrChange.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnRowAddUser.OnIdleState.IconLeftImage")));
            this.btnAddOrChange.OnIdleState.IconRightImage = ((System.Drawing.Image)(resources.GetObject("btnRowAddUser.OnIdleState.IconRightImage")));
            this.btnAddOrChange.OnPressedState.BorderColor = System.Drawing.Color.Green;
            this.btnAddOrChange.OnPressedState.BorderRadius = 20;
            this.btnAddOrChange.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Dash;
            this.btnAddOrChange.OnPressedState.BorderThickness = 2;
            this.btnAddOrChange.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(17)))), ((int)(((byte)(37)))));
            this.btnAddOrChange.OnPressedState.ForeColor = System.Drawing.Color.Green;
            this.btnAddOrChange.OnPressedState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("resource.IconLeftImage1")));
            this.btnAddOrChange.OnPressedState.IconRightImage = ((System.Drawing.Image)(resources.GetObject("resource.IconRightImage1")));
            this.btnAddOrChange.Size = new System.Drawing.Size(480, 40);
            this.btnAddOrChange.TabIndex = 0;
            this.btnAddOrChange.TabStop = false;
            this.btnAddOrChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddOrChange.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAddOrChange.TextMarginLeft = 0;
            this.btnAddOrChange.TextPadding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnAddOrChange.UseDefaultRadiusAndThickness = true;
            // 
            // bnfUserImage
            // 
            this.bnfUserImage.AllowFocused = false;
            this.bnfUserImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.bnfUserImage.AutoSizeHeight = false;
            this.bnfUserImage.BackColor = System.Drawing.Color.Transparent;
            this.bnfUserImage.BorderRadius = 20;
            this.bnfUserImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bnfUserImage.Image = global::Hotel_Management_System.Properties.Resources.Contact_512;
            this.bnfUserImage.IsCircle = false;
            this.bnfUserImage.Location = new System.Drawing.Point(10, 10);
            this.bnfUserImage.Name = "bnfUserImage";
            this.bnfUserImage.Size = new System.Drawing.Size(160, 160);
            this.bnfUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bnfUserImage.TabIndex = 3;
            this.bnfUserImage.TabStop = false;
            this.bnfUserImage.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Custom;
            // 
            // txtLogin
            // 
            this.txtLogin.AcceptsReturn = false;
            this.txtLogin.AcceptsTab = false;
            this.txtLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogin.AnimationSpeed = 200;
            this.txtLogin.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtLogin.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtLogin.AutoSizeHeight = true;
            this.txtLogin.BackColor = System.Drawing.Color.Transparent;
            this.txtLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtLogin.BackgroundImage")));
            this.txtLogin.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(92)))), ((int)(((byte)(169)))));
            this.txtLogin.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtLogin.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(71)))), ((int)(((byte)(128)))));
            this.txtLogin.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(120)))), ((int)(((byte)(170)))));
            this.txtLogin.BorderRadius = 10;
            this.txtLogin.BorderThickness = 2;
            this.txtLogin.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtLogin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLogin.DefaultFont = new System.Drawing.Font("Segoe UI", 10.75F);
            this.txtLogin.DefaultText = "";
            this.txtLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(17)))), ((int)(((byte)(37)))));
            this.txtLogin.ForeColor = System.Drawing.Color.White;
            this.txtLogin.HideSelection = true;
            this.txtLogin.IconLeft = global::Hotel_Management_System.Properties.Resources.UserLogin_32;
            this.txtLogin.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLogin.IconPadding = 7;
            this.txtLogin.IconRight = null;
            this.txtLogin.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLogin.Lines = new string[0];
            this.txtLogin.Location = new System.Drawing.Point(176, 23);
            this.txtLogin.MaxLength = 30;
            this.txtLogin.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtLogin.Modified = false;
            this.txtLogin.Multiline = false;
            this.txtLogin.Name = "txtLogin";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(92)))), ((int)(((byte)(169)))));
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtLogin.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtLogin.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(71)))), ((int)(((byte)(128)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtLogin.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(120)))), ((int)(((byte)(170)))));
            stateProperties4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(17)))), ((int)(((byte)(37)))));
            stateProperties4.ForeColor = System.Drawing.Color.White;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtLogin.OnIdleState = stateProperties4;
            this.txtLogin.Padding = new System.Windows.Forms.Padding(3);
            this.txtLogin.PasswordChar = '\0';
            this.txtLogin.PlaceholderForeColor = System.Drawing.Color.Gainsboro;
            this.txtLogin.PlaceholderText = "Логин";
            this.txtLogin.ReadOnly = false;
            this.txtLogin.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLogin.SelectedText = "";
            this.txtLogin.SelectionLength = 0;
            this.txtLogin.SelectionStart = 0;
            this.txtLogin.ShortcutsEnabled = true;
            this.txtLogin.Size = new System.Drawing.Size(314, 40);
            this.txtLogin.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtLogin.TabIndex = 4;
            this.txtLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtLogin.TextMarginBottom = 0;
            this.txtLogin.TextMarginLeft = 5;
            this.txtLogin.TextMarginTop = 1;
            this.txtLogin.TextPlaceholder = "Логин";
            this.txtLogin.UseSystemPasswordChar = false;
            this.txtLogin.WordWrap = true;
            // 
            // fUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(28)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlTitle);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Д/И Пользователя";
            this.TopMost = true;
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrIcon)).EndInit();
            this.pnlForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bnfUserImage)).EndInit();
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
        private System.Windows.Forms.ImageList imgList;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnAddOrChange;
        private Bunifu.UI.WinForms.BunifuPictureBox bnfUserImage;
        private Bunifu.UI.WinForms.BunifuTextBox txtLogin;
    }
}