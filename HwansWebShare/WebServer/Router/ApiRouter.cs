using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTcp.Server.Http;

namespace HwansWebShare.WebServer
{
    public class ApiRouter : BaseRouter
    {
        protected override string UrlMatchPattern => "^\\/api\\/";

        private SharedItem.SharedDirectories _sharedDirectories;

        public ApiRouter(SharedItem.SharedDirectories sharedDirectories)
        {
            _sharedDirectories = sharedDirectories;
        }

        public override HttpResponse Process(IHttpRequest httpRequest)
        {
            string url = httpRequest.Url.Substring(4);

            return new HttpResponse(HttpStatusCode.OK)
            {
                Content = Encoding.UTF8.GetBytes("ApiRouter -> " + httpRequest.Url + "<br/>" + string.Join("<br/>", _sharedDirectories.Select(s => s.Path)))
            };
        }
    }
}
