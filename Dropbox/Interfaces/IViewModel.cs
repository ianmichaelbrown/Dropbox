namespace Dropbox.Interfaces
{
    public interface IViewModel
    {
        string? InputFolderPath { get; set; }
        
        string? TargetFolderPath { get; set; }

        ISelectFolderCommand? SelectInputFolderCommand { get; }

        bool? IsSyncing { get; set; }

        string? SyncButtonText {  get; set; }

        string? SyncStatusText { get; set; }
    }
}
