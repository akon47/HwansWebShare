using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwansWebShare.WebServer.SharedItem
{
    public class SharedDirectory
    {
        public string Path { get; private set; }
        public bool Recursive { get; private set; }

        public SharedDirectory(string path)
        {
            Path = path;
        }
    }
}
