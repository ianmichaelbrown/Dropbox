namespace Dropbox.Interfaces
{
    interface IFileManager
    {
        string GetFolderPathAsync();

        bool CopyToTarget(string path);

        bool DeleteFromTarget(string path);

        bool AddToCopyQueue(string path);

        bool AddToDeleteQueue(string path);
    }
}
