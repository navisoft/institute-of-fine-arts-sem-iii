using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace eProjectsSemIII.Libs
{
    public static class FilesClass
    {
        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }
        public static void RenameFile(string oldPath, string newPath)
        {
            try
            {
                File.Move(oldPath, newPath);
            }
            catch
            {

            }
        }
    }
}