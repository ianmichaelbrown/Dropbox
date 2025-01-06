using System.Threading.Tasks;

namespace Dropbox.Interfaces
{
    public interface IFolderHelper
    {
        void Initialise();

        Task<string> GetFolderPathAsync();
    }
}
