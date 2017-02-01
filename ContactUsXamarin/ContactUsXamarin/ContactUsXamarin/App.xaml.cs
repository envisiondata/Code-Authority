using ContactUsXamarin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ContactUsXamarin
{
    public partial class App : Application
    {
        public static BasePage RootPage { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new ContactUsXamarin.MainPage();

            // The root page of your application
            RootPage = new BasePage(new Login());
            MainPage = RootPage;
            MainPage.BackgroundColor = Color.White;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
