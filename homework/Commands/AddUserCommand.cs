using homework.Model;
using homework.View;
using homework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace homework.Commands
{
    public class AddUserCommand : CommandBase
    {
        private readonly AdminViewModel _adminViewModel;
        public AddUserCommand(AdminViewModel adminViewModel)
        {
            _adminViewModel = adminViewModel;
        }
        public override void Execute(object parameter)
        {
            AddUserWindow adw = new AddUserWindow();
            adw.DataContext = new AddUserViewModel(_adminViewModel);
            adw.ShowDialog();
        }
    }
}
