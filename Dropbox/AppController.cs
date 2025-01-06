using Dropbox.Interfaces;
using Microsoft.UI.Xaml;

namespace Dropbox
{
    class AppController : IAppController
    {
        public AppController(IModel model,
                             ISyncManager syncManager,
                             IFileManager fileManager)
        {
            //syncManager.Start();
        }
    }
}
