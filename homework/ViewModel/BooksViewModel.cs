using homework.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework.ViewModel
{
    public class BooksViewModel : ViewModelBase
    {
        private ObservableCollection<Book> _booksCollection;
        public ObservableCollection<Book> BooksCollection
        {
            get { return _booksCollection; }
            set
            { 
                _booksCollection = value;
                OnPropertyChanged();
            }
        }
    }
}
