using homework.Core;
using homework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace homework.Commands.SubmitCommands
{
    public class DeliveriesSubmitCommand : CommandBase
    {
        DeliveriesViewModel _viewModel;
        public DeliveriesSubmitCommand(DeliveriesViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            try
            {
                switch (parameter)
                {
                    case "Название поставки":
                        _viewModel.DeliveriesCollection = Database.DB.Deliveries.Where(x => x.Name_delivery.Contains(_viewModel.Value)).ToList();
                        break;
                    case "Название компании":
                        _viewModel.DeliveriesCollection = Database.DB.Deliveries.Where(x => x.Name_company.Contains(_viewModel.Value)).ToList();
                        break;
                    case "Адрес":
                        _viewModel.DeliveriesCollection = Database.DB.Deliveries.Where(x => x.Adress.Contains(_viewModel.Value)).ToList();
                        break;
                    case "Телефон":
                        int Phone = int.Parse(_viewModel.Value);
                        _viewModel.DeliveriesCollection = Database.DB.Deliveries.Where(x => x.Phone == Phone).ToList();
                        break;
                    case "ИНН":
                        _viewModel.DeliveriesCollection = Database.DB.Deliveries.Where(x => x.INN.Contains(_viewModel.Value)).ToList();
                        break;
                    case "Cancel":
                        _viewModel.DeliveriesCollection = Database.DB.Deliveries.OrderBy(x => x.Code_delivery).ToList();
                        _viewModel.Value = "";
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка входных данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
        }
    }
}
