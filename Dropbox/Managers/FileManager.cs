using Dropbox.Interfaces;

namespace Dropbox.Managers
{
    class FileManager : IFileManager
    {
        private IFolderHelper _folderDialogHelper;

        public FileManager(IFolderHelper folderDialogHelper,
                           IFileWatcherService fileWatcherService)
        {
            _folderDialogHelper = folderDialogHelper;
        }

        public string GetFolderPathAsync()
        {
            return _folderDialogHelper.GetFolderPathAsync().Result;
        }

        public bool AddToCopyQueue(string path)
        {
            throw new System.NotImplementedException();
        }

        public bool AddToDeleteQueue(string path)
        {
            throw new System.NotImplementedException();
        }

        public bool CopyToTarget(string path)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteFromTarget(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}
