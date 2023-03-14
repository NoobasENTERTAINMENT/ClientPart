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
    }
}
