using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

/*
TODO
----------
:: FIX
:::: skin selection box not displaying name from file

:: Options
:::: toggle for exit popup

:: Custom windowframe
:::: move window with mouse
:::: snap window
:::: resize window

:: Right click quick changes
:::: shuffle seed
:::: find by index
:::: autonext interval 

:: Image Viewing
:::: Zoom

:: Skinning
:::: Other forms (FindBoxForm)
:::: Exit menu
:::: Recolor trackbar heads (may require OnPaint())
*/
namespace ImageViewer {
    public partial class MainForm : Form {

        #region GLOBAL VARS

        //Current Image index in list
        private int imageIndex = 0;

        //List of ImageInfos for current images
        public List<BindingList<ImageInfo>> Playlists = new List<BindingList<ImageInfo>>() { new BindingList<ImageInfo>(), new BindingList<ImageInfo>(), new BindingList<ImageInfo>(), new BindingList<ImageInfo>() };
        public List<ImageInfo> imagelist = new List<ImageInfo>();

        //Whether to preload images for quicker loading
        bool preload = false;

        //Max memory allowed to be used by preloading (must not exceed 4GB)
        int memLimit = 3000;//MB

        //Images currently preloaded, don't edit manually
        int preloadCount = 0;

        //Size in pixels of the option panel width
        int optPanelSize = 177;
       
        //Index tracking which playlist is currently selected (Default = 0)
        int SelectedPlaylistIndex = 0;

        //All loaded colorschemes
        List<ColorScheme> AllColorSchemes;
        
        //Active Color Scheme object
        ColorScheme ActiveColorScheme = new ColorScheme();

        //Size of window when not maximised
        Size nonMaxWindowSize = new Size(1296, 638);

        //Keep track of if window is maximised
        bool windowIsMaximised;

        //Whether the user is controlling the VideoControl Slider
        bool VC_UserMouseDown = false;

        //User Settings Object
        UserSettings userSettings = new UserSettings();

        #endregion

        #region CORE - ImageLoading

        public async void LoadImages(object sender, EventArgs e) {
            await _LoadImages(sender, e, true);
        }

        private async Task _LoadImages_NoPrompt(string[] files) {
            AttemptClearActiveList();

            List<string> validFiles = new List<string>();
            validFiles = await Task.Run(() => ValidateFolder(files));

            for (int i = 0; i < files.Length; i++) {
                Playlists[SelectedPlaylistIndex].Add(new ImageInfo(validFiles[i]));
            }
            InitPicBox();
        }

        private async void openFolderUnsafe_Click(object sender, EventArgs e) {
            await _openFolderUnsafe(sender, e);
        }

        private async Task _openFolderUnsafe(object sender, EventArgs e) {
            await _LoadImages(sender, e, false);
        }


        #pragma warning disable IDE0017
        private async Task _LoadImages(object sender, EventArgs e, bool validate) {
            ToolStripMenuItem send = (ToolStripMenuItem)sender;

            if (send.Name == "openImages") {
                OpenFileDialog fd = new OpenFileDialog();
                fd.Filter = "Images (*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG,)|*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG|" +
                    "Gifs (*.GIF)|*.GIF|" +
                    "Videos (*.MP4)|*.MP4|" +
                    "All (*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG;*.MP4)|*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG;*.MP4";
                fd.Multiselect = true;
                fd.Title = "Select Images";
                fd.ShowDialog();
                if (fd.FileNames.Length > 0) {
                    AttemptClearActiveList();
                    foreach (string image in fd.FileNames) {
                        Playlists[SelectedPlaylistIndex].Add(new ImageInfo(image));
                    }
                    InitPicBox();
                }
            }
            else {

                CommonOpenFileDialog ffd = new CommonOpenFileDialog();
                ffd.Title = "Select Folder";
                ffd.IsFolderPicker = true;
                if (ffd.ShowDialog() == CommonFileDialogResult.Cancel) { return; }
                var fileListNoSort = Directory.GetFiles(ffd.FileName, "*", SearchOption.AllDirectories);
                var files = new List<string>();

                files = validate ? await Task.Run(() => ValidateFolder(fileListNoSort)) : files = fileListNoSort.ToList();

                if (files.Count > 0) {
                    AttemptClearActiveList();
                    foreach (string image in files) {
                        Playlists[SelectedPlaylistIndex].Add(new ImageInfo(image));
                    }
                    InitPicBox();
                }
            }

            if(sortOrderBox.SelectedIndex != 4) {
                sortOrderChanged(null, null);
            }
        }
        #pragma warning restore

