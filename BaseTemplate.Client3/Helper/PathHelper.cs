using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTemplate.Client3.Helper
{
    public class PathHelper
    {
        public static void Init(string rootPath, bool createFolder = false)
        {
            RootPath = rootPath;
            if (createFolder)
            {
                Directory.CreateDirectory(RootPath);
                Directory.CreateDirectory(LogFolderPath);
            }
        }
        private static string rootPath;
        public static string RootPath 
        {
            get=> rootPath == null ? System.Environment.CurrentDirectory : rootPath;
            set => rootPath = value;
        }
        public static string LogFolderPath 
        { 
            get=>Path.Combine(RootPath,"log");
        }
        public static string LogFilePath
        {
            get => Path.Combine(LogFolderPath, "log-.txt");
        }
    }
}
