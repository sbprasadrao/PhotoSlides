using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using PhotoSlides.Services;
using PhotoSlides.Services.DomainObjects;
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
        protected IGroupNavigationService NavigationService
        {
            get { return ServiceLocator.Current.GetInstance<IGroupNavigationService>(); }
        }

        public RelayCommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new RelayCommand(OnViewLoadAsync));
        public RelayCommand UnloadedCommand => _unloadedCommand ?? (_unloadedCommand = new RelayCommand(OnViewUnloadAsync));

        public void Navigate<T>(NavigationGroup group = NavigationGroup.Default, object argument = null)
        {
            if (argument == null)
            {
                NavigationService.NavigateTo(typeof(T).FullName, group);
            }
            else
            {
                NavigationService.NavigateTo(typeof(T).FullName, group, argument);
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
