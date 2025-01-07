using Dropbox.Interfaces;

namespace Dropbox
{
    class AppController : IAppController
    {
        public AppController(IModel model,
                             IFileManager fileManager)
        {
        }
    }
}
