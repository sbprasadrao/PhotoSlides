using PhotoSlides.Services.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace PhotoSlides.Services
{
    public class GroupNavigationService : IGroupNavigationService
    {
        private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();
        private readonly Dictionary<NavigationGroup, Frame> _framesByGroup = new Dictionary<NavigationGroup, Frame>();

        private void goBack(Frame frame)
        {
            if (!frame.CanGoBack)
                return;
            frame.GoBack();
        }

        private void navigateTo(Frame frame, string pageKey, object parameter)
        {
            bool lockTaken = false;
            Dictionary<string, Type> dictionary = null;
            try
            {
                Monitor.Enter((object)(dictionary = this._pagesByKey), ref lockTaken);
                if (!this._pagesByKey.ContainsKey(pageKey))
                    throw new ArgumentException(string.Format("No such page: {0}. Did you forget to call GroupNavigationService.Configure?", (object)pageKey), "pageKey");
                frame.Navigate(this._pagesByKey[pageKey], parameter);
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit((object)dictionary);
            }
        }

        private string currentPageKey(Frame frame)
        {
            bool lockTaken = false;
            Dictionary<string, Type> dictionary = null;
            try
            {
                Monitor.Enter((object)(dictionary = this._pagesByKey), ref lockTaken);
                if (frame.BackStackDepth == 0)
                    return "-- ROOT --";
                if (frame.Content == null)
                    return "-- UNKNOWN --";
                Type currentType = frame.Content.GetType();
                if (Enumerable.All<KeyValuePair<string, Type>>((IEnumerable<KeyValuePair<string, Type>>)this._pagesByKey, (Func<KeyValuePair<string, Type>, bool>)(p => p.Value != currentType)))
                    return "-- UNKNOWN --";
                return Enumerable.FirstOrDefault<KeyValuePair<string, Type>>((IEnumerable<KeyValuePair<string, Type>>)this._pagesByKey, (Func<KeyValuePair<string, Type>, bool>)(i => i.Value == currentType)).Key;
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit((object)dictionary);
            }
        }

        public void Configure(string key, Type pageType)
        {
            bool lockTaken = false;
            Dictionary<string, Type> dictionary = null;
            try
            {
                Monitor.Enter((object)(dictionary = this._pagesByKey), ref lockTaken);
                if (this._pagesByKey.ContainsKey(key))
                    throw new ArgumentException("This key is already used: " + key);
                if (Enumerable.Any<KeyValuePair<string, Type>>((IEnumerable<KeyValuePair<string, Type>>)this._pagesByKey, (Func<KeyValuePair<string, Type>, bool>)(p => p.Value == pageType)))
                    throw new ArgumentException("This type is already configured with key " + Enumerable.First<KeyValuePair<string, Type>>((IEnumerable<KeyValuePair<string, Type>>)this._pagesByKey, (Func<KeyValuePair<string, Type>, bool>)(p => p.Value == pageType)).Key);
                this._pagesByKey.Add(key, pageType);
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit((object)dictionary);
            }
        }

        private Frame getFrame(NavigationGroup group)
        {
            return group == NavigationGroup.Default ? _framesByGroup[NavigationGroup.A] : _framesByGroup[group];
        }

        public void GoBack(NavigationGroup group = NavigationGroup.Default)
        {
            goBack(getFrame(group));
        }

        public void NavigateTo(string pageKey, NavigationGroup group = NavigationGroup.Default, object parameter = null)
        {
            navigateTo(getFrame(group), pageKey, parameter);
        }

        public string CurrentPageKey(NavigationGroup group)
        {
            return currentPageKey(getFrame(group));
        }

        public void RegisterGroup(Frame frame, NavigationGroup group = NavigationGroup.Default)
        {
            _framesByGroup.Add(group == NavigationGroup.Default ? NavigationGroup.A : group, frame);
        }
    }
}
