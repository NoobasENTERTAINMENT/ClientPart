using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using homework.Core;
using homework.Model;
using homework.Services;
using homework.View;
using homework.ViewModel;

namespace homework
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private NavigationStore _navigationStore;

        public App()
        {
            _navigationStore= new NavigationStore();
            Database.DB = new BooksDBEntities1();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new BooksViewModel();
            _navigationStore.CurrentGeneralViewModel = new LoginViewModel(_navigationStore);

            MainWindow = new GeneralView()
            {
                DataContext = new GeneralViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
