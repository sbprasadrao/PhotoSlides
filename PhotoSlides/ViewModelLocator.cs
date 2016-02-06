using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using PhotoSlides.View;
using PhotoSlides.ViewModel;
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
                SimpleIoc.Default.Register<INavigationService, NavigationService>();
            }
            else
            {
                var naviationService = initNavigationService();
                SimpleIoc.Default.Register<INavigationService>(() => naviationService);
            }

            SimpleIoc.Default.Register<LoginPageViewModel>();
            SimpleIoc.Default.Register<MainPageViewModel>();
        }

        private INavigationService initNavigationService()
        {
            var service = new NavigationService();

            service.Configure(typeof(LoginPageViewModel).FullName, typeof(LoginPage));
            service.Configure(typeof(MainPageViewModel).FullName, typeof(MainPage));
            return service;
        }

        public LoginPageViewModel LoginPageViewModel => ServiceLocator.Current.GetInstance<LoginPageViewModel>();
        public MainPageViewModel MainPageViewModel => ServiceLocator.Current.GetInstance<MainPageViewModel>();
    }
}
