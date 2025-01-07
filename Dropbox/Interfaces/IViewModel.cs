using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml.Media;
using System.Collections.ObjectModel;

namespace Dropbox.Interfaces
{
    public interface IViewModel
    {
        DispatcherQueue DispatcherQueue { get; set; }

        string? InputFolderPath { get; set; }
        
        string? TargetFolderPath { get; set; }

        ISelectFolderCommand? SelectInputFolderCommand { get; }

        bool? IsSyncing { get; set; }

        string? SyncButtonText {  get; set; }

        string? SyncStatusText { get; set; }

        SolidColorBrush SyncButtonColour { get; }

        ObservableCollection<string>? LogMessageList { get; set; }
    }
}
