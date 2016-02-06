using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSlides.Framework
{
    public class BaseViewModel : ViewModelBase
    {
        private RelayCommand _loadedCommand;
        private RelayCommand _unloadedCommand;
        protected INavigationService NavigationService
        {
            get { return ServiceLocator.Current.GetInstance<INavigationService>(); }
        }

        public RelayCommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new RelayCommand(OnViewLoadAsync));
        public RelayCommand UnloadedCommand => _unloadedCommand ?? (_unloadedCommand = new RelayCommand(OnViewUnloadAsync));

        public void Navigate<T>(object argument = null)
        {
            if (argument == null)
            {
                NavigationService.NavigateTo(typeof(T).FullName);
            }
            else
            {
                NavigationService.NavigateTo(typeof(T).FullName, argument);
            }
        }

        protected virtual async void OnViewLoadAsync()
        {

        }

        protected virtual async void OnViewUnloadAsync()
        {

        }

    }
}
