using homework.Commands;
using homework.Commands.SubmitCommands;
using homework.Core;
using homework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace homework.ViewModel
{
    public class AuthorsViewModel : ViewModelBase
    {
        public AuthorsViewModel()
        {
            AuthorsSubmitCommand = new AuthorsSubmitCommand(this);
        }
        private List<Author> _authorsCollection = Database.DB.Authors.OrderBy(x => x.Code_author).ToList();
        public List<Author> AuthorsCollection
        {
            get { return _authorsCollection; }
            set
            {
                _authorsCollection = value;
                OnPropertyChanged();
            }
        }

        private string _value = string.Empty;
        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
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
        private int _comboBoxSelectedIndex = 0;
        public int ComboBoxSelectedIndex
        {
            get { return _comboBoxSelectedIndex; }
            set
            {
                _comboBoxSelectedIndex = value;
                OnPropertyChanged();
                OnPropertyChanged("TextBoxVisibility");
                OnPropertyChanged("DatePickerVisibility");
            }
        }

        public Visibility TextBoxVisibility => ComboBoxSelectedIndex == 0 ? Visibility.Visible : Visibility.Hidden;
        public Visibility DatePickerVisibility => ComboBoxSelectedIndex == 1 ? Visibility.Visible : Visibility.Hidden;

        public ICommand AuthorsSubmitCommand { get; }
        public ICommand CellEditEndingCommand => new RelayCommand<Author>(OnCellEditEnding);
        private void OnCellEditEnding(Author e)
        {
            if (e is Author item)
            {
                Author authorModel = Database.DB.Authors.FirstOrDefault(x => x.Code_author == e.Code_author);
                if (authorModel != null)
                {
                    authorModel = e;
                    Database.DB.SaveChangesAsync();
                }

            }
        }
    }
}
