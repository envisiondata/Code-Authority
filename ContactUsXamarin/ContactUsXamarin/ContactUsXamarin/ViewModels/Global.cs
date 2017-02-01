using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactUsXamarin.ViewModels
{
    public class Global : Application
    {
        //This is a global Cached Application variable you can use between Views
        //Must be set first
        public static List<ContactUsXamarin.ViewModels.Contacts> MyContact;
    }
}
