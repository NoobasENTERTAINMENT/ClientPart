using homework.Core;
using homework.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework.Commands
{
    public class BooksSubmitCommand : CommandBase
    {
        BooksViewModel _viewModel;
        public BooksSubmitCommand(BooksViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            switch(parameter)
            {
                case "Название":
                    _viewModel.BooksCollection = Database.DB.Books.Where(x => x.Title_book.Contains(_viewModel.Value)).ToList();
                    break;
                case "Автор":
                    _viewModel.BooksCollection = Database.DB.Books.Where(x => x.Author.Name_author.Contains(_viewModel.Value)).ToList();
                    break;
                case "Количество страниц":
                    int pages = Convert.ToInt32(_viewModel.Value);
                    _viewModel.BooksCollection = Database.DB.Books.Where(x => x.Pages == pages).ToList();
                    break;
                case "Издатель":
                    _viewModel.BooksCollection = Database.DB.Books.Where(x => x.Publishing_house.Publish.Contains(_viewModel.Value)).ToList();
                    break;
                case "Cancel":
                    _viewModel.BooksCollection = Database.DB.Books.OrderBy(x => x.Code_book).ToList();
                    break;
            }
        }
    }
}
