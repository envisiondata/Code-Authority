using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using ContactUs.Service;
using ContactUs.Data.Repositories;

namespace ContactUs
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IContactService, ContactService>();
            container.RegisterType<IContactRepository, ContactRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}