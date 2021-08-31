using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTcp.Server.Http;

namespace HwansWebShare.WebServer
{
    public class HtmlRouter : BaseRouter
    {
        protected override string UrlMatchPattern => "^((?!\\/api\\/).).*";

        private string _htmlDirectory;

        public HtmlRouter(string htmlDirectory)
        {
            _htmlDirectory = htmlDirectory;
        }

        public override HttpResponse Process(IHttpRequest httpRequest)
        {
            string filePath = System.IO.Path.GetFullPath(_htmlDirectory + httpRequest.Url);
            if(System.IO.File.Exists(filePath))
            {
                return CreateHttpResponse(filePath);
            }
            else
            {
                return new HttpResponse(HttpStatusCode.NotFound)
                {
                    Content = Encoding.UTF8.GetBytes(filePath)
                };
            }
        }

        private HttpResponse CreateHttpResponse(string filePath)
        {
            HttpResponse httpResponse = new HttpResponse(HttpStatusCode.OK)
            {
                Content = System.IO.File.ReadAllBytes(filePath),
            };
            httpResponse.Headers.Add("content-type", MimeTypes.MimeTypeMap.GetMimeType(filePath));
            return httpResponse;
        }
    }
}
