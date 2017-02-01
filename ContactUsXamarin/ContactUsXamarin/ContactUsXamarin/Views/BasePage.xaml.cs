using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ContactUsXamarin.Views
{
    public partial class BasePage : NavigationPage
    {
        public BasePage()
        {
            InitializeComponent();
        }
        public BasePage(Page page)
        {
            InitializeComponent();
            page.Icon = "";
            this.Navigation.PushAsync(page);
            NavigationPage.SetBackButtonTitle(this, "Back");

            NavigationPage.SetTitleIcon(page, "blankicon.png");
        }
        
    }
}
