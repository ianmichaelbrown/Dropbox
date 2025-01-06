using Dropbox.Enums;
using System.Windows.Input;

namespace Dropbox.Interfaces
{
    public interface ISelectFolderCommand : ICommand
    {
        //bool IsForInputFolder { get; set; }
        FolderType FolderType { get; set; }
    }
}
