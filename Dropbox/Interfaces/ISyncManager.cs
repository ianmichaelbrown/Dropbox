namespace Dropbox.Interfaces
{
    interface ISyncManager
    {
        bool IsRunning { get; set; }

        void Start();
    }
}
