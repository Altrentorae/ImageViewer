using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer {
    public class UserSettings {
        public UserSettings() { }

        public int INT_VideoVolume { get; set; }
        public int INT_NewImageSetting { get; set; }
        public int INT_ImageSortSetting { get; set; }
        public int INT_SkinSelectedSetting { get; set; }
        public int INT_AutoplayInterval { get; set; }
        public bool BOOL_OptionsOpen { get; set; }
        public bool BOOL_ExitPromptEnabled { get; set; }
        public bool BOOL_ShuffleDoubleClickEnabled { get; set; }
        
    }
}
