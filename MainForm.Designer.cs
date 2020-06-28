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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImages = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 426);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label_imageIndex
            // 
            this.label_imageIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_imageIndex.ForeColor = System.Drawing.SystemColors.Control;
            this.label_imageIndex.Location = new System.Drawing.Point(0, 0);
            this.label_imageIndex.Name = "label_imageIndex";
            this.label_imageIndex.Size = new System.Drawing.Size(800, 24);
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
            this.buttonNext.Location = new System.Drawing.Point(768, 0);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(32, 24);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = ">";
            this.buttonNext.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.Button_UI);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonShuffle);
            this.panel1.Controls.Add(this.buttonPrev);
            this.panel1.Controls.Add(this.buttonNext);
            this.panel1.Controls.Add(this.label_imageIndex);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 426);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 24);
            this.panel1.TabIndex = 4;
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.BackColor = System.Drawing.Color.DimGray;
            this.buttonShuffle.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonShuffle.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonShuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShuffle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShuffle.ForeColor = System.Drawing.Color.White;
            this.buttonShuffle.Location = new System.Drawing.Point(734, 0);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(34, 24);
            this.buttonShuffle.TabIndex = 4;
            this.buttonShuffle.Text = "S";
            this.buttonShuffle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonShuffle.UseVisualStyleBackColor = false;
            this.buttonShuffle.Click += new System.EventHandler(this.buttonShuffle_Click);
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
            this.buttonPrev.Size = new System.Drawing.Size(32, 24);
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
            this.openImages.Size = new System.Drawing.Size(180, 22);
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
            this.openFolder.Size = new System.Drawing.Size(180, 22);
            this.openFolder.Text = "Open Folder";
            this.openFolder.Click += new System.EventHandler(this.LoadImages);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.exitToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DimGray;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "ImageViewer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_imageIndex;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonShuffle;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImages;
        private System.Windows.Forms.ToolStripMenuItem openFolder;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

