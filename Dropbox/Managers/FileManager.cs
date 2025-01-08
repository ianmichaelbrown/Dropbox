using Dropbox.Interfaces;
using System;
using System.Diagnostics;
using System.IO;

namespace Dropbox.Managers
{
    public class FileManager : IFileManager
    {
        private IFolderHelper _folderHelper;
        private IFileHelper _fileHelper;
        private IModel _model;

        public FileManager(IFileWatcherService fileWatcherService,
                           IFolderHelper folderHelper,
                           IFileHelper fileHelper,
                           IModel model)
        {
            _folderHelper = folderHelper;
            _fileHelper = fileHelper;
            _model = model;

            fileWatcherService.Initialise();
            fileWatcherService.FileAdded += OnFileWatcherService_FileAdded;
            fileWatcherService.FileRemoved += OnFileWatcherService_FileRemoved;
        }

        public string GetFolderPathAsync()
        {
            return _folderHelper.GetFolderPathAsync().Result;
        }

        private void OnFileWatcherService_FileAdded(string path)
        {
            string filename = Path.GetFileName(path);
            _model.AddLogMessage($"'{filename}' added to Input");

            CopyFileToTarget(path);
        }

        private void OnFileWatcherService_FileRemoved(string path)
        {
            string filename = Path.GetFileName(path);
            _model.AddLogMessage($"'{filename}' removed from Input");

            DeleteFileFromTarget(path);
        }

        private void CopyFileToTarget(string path)
        {
            string result = string.Empty;
            string filename = Path.GetFileName(path);
            var destPath = Path.Combine(_model.TargetFolderPath!, filename);

            if (_fileHelper.FileExists(path))
            {
                try
                {
                    _fileHelper.CopyFile(path, destPath, overwrite:true);
                    result = $"'{filename}' successfully synchronised with Target";
                }
                catch (Exception ex)
                {
                    result = $"*** Failed to synchronise '{filename}' with Target";
                    Debug.WriteLine($"{result}{Environment.NewLine}{ex.Message}{ex.StackTrace}");
                }
            }

            _model.AddLogMessage(result);
        }

        private void DeleteFileFromTarget(string path)
        {
            string result = string.Empty;
            string filename = Path.GetFileName(path);
            path = Path.Combine(_model.TargetFolderPath!, filename);

            if (_fileHelper.FileExists(path))
            {
                try
                {
                    _fileHelper.DeleteFile(path);
                    result = $"'{filename}' no longer in Target";
                }
                catch (Exception ex)
                {
                    result = $"*** Failed to delete '{filename}' from Target";
                    Debug.WriteLine($"{result}{Environment.NewLine}{ex.Message}{ex.StackTrace}");
                }
            }

            _model.AddLogMessage(result);
        }
    }
}
