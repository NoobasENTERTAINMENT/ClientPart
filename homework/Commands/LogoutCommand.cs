using homework.Services;
using homework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework.Commands
{
    public class LogoutCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public LogoutCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentGeneralViewModel = new LoginViewModel(_navigationStore);
        }
    }
}
