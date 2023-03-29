using homework.Core;
using homework.Model;
using homework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace homework.Commands
{
    public class FinallyAddUserCommand : CommandBase
    {
        private readonly AddUserViewModel _addUserViewModel;
        private readonly AdminViewModel _adminViewModel;
        public FinallyAddUserCommand(AddUserViewModel addUserViewModel, AdminViewModel adminViewModel)
        {
            _adminViewModel = adminViewModel;
            _addUserViewModel= addUserViewModel;
        }
        public override void Execute(object parameter)
        {
            try
            {
                if (_addUserViewModel.Login.Trim() != string.Empty
                || _addUserViewModel.Password.Trim() != string.Empty
                || _addUserViewModel.Role.Trim() != string.Empty)
                {
                    Role roleModel = Database.DB.Roles.FirstOrDefault(x => x.RoleName == _addUserViewModel.Role);
                    Database.DB.Users.Add(new User()
                    {
                        UserLogin = _addUserViewModel.Login,
                        UserPassword = _addUserViewModel.Password,
                        Role = roleModel
                    });
                    Database.DB.SaveChanges();
                    _adminViewModel.UsersCollection = Database.DB.Users.OrderBy(u => u.UserID).ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
        }
    }
}
