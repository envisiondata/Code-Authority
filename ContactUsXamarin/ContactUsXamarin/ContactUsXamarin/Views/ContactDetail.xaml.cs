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
    public partial class ContactDetail : ContentPage
    {
        string ContactID;
        public ContactDetail(string id)
        {
            InitializeComponent();

            ContactID = id;
        }

        protected override async void OnAppearing()
        {

            spinner.IsVisible = true;
            spinner.IsRunning = true;

            List<Contacts> MyContacts = await GetContactByID(ContactID);

            Contacts MyContact = MyContacts[0];

            BindingContext = MyContact;

            spinner.IsVisible = false;
            spinner.IsRunning = false;

        }
        private async Task<List<Contacts>> GetContactByID(string ContactID)
        {
            List<Contacts> MyContact;
            string queryString = "http://52.26.69.45:1111//ContactUSAPI/Contact/Get/" + ContactID;
            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (results != null)
            {

                string _results = Convert.ToString(results);

                _results = _results.Substring(1, _results.Length - 2).Replace(@"\", "");//

                var myList = JsonConvert.DeserializeObject<List<ContactUsXamarin.ViewModels.Contacts>>(_results);
                MyContact = (List<Contacts>)myList;
            }
            else
            {
                MyContact = new List<Contacts>();
            }
            return MyContact;
        }


    }
}
