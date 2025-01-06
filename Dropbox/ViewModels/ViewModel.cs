using Dropbox.Commands;
using Dropbox.Enums;
using Dropbox.Interfaces;
using System.Collections.ObjectModel;

namespace Dropbox.ViewModels
{
    public partial class ViewModel : NotifiableBase, IViewModel
    {
        private string? _inputFolderPath;
        private string? _targetFolderPath;
        private string? _syncStatusText;
        private string? _syncButtonText;

        //public ViewModel()
        //{

        //}
        public ViewModel(ISelectFolderCommand selectInputFolderCommand,
                         ISelectFolderCommand selectTargetFolderCommand,
                         ISyncStateCommand syncStateCommand)
        {
            SelectInputFolderCommand = selectInputFolderCommand;
            //SelectInputFolderCommand.IsForInputFolder = true;
            SelectInputFolderCommand.FolderType = FolderType.Input;

            SelectTargetFolderCommand = selectTargetFolderCommand;
            //SelectTargetFolderCommand.IsForInputFolder = false;
            SelectTargetFolderCommand.FolderType = FolderType.Target;
        }

        string? InputFolderPath
        {
			get => _inputFolderPath;
			set
            {
                if (null != _inputFolderPath)
                {
                    _inputFolderPath = value;
                    OnPropertyChanged();
                }
            }
		}

        string? TargetFolderPath
        {
            get => _targetFolderPath;
            set
            {
                if (null != _targetFolderPath)
                {
                    _targetFolderPath = value;
                    OnPropertyChanged();
                }
            }
        }

        string? SyncButtonText
        {
            get => _syncButtonText;
            set
            {
                if (null != _syncButtonText)
                {
                    _syncButtonText = value;
                    OnPropertyChanged();
                }
            }
        }

        string? SyncStatusText
        {
            get => _syncStatusText;
            set
            {
                if (null != _syncStatusText)
                {
                    _syncStatusText = value;
                    OnPropertyChanged();
                }
            }
        }

        public ISelectFolderCommand? SelectInputFolderCommand { get; set; }

        public ISelectFolderCommand? SelectTargetFolderCommand { get; set; }

        SyncStateCommand? SyncStateCommand { get; set; }

        ObservableCollection<string>? LogMessageList { get; set; }
    }
}
