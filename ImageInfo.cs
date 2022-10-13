using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPWrapper;

namespace ImageViewer {
    public class ImageInfo {

        public ImageInfo(string path)
        {
            imgPath = path;
            isVideo = path.Contains(".mp4");
            isGif = path.Contains(".gif");
            isOnlineResource = path.Contains("http");
            isWebP = path.ToLower().Contains(".webp");

            if (!isOnlineResource)
            {
                dateCreated = System.IO.File.GetCreationTime(path);
                dateModified = System.IO.File.GetLastWriteTime(path);
            }
        }
        public ImageInfo(string path, DateTime? created, DateTime? edited)
        {
            imgPath = path;
            isVideo = path.Contains(".mp4");
            isGif = path.Contains(".gif");
            isOnlineResource = path.Contains("http");

            dateCreated = created ?? DateTime.UtcNow;
            dateModified = edited ?? DateTime.UtcNow;

        }

        public bool isWebP { get; set; }
        public bool isOnlineResource { get; private set; }
        public bool isVideo { get; private set; }
        public bool isGif { get; private set; }
        public string imgPath { get; private set; }
        public string imgName { get => isOnlineResource ? imgPath : GetImageName(); private set { } }
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

        private void PreloadImage()
        {
            if (!isOnlineResource)
            {
                if (isWebP)
                {
                    using(WebP webp = new WebP())
                    {
                        ImageCache = webp.Load(imgPath);
                    }
                }
                else
                {
                    ImageCache = Image.FromFile(imgPath);
                }
            }
            else
            {

            }
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
