using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using ImageViewer;
using Newtonsoft.Json;

namespace ImageViewer
{
    class R34_API : ImageViewer.ExternalAPIHandler
    {
        public override async Task<List<ImageInfo>> GetImagesAsync(string[] tags, int amount)
        {
            if (amount > 1000) { amount = 1000; }
            if (amount <= 0) { amount = 1; }

            string url = "https://rule34.xxx/index.php?page=dapi&s=post&q=index";

            url += $"&tags={string.Join("+", tags)}";
            url += $"&limit={amount}";
            url += $"&json=1";

            using (var client = GetHttpClient())
            {
                client.BaseAddress = new Uri(url);
                APIStatus = ("Accessing R34 API");
                string response = await client.GetStringAsync(url);
                APIStatus = ("R34 call complete");

                //string result = await response.ReadAsStringAsync();
                List<R34_API_Internal.R34InnerResponse> dRes = JsonConvert.DeserializeObject<List<R34_API_Internal.R34InnerResponse>>(response);

                List<ImageInfo> images = new List<ImageInfo>();
                foreach (R34_API_Internal.R34InnerResponse resp in dRes)
                {
                    ImageInfo cur = new ImageInfo(resp.file_url);
                    images.Add(cur);
                }
                return await Task.FromResult(images);
            }
        }
    }
}

namespace R34_API_Internal
{
    public class R34InnerResponse
    {
        public string preview_url { get; set; }
        public string sample_url { get; set; }
        public string file_url { get; set; }
        public int directory { get; set; }
        public string hash { get; set; }
        public int height { get; set; }
        public int id { get; set; }
        public string image { get; set; }
        public int change { get; set; }
        public string owner { get; set; }
        public int parent_id { get; set; }
        public string rating { get; set; }
        public int sample { get; set; }
        public int sample_height { get; set; }
        public int sample_width { get; set; }
        public int score { get; set; }
        public string tags { get; set; }
        public int width { get; set; }
    }
}

