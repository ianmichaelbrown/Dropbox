using Dropbox.Enums;
using Dropbox.Interfaces;
using System;
using System.Diagnostics;
using System.IO;

namespace Dropbox.Services
{
    class FileWatcherService : IFileWatcherService
    {
        private IModel _model;
        private FileSystemWatcher? _watcher;
        private bool _isInitialised;

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
                _watcher.Changed += OnChanged;
                _watcher.Renamed += OnRenamed;
                _watcher.Deleted += OnDeleted;
                _watcher.Error += OnError;

                _watcher.NotifyFilter = NotifyFilters.FileName;

                _watcher.Filters.Add("*.*");

                _watcher.IncludeSubdirectories = false;

                //_watcher.InternalBufferSize = 65535;

                _isInitialised = true;

                //EnableWatcher();
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
            //DisableWatcher();
            ////_fileManager.AddFile(e.FullPath);
            //EnableWatcher();
            Debug.WriteLine($"Created {e.FullPath}");
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            Debug.WriteLine($"Changed {e.FullPath}");
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            Debug.WriteLine($"Renamed {e.FullPath}");
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Debug.WriteLine($"Deleted {e.FullPath}");
        }

        private void OnError(object sender, ErrorEventArgs e)
        {
            //message = $"*** FileSystemWatcher exception: '{e.GetException().Message}' ***";

            //Debug.WriteLine(message);
            //Log.Error(message);
            //((App)Application.Current).ShowTaskbarBalloon(message, BalloonIcon.Warning);
            //Thread.Sleep(3000);
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