        private void AttemptClearActiveList() {
            if (opt_combo_NIB.SelectedIndex == 0) { Playlists[SelectedPlaylistIndex].Clear(); }
        }

        #endregion

        #region CORE - Validation

        public List<string> ValidateFolder(string[] fileListNoSort) {
            int valid = 0;
            int invalid = 0;
            List<string> files = new List<string>();
            foreach (string f in fileListNoSort) {


                if (IsValidImage(f)) {
                    files.Add(f); valid++;
                }
                else {
                    invalid++;
                }

                ValidateFolderUIThread(valid, invalid, fileListNoSort.Length);
            }
            return files;
        }

        private void ValidateFolderUIThread(int valid, int invalid, int len) {
            if (this.label_imageIndex.InvokeRequired) {
                this.label_imageIndex.BeginInvoke((MethodInvoker)delegate () { label_imageIndex.Text = $"(Validating folder) | ({valid}/{invalid}/{len}) | ({GetPercent(valid + invalid, len).ToString()}%)"; });
            }
            else {
                label_imageIndex.Text = $"(Validating folder) | ({valid}/{invalid}/{len}) | ({(((valid + invalid) / len) * 100).ToString()}%)";
            }
        }

        private float GetPercent(int a, int B) {
            return ((float)a / (float)B) * 100;
        }

        bool IsValidImage(string filename) {
            if (new ImageInfo(filename).isVideo) { return true; }
            if (new ImageInfo(filename).isGif) { return true; }
            try {
                using (Image newImage = Image.FromFile(filename)) { }
            }
            catch (OutOfMemoryException) {
                //The file does not have a valid image format.
                //-or- GDI+ does not support the pixel format of the file
                Console.WriteLine("IsValidImage() :: Dumping path: " + filename);
                return false;
            }
            return true;
        }

        #endregion

        #region CORE - Memory Management

        private void Preload(BindingList<ImageInfo> list) {
            Process proc = Process.GetCurrentProcess();
            foreach (ImageInfo inf in list) {
                proc.Refresh();
                if ((proc.PrivateMemorySize64 / 1000) / 1000 > memLimit) { break; }
                inf.PreloadImageSafe();
                preloadCount++;
            }
        }

        private bool MemCheck(int memMB) {
            Process proc = Process.GetCurrentProcess();
            return !((proc.PrivateMemorySize64 / 1000) / 1000 > memMB);
        }

        private void ClearImageMem() {
            Console.WriteLine("Clearing Image Memory");
            foreach (ImageInfo img in Playlists[SelectedPlaylistIndex]) {

                if (shuffle) { if (img.imgPath == shuffleList[imageIndex].imgPath) { continue; } }
                else if (img.imgPath == Playlists[SelectedPlaylistIndex][imageIndex].imgPath) { continue; }

                img.DisposeImage();
            }
            GC.Collect(1);
            GC.WaitForPendingFinalizers();
        }

        #endregion

        #region CORE - ImageChanging / UI Visuals

        public void changeImage(ImageInfo inf) {
            try {
                if (inf.isVideo) {
                    pictureBox1.Visible = false;
                    axWindowsMediaPlayer1.Show();
                    axWindowsMediaPlayer1.URL = inf.imgPath;
                    axWindowsMediaPlayer1.uiMode = "none";
                    VideoPlayer_ToggleUI(true);

                }
                else if (inf.isGif) {
                    axWindowsMediaPlayer1.URL = "";
                    pictureBox1.Visible = true;
                    axWindowsMediaPlayer1.Hide();
                    pictureBox1.Image = inf.Image;
                    VideoPlayer_ToggleUI(false);
                }
                else {
                    axWindowsMediaPlayer1.URL = "";
                    pictureBox1.Visible = true;
                    axWindowsMediaPlayer1.Hide();
                    pictureBox1.Image = inf.Image;
                    VideoPlayer_ToggleUI(false);
                }
            
            }
            catch (OutOfMemoryException) {
                pictureBox1.Image = pictureBox1.ErrorImage;
            }


            UpdateUI();
        }

