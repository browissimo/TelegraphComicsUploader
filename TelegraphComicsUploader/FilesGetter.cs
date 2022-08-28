using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TelegraphComicsUploader
{
    internal class FilesGetter
    {
        private readonly string? folderPath = String.Empty;
        public FilesGetter(string? folderPath)
        {
            this.folderPath = folderPath;
        }

        public List<string> GetFilesPaths()
        {
            if (Directory.Exists(folderPath))
            {
                return Directory.GetFiles(folderPath).ToList<string>();
            }
            else
            {
                Console.WriteLine("Папки не существует");
                return new List<string> { };
            }
        }

        public string GetFolderName()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(folderPath);
                return dir.Name;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
