using Dropbox.Interfaces;

namespace Dropbox
{
    class AppController : IAppController
    {
        public AppController(IViewModel viewModel,
                             IModel model,
                             ISyncManager syncManager,
                             IFileManager fileManager)
        {
            //syncManager.Start();
        }
    }
}
