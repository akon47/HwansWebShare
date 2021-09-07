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

        public override HttpResponse Process(IHttpRequest httpRequest)
        {
            string url = httpRequest.Url.Substring(4);

            return new HttpResponse(HttpStatusCode.OK)
            {
                Content = Encoding.UTF8.GetBytes("ApiRouter -> " + httpRequest.Url)
            };
        }
    }
}
