namespace Dropbox.Interfaces
{
    public interface IFileHelper
    {
        bool FileExists(string path);

        void CopyFile(string sourceFileName, string destFileName, bool overwrite);

        void DeleteFile(string path);
    }
}
