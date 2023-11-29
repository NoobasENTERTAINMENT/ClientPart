using homework.Core;
using homework.Model;
using homework.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            try
            {
                switch (parameter)
                {
                    case "Add":
                        Author authorModel = new Author()
                        {
                            Name_author = _viewModel.Author
                        };
                        Book bookModel = new Book()
                        {
                            Title_book = _viewModel.Name,
                            Pages = _viewModel.Pages,
                            Author = authorModel
                        };
                        Database.DB.Books.Add(bookModel);
                        Database.DB.SaveChanges();

                        _viewModel.BooksCollection = Database.DB.Books.OrderBy(x => x.Code_book).ToList();
                        _viewModel.AuthorsCollection = Database.DB.Authors.Select(e => e.Name_author).ToList();
                        _viewModel.Author = null;
                        _viewModel.Pages = 0;
                        _viewModel.Name = null;
                        break;
                    case "Cancel":
                        _viewModel.Author = null;
                        _viewModel.Pages = 0;
                        _viewModel.Name = null;
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
