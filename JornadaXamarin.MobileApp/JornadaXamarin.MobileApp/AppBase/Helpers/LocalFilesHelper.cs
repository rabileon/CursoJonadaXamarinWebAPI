using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JornadaXamarin.MobileApp.AppBase.Helpers
{
    public static class LocalFilesHelper
    {
        private static readonly string localPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string SaveFile(string fileName, byte[] data)
        {
            var filePath = Path.Combine(localPath, fileName);
            File.WriteAllBytes(filePath, data);
            return filePath;
        }

        public static byte[] ReadFile(string fileName)
        {
            var filePath = Path.Combine(localPath, fileName);

            if (!File.Exists(filePath))
            {
                return null;
            }
            return File.ReadAllBytes(filePath);
        }
    }
}
