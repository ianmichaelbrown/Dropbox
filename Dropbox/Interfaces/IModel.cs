using Dropbox.Enums;

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

        bool CanStartStopSync { get; }

        void SetInputPath(string path);

        void SetTargetPath(string path);

        void ToggleSyncState();

        void AddLogMessage(string message);
    }
}
