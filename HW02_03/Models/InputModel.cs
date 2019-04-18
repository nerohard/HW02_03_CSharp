using System;
using System.Net.Mail;
using System.Windows;
using HW02_03.Exceptions;
using HW02_03.Managers;
using HW02_03.ViewModels;

namespace HW02_03.Models
{
    class InputModel
    {
        private Person _person;
        private InputViewModel _inputViewModel;
        private readonly DateTime _periodFrom;

        public InputModel(Person person, InputViewModel inputViewModel)
        {
            _person = person;
            _inputViewModel = inputViewModel;
            _periodFrom = new DateTime(DateTime.Now.Year - 135, DateTime.Now.Month, DateTime.Now.Day, 
                                        DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }

        public bool ValidateInput(string firstName, string lastName, string email, DateTime birthDateTime)
        {
            try
            {
                ValidateDate(birthDateTime);
                ValidateEmail(email);

                _person = new Person(firstName, lastName, email, birthDateTime);

                NavigationManager.Instance.LoadOutput(_person);
                NavigationManager.Instance.Navigate(IOHandlers.Output);

                if (_person.IsBirthday) MessageBox.Show("Happy Birthday!");

                return true;
            }
            catch (Exception e)
            {
                _inputViewModel.ShowInvalidInputMessage(e);
                return false;
            }

        }

        private void ValidateDate(DateTime date)
        {
            if (date <= _periodFrom) throw new InvalidAgeException();
            if (date > DateTime.Now) throw new InvalidDateException();
        }

        private void ValidateEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
            }
            catch (FormatException)
            {
                throw new InvalidEmailException();
            }
        }
    }
}


    
