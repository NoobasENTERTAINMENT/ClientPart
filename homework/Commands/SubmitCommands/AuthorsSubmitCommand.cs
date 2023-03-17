﻿using homework.Core;
using homework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace homework.Commands.SubmitCommands
{
    public class AuthorsSubmitCommand : CommandBase
    {
        AuthorsViewModel _viewModel;
        public AuthorsSubmitCommand(AuthorsViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            try
            {
                switch (parameter)
                {
                    case "Имя автора":
                        _viewModel.AuthorsCollection = Database.DB.Authors.Where(x => x.Name_author.Contains(_viewModel.Value)).ToList();
                        break;
                    case "Год рождения":
                        _viewModel.AuthorsCollection = Database.DB.Authors.Where(x => x.Birthday == _viewModel.ValueDate).ToList();
                        break;
                    case "Cancel":
                        _viewModel.AuthorsCollection = Database.DB.Authors.OrderBy(x => x.Code_author).ToList();
                        _viewModel.Value = "";
                        _viewModel.ValueDate = DateTime.Now;
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