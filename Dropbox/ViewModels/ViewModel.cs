using Dropbox.Enums;
using Dropbox.Interfaces;
using System.Collections.ObjectModel;

namespace Dropbox.ViewModels
{
    public partial class ViewModel : NotifiableBase, IViewModel
    {
        private readonly string StartSyncText = "Start Synchronising";
        private readonly string StopSyncText = "Stop Synchronising";
        private readonly string SyncRunningStatusText = "Synchronising files...";
        private readonly string SyncStoppedStatusText = "Synchronising stopped";

        private string? _inputFolderPath;
        private string? _targetFolderPath;
        private string? _syncStatusText;
        private string? _syncButtonText;
        private bool? isSyncing;

        public ViewModel(ISelectFolderCommand selectInputFolderCommand,
                         ISelectFolderCommand selectTargetFolderCommand,
                         ISyncStateCommand syncStateCommand,
                         IModel model)
        {
            SelectInputFolderCommand = selectInputFolderCommand;
            SelectInputFolderCommand.FolderType = FolderType.Input;

            SelectTargetFolderCommand = selectTargetFolderCommand;
            SelectTargetFolderCommand.FolderType = FolderType.Target;

            SyncStateCommand = syncStateCommand;

            model.FolderPathUpdated += OnFolderPathUpdated;

            IsSyncing = model.IsSyncing;

            model.SyncStateChanged += OnSyncStateChanged;
        }

        public string? InputFolderPath
        {
			get => _inputFolderPath;
			set
            {
                if (value != _inputFolderPath)
                {
                    _inputFolderPath = value;
                    OnPropertyChanged();
                }
            }
		}

        public string? TargetFolderPath
        {
            get => _targetFolderPath;
            set
            {
                if (value != _targetFolderPath)
                {
                    _targetFolderPath = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool? IsSyncing
        {
            get => isSyncing;
            set
            {
                if (value != isSyncing)
                {
                    isSyncing = value;
                    OnPropertyChanged();

                    UpdateSyncButton();
                    UpdateSyncStatus();
                }
            }
        }

        public string? SyncButtonText
        {
            get => _syncButtonText;
            set
            {
                if (value != _syncButtonText)
                {
                    _syncButtonText = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? SyncStatusText
        {
            get => _syncStatusText;
            set
            {
                if (value != _syncStatusText)
                {
                    _syncStatusText = value;
                    OnPropertyChanged();
                }
            }
        }

        public ISelectFolderCommand? SelectInputFolderCommand { get; set; }

        public ISelectFolderCommand? SelectTargetFolderCommand { get; set; }

        public ISyncStateCommand? SyncStateCommand { get; set; }

        ObservableCollection<string>? LogMessageList { get; set; }

        private void UpdateSyncButton()
        {
            SyncButtonText = (bool)IsSyncing! ? StopSyncText : StartSyncText;
        }

        private void UpdateSyncStatus()
        {
            SyncStatusText = (bool)IsSyncing! ? SyncRunningStatusText : SyncStoppedStatusText;
        }

        private void OnFolderPathUpdated(FolderType folderType, string path)
        {
            if (folderType == FolderType.Input)
            {
                InputFolderPath = path;
            }
            else
            {
                TargetFolderPath = path;
            }

            SyncStateCommand!.RaiseCanExecuteChanged();
        }

        private void OnSyncStateChanged(bool isSyncing)
        {
            IsSyncing = isSyncing;

            SelectInputFolderCommand!.RaiseCanExecuteChanged();
            SelectTargetFolderCommand!.RaiseCanExecuteChanged();
        }
    }
}
