using Dropbox.Enums;
using Dropbox.Interfaces;
using System.Diagnostics;
using System.IO;

namespace Dropbox.Services
{
    public class FileWatcherService : IFileWatcherService
    {
        private IModel _model;
        private FileSystemWatcher? _watcher;
        private bool _isInitialised;

        public event IFileWatcherService.FileAddedHandler? FileAdded;
        public event IFileWatcherService.FileRemovedHandler? FileRemoved;

        public FileWatcherService(IModel model)
        {
            _model = model;

            _model.FolderPathUpdated += OnFolderPathUpdated;
            _model.SyncStateChanged += OnSyncStateChanged;
        }

        public void Initialise()
        {
            if (!_isInitialised)
            {
                _watcher = new FileSystemWatcher();
                _watcher.Created += OnCreated;
                _watcher.Deleted += OnDeleted;
                _watcher.Error += OnError;

                _watcher.NotifyFilter = NotifyFilters.FileName;

                _watcher.Filters.Add("*.*");

                _watcher.IncludeSubdirectories = false;

                _isInitialised = true;
            }
        }

        private void EnableWatcher()
        {
            if (_isInitialised && !string.IsNullOrEmpty(_watcher!.Path))
            {
                _watcher!.EnableRaisingEvents = true;
            }
        }

        private void DisableWatcher()
        {
            if (_isInitialised)
            {
                _watcher!.EnableRaisingEvents = false;
            }
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            Debug.WriteLine($"Created {e.FullPath}");

            FileAdded?.Invoke(e.FullPath);
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Debug.WriteLine($"Deleted {e.FullPath}");

            FileRemoved?.Invoke(e.FullPath);
        }

        private void OnError(object sender, ErrorEventArgs e)
        {
            Debug.WriteLine($"*** FileSystemWatcher exception: '{e.GetException().Message}' ***");
        }

        private void OnFolderPathUpdated(FolderType folderType, string path)
        {
            if (folderType == FolderType.Input)
            {
                SetMonitoredFolder(path);
            }
        }

        private void OnSyncStateChanged(bool isSyncing)
        {
            if (_model.IsSyncing)
            {
                EnableWatcher();
            }
            else
            {
                DisableWatcher();
            }
        }

        private void SetMonitoredFolder(string folderPath)
        {
            if (_isInitialised)
            {
                _watcher!.Path = folderPath;
            }
        }
    }
}
