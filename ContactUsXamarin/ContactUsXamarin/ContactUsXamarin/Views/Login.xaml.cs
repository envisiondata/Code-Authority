using ContactUsXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ContactUsXamarin.Views
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {            
            string platformName = Device.OS.ToString();
            Content.FindByName<Button>("loginButton" + platformName).IsEnabled = false;
            
            string UserName = Content.FindByName<Entry>("UserName" + platformName).Text;
            string Password = Content.FindByName<Entry>("Password" + platformName).Text;

            IsBusy = true;

            if (await Core.GetLogin(UserName, Password) == true)
            {
                //Navigate to the new Page
                var _Contact = new Contact();
                Navigation.PushAsync(_Contact);
            }
            else
            {
                DisplayAlert("Invalid Login", "You have entered invalid credentials", "OK");
            }
        }
    }
}