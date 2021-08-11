using System;
using System.IO;

namespace MVVM_XML_RS.Services
{
    internal class PathFinder
    {
        public static string PathFinder_Ex()
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new ();
            openFileDlg.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDlg.DefaultExt = ".xml";
            openFileDlg.Filter = "Документ (.xml)|*.xml";
            
            return (openFileDlg.ShowDialog() is true) ? openFileDlg.FileName : string.Empty;
        }
    }
}
