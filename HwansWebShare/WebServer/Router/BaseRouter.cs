using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SimpleTcp.Server.Http;

namespace HwansWebShare.WebServer
{
    public abstract class BaseRouter : IRouter
    {
        protected abstract string UrlMatchPattern { get; }

        public bool IsRequestMatched(IHttpRequest httpRequest)
        {
            return Regex.IsMatch(httpRequest.Url, UrlMatchPattern);
        }

        public abstract HttpResponse Process(IHttpRequest httpRequest);
    }
}