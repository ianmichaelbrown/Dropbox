﻿using Dropbox.Commands;
using Dropbox.Helpers;
using Dropbox.Interfaces;
using Dropbox.Managers;
using Dropbox.Models;
using Dropbox.Services;
using Dropbox.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Dropbox
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        private Window? m_window;
        private IHost? _host;

        public static MainWindow MainWindow = new();

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override async void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            Configure();

            await _host!.StartAsync();

            var appController = _host.Services.GetRequiredService<IAppController>();

            //m_window = new MainWindow();
            //var vm = _host.Services.GetRequiredService<IViewModel>();
            //((MainWindow)m_window).Initialise(vm);

            //var folderDialogHelper = _host.Services.GetRequiredService<IFolderHelper>();
            //folderDialogHelper.Initialise(m_window);

            //m_window.Activate();

            var folderDialogHelper = _host.Services.GetRequiredService<IFolderHelper>();
            folderDialogHelper.Initialise();// App.MainWindow);

            var vm = _host.Services.GetRequiredService<IViewModel>();
            MainWindow.Initialise(vm);
            MainWindow.Activate();
        }

        private void Configure()
        {
            _host = new HostBuilder()
                        .ConfigureServices(services =>
                        {
                            // Controllers
                            services.AddSingleton<IAppController, AppController>();
                            // Managers
                            services.AddSingleton<IFileManager, FileManager>();
                            services.AddSingleton<ISyncManager, SyncManager>();
                            // Services
                            services.AddSingleton<IFileWatcherService, FileWatcherService>();
                            // Helpers
                            services.AddSingleton<IFolderHelper, FolderHelper>();
                            // Commands
                            services.AddTransient<ISelectFolderCommand, SelectFolderCommand>();
                            services.AddSingleton<ISyncStateCommand, SyncStateCommand>();
                            // Models
                            services.AddSingleton<IModel, Model>();
                            // ViewModels
                            services.AddSingleton<IViewModel, ViewModel>();
                        })
                        .Build();
        }
    }
}
