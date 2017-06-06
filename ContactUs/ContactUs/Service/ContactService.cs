using ContactUs.Data.Repositories;
using ContactUs.Models;
using ContactUs.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using ContactUs.Data.Model;

namespace ContactUs.Service
{
    public class ContactService : IContactService
    {
        IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepo)
        {
            _contactRepository = contactRepo;
        }
        public void PostContact(ContactViewModel myContact)
        {
            Contact _contact = MapToEntity(myContact);

            _contactRepository.PostContact(_contact);
        }

        public bool Delete(string id)
        {
            return _contactRepository.Delete(id);
        }
        public List<ContactViewModel> GetContacts()
        {
            List<Contact> ListContact = _contactRepository.GetContacts();

            return MapToViewModel(ListContact);
        }

        private List<ContactViewModel> MapToViewModel(List<Contact> Model)
        {
            List<ContactViewModel> ViewModel = new List<ContactViewModel>();

            foreach(Contact _contat in Model)
            {
                ContactViewModel _viewModel = new ContactViewModel();

                _viewModel.ContactID = _contat.ContactID;
                _viewModel.BestTimeToCall = _contat.BestTimeToCall;
                _viewModel.EmailAddress = _contat.EmailAddress;
                _viewModel.FirstName = _contat.FirstName;
                _viewModel.LastName = _contat.LastName;
                _viewModel.Telephone = _contat.Telephone;

                ViewModel.Add(_viewModel);
            }

            return ViewModel;
        }

        private Contact MapToEntity(ContactViewModel ViewModel)
        {
            Contact _contact = new Contact();

            _contact.ContactID = ViewModel.ContactID;
            _contact.BestTimeToCall = ViewModel.BestTimeToCall;
            _contact.EmailAddress = ViewModel.EmailAddress;
            _contact.FirstName = ViewModel.FirstName;
            _contact.LastName = ViewModel.LastName;
            _contact.Telephone = ViewModel.Telephone;

            return _contact;
        }
    }
}