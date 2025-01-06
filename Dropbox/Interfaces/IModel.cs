using Dropbox.Enums;
using System.Collections.Generic;

namespace Dropbox.Interfaces
{
    public interface IModel
    {
        delegate void FolderPathUpdatedHandler(FolderType folderType, string path);
        event FolderPathUpdatedHandler? FolderPathUpdated;

        delegate void SyncStateChangedHandler(bool isSyncing);
        event SyncStateChangedHandler? SyncStateChanged;

        delegate void NewLogMessageHandler(string logMessage);

        string? InputFolderPath { get; set; }

        string? TargetFolderPath { get; set; }

        bool IsSyncing { get; set; }

        Queue<string> FileCopyPathQueue { get; set; }

        Queue<string> FileDeletePathQueue { get; set; }

        void SetInputPath(string path);

        void SetTargetPath(string path);

        void ToggleSyncState();

        void AddToCopyQueue(string path);

        void AddToDeleteQueue(string path);

        // remove from queues?
    }
}
