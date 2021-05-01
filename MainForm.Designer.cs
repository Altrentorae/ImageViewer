namespace ImageViewer {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_imageIndex = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.NavPanel = new System.Windows.Forms.Panel();
            this.VC_VolumeSlider = new System.Windows.Forms.TrackBar();
            this.VC_Slider = new System.Windows.Forms.TrackBar();
            this.VC_PP = new System.Windows.Forms.Button();
            this.button_toggleOptionsPanel = new System.Windows.Forms.Button();
            this.button_AutoNext = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.VC_StartTimeLabel = new System.Windows.Forms.Label();
            this.VC_EndTimeLabel = new System.Windows.Forms.Label();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImages = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderUnsafe = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findByIndex = new System.Windows.Forms.ToolStripMenuItem();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.autonext_Interval_Box = new System.Windows.Forms.NumericUpDown();
            this.skinGroupBox = new System.Windows.Forms.GroupBox();
            this.CustomSkin_Delete = new System.Windows.Forms.Button();
            this.customSkin_Save = new System.Windows.Forms.Button();
            this.customSkinNameBox = new System.Windows.Forms.TextBox();
            this.colorpicker_navbar = new System.Windows.Forms.Button();
            this.colorpicker_buttonOn = new System.Windows.Forms.Button();
            this.colorpicker_options = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.colorpicker_menustrip = new System.Windows.Forms.Button();
            this.colorpicker_FormBase = new System.Windows.Forms.Button();
            this.colorpicker_Text = new System.Windows.Forms.Button();
            this.skinSelectionBox = new System.Windows.Forms.ComboBox();
            this.sortOrderBox = new System.Windows.Forms.ComboBox();
            this.opt_combo_NIB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_NewImageBehaviour = new System.Windows.Forms.Label();
            this.imageNameTag = new System.Windows.Forms.Label();
            this.SystemButton_Close = new System.Windows.Forms.Button();
            this.SystemButton_Max = new System.Windows.Forms.Button();
            this.SystemButton_Min = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.NavPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VC_VolumeSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VC_Slider)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.optionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autonext_Interval_Box)).BeginInit();
            this.skinGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1104, 551);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragDrop);
            this.pictureBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragEnter);
            this.pictureBox1.DragLeave += new System.EventHandler(this.pictureBox1_DragLeave);
            // 
            // label_imageIndex
            // 
            this.label_imageIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_imageIndex.ForeColor = System.Drawing.SystemColors.Control;
            this.label_imageIndex.Location = new System.Drawing.Point(1050, 1);
            this.label_imageIndex.Name = "label_imageIndex";
            this.label_imageIndex.Size = new System.Drawing.Size(112, 23);
            this.label_imageIndex.TabIndex = 2;
            this.label_imageIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonNext
            // 
            this.buttonNext.BackColor = System.Drawing.Color.DimGray;
            this.buttonNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonNext.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNext.ForeColor = System.Drawing.Color.White;
            this.buttonNext.Location = new System.Drawing.Point(1248, 0);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(32, 27);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = ">";
            this.buttonNext.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.Button_UI);
            // 
            // NavPanel
            // 
            this.NavPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.NavPanel.Controls.Add(this.VC_VolumeSlider);
            this.NavPanel.Controls.Add(this.VC_Slider);
            this.NavPanel.Controls.Add(this.VC_PP);
            this.NavPanel.Controls.Add(this.button_toggleOptionsPanel);
            this.NavPanel.Controls.Add(this.button_AutoNext);
            this.NavPanel.Controls.Add(this.button1);
            this.NavPanel.Controls.Add(this.buttonShuffle);
            this.NavPanel.Controls.Add(this.VC_StartTimeLabel);
            this.NavPanel.Controls.Add(this.VC_EndTimeLabel);
            this.NavPanel.Controls.Add(this.buttonPrev);
            this.NavPanel.Controls.Add(this.buttonNext);
            this.NavPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.NavPanel.Location = new System.Drawing.Point(0, 572);
            this.NavPanel.Name = "NavPanel";
            this.NavPanel.Size = new System.Drawing.Size(1280, 27);
            this.NavPanel.TabIndex = 4;
            // 
            // VC_VolumeSlider
            // 
            this.VC_VolumeSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.VC_VolumeSlider.LargeChange = 1;
            this.VC_VolumeSlider.Location = new System.Drawing.Point(178, 0);
            this.VC_VolumeSlider.Maximum = 100;
            this.VC_VolumeSlider.Name = "VC_VolumeSlider";
            this.VC_VolumeSlider.Size = new System.Drawing.Size(109, 45);
            this.VC_VolumeSlider.TabIndex = 9;
            this.VC_VolumeSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.VC_VolumeSlider.ValueChanged += new System.EventHandler(this.VC_VolumeChanged);
            // 
            // VC_Slider
            // 
            this.VC_Slider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VC_Slider.LargeChange = 1;
            this.VC_Slider.Location = new System.Drawing.Point(282, 0);
            this.VC_Slider.Name = "VC_Slider";
            this.VC_Slider.Size = new System.Drawing.Size(754, 45);
            this.VC_Slider.TabIndex = 9;
            this.VC_Slider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.VC_Slider.ValueChanged += new System.EventHandler(this.VideoControl_SliderChanged);
            this.VC_Slider.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VC_Slider_MouseDown);
            this.VC_Slider.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VC_Slider_MouseUp);
            // 
            // VC_PP
            // 
            this.VC_PP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.VC_PP.BackColor = System.Drawing.Color.DimGray;
            this.VC_PP.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.VC_PP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VC_PP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VC_PP.ForeColor = System.Drawing.Color.White;
            this.VC_PP.Location = new System.Drawing.Point(68, 0);
            this.VC_PP.Name = "VC_PP";
            this.VC_PP.Size = new System.Drawing.Size(34, 27);
            this.VC_PP.TabIndex = 8;
            this.VC_PP.Text = "||";
            this.VC_PP.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.VC_PP.UseVisualStyleBackColor = false;
            this.VC_PP.Click += new System.EventHandler(this.VideoControl_PlayPause);
            // 
            // button_toggleOptionsPanel
            // 
            this.button_toggleOptionsPanel.BackColor = System.Drawing.Color.DimGray;
            this.button_toggleOptionsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_toggleOptionsPanel.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button_toggleOptionsPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_toggleOptionsPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_toggleOptionsPanel.ForeColor = System.Drawing.Color.White;
            this.button_toggleOptionsPanel.Location = new System.Drawing.Point(1112, 0);
            this.button_toggleOptionsPanel.Name = "button_toggleOptionsPanel";
            this.button_toggleOptionsPanel.Size = new System.Drawing.Size(34, 27);
            this.button_toggleOptionsPanel.TabIndex = 7;
            this.button_toggleOptionsPanel.Text = "#";
            this.button_toggleOptionsPanel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_toggleOptionsPanel.UseVisualStyleBackColor = false;
            this.button_toggleOptionsPanel.Click += new System.EventHandler(this.button_toggleOptionsPanel_Click);
            // 
            // button_AutoNext
            // 
            this.button_AutoNext.BackColor = System.Drawing.Color.DimGray;
            this.button_AutoNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_AutoNext.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button_AutoNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_AutoNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AutoNext.ForeColor = System.Drawing.Color.White;
            this.button_AutoNext.Location = new System.Drawing.Point(1146, 0);
            this.button_AutoNext.Name = "button_AutoNext";
            this.button_AutoNext.Size = new System.Drawing.Size(34, 27);
            this.button_AutoNext.TabIndex = 6;
            this.button_AutoNext.Text = "A";
            this.button_AutoNext.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_AutoNext.UseVisualStyleBackColor = false;
            this.button_AutoNext.Click += new System.EventHandler(this.button_AutoNext_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1180, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 27);
            this.button1.TabIndex = 5;
            this.button1.Text = "?";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.randomIndexButton);
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.BackColor = System.Drawing.Color.DimGray;
            this.buttonShuffle.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonShuffle.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonShuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShuffle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShuffle.ForeColor = System.Drawing.Color.White;
            this.buttonShuffle.Location = new System.Drawing.Point(1214, 0);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(34, 27);
            this.buttonShuffle.TabIndex = 4;
            this.buttonShuffle.Text = "S";
            this.buttonShuffle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonShuffle.UseVisualStyleBackColor = false;
            this.buttonShuffle.Click += new System.EventHandler(this.buttonShuffle_Click);
            // 
            // VC_StartTimeLabel
            // 
            this.VC_StartTimeLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.VC_StartTimeLabel.Location = new System.Drawing.Point(100, 3);
            this.VC_StartTimeLabel.Name = "VC_StartTimeLabel";
            this.VC_StartTimeLabel.Size = new System.Drawing.Size(82, 23);
            this.VC_StartTimeLabel.TabIndex = 2;
            this.VC_StartTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // VC_EndTimeLabel
            // 
            this.VC_EndTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.VC_EndTimeLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.VC_EndTimeLabel.Location = new System.Drawing.Point(1037, 4);
            this.VC_EndTimeLabel.Name = "VC_EndTimeLabel";
            this.VC_EndTimeLabel.Size = new System.Drawing.Size(69, 23);
            this.VC_EndTimeLabel.TabIndex = 2;
            this.VC_EndTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonPrev
            // 
            this.buttonPrev.BackColor = System.Drawing.Color.DimGray;
            this.buttonPrev.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonPrev.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrev.ForeColor = System.Drawing.Color.White;
            this.buttonPrev.Location = new System.Drawing.Point(0, 0);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(32, 27);
            this.buttonPrev.TabIndex = 3;
            this.buttonPrev.Text = "<";
            this.buttonPrev.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonPrev.UseVisualStyleBackColor = false;
            this.buttonPrev.Click += new System.EventHandler(this.Button_UI);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImages,
            this.openFolder,
            this.openFolderUnsafe,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openImages
            // 
            this.openImages.BackColor = System.Drawing.Color.DimGray;
            this.openImages.ForeColor = System.Drawing.SystemColors.Control;
            this.openImages.Image = ((System.Drawing.Image)(resources.GetObject("openImages.Image")));
            this.openImages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openImages.Name = "openImages";
            this.openImages.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openImages.ShowShortcutKeys = false;
            this.openImages.Size = new System.Drawing.Size(179, 22);
            this.openImages.Text = "&Open";
            this.openImages.Click += new System.EventHandler(this.LoadImages);
            // 
            // openFolder
            // 
            this.openFolder.BackColor = System.Drawing.Color.DimGray;
            this.openFolder.ForeColor = System.Drawing.SystemColors.Control;
            this.openFolder.Image = ((System.Drawing.Image)(resources.GetObject("openFolder.Image")));
            this.openFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFolder.Name = "openFolder";
            this.openFolder.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFolder.ShowShortcutKeys = false;
            this.openFolder.Size = new System.Drawing.Size(179, 22);
            this.openFolder.Text = "Open Folder";
            this.openFolder.Click += new System.EventHandler(this.LoadImages);
            // 
            // openFolderUnsafe
            // 
            this.openFolderUnsafe.BackColor = System.Drawing.Color.DimGray;
            this.openFolderUnsafe.ForeColor = System.Drawing.SystemColors.Control;
            this.openFolderUnsafe.Image = ((System.Drawing.Image)(resources.GetObject("openFolderUnsafe.Image")));
            this.openFolderUnsafe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFolderUnsafe.Name = "openFolderUnsafe";
            this.openFolderUnsafe.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFolderUnsafe.ShowShortcutKeys = false;
            this.openFolderUnsafe.Size = new System.Drawing.Size(179, 22);
            this.openFolderUnsafe.Text = "Open Folder (Unsafe)";
            this.openFolderUnsafe.Click += new System.EventHandler(this.openFolderUnsafe_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.exitToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DimGray;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.findToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1280, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findByIndex});
            this.findToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.findToolStripMenuItem.Text = "Find";
            // 
            // findByIndex
            // 
            this.findByIndex.BackColor = System.Drawing.Color.DimGray;
            this.findByIndex.ForeColor = System.Drawing.Color.White;
            this.findByIndex.Name = "findByIndex";
            this.findByIndex.Size = new System.Drawing.Size(103, 22);
            this.findByIndex.Text = "Index";
            this.findByIndex.Click += new System.EventHandler(this.findByIndex_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 24);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(1100, 551);
            this.axWindowsMediaPlayer1.TabIndex = 5;
            this.axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.VideoPlayer_StateChange);
            // 
            // optionsPanel
            // 
            this.optionsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.optionsPanel.Controls.Add(this.autonext_Interval_Box);
            this.optionsPanel.Controls.Add(this.skinGroupBox);
            this.optionsPanel.Controls.Add(this.skinSelectionBox);
            this.optionsPanel.Controls.Add(this.sortOrderBox);
            this.optionsPanel.Controls.Add(this.opt_combo_NIB);
            this.optionsPanel.Controls.Add(this.label4);
            this.optionsPanel.Controls.Add(this.label2);
            this.optionsPanel.Controls.Add(this.label1);
            this.optionsPanel.Controls.Add(this.label_NewImageBehaviour);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.optionsPanel.Location = new System.Drawing.Point(1100, 24);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(180, 548);
            this.optionsPanel.TabIndex = 6;
            // 
            // autonext_Interval_Box
            // 
            this.autonext_Interval_Box.Location = new System.Drawing.Point(9, 350);
            this.autonext_Interval_Box.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.autonext_Interval_Box.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.autonext_Interval_Box.Name = "autonext_Interval_Box";
            this.autonext_Interval_Box.Size = new System.Drawing.Size(64, 20);
            this.autonext_Interval_Box.TabIndex = 3;
            this.autonext_Interval_Box.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // skinGroupBox
            // 
            this.skinGroupBox.Controls.Add(this.CustomSkin_Delete);
            this.skinGroupBox.Controls.Add(this.customSkin_Save);
            this.skinGroupBox.Controls.Add(this.customSkinNameBox);
            this.skinGroupBox.Controls.Add(this.colorpicker_navbar);
            this.skinGroupBox.Controls.Add(this.colorpicker_buttonOn);
            this.skinGroupBox.Controls.Add(this.colorpicker_options);
            this.skinGroupBox.Controls.Add(this.label3);
            this.skinGroupBox.Controls.Add(this.colorpicker_menustrip);
            this.skinGroupBox.Controls.Add(this.colorpicker_FormBase);
            this.skinGroupBox.Controls.Add(this.colorpicker_Text);
            this.skinGroupBox.ForeColor = System.Drawing.SystemColors.Control;
            this.skinGroupBox.Location = new System.Drawing.Point(12, 149);
            this.skinGroupBox.Name = "skinGroupBox";
            this.skinGroupBox.Size = new System.Drawing.Size(156, 171);
            this.skinGroupBox.TabIndex = 2;
            this.skinGroupBox.TabStop = false;
            this.skinGroupBox.Text = "Skin Settings";
            // 
            // CustomSkin_Delete
            // 
            this.CustomSkin_Delete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CustomSkin_Delete.Location = new System.Drawing.Point(88, 142);
            this.CustomSkin_Delete.Name = "CustomSkin_Delete";
            this.CustomSkin_Delete.Size = new System.Drawing.Size(62, 23);
            this.CustomSkin_Delete.TabIndex = 2;
            this.CustomSkin_Delete.Text = "Delete";
            this.CustomSkin_Delete.UseVisualStyleBackColor = true;
            this.CustomSkin_Delete.Click += new System.EventHandler(this.customSkin_Delete);
            // 
            // customSkin_Save
            // 
            this.customSkin_Save.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.customSkin_Save.Location = new System.Drawing.Point(6, 142);
            this.customSkin_Save.Name = "customSkin_Save";
            this.customSkin_Save.Size = new System.Drawing.Size(62, 23);
            this.customSkin_Save.TabIndex = 2;
            this.customSkin_Save.Text = "Save";
            this.customSkin_Save.UseVisualStyleBackColor = true;
            this.customSkin_Save.Click += new System.EventHandler(this.customSkin_Save_Click);
            // 
            // customSkinNameBox
            // 
            this.customSkinNameBox.Location = new System.Drawing.Point(6, 119);
            this.customSkinNameBox.Name = "customSkinNameBox";
            this.customSkinNameBox.Size = new System.Drawing.Size(144, 20);
            this.customSkinNameBox.TabIndex = 1;
            // 
            // colorpicker_navbar
            // 
            this.colorpicker_navbar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.colorpicker_navbar.Location = new System.Drawing.Point(6, 77);
            this.colorpicker_navbar.Name = "colorpicker_navbar";
            this.colorpicker_navbar.Size = new System.Drawing.Size(62, 23);
            this.colorpicker_navbar.TabIndex = 0;
            this.colorpicker_navbar.Text = "Nav";
            this.colorpicker_navbar.UseVisualStyleBackColor = true;
            this.colorpicker_navbar.Click += new System.EventHandler(this.CustomSkin_ButtonClicked);
            // 
            // colorpicker_buttonOn
            // 
            this.colorpicker_buttonOn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.colorpicker_buttonOn.Location = new System.Drawing.Point(88, 77);
            this.colorpicker_buttonOn.Name = "colorpicker_buttonOn";
            this.colorpicker_buttonOn.Size = new System.Drawing.Size(62, 23);
            this.colorpicker_buttonOn.TabIndex = 0;
            this.colorpicker_buttonOn.Text = "Enabled";
            this.colorpicker_buttonOn.UseVisualStyleBackColor = true;
            this.colorpicker_buttonOn.Click += new System.EventHandler(this.CustomSkin_ButtonClicked);
            // 
            // colorpicker_options
            // 
            this.colorpicker_options.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.colorpicker_options.Location = new System.Drawing.Point(6, 48);
            this.colorpicker_options.Name = "colorpicker_options";
            this.colorpicker_options.Size = new System.Drawing.Size(62, 23);
            this.colorpicker_options.TabIndex = 0;
            this.colorpicker_options.Text = "Options";
            this.colorpicker_options.UseVisualStyleBackColor = true;
            this.colorpicker_options.Click += new System.EventHandler(this.CustomSkin_ButtonClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(6, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Skin Name";
            // 
            // colorpicker_menustrip
            // 
            this.colorpicker_menustrip.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.colorpicker_menustrip.Location = new System.Drawing.Point(88, 48);
            this.colorpicker_menustrip.Name = "colorpicker_menustrip";
            this.colorpicker_menustrip.Size = new System.Drawing.Size(62, 23);
            this.colorpicker_menustrip.TabIndex = 0;
            this.colorpicker_menustrip.Text = "Menu Bar";
            this.colorpicker_menustrip.UseVisualStyleBackColor = true;
            this.colorpicker_menustrip.Click += new System.EventHandler(this.CustomSkin_ButtonClicked);
            // 
            // colorpicker_FormBase
            // 
            this.colorpicker_FormBase.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.colorpicker_FormBase.Location = new System.Drawing.Point(6, 19);
            this.colorpicker_FormBase.Name = "colorpicker_FormBase";
            this.colorpicker_FormBase.Size = new System.Drawing.Size(62, 23);
            this.colorpicker_FormBase.TabIndex = 0;
            this.colorpicker_FormBase.Text = "Base";
            this.colorpicker_FormBase.UseVisualStyleBackColor = true;
            this.colorpicker_FormBase.Click += new System.EventHandler(this.CustomSkin_ButtonClicked);
            // 
            // colorpicker_Text
            // 
            this.colorpicker_Text.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.colorpicker_Text.Location = new System.Drawing.Point(88, 19);
            this.colorpicker_Text.Name = "colorpicker_Text";
            this.colorpicker_Text.Size = new System.Drawing.Size(62, 23);
            this.colorpicker_Text.TabIndex = 0;
            this.colorpicker_Text.Text = "Text";
            this.colorpicker_Text.UseVisualStyleBackColor = true;
            this.colorpicker_Text.Click += new System.EventHandler(this.CustomSkin_ButtonClicked);
            // 
            // skinSelectionBox
            // 
            this.skinSelectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinSelectionBox.FormattingEnabled = true;
            this.skinSelectionBox.Location = new System.Drawing.Point(9, 122);
            this.skinSelectionBox.Name = "skinSelectionBox";
            this.skinSelectionBox.Size = new System.Drawing.Size(156, 21);
            this.skinSelectionBox.TabIndex = 1;
            this.skinSelectionBox.SelectedIndexChanged += new System.EventHandler(this.SkinSelectionChanged);
            // 
            // sortOrderBox
            // 
            this.sortOrderBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortOrderBox.FormattingEnabled = true;
            this.sortOrderBox.Items.AddRange(new object[] {
            "Date Modified (Newest)",
            "Date Modified (Oldest)",
            "Date Created (Newest)",
            "Date Created (Oldest)",
            "None"});
            this.sortOrderBox.Location = new System.Drawing.Point(9, 73);
            this.sortOrderBox.Name = "sortOrderBox";
            this.sortOrderBox.Size = new System.Drawing.Size(156, 21);
            this.sortOrderBox.TabIndex = 1;
            this.sortOrderBox.SelectedIndexChanged += new System.EventHandler(this.sortOrderChanged);
            // 
            // opt_combo_NIB
            // 
            this.opt_combo_NIB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.opt_combo_NIB.FormattingEnabled = true;
            this.opt_combo_NIB.Items.AddRange(new object[] {
            "Replace",
            "Additive (End)",
            "Additive (Start)"});
            this.opt_combo_NIB.Location = new System.Drawing.Point(9, 25);
            this.opt_combo_NIB.Name = "opt_combo_NIB";
            this.opt_combo_NIB.Size = new System.Drawing.Size(156, 21);
            this.opt_combo_NIB.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(6, 334);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Auto Interval";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(6, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Skin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(6, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sorting Order";
            // 
            // label_NewImageBehaviour
            // 
            this.label_NewImageBehaviour.AutoSize = true;
            this.label_NewImageBehaviour.ForeColor = System.Drawing.SystemColors.Control;
            this.label_NewImageBehaviour.Location = new System.Drawing.Point(6, 9);
            this.label_NewImageBehaviour.Name = "label_NewImageBehaviour";
            this.label_NewImageBehaviour.Size = new System.Drawing.Size(112, 13);
            this.label_NewImageBehaviour.TabIndex = 0;
            this.label_NewImageBehaviour.Text = "New Image Behaviour";
            // 
            // imageNameTag
            // 
            this.imageNameTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageNameTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageNameTag.ForeColor = System.Drawing.SystemColors.Control;
            this.imageNameTag.Location = new System.Drawing.Point(103, 1);
            this.imageNameTag.Name = "imageNameTag";
            this.imageNameTag.Size = new System.Drawing.Size(933, 21);
            this.imageNameTag.TabIndex = 7;
            this.imageNameTag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.imageNameTag.DoubleClick += new System.EventHandler(this.imageNameTag_DoubleClick);
            // 
            // SystemButton_Close
            // 
            this.SystemButton_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SystemButton_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SystemButton_Close.ForeColor = System.Drawing.Color.White;
            this.SystemButton_Close.Location = new System.Drawing.Point(1244, 1);
            this.SystemButton_Close.Name = "SystemButton_Close";
            this.SystemButton_Close.Size = new System.Drawing.Size(32, 23);
            this.SystemButton_Close.TabIndex = 8;
            this.SystemButton_Close.Text = "X";
            this.SystemButton_Close.UseVisualStyleBackColor = true;
            this.SystemButton_Close.Click += new System.EventHandler(this.SystemButton_Close_Click);
            // 
            // SystemButton_Max
            // 
            this.SystemButton_Max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SystemButton_Max.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SystemButton_Max.ForeColor = System.Drawing.Color.White;
            this.SystemButton_Max.Location = new System.Drawing.Point(1206, 1);
            this.SystemButton_Max.Name = "SystemButton_Max";
            this.SystemButton_Max.Size = new System.Drawing.Size(32, 23);
            this.SystemButton_Max.TabIndex = 8;
            this.SystemButton_Max.Text = "";
            this.SystemButton_Max.UseVisualStyleBackColor = true;
            this.SystemButton_Max.Click += new System.EventHandler(this.SystemButton_Max_Click);
            // 
            // SystemButton_Min
            // 
            this.SystemButton_Min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SystemButton_Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SystemButton_Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SystemButton_Min.ForeColor = System.Drawing.Color.White;
            this.SystemButton_Min.Location = new System.Drawing.Point(1168, 1);
            this.SystemButton_Min.Name = "SystemButton_Min";
            this.SystemButton_Min.Size = new System.Drawing.Size(32, 23);
            this.SystemButton_Min.TabIndex = 8;
            this.SystemButton_Min.Text = "-";
            this.SystemButton_Min.UseVisualStyleBackColor = true;
            this.SystemButton_Min.Click += new System.EventHandler(this.SystemButton_Min_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1280, 599);
            this.Controls.Add(this.label_imageIndex);
            this.Controls.Add(this.SystemButton_Min);
            this.Controls.Add(this.SystemButton_Max);
            this.Controls.Add(this.SystemButton_Close);
            this.Controls.Add(this.imageNameTag);
            this.Controls.Add(this.optionsPanel);
            this.Controls.Add(this.NavPanel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "ImageViewer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.NavPanel.ResumeLayout(false);
            this.NavPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VC_VolumeSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VC_Slider)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autonext_Interval_Box)).EndInit();
            this.skinGroupBox.ResumeLayout(false);
            this.skinGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_imageIndex;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Panel NavPanel;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonShuffle;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImages;
        private System.Windows.Forms.ToolStripMenuItem openFolder;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findByIndex;
        private System.Windows.Forms.Button button_AutoNext;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.Button button_toggleOptionsPanel;
        private System.Windows.Forms.ComboBox opt_combo_NIB;
        private System.Windows.Forms.Label label_NewImageBehaviour;
        private System.Windows.Forms.ToolStripMenuItem openFolderUnsafe;
        private System.Windows.Forms.Label imageNameTag;
        private System.Windows.Forms.ComboBox sortOrderBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox skinGroupBox;
        private System.Windows.Forms.ComboBox skinSelectionBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button colorpicker_Text;
        private System.Windows.Forms.Button colorpicker_navbar;
        private System.Windows.Forms.Button colorpicker_buttonOn;
        private System.Windows.Forms.Button colorpicker_options;
        private System.Windows.Forms.Button colorpicker_menustrip;
        private System.Windows.Forms.Button colorpicker_FormBase;
        private System.Windows.Forms.Button CustomSkin_Delete;
        private System.Windows.Forms.Button customSkin_Save;
        private System.Windows.Forms.TextBox customSkinNameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown autonext_Interval_Box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SystemButton_Close;
        private System.Windows.Forms.Button SystemButton_Max;
        private System.Windows.Forms.Button SystemButton_Min;
        private System.Windows.Forms.TrackBar VC_Slider;
        private System.Windows.Forms.Button VC_PP;
        private System.Windows.Forms.Label VC_StartTimeLabel;
        private System.Windows.Forms.Label VC_EndTimeLabel;
        private System.Windows.Forms.TrackBar VC_VolumeSlider;
    }
}

