using homework.Commands;
using homework.Commands.SubmitCommands;
using homework.Core;
using homework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace homework.ViewModel
{
    public class DeliveriesViewModel : ViewModelBase
    {
        public DeliveriesViewModel()
        {
            DeliveriesSubmitCommand = new DeliveriesSubmitCommand(this);
        }
        private List<Delivery> _deliveriesCollection = Database.DB.Deliveries.OrderBy(x => x.Code_delivery).ToList();
        public List<Delivery> DeliveriesCollection
        {
            get { return _deliveriesCollection; }
            set
            {
                _deliveriesCollection = value;
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

        public ICommand DeliveriesSubmitCommand { get; }
        public ICommand CellEditEndingCommand => new RelayCommand<Delivery>(OnCellEditEnding);
        private void OnCellEditEnding(Delivery e)
        {
            if (e is Delivery item)
            {
                Delivery deliveryModel = Database.DB.Deliveries.FirstOrDefault(x => x.Code_delivery == e.Code_delivery);
                if (deliveryModel != null)
                {
                    deliveryModel = e;
                    Database.DB.SaveChangesAsync();
                }

            }
        }
    }
}