        public void UpdateUI() {
            label_imageIndex.Text = $"{imageIndex + 1} {LangFile.WORD_OF} {Playlists[SelectedPlaylistIndex].Count}";
            imageNameTag.Text = shuffle ? $"{shuffleList[imageIndex].imgName}" : $"{Playlists[SelectedPlaylistIndex].ToList()[imageIndex].imgName}";
            if (shuffle) { label_imageIndex.Text += $" [{Playlists[SelectedPlaylistIndex].ToList().FindIndex(i => i == shuffleList[imageIndex]) + 1}]"; }
            if (preload) { label_imageIndex.Text += $" ({preloadCount} {LangFile.WORD_PRELOADED})"; }

        }

        private void InitPicBox() {
            if (preload) { Preload(Playlists[SelectedPlaylistIndex]); }
            changeImage(Playlists[SelectedPlaylistIndex][0]);
            //pictureBox1.Image = Playlists[SelectedPlaylistIndex][0].Image;
            UpdateUI();
        }

        #endregion

        #region CORE - Initialisation

        //INIT AND RESIZING

        public MainForm() {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void MainForm_Load(object sender, EventArgs e) {

            VideoPlayer_ToggleUI(false);
            axWindowsMediaPlayer1.Hide();
            pictureBox1.AllowDrop = true;

            AllColorSchemes = new List<ColorScheme>();
            AddDefaultSkins();
            ReadAllSkins();
            skinSelectionBox.SelectedIndex = 0;
            

            bool isElevated;
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent()) {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);

                Console.WriteLine("isElevated: " + isElevated);
                if (isElevated) { MessageBox.Show(LangFile.ELEVATED_WARNTEXT, LangFile.ELEVATED_WARNTITLE, MessageBoxButtons.OK); }
            }

            InitialiseInteractiveUI();
            InitialiseSettingsControlsEventHandlers();
        }

        private async void sortOrderChanged(object sender, EventArgs e) {
            if (Playlists[SelectedPlaylistIndex].Count < 2) { return; }
            await SortImages(sortOrderBox.SelectedIndex);
        }

        private async Task SortImages(int sortIndex) {
            BindingList<ImageInfo> returnList = await Task.Run(() => _SortImages(sortIndex));
            UpdateUI();
            _AssignNewList(returnList);
            if (!shuffle) {
                changeImage(Playlists[SelectedPlaylistIndex][imageIndex]);
            }
        }

        private async Task<BindingList<ImageInfo>> _SortImages(int sortIndex) {
            List<ImageInfo> tempList = new List<ImageInfo>();
            await Task.Run(() => { 
                switch (sortIndex) {
                    case 0: tempList = Playlists[SelectedPlaylistIndex].ToList().OrderBy(x => x.dateModified).ToList(); tempList.Reverse(); break;
                    case 1: tempList = Playlists[SelectedPlaylistIndex].ToList().OrderBy(x => x.dateModified).ToList(); break;
                    case 2: tempList = Playlists[SelectedPlaylistIndex].ToList().OrderBy(x => x.dateCreated).ToList(); tempList.Reverse(); break;
                    case 3: tempList = Playlists[SelectedPlaylistIndex].ToList().OrderBy(x => x.dateCreated).ToList(); break;
                    case 4: break;
                }
            });
            return new BindingList<ImageInfo>(tempList);


        }

        private void _AssignNewList(BindingList<ImageInfo> newList) {
            Playlists[SelectedPlaylistIndex] = newList;
        }

        private void InitialiseInteractiveUI() {
            if (File.Exists("~UserSettings.json")) {
                InitialiseFromFile();
            }

            //This is the defaults
            else {
                VC_VolumeSlider.Value = 50;
                opt_combo_NIB.SelectedIndex = 1;
                sortOrderBox.SelectedIndex = 0;
                skinSelectionBox.SelectedIndex = 0; skinSelectionBox.Text = AllColorSchemes[skinSelectionBox.SelectedIndex].SkinName;
                autonext_Interval_Box.Value = 6;
            }
        }

        #endregion

        #region FEATURE - RandomIndex

        Random rng = new Random();
        private void randomIndexButton(object sender, EventArgs e) {
            if(Playlists[SelectedPlaylistIndex].Count < 2) { return; }
            imageIndex = rng.Next(0, Playlists[SelectedPlaylistIndex].Count);
            changeImage(shuffle ? shuffleList[imageIndex] : Playlists[SelectedPlaylistIndex][imageIndex]);
        }

        #endregion

        #region FEATURE - GoToIndex

