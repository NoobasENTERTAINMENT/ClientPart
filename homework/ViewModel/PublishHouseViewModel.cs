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
    public class PublishHouseViewModel : ViewModelBase
    {
        public PublishHouseViewModel()
        {
            PublishHouseSubmitCommand = new PublishingHouseSubmitCommand(this);
        }
        private List<Publishing_house> _publishHouseCollection = Database.DB.Publishing_house.OrderBy(x => x.Code_publish).ToList();
        public List<Publishing_house> PublishHouseCollection
        {
            get { return _publishHouseCollection; }
            set
            {
                _publishHouseCollection = value;
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

        public ICommand PublishHouseSubmitCommand { get; }
        public ICommand CellEditEndingCommand => new RelayCommand<Publishing_house>(OnCellEditEnding);
        private void OnCellEditEnding(Publishing_house e)
        {
            if (e is Publishing_house item)
            {
                Publishing_house publishing_houseModel = Database.DB.Publishing_house.FirstOrDefault(x => x.Code_publish == e.Code_publish);
                if (publishing_houseModel != null)
                {
                    publishing_houseModel = e;
                    Database.DB.SaveChangesAsync();
                }

            }
        }
    }
}
