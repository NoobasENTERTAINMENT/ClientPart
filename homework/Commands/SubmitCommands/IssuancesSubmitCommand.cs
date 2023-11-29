using homework.Core;
using homework.Model;
using homework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace homework.Commands.SubmitCommands
{
    public class IssuancesSubmitCommand : CommandBase
    {
        IssuancesViewModel _viewModel;
        public IssuancesSubmitCommand(IssuancesViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            try
            {
                switch (parameter)
                {
                    case "Add":
                        Client client = new Client()
                        {
                            Name = _viewModel.Name,
                            Class = int.Parse(_viewModel.Class)
                        };

                        Issuance issuanceModel = new Issuance()
                        {
                            Amount = int.Parse(_viewModel.Count),
                            Book = Database.DB.Books.FirstOrDefault(x => x.Title_book == _viewModel.TitleBook),
                            Client = client,
                            Date_order = _viewModel.ValueDate
                        };
                        Database.DB.Issuances.Add(issuanceModel);
                        Database.DB.SaveChanges();

                        _viewModel.BooksCollection = Database.DB.Books.Select(e => e.Title_book).ToList();
                        _viewModel.IssuancesCollection = Database.DB.Issuances.OrderBy(x => x.Code_issuance).ToList();

                        _viewModel.TitleBook = null;
                        _viewModel.ValueDate = DateTime.Now;
                        _viewModel.Count = null;
                        _viewModel.Name = "";
                        _viewModel.Class = null;
                        break;
                    case "Cancel":
                        _viewModel.TitleBook = null;
                        _viewModel.ValueDate = DateTime.Now;
                        _viewModel.Count = null;
                        _viewModel.Name = "";
                        _viewModel.Class = null;
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
