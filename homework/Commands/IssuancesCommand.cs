using homework.Services;
using homework.ViewModel;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework.Commands
{
    public class IssuancesCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public IssuancesCommand(NavigationStore navigationStore)
        {
            _navigationStore= navigationStore;
        }
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new IssuancesViewModel();
        }
    }
}
