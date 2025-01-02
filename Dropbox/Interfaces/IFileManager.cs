namespace Dropbox.Interfaces
{
    interface IFileManager
    {
        bool CopyToTarget(string path);

        bool DeleteFromTarget(string path);

        bool AddToCopyQueue(string path);

        bool AddToDeleteQueue(string path);
    }
}
