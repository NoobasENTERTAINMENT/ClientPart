using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using homework.ViewModel;

namespace homework
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public DisplayRootRegistry displayRootRegistry = new DisplayRootRegistry();
        GlobalViewModel globalViewModel;

        public App()
        {
            displayRootRegistry.RegisterWindowType<GlobalViewModel, MainWindow>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            globalViewModel = new GlobalViewModel();

            await displayRootRegistry.ShowModalPresentation(globalViewModel);

            Shutdown();
        }
    }
}
