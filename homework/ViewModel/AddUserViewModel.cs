using homework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace homework.ViewModel
{
    public class AddUserViewModel : ViewModelBase
    {
        private readonly AdminViewModel _adminViewModel;
        public AddUserViewModel(AdminViewModel adminViewModel)
        {
            _adminViewModel = adminViewModel;
            FinallyAddUserCommand = new FinallyAddUserCommand(this, _adminViewModel);
        }
		private string _login;
		public string Login
		{
			get { return _login; }
			set { _login = value; OnPropertyChanged(); }
		}

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        private string _role;
        public string Role
        {
            get { return _role; }
            set { _role = value; OnPropertyChanged(); }
        }

        public ICommand FinallyAddUserCommand { get; }
    }
}
