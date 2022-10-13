using ImageViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewer
{
    public partial class OnlineSourceForm : Form
    {

        public MainForm OwningForm;

        public OnlineSourceForm(MainForm Parent, ColorScheme scheme)
        {
            OwningForm = Parent;
            InitializeComponent();

            ColorScheme _ = new ColorScheme();
            Skinner.ApplySkin(this, scheme, out _, null, null);
        }

        private enum status
        {
            Success,
            Failure,
            Working
        }

        private void UpdateStatus(status stat, string text)
        {
            STATUS_LABEL.Text = $"Status: {stat} - {text}";
        }

        private bool GetAnyChecked()
        {
            return
                    R34_checkbox.Checked
                ||  derpi_checkbox.Checked
                ||  E6_checkbox.Checked;
        }





        private async void search_searchAndClose_Button_Click(object sender, EventArgs e)
        {
            if (search_richTextBox.Text.Trim() == "") { UpdateStatus(status.Failure, "No Tags provided"); return; }
            string[] tags = search_richTextBox.Text.Split('\n');
            int amount = (int)imageAmount_numericBox.Value;

            if (!GetAnyChecked()) { UpdateStatus(status.Failure, "No sources selected!"); return; }

            R34_API     r34 = new R34_API();
            Derpi_API   D = new Derpi_API();
            E6_API      e6 = new E6_API();

            r34.OnAPIStatusChanged += (object s, APIStatusChangedArgs args) => UpdateStatus(status.Working, args.newAPIStatus);
            D.OnAPIStatusChanged += (object s, APIStatusChangedArgs args) => UpdateStatus(status.Working, args.newAPIStatus);
            e6.OnAPIStatusChanged += (object s, APIStatusChangedArgs args) => UpdateStatus(status.Working, args.newAPIStatus);

            if (R34_checkbox.Checked) { try { await OwningForm.LoadImages_FromAPI(r34, tags, amount); } catch (ArgumentOutOfRangeException) { } }
            if (derpi_checkbox.Checked) { try { await OwningForm.LoadImages_FromAPI(D, tags, amount); } catch (ArgumentOutOfRangeException) { } }
            if (E6_checkbox.Checked) { try { await OwningForm.LoadImages_FromAPI(e6, tags, amount); } catch (ArgumentOutOfRangeException) { } }

            this.Close();
        }

        private void URL_Load_button_Click(object sender, EventArgs e) { LoadFromURL(false); }
        private void URL_LoadAndClose_button_Click(object sender, EventArgs e) { LoadFromURL(true); }
        private void LoadFromURL(bool closeForm)
        {
            if(fromURL_textbox.Text.Trim() == "") { UpdateStatus(status.Failure, "No URL provided"); return; }
            try
            {
                OwningForm.LoadImageFromII(new ImageInfo(fromURL_textbox.Text));
                UpdateStatus(status.Success, "Found image, loading...");
            }
            catch (Exception)
            {
                UpdateStatus(status.Failure, "Cannot find image.");
            }

            if (closeForm) { this.Close(); }
            else { fromURL_textbox.Text = ""; }
        }

        
    }
}
