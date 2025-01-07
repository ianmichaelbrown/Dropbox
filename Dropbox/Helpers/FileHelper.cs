using Dropbox.Interfaces;
using System.IO;

namespace Dropbox.Helpers
{
    class FileHelper : IFileHelper
    {
        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public void CopyFile(string sourceFileName, string destFileName, bool overwrite)
        {
            File.Copy(sourceFileName, destFileName, overwrite);
        }

        public void DeleteFile(string path)
        {
            File.Delete(path);
        }
    }
}
