using Dropbox.Enums;
using Dropbox.Interfaces;
using System.Diagnostics;

namespace Dropbox.Models
{
    class Model : IModel
    {
        public string? InputFolderPath { get; set; }
        public string? TargetFolderPath { get; set; }
        public bool IsSyncing { get; set; }

        public event IModel.FolderPathUpdatedHandler? FolderPathUpdated;
        public event IModel.SyncStateChangedHandler? SyncStateChanged;

        public Model()
        {
            IsSyncing = false;
        }

        public bool CanStartStopSync => !string.IsNullOrWhiteSpace(InputFolderPath) && !string.IsNullOrWhiteSpace(TargetFolderPath);

        public void SetInputPath(string path)
        {
            InputFolderPath = path;

            FolderPathUpdated?.Invoke(FolderType.Input, path);
        }

        public void SetTargetPath(string path)
        {
            TargetFolderPath = path;

            FolderPathUpdated?.Invoke(FolderType.Target, path);
        }

        public void ToggleSyncState()
        {
            IsSyncing = !IsSyncing;

            SyncStateChanged?.Invoke(IsSyncing);
        }

        public void AddLogMessage(string message)
        {
            Debug.WriteLine("Log message: " + message);

            if (!string.IsNullOrWhiteSpace(message))
            {
                // notify vm
            }
        }
    }
}
