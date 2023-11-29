using homework.Commands.SubmitCommands;
using homework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using homework.Core;
using homework.Commands;
using System.Data;

namespace homework.ViewModel
{
    public class IssuancesViewModel : ViewModelBase
    {
        public IssuancesViewModel()
        {
            IssuancesSubmitCommand = new IssuancesSubmitCommand(this);
        }

        private List<string> _booksCollection = Database.DB.Books.Select(e => e.Title_book).ToList();
        public List<string> BooksCollection
        {
            get { return _booksCollection; }
            set
            {
                _booksCollection = value;
                OnPropertyChanged();
            }
        }

        private List<Issuance> _issuancesCollection = Database.DB.Issuances.OrderBy(x => x.Code_issuance).ToList();
        public List<Issuance> IssuancesCollection
        {
            get { return _issuancesCollection; }
            set
            {
                _issuancesCollection = value;
                OnPropertyChanged();
            }
        }

        private DateTime _valueDate = DateTime.Now;
        public DateTime ValueDate
        {
            get { return _valueDate; }
            set
            {
                _valueDate = value;
                OnPropertyChanged();
            }
        }
        private string _count;
        public string Count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged();
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        private string _class;
        public string Class
        {
            get { return _class; }
            set
            {
                _class = value;
                OnPropertyChanged();
            }
        }

        private string _titleBook;
        public string TitleBook
        {
            get { return _titleBook; }
            set
            {
                _titleBook = value;
                OnPropertyChanged();
            }
        }

        public ICommand IssuancesSubmitCommand { get; }
        public ICommand CellEditEndingCommand => new RelayCommand<Issuance>(OnCellEditEnding);
        private void OnCellEditEnding(Issuance e)
        {
            if (e is Issuance item)
            {
                Issuance purchaseModel = Database.DB.Issuances.FirstOrDefault(x => x.Code_issuance == e.Code_issuance);
                if (purchaseModel != null)
                {
                    purchaseModel = e;
                    Database.DB.SaveChangesAsync();
                }

            }
        }
    }
}

