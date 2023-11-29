using homework.Commands;
using homework.Services;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Input;

namespace homework.ViewModel
{
    public class ContentViewModel : ViewModelBase
    {
        private NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        
        public ContentViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            BooksCommand = new BooksCommand(_navigationStore);
            IssuancesCommand = new IssuancesCommand(_navigationStore);
            LogoutCommand = new LogoutCommand(_navigationStore);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public ICommand BooksCommand { get; }
        public ICommand IssuancesCommand { get; }
        public ICommand LogoutCommand { get; }
    }
}
