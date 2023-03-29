using homework.Commands;
using homework.Core;
using homework.Model;
using homework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace homework.ViewModel
{
    public class AdminViewModel : ViewModelBase
    {
        private NavigationStore _navigationStore;
        public AdminViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            DeleteUserCommand = new DeleteUserCommand(this);
            AddUserCommand = new AddUserCommand(this);
        }
        private List<User> _usersCollection = Database.DB.Users.OrderBy(x => x.UserID).ToList();
        public List<User> UsersCollection
        {
            get { return _usersCollection; }
            set
            {
                _usersCollection = value;
                OnPropertyChanged();
            }
        }
        public ICommand DeleteUserCommand { get; }
        public ICommand AddUserCommand { get; }
    }
}
