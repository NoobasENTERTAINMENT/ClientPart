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

namespace homework.ViewModel
{
    public class PurchasesViewModel : ViewModelBase
    {
        public PurchasesViewModel()
        {
            PurchaseSubmitCommand = new PurchasesSubmitCommand(this);
        }
        private List<Purchase> _purchasesCollection = Database.DB.Purchases.OrderBy(x => x.Code_purchase).ToList();
        public List<Purchase> PurchasesCollection
        {
            get { return _purchasesCollection; }
            set
            {
                _purchasesCollection = value;
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
        public Visibility TextBoxVisibility => ComboBoxSelectedIndex != 1 ? Visibility.Visible : Visibility.Hidden;
        public Visibility DatePickerVisibility => ComboBoxSelectedIndex == 1 ? Visibility.Visible : Visibility.Hidden;

        public ICommand PurchaseSubmitCommand { get; }
        public ICommand CellEditEndingCommand => new RelayCommand<Purchase>(OnCellEditEnding);
        private void OnCellEditEnding(Purchase e)
        {
            if (e is Purchase item)
            {
                Purchase purchaseModel = Database.DB.Purchases.FirstOrDefault(x => x.Code_purchase == e.Code_purchase);
                if (purchaseModel != null)
                {
                    purchaseModel = e;
                    Database.DB.SaveChangesAsync();
                }

            }
        }
    }
}

