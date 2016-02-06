using GalaSoft.MvvmLight.Command;
using PhotoSlides.Data;
using PhotoSlides.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace PhotoSlides.ViewModel
{
    public class LoginPageViewModel : BaseViewModel //NotificationBase
    {
        private RelayCommand _loginCommand;
        private RelayCommand _cancelCommand;

        private string _loginName;
        private string _password;
        public string LoginName
        {
            get { return _loginName; }
            set { Set(() => LoginName, ref _loginName, value); }
        }

        public string Password
        {
            get { return _password; }
            set { Set(() => Password, ref _password, value); }
        }

        public RelayCommand LoginCommand => _loginCommand ?? (_loginCommand = new RelayCommand(LoginAsync, () => true));

        public RelayCommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand(cancel, () => true));

        private void cancel()
        {
            Application.Current.Exit();
        }
        public async void LoginAsync()
        {
            if (string.IsNullOrEmpty(LoginName) || string.IsNullOrEmpty(Password))
            {
                var dialog = new MessageDialog("Login Failed");
                await dialog.ShowAsync();
                return;
            }

            AuthorizationManager.Instance.Initialize(LoginName);

            Navigate<MainPageViewModel>();
        }
    }
}
