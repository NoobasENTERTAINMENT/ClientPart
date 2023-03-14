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
    public class PurchasesSubmitCommand : CommandBase
    {
        PurchasesViewModel _viewModel;
        public PurchasesSubmitCommand(PurchasesViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            try
            {
                switch (parameter)
                {
                    case "Книга":
                        _viewModel.PurchasesCollection = Database.DB.Purchases.Where(x => x.Book.Title_book.Contains(_viewModel.Value)).ToList();
                        break;
                    case "Дата заказа":
                        _viewModel.PurchasesCollection = Database.DB.Purchases.Where(x => x.Date_order == _viewModel.ValueDate).ToList();
                        break;
                    case "Поставщик":
                        _viewModel.PurchasesCollection = Database.DB.Purchases.Where(x => x.Delivery.Name_delivery.Contains(_viewModel.Value)).ToList();
                        break;
                    case "Цена":
                        int cost = int.Parse(_viewModel.Value);
                        _viewModel.PurchasesCollection = Database.DB.Purchases.Where(x => x.Cost == cost).ToList();
                        break;
                    case "Количество":
                        int amount = int.Parse(_viewModel.Value);
                        _viewModel.PurchasesCollection = Database.DB.Purchases.Where(x => x.Amount == amount).ToList();
                        break;
                    case "Cancel":
                        _viewModel.PurchasesCollection = Database.DB.Purchases.OrderBy(x => x.Code_purchase).ToList();
                        _viewModel.Value = "";
                        _viewModel.ValueDate = DateTime.Now;
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
