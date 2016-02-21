using PhotoSlides.Services.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace PhotoSlides.Services
{
    public interface IGroupNavigationService
    {
        void GoBack(NavigationGroup group = NavigationGroup.Default);
        void NavigateTo(string pageKey, NavigationGroup group = NavigationGroup.Default, object parameter = null);
        void Configure(string key, Type pageType);

        string CurrentPageKey(NavigationGroup group = NavigationGroup.Default);

        void RegisterGroup(Frame frame, NavigationGroup group = NavigationGroup.Default);
    }
}
