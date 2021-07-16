using System;
using System.IO;

namespace MVVM_XML_RS.Services
{
    internal class PathFinder
    {
        public static string PathFinder_Ex()
        {
            string path = "";

            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            openFileDlg.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDlg.DefaultExt = ".xml";
            openFileDlg.Filter = "Документ (.xml)|*.xml";
            Nullable<bool> result = openFileDlg.ShowDialog();
            if (result == true)
            {
                path = openFileDlg.FileName;
            }
            return path;
        }
    }
}
