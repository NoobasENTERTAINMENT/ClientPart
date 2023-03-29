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
    public class DeleteUserCommand : CommandBase
    {
        private readonly AdminViewModel _adminViewModel;
        public DeleteUserCommand(AdminViewModel adminViewModel)
        {
            _adminViewModel= adminViewModel;
        }
        public override void Execute(object parameter)
        {
            if(parameter is User userParameter)
            {
                Database.DB.Users.Remove(userParameter);

                Database.DB.SaveChanges();
                _adminViewModel.UsersCollection = Database.DB.Users.OrderBy(u => u.UserID).ToList();
            }
            else
            {
                MessageBox.Show("Пользователь не выбран", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
