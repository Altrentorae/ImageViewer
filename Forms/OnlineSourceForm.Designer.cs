namespace ImageViewer
{
    partial class OnlineSourceForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.derpi_checkbox = new System.Windows.Forms.CheckBox();
            this.R34_checkbox = new System.Windows.Forms.CheckBox();
            this.Search_ClearAll = new System.Windows.Forms.Button();
            this.Search_SelectAll = new System.Windows.Forms.Button();
            this.search_searchAndClose_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.imageAmount_numericBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.search_richTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.URL_Load_button = new System.Windows.Forms.Button();
            this.URL_LoadAndClose_button = new System.Windows.Forms.Button();
            this.fromURL_textbox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.STATUS_LABEL = new System.Windows.Forms.ToolStripStatusLabel();
            this.E6_checkbox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageAmount_numericBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.Search_ClearAll);
            this.groupBox1.Controls.Add(this.Search_SelectAll);
            this.groupBox1.Controls.Add(this.search_searchAndClose_Button);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.imageAmount_numericBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.search_richTextBox);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 393);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Gray;
            this.groupBox3.Controls.Add(this.E6_checkbox);
            this.groupBox3.Controls.Add(this.derpi_checkbox);
            this.groupBox3.Controls.Add(this.R34_checkbox);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(6, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(390, 161);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sources";
            // 
            // derpi_checkbox
            // 
            this.derpi_checkbox.AutoSize = true;
            this.derpi_checkbox.Location = new System.Drawing.Point(288, 57);
            this.derpi_checkbox.Name = "derpi_checkbox";
            this.derpi_checkbox.Size = new System.Drawing.Size(96, 17);
            this.derpi_checkbox.TabIndex = 0;
            this.derpi_checkbox.Text = "Derpibooru.org";
            this.derpi_checkbox.UseVisualStyleBackColor = true;
            // 
            // R34_checkbox
            // 
            this.R34_checkbox.AutoSize = true;
            this.R34_checkbox.Location = new System.Drawing.Point(288, 11);
            this.R34_checkbox.Name = "R34_checkbox";
            this.R34_checkbox.Size = new System.Drawing.Size(78, 17);
            this.R34_checkbox.TabIndex = 0;
            this.R34_checkbox.Text = "Rule34.xxx";
            this.R34_checkbox.UseVisualStyleBackColor = true;
            // 
            // Search_ClearAll
            // 
            this.Search_ClearAll.Location = new System.Drawing.Point(402, 42);
            this.Search_ClearAll.Name = "Search_ClearAll";
            this.Search_ClearAll.Size = new System.Drawing.Size(71, 25);
            this.Search_ClearAll.TabIndex = 5;
            this.Search_ClearAll.Text = "Clear All";
            this.Search_ClearAll.UseVisualStyleBackColor = true;
            // 
            // Search_SelectAll
            // 
            this.Search_SelectAll.Location = new System.Drawing.Point(402, 11);
            this.Search_SelectAll.Name = "Search_SelectAll";
            this.Search_SelectAll.Size = new System.Drawing.Size(71, 25);
            this.Search_SelectAll.TabIndex = 5;
            this.Search_SelectAll.Text = "Select All";
            this.Search_SelectAll.UseVisualStyleBackColor = true;
            // 
            // search_searchAndClose_Button
            // 
            this.search_searchAndClose_Button.Location = new System.Drawing.Point(13, 343);
            this.search_searchAndClose_Button.Name = "search_searchAndClose_Button";
            this.search_searchAndClose_Button.Size = new System.Drawing.Size(121, 31);
            this.search_searchAndClose_Button.TabIndex = 5;
            this.search_searchAndClose_Button.Text = "Search and Close";
            this.search_searchAndClose_Button.UseVisualStyleBackColor = true;
            this.search_searchAndClose_Button.Click += new System.EventHandler(this.search_searchAndClose_Button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Image Amount";
            // 
            // imageAmount_numericBox
            // 
            this.imageAmount_numericBox.Location = new System.Drawing.Point(378, 191);
            this.imageAmount_numericBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.imageAmount_numericBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.imageAmount_numericBox.Name = "imageAmount_numericBox";
            this.imageAmount_numericBox.Size = new System.Drawing.Size(85, 20);
            this.imageAmount_numericBox.TabIndex = 3;
            this.imageAmount_numericBox.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search Tags - Newline Separated";
            // 
            // search_richTextBox
            // 
            this.search_richTextBox.DetectUrls = false;
            this.search_richTextBox.Location = new System.Drawing.Point(10, 212);
            this.search_richTextBox.Name = "search_richTextBox";
            this.search_richTextBox.Size = new System.Drawing.Size(453, 116);
            this.search_richTextBox.TabIndex = 1;
            this.search_richTextBox.Text = "";
            this.search_richTextBox.WordWrap = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.URL_Load_button);
            this.groupBox2.Controls.Add(this.URL_LoadAndClose_button);
            this.groupBox2.Controls.Add(this.fromURL_textbox);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 412);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(479, 91);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "From URL";
            // 
            // URL_Load_button
            // 
            this.URL_Load_button.Location = new System.Drawing.Point(140, 45);
            this.URL_Load_button.Name = "URL_Load_button";
            this.URL_Load_button.Size = new System.Drawing.Size(121, 31);
            this.URL_Load_button.TabIndex = 5;
            this.URL_Load_button.Text = "Load";
            this.URL_Load_button.UseVisualStyleBackColor = true;
            this.URL_Load_button.Click += new System.EventHandler(this.URL_Load_button_Click);
            // 
            // URL_LoadAndClose_button
            // 
            this.URL_LoadAndClose_button.Location = new System.Drawing.Point(13, 45);
            this.URL_LoadAndClose_button.Name = "URL_LoadAndClose_button";
            this.URL_LoadAndClose_button.Size = new System.Drawing.Size(121, 31);
            this.URL_LoadAndClose_button.TabIndex = 5;
            this.URL_LoadAndClose_button.Text = "Load and Close";
            this.URL_LoadAndClose_button.UseVisualStyleBackColor = true;
            this.URL_LoadAndClose_button.Click += new System.EventHandler(this.URL_LoadAndClose_button_Click);
            // 
            // fromURL_textbox
            // 
            this.fromURL_textbox.Location = new System.Drawing.Point(10, 19);
            this.fromURL_textbox.Name = "fromURL_textbox";
            this.fromURL_textbox.Size = new System.Drawing.Size(453, 20);
            this.fromURL_textbox.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.STATUS_LABEL});
            this.statusStrip1.Location = new System.Drawing.Point(0, 512);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(503, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // STATUS_LABEL
            // 
            this.STATUS_LABEL.BackColor = System.Drawing.Color.Silver;
            this.STATUS_LABEL.Name = "STATUS_LABEL";
            this.STATUS_LABEL.Size = new System.Drawing.Size(167, 17);
            this.STATUS_LABEL.Text = "Status: Success - Form Loaded";
            // 
            // E6_checkbox
            // 
            this.E6_checkbox.AutoSize = true;
            this.E6_checkbox.Location = new System.Drawing.Point(288, 34);
            this.E6_checkbox.Name = "E6_checkbox";
            this.E6_checkbox.Size = new System.Drawing.Size(68, 17);
            this.E6_checkbox.TabIndex = 0;
            this.E6_checkbox.Text = "e621.net";
            this.E6_checkbox.UseVisualStyleBackColor = true;
            // 
            // OnlineSourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(503, 534);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OnlineSourceForm";
            this.Text = "Load Images from Online Sources - ImageViewer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageAmount_numericBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button search_searchAndClose_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown imageAmount_numericBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox search_richTextBox;
        private System.Windows.Forms.CheckBox R34_checkbox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button URL_Load_button;
        private System.Windows.Forms.Button URL_LoadAndClose_button;
        private System.Windows.Forms.TextBox fromURL_textbox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel STATUS_LABEL;
        private System.Windows.Forms.Button Search_ClearAll;
        private System.Windows.Forms.Button Search_SelectAll;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox derpi_checkbox;
        private System.Windows.Forms.CheckBox E6_checkbox;
    }
}