using GalaSoft.MvvmLight.Command;
using PhotoSlides.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSlides.ViewModel.Albums
{
    public class AlbumsViewModel : BaseViewModel
    {
        private RelayCommand _createAlbumCommand;
        private RelayCommand _deleteAlbumCommand;
        private List<string> _albums = new List<string>();
        private string _selectedAlbum;
        

        public string SelectedAlbum
        {
            get { return _selectedAlbum; }
            set { Set(() => SelectedAlbum, ref _selectedAlbum, value); }
        }

        public List<string> Categories
        {
            get { return _albums; }
            set { Set(() => Categories, ref _albums, value); }
        }

        public AlbumsViewModel()
        {
            Categories = new List<string> { "General", "Places", "Relatives", "Animals" };
        }

        private bool _isLoaded;

        protected override void OnViewLoadAsync()
        {
            base.OnViewLoadAsync();

            if (!_isLoaded)
            {
                load();
                _isLoaded = true;
            }
        }

        private void load()
        {
            Categories = new List<string> { "General", "Places", "Relatives", "Animals" };
        }

        public RelayCommand CreateAlbumCommand => _createAlbumCommand ?? (_createAlbumCommand = new RelayCommand(() =>
        {
            Categories.Add("New Alubm");
        }, () => true));

        public RelayCommand DeleteAlbumCommand => _deleteAlbumCommand ?? (_deleteAlbumCommand = new RelayCommand(() =>
        {
            if (Categories.Contains(SelectedAlbum))
            {
                Categories.Remove(SelectedAlbum);
            }
        }, () => true));
    }
}
