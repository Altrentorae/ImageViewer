using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer
{
    class E6_API : ExternalAPIHandler
    {
        public override async Task<List<ImageInfo>> GetImagesAsync(string[] tags, int amount)
        {
            if (amount > 320) { amount = 320; }
            if (amount <= 0) { amount = 1; }

            string url = "https://e621.net/posts.json";

            url += $"?tags={string.Join("+", tags)}";
            url += $"&limit={amount}";

            using (var client = GetHttpClient())
            {
                client.BaseAddress = new Uri(url);
                APIStatus = ("Accessing E6 API");

                E6_API_Internal.Root dRes;
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    ValidateResponse(response);
                    string respStr = response.Content.ReadAsStringAsync().Result;
                    dRes = JsonConvert.DeserializeObject<E6_API_Internal.Root>(respStr);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"E6 API Failed with {e}");
                    APIStatus = ($"E6 API Failed");
                    return await Task.FromResult<List<ImageInfo>>(null);
                }

                APIStatus = ("E6 call complete");

                List<ImageInfo> images = new List<ImageInfo>();
                foreach (E6_API_Internal.Post post in dRes.posts)
                {
                    if(post.file.url != null)
                    {
                        ImageInfo cur = new ImageInfo(post.file.url, post.created_at, post.updated_at);
                        images.Add(cur);
                    }
                }
                return await Task.FromResult(images);
            }
        }
    }
}

namespace E6_API_Internal
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class File
    {
        public int width { get; set; }
        public int height { get; set; }
        public string ext { get; set; }
        public int size { get; set; }
        public string md5 { get; set; }
        public string url { get; set; }
    }

    public class Preview
    {
        public int width { get; set; }
        public int height { get; set; }
        public string url { get; set; }
    }

    public class _480p
    {
        public string type { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public List<string> urls { get; set; }
    }

    public class Original
    {
        public string type { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public List<string> urls { get; set; }
    }

    public class Alternates
    {
        public _480p _480p { get; set; }
        public Original original { get; set; }
    }

    public class Sample
    {
        public bool has { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public string url { get; set; }
        public Alternates alternates { get; set; }
    }

    public class Score
    {
        public int up { get; set; }
        public int down { get; set; }
        public int total { get; set; }
    }

    public class Tags
    {
        public List<string> general { get; set; }
        public List<string> species { get; set; }
        public List<string> character { get; set; }
        public List<string> copyright { get; set; }
        public List<string> artist { get; set; }
        public List<string> invalid { get; set; }
        public List<string> lore { get; set; }
        public List<string> meta { get; set; }
    }

    public class Flags
    {
        public bool pending { get; set; }
        public bool flagged { get; set; }
        public bool note_locked { get; set; }
        public bool status_locked { get; set; }
        public bool rating_locked { get; set; }
        public bool deleted { get; set; }
    }

    public class Relationships
    {
        public int? parent_id { get; set; }
        public bool has_children { get; set; }
        public bool has_active_children { get; set; }
        public List<int> children { get; set; }
    }

    public class Post
    {
        public int id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public File file { get; set; }
        public Preview preview { get; set; }
        public Sample sample { get; set; }
        public Score score { get; set; }
        public Tags tags { get; set; }
        public List<object> locked_tags { get; set; }
        public int change_seq { get; set; }
        public Flags flags { get; set; }
        public string rating { get; set; }
        public int fav_count { get; set; }
        public List<string> sources { get; set; }
        public List<int> pools { get; set; }
        public Relationships relationships { get; set; }
        public int? approver_id { get; set; }
        public int uploader_id { get; set; }
        public string description { get; set; }
        public int comment_count { get; set; }
        public bool is_favorited { get; set; }
        public bool has_notes { get; set; }
        public double? duration { get; set; }
    }

    public class Root
    {
        public List<Post> posts { get; set; }
    }


}