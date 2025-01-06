using Dropbox.Enums;
using Dropbox.Interfaces;
using System.Collections.Generic;
using static Dropbox.Interfaces.IModel;

namespace Dropbox.Models
{
    class Model : IModel
    {
        public string? InputFolderPath { get; set; }
        public string? TargetFolderPath { get; set; }
        public bool IsSyncing { get; set; }
        public Queue<string> FileCopyPathQueue { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public Queue<string> FileDeletePathQueue { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public event FolderPathUpdatedHandler? FolderPathUpdated;
        public event SyncStateChangedHandler? SyncStateChanged;

        public Model()
        {
            IsSyncing = false;
        }

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

        public void AddToCopyQueue(string path)
        {
            throw new System.NotImplementedException();
        }

        public void AddToDeleteQueue(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}
