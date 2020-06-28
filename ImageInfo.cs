using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer {
    public class ImageInfo {
        public ImageInfo(string path) {
            imgPath = path;
        }

        public string imgPath { get; private set; }
        private Image ImageCache;
        public Image Image {
            get {
                PreloadImageSafe();
                return ImageCache;
            }
            private set { }            
        }

        public void PreloadImage() {
            ImageCache = Image.FromFile(imgPath);
        }
        public void PreloadImageSafe() {
            if (ImageCache == null) {
                PreloadImage();
            }
        }

        public int relativeIndex { get; set; }

        public void DisposeImage() {
            Image.Dispose();
            ImageCache = null;
        }
    }
}
