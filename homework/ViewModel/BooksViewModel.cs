using homework.Commands;
using homework.Core;
using homework.Model;
using homework.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace homework.ViewModel
{
    public class BooksViewModel : ViewModelBase
    {
        public BooksViewModel()
        {
            BooksSubmitCommand = new BooksSubmitCommand(this);
        }
        private List<Book> _booksCollection = Database.DB.Books.OrderBy(x => x.Code_book).ToList();
        public List<Book> BooksCollection
        {
            get { return _booksCollection; }
            set
            { 
                _booksCollection = value;
                OnPropertyChanged();
            }
        }

        private string _value = string.Empty;
        public string Value
        {
            get { return _value; }
            set { _value = value;
                OnPropertyChanged();
            }
        }

        public ICommand BooksSubmitCommand { get; }
        public ICommand CellEditEndingCommand => new RelayCommand<Book>(OnCellEditEnding);
        private void OnCellEditEnding(Book e)
        {
            if (e is Book item)
            {
                Book bookModel = Database.DB.Books.FirstOrDefault(x => x.Code_book == e.Code_book);
                if(bookModel != null)
                {
                    bookModel = e;
                    Database.DB.SaveChangesAsync();
                }
                
            }
        }
    }
}
