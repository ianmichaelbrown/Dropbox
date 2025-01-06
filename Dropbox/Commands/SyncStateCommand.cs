using Dropbox.Interfaces;
using System;

namespace Dropbox.Commands
{
    partial class SyncStateCommand : ISyncStateCommand
    {
        private IModel _model;

        public event EventHandler? CanExecuteChanged;

        public SyncStateCommand(IModel model)
        {
            _model = model;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _model.ToggleSyncState();
        }
    }
}
