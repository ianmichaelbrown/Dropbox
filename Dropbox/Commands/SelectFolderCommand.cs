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

        //public bool IsForInputFolder { get; set; } = true;

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
            //bool isForInputFolder = true;

            //if (parameter != null && bool.TryParse(parameter, out isForInputFolder))
            {
                //bool isForInputFolder = (bool)parameter;
                
                var folderPath = await _folderHelper.GetFolderPathAsync();

                //if (isForInputFolder)
                if (FolderType == FolderType.Input)
                {
                    _model.InputFolderPath = folderPath;
                }
                else
                {
                    _model.TargetFolderPath = folderPath;
                }
            }
        }
    }
}
