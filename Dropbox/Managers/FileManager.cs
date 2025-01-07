using Dropbox.Interfaces;
using System.IO;

namespace Dropbox.Managers
{
    class FileManager : IFileManager
    {
        private IFolderHelper _folderDialogHelper;
        private IModel _model;

        public FileManager(IFolderHelper folderDialogHelper,
                           IFileWatcherService fileWatcherService,
                           IModel model)
        {
            _folderDialogHelper = folderDialogHelper;
            _model = model;

            fileWatcherService.Initialise();
            fileWatcherService.FileAdded += OnFileWatcherService_FileAdded;
            fileWatcherService.FileRemoved += OnFileWatcherService_FileRemoved;
        }

        public string GetFolderPathAsync()
        {
            return _folderDialogHelper.GetFolderPathAsync().Result;
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

            if (File.Exists(path))
            {
                try
                {
                    File.Copy(path, destPath, overwrite:true);
                    result = $"'{filename}' successfully synchronised with Target";
                }
                catch
                {
                    result = $"*** Failed to synchronise '{filename}' with Target";
                }
            }

            _model.AddLogMessage(result);
        }

        private void DeleteFileFromTarget(string path)
        {
            string result = string.Empty;
            string filename = Path.GetFileName(path);
            path = Path.Combine(_model.TargetFolderPath!, filename);

            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                    result = $"'{filename}' no longer in Target";
                }
                catch
                {
                    result = $"*** Failed to delete '{filename}' from Target";
                }
            }

            _model.AddLogMessage(result);
        }
    }
}
