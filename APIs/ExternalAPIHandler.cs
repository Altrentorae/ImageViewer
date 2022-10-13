using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ImageViewer
{
    public class ExternalAPIHandler
    {
        public string Key { get; set; }


        public delegate void APIStatusChangedHandler(object obj, APIStatusChangedArgs args);
        public event APIStatusChangedHandler OnAPIStatusChanged;

        private string innerAPIStatus;
        public string APIStatus
        {
            get => innerAPIStatus;
            protected set
            {
                innerAPIStatus = value;
                OnAPIStatusChanged(this, new APIStatusChangedArgs(value));
            }
        }

        public HttpClient GetHttpClient()
        {
            HttpClient http = new HttpClient();
            http.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "ImageViewer; dotnet/4.7.2 (https://Github.com/Altrentorae/ImageViewer)");
            return http;
        }

        public void ValidateResponse(HttpResponseMessage hrm)
        {
            if (!hrm.IsSuccessStatusCode) { throw new HttpRequestException($"API threw code {hrm.StatusCode}"); }
        }


        //VIRTUAL METHODS

        public virtual Task<List<ImageInfo>> GetImagesAsync(string[] tags, int amount)
        {
            return null;
        }

    }

    public class APIStatusChangedArgs : EventArgs
    {
        public APIStatusChangedArgs(string _apistatus)
        {
            newAPIStatus = _apistatus;
        }

        public string newAPIStatus { get; set; }
    }
}
