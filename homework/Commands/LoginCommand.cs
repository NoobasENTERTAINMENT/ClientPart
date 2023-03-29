using homework.Core;
using homework.Model;
using homework.Services;
using homework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace homework.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly LoginViewModel _loginViewModel;
        public LoginCommand(LoginViewModel loginViewModel, NavigationStore navigationStore)
        {
            _loginViewModel = loginViewModel;
            _navigationStore = navigationStore;
        }
        public override void Execute(object parameter)
        {
            PasswordBox PB = parameter as PasswordBox;
            string Password = PB.Password;
            User userModel = Database.DB.Users.FirstOrDefault(x => x.UserLogin == _loginViewModel.Login && x.UserPassword == Password);
            if(userModel != null)
            {
                if(userModel.Role.RoleID == 2)
                {
                    _navigationStore.CurrentGeneralViewModel = new ContentViewModel(_navigationStore);
                }
                else
                {
                    _navigationStore.CurrentGeneralViewModel = new AdminViewModel(_navigationStore);
                }
            }
            else
            {
                MessageBox.Show("Неверные данные", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
        }
    }
}
