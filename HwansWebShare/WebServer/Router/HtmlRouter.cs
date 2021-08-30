﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTcp.Server.Http;

namespace HwansWebShare.WebServer
{
    public class HtmlRouter : BaseRouter
    {
        protected override string UrlMatchPattern => "^\\/$";

        public override HttpResponse Process(IHttpRequest httpRequest)
        {
            return new HttpResponse(HttpStatusCode.OK)
            {
                Content = Encoding.UTF8.GetBytes("Hello !!")
            };
        }
    }
}