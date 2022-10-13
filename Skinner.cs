using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewer
{
    public static class Skinner
    {
        private static Color GetInvertedColor(Color c)
        {
            return Color.FromArgb(c.ToArgb() ^ 0xffffff);
        }

        private static List<Control> GetAllControls(this Control container)
        {
            List<Control> ControlList = new List<Control>();
            foreach (Control c in container.Controls)
            {
                ControlList.Add(c);

                if (c.Controls.Count > 0) { GetAllControls(c); }
            }
            return ControlList;
        }

        public static void ApplySkin(this Form form, ColorScheme newSkin, out ColorScheme newActiveScheme, MenuStrip menuStrip = null, List<Control> additionalControls = null)
        {

            //ControlList.Clear();
            List<Control> _controlList = form.GetAllControls();
            if (additionalControls != null)
            {
                _controlList.AddRange(additionalControls);
            }
            form.BackColor = newSkin.FormBase;

            foreach (Control C in _controlList)
            {
                if (C.GetType() == typeof(MenuStrip))
                {
                    C.BackColor = newSkin.MenuStrip;
                    C.ForeColor = newSkin.Text_Foreground;
                }
                if (C.GetType() == typeof(Panel))
                {
                    switch (C.Name)
                    {
                        case "NavPanel": C.BackColor = newSkin.NavBar; break;
                        case "optionsPanel": C.BackColor = newSkin.OptionsPanel; break;
                    }
                    C.ForeColor = newSkin.NavBar;
                }
                if (C.GetType() == typeof(PictureBox))
                {
                    C.BackColor = newSkin.FormBase;
                }
                if (C.GetType() == typeof(GroupBox))
                {
                    C.BackColor = C.Parent.BackColor;
                    C.ForeColor = newSkin.Text_Foreground;
                }

            }
            foreach (Control C in _controlList)
            {
                if (C.GetType() == typeof(Label))
                {
                    C.ForeColor = newSkin.Text_Foreground;
                    if (C.Name == "imageNameTag") { C.BackColor = newSkin.MenuStrip; continue; }
                    if (C.Name == "label_imageIndex") { C.BackColor = newSkin.MenuStrip; continue; }
                    C.BackColor = C.Parent.BackColor;
                }
                if (C.GetType() == typeof(Button))
                {
                    if (C.Parent.Name == "skinGroupBox")
                    {
                        if (C.Name == "colorpicker_FormBase") { C.BackColor = newSkin.FormBase; C.ForeColor = GetInvertedColor(newSkin.FormBase); }
                        if (C.Name == "colorpicker_Text") { C.BackColor = newSkin.Text_Foreground; C.ForeColor = GetInvertedColor(newSkin.Text_Foreground); }
                        if (C.Name == "colorpicker_menustrip") { C.BackColor = newSkin.MenuStrip; C.ForeColor = GetInvertedColor(newSkin.MenuStrip); }
                        if (C.Name == "colorpicker_navbar") { C.BackColor = newSkin.NavBar; C.ForeColor = GetInvertedColor(newSkin.NavBar); }
                        if (C.Name == "colorpicker_options") { C.BackColor = newSkin.OptionsPanel; C.ForeColor = GetInvertedColor(newSkin.OptionsPanel); }
                        if (C.Name == "colorpicker_buttonOn") { C.BackColor = newSkin.Button_On; C.ForeColor = GetInvertedColor(newSkin.Button_On); }
                        continue;
                    }
                    Button b = (Button)C;
                    b.FlatAppearance.BorderColor = newSkin.NavBar;
                    
                    C.ForeColor = newSkin.Text_Foreground;
                    C.BackColor = newSkin.NavBar;
                }
                if (C.GetType() == typeof(ToolStripMenuItem))
                {
                    C.ForeColor = newSkin.Text_Foreground;
                    C.BackColor = C.Parent.BackColor;
                }
                if (C.GetType() == typeof(MenuItem))
                {
                    C.ForeColor = newSkin.Text_Foreground;
                    C.BackColor = C.Parent.BackColor;
                }
            }

            if (menuStrip != null)
            {
                foreach (ToolStripMenuItem mi in menuStrip.Items)
                {
                    if (mi.GetType() == typeof(ToolStripSeparator)) { continue; }
                    foreach (ToolStripMenuItem mi2 in mi.DropDownItems)
                    {
                        mi2.BackColor = newSkin.MenuStrip;
                        mi2.ForeColor = newSkin.Text_Foreground;
                    }
                    mi.BackColor = newSkin.MenuStrip;
                    mi.ForeColor = newSkin.Text_Foreground;

                }
            }
            newActiveScheme = newSkin;
        }
    }
}
