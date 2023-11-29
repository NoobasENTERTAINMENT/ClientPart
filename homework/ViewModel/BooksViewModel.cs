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

        private List<string> _authorsCollection = Database.DB.Authors.Select(e => e.Name_author).ToList();
        public List<string> AuthorsCollection
        {
            get { return _authorsCollection; }
            set
            {
                _authorsCollection = value;
                OnPropertyChanged();
            }
        }

        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set {_name = value;
                OnPropertyChanged();
            }
        }

        private string _author = string.Empty;
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                OnPropertyChanged();
            }
        }

        private int _pages;
        public int Pages
        {
            get { return _pages; }
            set
            {
                _pages = value;
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
