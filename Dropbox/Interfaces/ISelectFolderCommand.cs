using Dropbox.Enums;
using System.Windows.Input;

namespace Dropbox.Interfaces
{
    public interface ISelectFolderCommand : ICommand
    {
        FolderType FolderType { get; set; }
    }
}
