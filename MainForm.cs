using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewer {
    public partial class MainForm : Form {


        public void LoadImages(object sender, EventArgs e) {

            ToolStripMenuItem send = (ToolStripMenuItem)sender;

            if (send.Name == "openImages") {
                OpenFileDialog fd = new OpenFileDialog();
                fd.Filter = "Images (*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG,)|*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG|" +
                    "Gifs (*.GIF)|*.GIF";
                fd.Multiselect = true;
                fd.Title = "Select Images";
                fd.ShowDialog();
                if (fd.FileNames.Length > 0) {
                    imageList.Clear();
                    foreach (string image in fd.FileNames) {
                        imageList.Add(new ImageInfo(image));
                    }
                    UpdateImage();
                }
            }
            else {
                CommonOpenFileDialog ffd = new CommonOpenFileDialog();
                ffd.Title = "Select Folder";
                ffd.IsFolderPicker = true;
                if (ffd.ShowDialog() == CommonFileDialogResult.Cancel) { return; }
                var files = Directory.GetFiles(ffd.FileName);
                if (files.Length > 0) {
                    imageList.Clear();
                    foreach (string image in files) {
                        imageList.Add(new ImageInfo(image));
                    }
                    UpdateImage();
                }
            }
        }

        public List<ImageInfo> imageList = new List<ImageInfo>();
        public int imageIndex { get; set; }

        private bool wasRight = true;
        private void Button_UI(object sender, EventArgs e) {
            Button temp = (Button)sender;
            Keys k = Keys.Left;
            if (temp.Name == "buttonNext") { k = Keys.Right; }
            KeyEventArgs kea = new KeyEventArgs(k);
            MainForm_KeyDown(sender, kea);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            MainForm_KeyDown(null, new KeyEventArgs(keyData));
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private Random rng = new Random();
        private bool shuffle = false;
        private void MainForm_KeyDown(object sender, KeyEventArgs e) {
            if (imageList.Count == 0) { return; }
            if (!shuffle) {
                switch (e.KeyCode) {
                    case Keys.Left:
                        if (imageIndex - 1 < 0) {
                            imageIndex = imageList.Count - 1;
                        }
                        else {
                            imageIndex--;
                        }
                        wasRight = false;
                        break;
                    case Keys.Right:
                        if (imageIndex + 1 > imageList.Count - 1) {
                            imageIndex = 0;
                        }
                        else {
                            imageIndex++;
                        }
                        wasRight = true;
                        break;
                }
                UpdateImage(imageIndex);
            }
            else {
                switch (e.KeyCode) {
                    case Keys.Left:
                        UpdateImage(previousIndex);
                        break;
                    case Keys.Right:
                        UpdateImage(rng.Next(imageList.Count - 1));
                        break;
                }
            }

        }



        int previousIndex = 0;
        bool initSkip = true;
        public void UpdateImage() {
            UpdateImage(imageIndex);
        }
        public void UpdateImage(int Index) {
            if (!initSkip) {
                pictureBox1.Image.Dispose();
                imageList[previousIndex].DisposeImage();
            }
            try {
                pictureBox1.Image = imageList[Index].Image;
            }
            catch (OutOfMemoryException e) {
                //imageList.RemoveAt(Index);
                if (wasRight) {
                    imageIndex++;
                }
                else {
                    imageIndex--;
                }
                imageIndex = Index;
                UpdateImage();
            }
            imageIndex = Index;
            previousIndex = imageIndex;
            initSkip = false;
            UpdateUI();
        }

        public void UpdateUI() {
            label_imageIndex.Text = $"{imageIndex + 1} of {imageList.Count}";
        }

        private void buttonShuffle_Click(object sender, EventArgs e) {
            shuffle = !shuffle;
            buttonShuffle.BackColor = shuffle ? Color.DarkSlateBlue : Color.DimGray;
        }


        public MainForm() {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
