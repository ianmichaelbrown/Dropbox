using System.Collections.Generic;

namespace Dropbox.Interfaces
{
    public interface IModel
    {
        delegate void SyncStateChangedHandler(bool isSyncing);

        delegate void NewLogMessageHandler(string logMessage);

        string? InputFolderPath { get; set; }

        string TargetFolderPath { get; set; }

        bool IsSyncing { get; set; }

        Queue<string> FileCopyPathQueue { get; set; }

        Queue<string> FileDeletePathQueue { get; set; }

        void SetInputPath(string path);

        void SetTargetPath(string path);

        void SetSyncState(bool isSyncing);

        void AddToCopyQueue(string path);

        void AddToDeleteQueue(string path);
        
        // remove from queues?
    }
}
