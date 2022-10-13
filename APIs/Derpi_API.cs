using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer
{
    class Derpi_API : ExternalAPIHandler
    {
        public override async Task<List<ImageInfo>> GetImagesAsync(string[] tags, int amount)
        {
            if (amount > 500) { amount = 500; }
            if (amount <= 0) { amount = 1; }


            APIStatus = ("Accessing Derpi API");

            using (var client = GetHttpClient())
            {
                List<ImageInfo> images = new List<ImageInfo>();

                string url = "https://derpibooru.org/api/v1/json/search/images";
                client.BaseAddress = new Uri(url);

                int imgsFetched = 0;
                int page = 0;
                while (imgsFetched < amount)
                {
                    url = "https://derpibooru.org/api/v1/json/search/images";

                    url += $"?q={string.Join("%2C+", tags)}";
                    url += $"&filter_id=57027"; //"Everything" filter
                    url += $"&per_page=50";     //50? so low for an API :(

                    
                    page++;
                    url += $"&page={page}";

                    APIStatus = ($"Derpi call paginated p={page}");

                    D_API_Internal.Root dRes = null;
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(new Uri(url));
                        ValidateResponse(response);
                        string respStr = response.Content.ReadAsStringAsync().Result;
                        dRes = D_API_Internal.Conv.ConvertToRoot(respStr);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Derpi API Failed with {e}");
                        APIStatus = ($"Derpi API Failed");
                        return await Task.FromResult<List<ImageInfo>>(null);
                    }
                    

                    foreach (D_API_Internal.Image resp in dRes.images)
                    {
                        if(resp != null)
                        {
                            ImageInfo cur = new ImageInfo(resp.view_url, resp.created_at, resp.updated_at);
                            images.Add(cur);
                        }
                    }
                    imgsFetched += 50;
                }
                APIStatus = ("Derpi call complete");

                return await Task.FromResult(images);
            }
        }

    }

}
namespace D_API_Internal
{

    public class Conv
    {
        public static Root ConvertToRoot(string json)
        {
            Root R = JsonConvert.DeserializeObject<D_API_Internal.Root>(json);
            return R;
        }
    }

    public class Intensities
    {
        public double ne { get; set; }
        public double nw { get; set; }
        public double se { get; set; }
        public double sw { get; set; }
    }

    public class Representations
    {
        public string full { get; set; }
        public string large { get; set; }
        public string medium { get; set; }
        public string small { get; set; }
        public string tall { get; set; }
        public string thumb { get; set; }
        public string thumb_small { get; set; }
        public string thumb_tiny { get; set; }
        public string mp4 { get; set; }
        public string webm { get; set; }
    }

    public class Image
    {
        public int? uploader_id { get; set; }
        public Intensities intensities { get; set; }
        public int faves { get; set; }
        public string sha512_hash { get; set; }
        public List<string> tags { get; set; }
        public int size { get; set; }
        public int comment_count { get; set; }
        public string uploader { get; set; }
        public DateTime updated_at { get; set; }
        public string source_url { get; set; }
        public double wilson_score { get; set; }
        public int score { get; set; }
        public string description { get; set; }
        public int id { get; set; }
        public int upvotes { get; set; }
        public int height { get; set; }
        public DateTime created_at { get; set; }
        public object deletion_reason { get; set; }
        public bool thumbnails_generated { get; set; }
        public bool animated { get; set; }
        public bool processed { get; set; }
        public DateTime first_seen_at { get; set; }
        public string view_url { get; set; }
        public List<int> tag_ids { get; set; }
        public Representations representations { get; set; }
        public bool hidden_from_users { get; set; }
        public double aspect_ratio { get; set; }
        public int tag_count { get; set; }
        public int downvotes { get; set; }
        public int width { get; set; }
        public object duplicate_of { get; set; }
        public double duration { get; set; }
        public string name { get; set; }
        public string mime_type { get; set; }
        public string orig_sha512_hash { get; set; }
        public bool spoilered { get; set; }
        public string format { get; set; }
    }

    public class Root
    {
        [JsonProperty("images")]
        internal List<Image> images { get; set; }
        public List<object> interactions { get; set; }
        public int total { get; set; }
    }

}
