using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer {
    public class ColorScheme {

        public ColorScheme() { }
        public ColorScheme(string name, ColorScheme inherited) {
            SkinName = name;
            FormBase = inherited.FormBase;
            Text_Foreground = inherited.Text_Foreground;
            OptionsPanel = inherited.OptionsPanel;
            MenuStrip = inherited.MenuStrip;
            NavBar = inherited.NavBar;
            Button_On = inherited.Button_On;
        }
        public ColorScheme(string name) {
            SkinName = name;
        }

        public string SkinName { get; set; }

        public Color FormBase { get; set; }
        public Color Text_Foreground { get; set; }
        public Color OptionsPanel { get; set; }
        public Color MenuStrip { get; set; }
        public Color NavBar { get; set; }
        public Color Button_On { get; set; }

    }
}
