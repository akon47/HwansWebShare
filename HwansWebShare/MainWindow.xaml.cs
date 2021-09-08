using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HwansWebShare.WebServer;

namespace HwansWebShare
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            WebShareServer.Instance.Start();
        }

        private void SharedList_Drop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                foreach(string path in (string[])e.Data.GetData(DataFormats.FileDrop))
                {
                    FileAttributes fileAttributes = File.GetAttributes(path);
                    if(fileAttributes.HasFlag(FileAttributes.Directory))
                    {
                        WebShareServer.Instance.SharedDirectories.Add(new WebServer.SharedItem.SharedDirectory(path));
                    }
                }
            }
        }
    }
}
