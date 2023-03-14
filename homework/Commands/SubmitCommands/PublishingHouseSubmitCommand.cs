using homework.Core;
using homework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace homework.Commands.SubmitCommands
{
    public class PublishingHouseSubmitCommand : CommandBase
    {
        PublishHouseViewModel _viewModel;
        public PublishingHouseSubmitCommand(PublishHouseViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            try
            {
                switch (parameter)
                {
                    case "Издатель":
                        _viewModel.PublishHouseCollection = Database.DB.Publishing_house.Where(x => x.Publish.Contains(_viewModel.Value)).ToList();
                        break;
                    case "Город":
                        _viewModel.PublishHouseCollection = Database.DB.Publishing_house.Where(x => x.City.Contains(_viewModel.Value)).ToList();
                        break;
                    case "Cancel":
                        _viewModel.PublishHouseCollection = Database.DB.Publishing_house.OrderBy(x => x.Code_publish).ToList();
                        _viewModel.Value = "";
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
