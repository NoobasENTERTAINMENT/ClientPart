using homework.Services;
using homework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _navigationStore.CurrentGeneralViewModel = new ContentViewModel(_navigationStore);
        }
    }
}
