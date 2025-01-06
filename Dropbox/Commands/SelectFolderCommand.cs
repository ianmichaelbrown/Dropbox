using Dropbox.Enums;
using Dropbox.Interfaces;
using System;

namespace Dropbox.Commands
{
    public partial class SelectFolderCommand : ISelectFolderCommand
    {
        private IFolderHelper _folderHelper;
        private IModel _model;

        public FolderType FolderType { get; set; }

        public event EventHandler? CanExecuteChanged;

        public SelectFolderCommand(IFolderHelper folderHelper,
                                   IModel model)
        {
            _folderHelper = folderHelper;
            _model = model;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            var folderPath = await _folderHelper.GetFolderPathAsync();

            if (FolderType == FolderType.Input)
            {
                _model.SetInputPath(folderPath);
            }
            else
            {
                _model.SetTargetPath(folderPath);
            }
        }
    }
}
