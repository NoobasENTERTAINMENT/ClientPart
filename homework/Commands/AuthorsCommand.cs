using homework.Services;
using homework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework.Commands
{
    public class AuthorsCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public AuthorsCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new AuthorsViewModel();
        }
    }
}
