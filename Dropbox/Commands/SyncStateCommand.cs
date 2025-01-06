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
            return _model.CanStartStopSync;
        }

        public void Execute(object? parameter)
        {
            _model.ToggleSyncState();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
