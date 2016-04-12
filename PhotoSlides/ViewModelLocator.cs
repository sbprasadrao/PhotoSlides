using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using PhotoSlides.Services;
using PhotoSlides.View;
using PhotoSlides.View.Albums;
using PhotoSlides.View.Favorites;
using PhotoSlides.View.Settings;
using PhotoSlides.ViewModel;
using PhotoSlides.ViewModel.Albums;
using PhotoSlides.ViewModel.Favorites;
using PhotoSlides.ViewModel.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSlides
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IGroupNavigationService, GroupNavigationService>();
            }
            else
            {
                var naviationService = initNavigationService();
                SimpleIoc.Default.Register<IGroupNavigationService>(() => naviationService);
            }

            SimpleIoc.Default.Register<LoginPageViewModel>();
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<AlbumsViewModel>();
        }

        private IGroupNavigationService initNavigationService()
        {
            var service = new GroupNavigationService();

            service.Configure(typeof(LoginPageViewModel).FullName, typeof(LoginPage));
            service.Configure(typeof(MainPageViewModel).FullName, typeof(MainPage));
            service.Configure(typeof(AlbumsViewModel).FullName, typeof(AlbumsView));
            service.Configure(typeof(FavoritesViewModel).FullName, typeof(FavoritesView));
            service.Configure(typeof(SettingsViewModel).FullName, typeof(SettingsView));
            return service;
        }

        public LoginPageViewModel LoginPageViewModel => ServiceLocator.Current.GetInstance<LoginPageViewModel>();
        public MainPageViewModel MainPageViewModel => ServiceLocator.Current.GetInstance<MainPageViewModel>();

        public AlbumsViewModel AlbumsViewModel => ServiceLocator.Current.GetInstance<AlbumsViewModel>();
    }
}