        private void findByIndex_Click(object sender, EventArgs e) {
            FindBoxForm form = new FindBoxForm();
            form.ShowDialog(this);
        }
        public void GotoIndex_Return(int index) {
            imageIndex = index;
            changeImage(shuffle ? shuffleList[index] : Playlists[SelectedPlaylistIndex][index]);

        }

        #endregion

        #region FEATURE - HOTKEYS

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            KeyEventArgs kd = new KeyEventArgs(keyData);
            if (kd.KeyCode == Keys.Left || kd.KeyCode == Keys.Right) {
                MainForm_KeyDown(null, kd); return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e) {

            int newIndex = imageIndex;
            if (Playlists[SelectedPlaylistIndex].Count == 0) { return; }

            if (e.KeyCode == Keys.F && e.Control) { findByIndex.PerformClick(); UpdateUI(); return; }

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right) {
                if (autoNext) { autoNext_Tick = (int)autonext_Interval_Box.Value; }
                if (!shuffle) {
                    switch (e.KeyCode) {
                        case Keys.Left:
                            if (imageIndex - 1 < 0) { newIndex = Playlists[SelectedPlaylistIndex].Count - 1; }
                            else { newIndex--; }
                            changeImage(Playlists[SelectedPlaylistIndex][newIndex]); break;
                        case Keys.Right:
                            if (imageIndex + 1 > Playlists[SelectedPlaylistIndex].Count - 1) { newIndex = 0; }
                            else { newIndex++; }
                            changeImage(Playlists[SelectedPlaylistIndex][newIndex]); break;
                    }
                }
                else {
                    switch (e.KeyCode) {
                        case Keys.Left:
                            if (imageIndex - 1 < 0) { newIndex = shuffleList.Count - 1; }
                            else { newIndex--; }
                            changeImage(shuffleList[newIndex]); break;
                        case Keys.Right:
                            if (imageIndex + 1 > shuffleList.Count - 1) { newIndex = 0; }
                            else { newIndex++; }
                            changeImage(shuffleList[newIndex]); break;
                    }
                }

            }

            if (!MemCheck(1000)) { ClearImageMem(); }

