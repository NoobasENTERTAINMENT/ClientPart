using homework.Commands;
using homework.Services;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Input;

namespace homework.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        
        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            BooksCommand = new BooksCommand(_navigationStore);
            AuthorsCommand = new AuthorsCommand(_navigationStore);
            DeliveriesCommand = new DeliveriesCommand(_navigationStore);
            PublishHouseCommand = new PublishHouseCommand(_navigationStore);
            PurchasesCommand = new PurchasesCommand(_navigationStore);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public ICommand BooksCommand { get; }
        public ICommand AuthorsCommand { get; }
        public ICommand DeliveriesCommand { get; }
        public ICommand PublishHouseCommand { get; }
        public ICommand PurchasesCommand { get; }
    }
}
