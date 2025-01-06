using Dropbox.Interfaces;
using Microsoft.UI.Xaml;
using System.Threading.Tasks;
using System;
using Windows.Storage.AccessCache;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace Dropbox.Helpers
{
    class FolderHelper : IFolderHelper
    {
        private FolderPicker? _folderPicker;

        public void Initialise()//Window? window)
        {
            var window = App.MainWindow;

            _folderPicker = new FolderPicker();
            _folderPicker.FileTypeFilter.Add("*");

            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
            WinRT.Interop.InitializeWithWindow.Initialize(_folderPicker, hWnd);
        }

        public async Task<string> GetFolderPathAsync()
        {
            StorageFolder folder = await _folderPicker!.PickSingleFolderAsync();

            if (folder != null)
            {
                //StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", folder);
                return folder.Path;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
