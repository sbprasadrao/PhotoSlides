using GalaSoft.MvvmLight.Command;
using PhotoSlides.Framework;
using PhotoSlides.Services.DomainObjects;
using PhotoSlides.Utility;
using PhotoSlides.View;
using PhotoSlides.ViewModel.Albums;
using PhotoSlides.ViewModel.Favorites;
using PhotoSlides.ViewModel.Settings;

namespace PhotoSlides
{
    public class MainPageViewModel : BaseViewModel
    {
        private bool _isMenuOpen;
        private string _title;



        private RelayCommand _menuOpenedCommand;
        private RelayCommand _albumsCommand;
        private RelayCommand _settingsCommand;
        private RelayCommand _favoritesCommand;

        public bool IsMenuOpen
        {
            get { return _isMenuOpen; }
            set { Set(() => IsMenuOpen, ref _isMenuOpen, value); }
        }

        public string Title
        {
            get { return _title; }
            set { Set(() => Title, ref _title, value); }
        }

        public RelayCommand MenuOpenedCommand => _menuOpenedCommand ?? (_menuOpenedCommand = new RelayCommand(() => IsMenuOpen = !IsMenuOpen, () => true));

        public RelayCommand AlbumsCommand => _albumsCommand ?? (_albumsCommand = new RelayCommand(() =>
        {
            Title = Views.Albums.Description();
            Navigate<AlbumsViewModel>(NavigationGroup.B);
        }, () => true));

        public RelayCommand FavoritesCommand => _favoritesCommand ?? (_favoritesCommand = new RelayCommand(() => { Title = Views.Favorites.Description(); Navigate<FavoritesViewModel>(NavigationGroup.B); }, () => true));

        public RelayCommand SettingsCommand => _settingsCommand ?? (_settingsCommand = new RelayCommand(() => { Title = Views.Settings.Description(); Navigate<SettingsViewModel>(NavigationGroup.B); }, () => true));

        public MainPageViewModel()
        {
            Title = "Main Page";
        }


    }
}
