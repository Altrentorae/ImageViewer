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
            isVideo = path.Contains(".mp4");
            isGif = path.Contains(".gif");
            dateCreated = System.IO.File.GetCreationTime(path);
            dateModified = System.IO.File.GetLastWriteTime(path);
        }

        public bool isVideo { get; private set; }
        public bool isGif { get; private set; }
        public string imgPath { get; private set; }
        public string imgName { get => GetImageName(); private set { } }
        public DateTime dateCreated { get; private set; }
        public DateTime dateModified { get; private set; }

        private Image ImageCache;
        public Image Image {
            get {
                PreloadImageSafe();
                return ImageCache;
            }
            private set { }            
        }

        private void PreloadImage() {
            ImageCache = Image.FromFile(imgPath);
        }
        public void PreloadImageSafe() {
            if (ImageCache == null) {
                PreloadImage();
            }
        }

        public void DisposeImage() {
            if(ImageCache == null) { return; }
            //Image.Dispose();
            ImageCache = null;
        }

        private string GetImageName(int FolderFallback = 0) {
            FolderFallback++;

            string[] split = imgPath.Split('\\');
            Array.Reverse(split);

            string retStr = "";
            for (int i = 0; i<FolderFallback; i++) {
                retStr += split[i];
            }

            return retStr;
        }
    }
}
