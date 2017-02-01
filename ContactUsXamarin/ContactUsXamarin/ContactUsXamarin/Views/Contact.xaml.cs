using ContactUsXamarin.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ContactUsXamarin.Views
{
    public partial class Contact : ContentPage
    {
        
        public Contact()
        {
            Title = "Contact US XAMARIN";
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, true);
            //NavigationPage.SetHasBackButton(this, false);

            
        }
        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; 
            }
            var selectedItem = e.SelectedItem as Contacts;
            
            ((ListView)sender).SelectedItem = null;

            var _ContactDetail = new ContactDetail(selectedItem.ContactID.ToString());

            Navigation.PushAsync(_ContactDetail);
        }
        protected override async void OnAppearing()
        {

            spinner.IsVisible = true;
            spinner.IsRunning = true;
            List<Contacts> MyContacts = await GetContacts();

            ContactView.ItemsSource = MyContacts;

            spinner.IsVisible = false;
            spinner.IsRunning = false;

        }
        private async Task<List<Contacts>> GetContacts()
        {
            List<Contacts> MyContacts;
            string queryString = "http://52.26.69.45:1111//ContactUSAPI/Contact/Get";
            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (results != null)
            {

                string _results = Convert.ToString(results);

                _results = _results.Substring(1, _results.Length - 2).Replace(@"\", "");//

                var myList = JsonConvert.DeserializeObject<List<ContactUsXamarin.ViewModels.Contacts>>(_results);
                MyContacts = (List<Contacts>)myList;
            }
            else
            {
                MyContacts = new List<Contacts>();
            }
            return MyContacts;
        }
    }
}
