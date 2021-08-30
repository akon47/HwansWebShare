using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTcp.Server.Http;

namespace HwansWebShare.WebServer
{
    public interface IRouter
    {
        bool IsRequestMatched(IHttpRequest httpRequest);

        HttpResponse Process(IHttpRequest httpRequest);
    }
}
