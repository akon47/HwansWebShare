using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyValueConfig;

namespace HwansWebShare.WebServer.SharedItem
{
    public class SharedDirectory : NotifyPropertyBase, IConfigurable
    {
        public string Path { get; private set; }

        private bool recursive = false;
        public bool Recursive
        {
            get => recursive;
            set => SetProperty(ref recursive, value);
        }

        public SharedDirectory(string path)
        {
            Path = path;
        }

        public ConfigStore CreateConfigStore()
        {
            ConfigStore configStore = new ConfigStore();

            configStore.SetValue(nameof(Path), Path);
            configStore.SetValue(nameof(Recursive), Recursive);

            return configStore;
        }

        public void LoadFromConfigStore(ConfigStore configStore)
        {
            Path = configStore.GetString(nameof(Path), "");
            Recursive = configStore.GetBool(nameof(Recursive), false);
        }
    }
}