            imageIndex = newIndex;
            UpdateUI();
        }

        #endregion

        #region FEATURE - Shuffle

        private bool shuffle = false;
        private List<ImageInfo> shuffleList = new List<ImageInfo>();
        private void buttonShuffle_Click(object sender, EventArgs e) {
            if(Playlists[SelectedPlaylistIndex].Count < 2) { return; }
            shuffle = !shuffle;
            buttonShuffle.BackColor = shuffle ? ActiveColorScheme.Button_On : ActiveColorScheme.NavBar;
            if (shuffle) {
                shuffleList = new List<ImageInfo>(Playlists[SelectedPlaylistIndex]);
                shuffleList.Shuffle();
            }

            if (shuffle) {
                changeImage(shuffleList[imageIndex]);
            }
            else {
                changeImage(Playlists[SelectedPlaylistIndex][imageIndex]);
            }
        }

        #endregion

        #region FEATURE - UI Interactive / Other UI

        private void Button_UI(object sender, EventArgs e) {
            Button temp = (Button)sender;
            Keys k = Keys.Left;
            if (temp.Name == "buttonNext") { k = Keys.Right; }
            KeyEventArgs kea = new KeyEventArgs(k);
            MainForm_KeyDown(sender, kea);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void button_toggleOptionsPanel_Click(object sender, EventArgs e) {
            optionsPanel.Visible = !optionsPanel.Visible;
            optionsPanel.Width = optionsPanel.Visible ? optPanelSize : 0;
            pictureBox1.Width = optionsPanel.Visible ? this.Width - optPanelSize : this.Width;
            axWindowsMediaPlayer1.Width = optionsPanel.Visible ? this.Width - optPanelSize : this.Width;
            button_toggleOptionsPanel.BackColor = optionsPanel.Visible ? ActiveColorScheme.Button_On : ActiveColorScheme.NavBar;
        }

        

        //find image in explorer
        private void imageNameTag_DoubleClick(object sender, EventArgs e) {
            try {
                string arg = $@"/select, ""{
                    (shuffle ?
                    shuffleList[imageIndex].imgPath
                    :
                    Playlists[SelectedPlaylistIndex].ToList()[imageIndex].imgPath) }";
                Process.Start("explorer.exe" , arg);
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        #endregion

        #region FEATURE - AutoNext

        Timer t = new Timer() {
            Interval = 1000

        };

        bool tickBound = false;
        bool autoNext = false;
        int autoNext_Tick;
        private void button_AutoNext_Click(object sender, EventArgs e) {
            autoNext = !autoNext;
            button_AutoNext.BackColor = autoNext ? ActiveColorScheme.Button_On : ActiveColorScheme.NavBar;

            if (!tickBound) {
                autoNext_Tick = (int)autonext_Interval_Box.Value;
                t.Tick += AutoNextTick;
                tickBound = true;
            }

            if (autoNext) {
                t.Start();

            }
            else {
                t.Stop();

            }
        }
        private void AutoNextTick(object s, EventArgs e) {
            autoNext_Tick--;
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying) { autoNext_Tick = 0; }
            if (this.button_AutoNext.InvokeRequired) {
                this.button_AutoNext.BeginInvoke((MethodInvoker)delegate () { button_AutoNext.Text = (autoNext_Tick + 1).ToString(); });
            }
            else {
                button_AutoNext.Text = (autoNext_Tick + 1).ToString();
            }
            if (autoNext_Tick < 0) { buttonNext.PerformClick(); autoNext_Tick = (int)autonext_Interval_Box.Value; }

            t.Start();
        }

        #endregion

        #region FEATURE - DragDrop

        private void pictureBox1_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.All;
                pictureBox1.BackColor = Color.DarkGreen;
            }
            else {
                e.Effect = DragDropEffects.None;
                pictureBox1.BackColor = Color.Gray;
            }
        }

        private void pictureBox1_DragLeave(object sender, EventArgs e) {
            pictureBox1.BackColor = Color.Gray;
        }

        private async void pictureBox1_DragDrop(object sender, DragEventArgs e) {
            {
                string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                await _LoadImages_NoPrompt(s);
                pictureBox1.BackColor = Color.Gray;
            }
        }

        #endregion

        #region FEATURE - ColorScheme / Skin

        private void AddDefaultSkins() {
            DEFAULTS.Clear();
            DEFAULTS = new List<ColorScheme> {
                DEF_GREY,
                CS_Blue
            };
            AllColorSchemes.AddRange(DEFAULTS);
        }

        public List<ColorScheme> DEFAULTS = new List<ColorScheme>() { };

        ColorScheme DEF_GREY = new ColorScheme("Default Grey") {
            FormBase = Color.Gray,
            Text_Foreground = Color.White,
            MenuStrip = Color.DimGray,
            NavBar = Color.DimGray,
            OptionsPanel = Color.FromArgb(64, 64, 64),
            Button_On = Color.DarkSlateBlue
        };

        ColorScheme CS_Blue = new ColorScheme("CS_BLUE") {
            FormBase = Color.Blue,
            Text_Foreground = Color.White,
            MenuStrip = Color.DarkBlue,
            NavBar = Color.DarkBlue,
            OptionsPanel = Color.DarkCyan,
            Button_On = Color.Aqua
        };

        //---------------------------------------------------//

            //one of the skin element colorpickers was clicked
        private void CustomSkin_ButtonClicked(object sender, EventArgs e) {
            Button B = (Button)sender;
            ColorScheme cs = ActiveColorScheme;

            ColorDialog col = new ColorDialog() {
                AllowFullOpen = true,
                Color = B.BackColor
            };


            if (col.ShowDialog() == DialogResult.OK) {
                switch (B.Name) {
                    case "colorpicker_FormBase": cs.FormBase = col.Color; break;
                    case "colorpicker_Text": cs.Text_Foreground = col.Color; break;
                    case "colorpicker_menustrip": cs.MenuStrip = col.Color; break;
                    case "colorpicker_navbar": cs.NavBar = col.Color; break;
                    case "colorpicker_options": cs.OptionsPanel = col.Color; break;
                    case "colorpicker_buttonOn": cs.Button_On = col.Color; break;
                }
            }

            ApplySkin(cs);
            
        }

            //Save the custom skin, if same name exists, overwrite
            //If skin settings match preset skin, ignore
        private void customSkin_Save_Click(object sender, EventArgs e) {
            if(customSkinNameBox.Text.Trim() == "") { return; }
            if (AllColorSchemes != null) {
                if (AllColorSchemes.Count > 0) {
                    if (AllColorSchemes.Any(n => n.SkinName == customSkinNameBox.Text)) { return; }
                }
            }
            ColorScheme newscheme = new ColorScheme(customSkinNameBox.Text, ActiveColorScheme);
            AllColorSchemes.Add(newscheme);
            AllColorSchemes.RemoveAll(x => DEFAULTS.Contains(x));
            File.Delete("~Skins.json");
            StreamWriter sw = new StreamWriter("~Skins.json", false);
            sw.Write(JsonConvert.SerializeObject(AllColorSchemes));
            sw.Close();
            ReadAllSkins();
            skinSelectionBox.SelectedIndex = skinSelectionBox.Items.Count-1;
        }

        private void ReadAllSkins() {

            if (AllColorSchemes != null) {
                if (AllColorSchemes.Count > 0) {
                    AllColorSchemes.Clear();
                    skinSelectionBox.Items.Clear();
                }
            }
            try {
                AllColorSchemes = JsonConvert.DeserializeObject<List<ColorScheme>>(File.ReadAllText("~Skins.json"));
            }
            
            catch(FileNotFoundException) { }

            if (AllColorSchemes == null) { AllColorSchemes = new List<ColorScheme>(); }

            if (AllColorSchemes == null) { return;  }
            if (AllColorSchemes.Count == DEFAULTS.Count) { return; }

            AddDefaultSkins();

            foreach(ColorScheme cs in AllColorSchemes) {
                skinSelectionBox.Items.Add(cs.SkinName);
            }
        }

        private void customSkin_Delete(object sender, EventArgs e) {
            if(AllColorSchemes.Any(x => x.SkinName == customSkinNameBox.Text)) { if(MessageBox.Show(
                $"Are you sure you want to delete skin: {customSkinNameBox.Text}","Delete skin?",
                MessageBoxButtons.YesNo) == DialogResult.No) { return; }
            }
            AllColorSchemes = AllColorSchemes.Where(x => x.SkinName != customSkinNameBox.Text).ToList();
            AllColorSchemes.RemoveAll(x => DEFAULTS.Contains(x));
            StreamWriter sw = new StreamWriter("~Skins.json", false);
            sw.Write(JsonConvert.SerializeObject(AllColorSchemes));
            sw.Close();
            ReadAllSkins();
            skinSelectionBox.SelectedIndex = skinSelectionBox.Items.Count-1;

        }

        private void SkinSelectionChanged(object sender, EventArgs e) {
            try {
                ApplySkin(AllColorSchemes[skinSelectionBox.SelectedIndex]);
            }
            catch (ArgumentOutOfRangeException) { ApplySkin(AllColorSchemes[0]); }
            customSkinNameBox.Text = ActiveColorScheme.SkinName;
        }

        //--------------------------------------------------//

        public void ApplySkin(ColorScheme newSkin) {

            ControlList.Clear();
            List<Control> _controlList = GetAllControls(this);

            this.BackColor = newSkin.FormBase;

            foreach (Control C in _controlList) {
                if (C.GetType() == typeof(MenuStrip)) {
                    C.BackColor = newSkin.MenuStrip;
                    C.ForeColor = newSkin.Text_Foreground;
                }
                if (C.GetType() == typeof(Panel)) {
                    switch (C.Name) {
                        case "NavPanel": C.BackColor = newSkin.NavBar; break;
                        case "optionsPanel": C.BackColor = newSkin.OptionsPanel; break;
                    }
                    C.ForeColor = newSkin.NavBar;
                }
                if(C.GetType() == typeof(PictureBox)) {
                    C.BackColor = newSkin.FormBase;
                }
                if (C.GetType() == typeof(GroupBox)) {
                    C.BackColor = C.Parent.BackColor;
                    C.ForeColor = newSkin.Text_Foreground;
                }

            }
            foreach (Control C in _controlList) {
                if (C.GetType() == typeof(Label)) {
                    C.ForeColor = newSkin.Text_Foreground;
                    if (C.Name == "imageNameTag") { C.BackColor = newSkin.MenuStrip; continue; }
                    if (C.Name == "label_imageIndex") { C.BackColor = newSkin.MenuStrip; continue; }
                    C.BackColor = C.Parent.BackColor;
                }
                if (C.GetType() == typeof(Button)) {
                    if(C.Parent.Name == "skinGroupBox") {
                        if(C.Name == "colorpicker_FormBase") { C.BackColor = newSkin.FormBase; C.ForeColor = GetInvertedColor(newSkin.FormBase);  }
                        if(C.Name == "colorpicker_Text") { C.BackColor = newSkin.Text_Foreground; C.ForeColor = GetInvertedColor(newSkin.Text_Foreground); }
                        if(C.Name == "colorpicker_menustrip") { C.BackColor = newSkin.MenuStrip; C.ForeColor = GetInvertedColor(newSkin.MenuStrip); }
                        if(C.Name == "colorpicker_navbar") { C.BackColor = newSkin.NavBar; C.ForeColor = GetInvertedColor(newSkin.NavBar); }
                        if(C.Name == "colorpicker_options") { C.BackColor = newSkin.OptionsPanel; C.ForeColor = GetInvertedColor(newSkin.OptionsPanel); }
                        if(C.Name == "colorpicker_buttonOn") { C.BackColor = newSkin.Button_On; C.ForeColor = GetInvertedColor(newSkin.Button_On); }
                        continue;
                    }
                    Button b = (Button)C;
                    b.FlatAppearance.BorderColor = C.Parent.BackColor;
                    C.ForeColor = newSkin.Text_Foreground;
                    C.BackColor = C.Parent.BackColor;
                }
                if (C.GetType() == typeof(ToolStripMenuItem)) {
                    C.ForeColor = newSkin.Text_Foreground;
                    C.BackColor = C.Parent.BackColor;
                }
                if (C.GetType() == typeof(MenuItem)) {
                    C.ForeColor = newSkin.Text_Foreground;
                    C.BackColor = C.Parent.BackColor;
                }
            }

            foreach(ToolStripMenuItem mi in menuStrip1.Items) {
                foreach (ToolStripMenuItem mi2 in mi.DropDownItems) {
                    mi2.BackColor = newSkin.MenuStrip;
                    mi2.ForeColor = newSkin.Text_Foreground;
                }
                mi.BackColor = newSkin.MenuStrip;
                mi.ForeColor = newSkin.Text_Foreground;
                
            }

            ActiveColorScheme = newSkin;
        }
        
        List<Control> ControlList = new List<Control>();
        private List<Control> GetAllControls(Control container) {
            foreach (Control c in container.Controls) {
                ControlList.Add(c);
                
                if (c.Controls.Count > 0) { GetAllControls(c); }
            }
            return ControlList;
        }

        private Color GetInvertedColor(Color c) {
            return Color.FromArgb(c.ToArgb() ^ 0xffffff);
        }

        private void MainForm_Shown(object sender, EventArgs e) {
            //ApplySkin(CS_Blue);
            ReadAllSkins();
        }





        #endregion

        #region CORE - PERSISTING DATA

        private void InitialiseSettingsControlsEventHandlers() {
            button_toggleOptionsPanel.Click += (s, e) => WriteSettings();
            autonext_Interval_Box.ValueChanged += (s, e) => WriteSettings();
            sortOrderBox.SelectedIndexChanged += (s, e) => WriteSettings();
            opt_combo_NIB.SelectedIndexChanged += (s, e) => WriteSettings();
            skinSelectionBox.SelectedIndexChanged += (s, e) => WriteSettings();
            autonext_Interval_Box.ValueChanged += (s, e) => WriteSettings();
        }

        private void WriteSettings() {
            UpdateSettingsFromForm();
            StreamWriter sw = new StreamWriter("~UserSettings.json", false);
            sw.Write(JsonConvert.SerializeObject(userSettings));
            sw.Close();
        }

        private void UpdateSettingsFromForm() {
            userSettings.BOOL_OptionsOpen = optionsPanel.Visible;
            userSettings.INT_AutoplayInterval = (int)autonext_Interval_Box.Value;
            userSettings.INT_ImageSortSetting = sortOrderBox.SelectedIndex;
            userSettings.INT_NewImageSetting = opt_combo_NIB.SelectedIndex;
            userSettings.INT_SkinSelectedSetting = skinSelectionBox.SelectedIndex;
            userSettings.INT_VideoVolume = VC_VolumeSlider.Value;
        }

        //Called from InitialiseInteractiveUI() in Region-Initialisation
        private void InitialiseFromFile() {
            UserSettings us = JsonConvert.DeserializeObject<UserSettings>(File.ReadAllText("~UserSettings.json"));

            VC_VolumeSlider.Value = us.INT_VideoVolume;
            opt_combo_NIB.SelectedIndex = us.INT_NewImageSetting;
            sortOrderBox.SelectedIndex = us.INT_ImageSortSetting;
            //skinSelectionBox.SelectedIndex = us.INT_SkinSelectedSetting; skinSelectionBox.Text = AllColorSchemes[skinSelectionBox.SelectedIndex].SkinName;
            autonext_Interval_Box.Value = us.INT_AutoplayInterval;
            optionsPanel.Visible = us.BOOL_OptionsOpen; button_toggleOptionsPanel.BackColor = us.BOOL_OptionsOpen ? ActiveColorScheme.Button_On : ActiveColorScheme.NavBar;
        }

        #endregion

        #region CORE - VideoPlayer Controls

        private void VideoPlayer_StateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e) {
            if(e.newState == 3) {
                VideoControl_UpdateAll();
                StartVideoTick();
            }
            else {
                vTick.Stop();
            }
        }

        private void VideoControl_UpdateAll() {
            Console.WriteLine(axWindowsMediaPlayer1.currentMedia.duration.ToString());
            Console.WriteLine(Convert.ToInt32(axWindowsMediaPlayer1.currentMedia.duration).ToString());
            VC_Slider.Maximum = Convert.ToInt32(axWindowsMediaPlayer1.currentMedia.duration);
            VC_EndTimeLabel.Text = TimeSpan.FromSeconds(VC_Slider.Maximum).ToString(@"mm\:ss");
            VC_StartTimeLabel.Text = "00:00";
        }

        private void VideoControl_PlayPause(object sender, EventArgs e) {
            if(axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying) {
                VC_PP.Text = "|>";
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
            else {
                VC_PP.Text = "||";
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }

        }

        private void VideoControl_SliderChanged(object sender, EventArgs e) {
            if (!VC_UserMouseDown) { return; } //If changed by videoplayer itself, ignore

            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = TimeSpan.FromSeconds(VC_Slider.Value).TotalSeconds;
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void VC_Slider_MouseDown(object sender, MouseEventArgs e) {
            //Console.WriteLine("MD");
            VC_UserMouseDown = true;
        }

        private void VC_Slider_MouseUp(object sender, MouseEventArgs e) {
            //Console.WriteLine("MU");
            VC_UserMouseDown = false;
        }

        bool videoTickBound = false;
        Timer vTick = new Timer();
        private void StartVideoTick() {
            if (!videoTickBound) {
                vTick.Tick += VTick_Tick;
                vTick.Interval = 100;
                vTick.Start();
            }
        }

        private void VTick_Tick(object sender, EventArgs e) {
            VC_StartTimeLabel.Text = TimeSpan.FromSeconds(axWindowsMediaPlayer1.Ctlcontrols.currentPosition).ToString(@"mm\:ss");
            int calc = (int)TimeSpan.FromSeconds(axWindowsMediaPlayer1.Ctlcontrols.currentPosition).TotalSeconds;
            VC_Slider.Value = calc > VC_Slider.Maximum ? VC_Slider.Maximum : calc;
        }

        private void VC_VolumeChanged(object sender, EventArgs e) {
            axWindowsMediaPlayer1.settings.volume = VC_VolumeSlider.Value;
        }

        #endregion

        #region CORE - Window Sizing

        private void SystemButton_Close_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Are you sure you want to close ImageViewer?", "Close ImageViewer?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                Environment.Exit(0);
            }
        }

        private void SystemButton_Max_Click(object sender, EventArgs e) {
            if(this.WindowState == FormWindowState.Maximized) { this.WindowState = FormWindowState.Normal; }
            else if(this.WindowState == FormWindowState.Normal) { this.WindowState = FormWindowState.Maximized; }
            //this.Size = windowIsMaximised ? nonMaxWindowSize : Screen.PrimaryScreen.Bounds.Size;
            windowIsMaximised = !windowIsMaximised;
        }

        private void SystemButton_Min_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Minimized;
        }

        private void VideoPlayer_ToggleUI(bool bOn) {
            if (bOn) {
                VC_PP.Show();
                VC_Slider.Show();
                VC_VolumeSlider.Show();
                VC_StartTimeLabel.Show();
                VC_EndTimeLabel.Show();
            }
            else {
                VC_PP.Hide();
                VC_Slider.Hide();
                VC_VolumeSlider.Hide();
                VC_StartTimeLabel.Hide();
                VC_EndTimeLabel.Hide();
            }
        }


        #endregion

        
    }
}
