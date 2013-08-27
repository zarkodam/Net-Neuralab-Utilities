using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;

namespace MusicManager.Utilities
{
    public static class DataManager
    {
        public static void CopyFile(string fullSourcePath, string destination, string rootFolderName, string subFolderName, string destFileName)
        {
            string destFolder = Path.Combine(destination, rootFolderName, subFolderName);
            string destFile = Path.Combine(destFolder, string.Concat(destFileName, Path.GetExtension(fullSourcePath)));

            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(Path.Combine(destFolder));

            try
            {
                File.Copy(fullSourcePath, destFile, true);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void CopyFiles(string source, string destination, string rootFolderName, string subFolderName)
        {
            string sourceFile = Path.Combine(string.Concat(@"", source));
            string destFolder = Path.Combine(string.Concat(@"", destination), rootFolderName, subFolderName);

            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(Path.Combine(destFolder));

            string[] files = Directory.GetFiles(source);
            foreach (string file in files)
            {
                File.Copy(file, Path.Combine(destFolder, Path.GetFileName(file)), true);
                Trace.WriteLine(file);
            }
        }

        public static void MoveFile(string source, string destionation)
        {
            try
            {
                System.IO.File.Move(source, destionation);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void MoveDirectory(string source, string destionation)
        {
            try
            {
                Directory.Move(source, destionation);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void DeleteFile(string destination, string fileName)
        {
            if (File.Exists(string.Concat(@"", Path.Combine(destination, fileName))))
            {
                try
                {
                    File.Delete(string.Concat(@"", Path.Combine(destination, fileName)));
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public static void DeleteDirectory(string destination)
        {
            if (Directory.Exists(string.Concat(@"", destination)))
            {
                try
                {
                    Directory.Delete(string.Concat(@"", destination), true);
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
