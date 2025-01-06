using Dropbox.Commands;

namespace Dropbox.Interfaces
{
    public interface IViewModel
    {
        ISelectFolderCommand? SelectInputFolderCommand { get; }
    }
}
