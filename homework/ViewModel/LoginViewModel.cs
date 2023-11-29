using homework.Commands;
using homework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace homework.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public LoginViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            LoginCommand = new LoginCommand(this, _navigationStore);
        }
        private string _login = "Maria Ivanovna";
		public string Login
		{
			get
			{
				return _login;
			}
			set
			{
				_login = value;
				OnPropertyChanged();
			}
		}

        private string _password;

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }
    }
}
