using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DocumentNumber.Services;
using DocumentNumber.ViewModels;
using DocumentNumber.Views;
using DocumentNumberCalculator.Serivce;
using System.Printing;


namespace DocumentNumber
{
    public partial class App : Application
    {

        private static IHost? host = null;

        public App()
        {
         
            // host initialisieren
            host = Host.CreateDefaultBuilder()
                 .ConfigureServices(services =>
                 {
                     //services registrieren
                     services.AddSingleton<MainWindowViewModel>();
                     services.AddSingleton<MainWindowView>();
                     services.AddSingleton<IComputerDocumentNumbers, DocumentNumberComputer>();
                     services.AddSingleton<FolderOpenerService>();
                 }
                 )
                 .Build();
        }


        //start
        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();
            var mainWindow = host.Services.GetRequiredService<MainWindowView>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        //programm ende
        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                await host.StopAsync();
            }
            base.OnExit(e);
        }
    }
}
