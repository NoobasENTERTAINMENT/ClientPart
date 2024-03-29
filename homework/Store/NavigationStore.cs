﻿using homework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework.Services
{
    public class NavigationStore
    {
		private ViewModelBase _currentViewModel;
		public ViewModelBase CurrentViewModel
        {
			get { return _currentViewModel; }
			set 
			{ 
				_currentViewModel = value;
				OnCurrentViewModelChanged();
			}
		}
        private ViewModelBase _currentGeneralViewModel;
        public ViewModelBase CurrentGeneralViewModel
        {
            get { return _currentGeneralViewModel; }
            set
            {
                _currentGeneralViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action CurrentViewModelChanged;

	}
}
