namespace Dropbox.Interfaces
{
    public interface IFileWatcherService
    {
        delegate void FileAddedHandler(string path);
        event FileAddedHandler FileAdded;

        delegate void FileRemovedHandler(string path);
        event FileRemovedHandler FileRemoved;

        void Initialise();
    }
}
