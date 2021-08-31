using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTcp.Server;
using SimpleTcp.Server.Http;

namespace HwansWebShare.WebServer
{
    public sealed class WebShareServer : NotifyPropertyBase, IDisposable
    {
        #region Constuctor
        private static volatile WebShareServer instance;
        private static object syncRoot = new object();
        public static WebShareServer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new WebShareServer();
                        }
                    }
                }

                return instance;
            }
        }

        private WebShareServer()
        {
            httpServer = new HttpServer();
            httpServer.HttpRequest += HttpServer_HttpRequest;

            routers = new List<IRouter>();
            routers.Add(new ApiRouter());
            routers.Add(new HtmlRouter(AppConstants.HtmlFolderPath));
        }
        #endregion

        #region Properties
        private string rootDirecotry;
        public string RootDirectory
        {
            get => rootDirecotry;
            set => SetProperty(ref rootDirecotry, value);
        }
        #endregion

        #region Private Members
        private HttpServer httpServer;
        private List<IRouter> routers;
        #endregion

        #region Public Methods
        public void Start(int port = 80)
        {
            httpServer?.Start(port);
        }

        public void Stop()
        {
            httpServer?.Stop();
        }

        public void Dispose()
        {
            httpServer?.Dispose();
        }
        #endregion

        #region Private Methods
        private HttpResponse HttpServer_HttpRequest(object sender, HttpRequestEventArgs e)
        {
            try
            {
                var matchedRouter = routers.SingleOrDefault(router => router.IsRequestMatched(e.Request));
                return matchedRouter != null ? matchedRouter.Process(e.Request) : new HttpResponse(HttpStatusCode.NotFound);
            }
            catch(Exception ex)
            {
                return new HttpResponse(HttpStatusCode.InternalServerError)
                {
                    Content = Encoding.UTF8.GetBytes(ex.Message)
                };
            }
        }
        #endregion
    }
}
