using System;
using System.IO;

namespace progreso3mj
{
    public static class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(path, filename);
        }
    }
}
