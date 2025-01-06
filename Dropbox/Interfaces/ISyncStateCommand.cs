using System.Windows.Input;

namespace Dropbox.Interfaces
{
    public interface ISyncStateCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }
}
