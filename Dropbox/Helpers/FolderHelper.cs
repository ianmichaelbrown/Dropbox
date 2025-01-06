using Dropbox.Interfaces;
using System.Threading.Tasks;
using System;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace Dropbox.Helpers
{
    class FolderHelper : IFolderHelper
    {
        private FolderPicker? _folderPicker;

        public void Initialise()
        {
            _folderPicker = new FolderPicker();
            _folderPicker.FileTypeFilter.Add("*");

            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(App.MainWindow);
            WinRT.Interop.InitializeWithWindow.Initialize(_folderPicker, hWnd);
        }

        public async Task<string> GetFolderPathAsync()
        {
            StorageFolder folder = await _folderPicker!.PickSingleFolderAsync();

            if (folder != null)
            {
                return folder.Path;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
