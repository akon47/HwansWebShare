using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTcp.Server;

namespace HwansWebShare.HttpServer
{
    public sealed class HwansWebServer : IDisposable
    {
        #region Constuctor
        private static volatile HwansWebServer instance;
        private static object syncRoot = new object();
        public static HwansWebServer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new HwansWebServer();
                        }
                    }
                }

                return instance;
            }
        }

        private HwansWebServer()
        {
            rawTcpServer = new RawTcpServer();
            rawTcpServer.DataReceived += RawTcpServer_DataReceived;
        }
        #endregion

        #region Private Members
        private RawTcpServer rawTcpServer;
        #endregion

        #region Public Methods
        public void Start()
        {
            rawTcpServer?.Start(80);
        }

        public void Stop()
        {
            rawTcpServer?.Stop();
        }

        public void Dispose()
        {
            rawTcpServer?.Dispose();
        }
        #endregion

        #region Private Methods

        private void RawTcpServer_DataReceived(object sender, DataReceivedEventArgs e)
        {
            // test code...
            byte[] buffer = new byte[e.Client.BytesToRead];
            e.Client.Read(buffer, 0, buffer.Length);
            Console.WriteLine(Encoding.ASCII.GetString(buffer));


            string contentString = "Hello, World!!";
            byte[] content = Encoding.ASCII.GetBytes(contentString);

            StringBuilder sb = new StringBuilder();
            sb.Append("HTTP/1.1 200 OK\r\n");
            sb.Append($"Content-Length: {content.Length}\r\n");
            sb.Append("Content-Type: text/html\r\n\r\n");
            sb.Append(contentString);

            byte[] response = Encoding.ASCII.GetBytes(sb.ToString());
            e.Client.Write(response, 0, response.Length);

            e.Client.TcpClient.Dispose();
        }
        #endregion
    }
}
