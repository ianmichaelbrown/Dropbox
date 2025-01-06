using Microsoft.UI.Xaml;
using System.Threading.Tasks;

namespace Dropbox.Interfaces
{
    public interface IFolderHelper
    {
        void Initialise();// Window? window);

        Task<string> GetFolderPathAsync();
    }
}
