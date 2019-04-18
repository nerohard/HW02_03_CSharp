using System;
using System.Windows.Input;
using HW02_03.Models;
using HW02_03.Tools;

namespace HW02_03.ViewModels
{
    class OutputViewModel : ObservableItem
    {
        public readonly OutputModel Model;

        private string _firstName = String.Empty, _lastName = String.Empty, _email = String.Empty, 
                        _sunSign = String.Empty, _chineseSign = String.Empty;
        private bool _isAdult, _isBirthday;
        private DateTime _birthDate;

        private ICommand _toFormCommand;

        public OutputViewModel(Person person)
        {
            Model = new OutputModel(person);
            EditPersonInfo(person);
        }

        public void EditPersonInfo(Person person)
        {
            FirstName = person.FirstName;
            LastName = person.SecondName;
            Email = person.Email;
            BirthDate = person.BirthDateTime;

            IsAdult = person.IsAdult;
            SunSign = person.SunSign;
            ChineseSign = person.ChineseSign;
            IsBirthday = person.IsBirthday;
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public bool IsAdult
        {
            get { return _isAdult; }
            set
            {
                _isAdult = value;
                OnPropertyChanged("IsAdult");
            }
        }

        public string SunSign
        {
            get { return _sunSign; }
            set
            {
                _sunSign = value;
                OnPropertyChanged("SunSign");
            }
        }

        public string ChineseSign
        {
            get { return _chineseSign; }
            set
            {
                _chineseSign = value;
                OnPropertyChanged("ChineseSign");
            }
        }

        public bool IsBirthday
        {
            get { return _isBirthday; }
            set
            {
                _isBirthday = value;
                OnPropertyChanged("IsBirthday");
            }
        }

        public ICommand ToFormCommand
        {
            get
            {
                if (_toFormCommand == null) _toFormCommand = new RelayCommand<object>(ExecuteOutput, ExecuteOutputCan);
                return _toFormCommand;
            }
            set { ChangeAndNotify(ref _toFormCommand, value, () => ToFormCommand); }
        }

        private void ExecuteOutput(object obj) { Model.ToForm(); }
        private bool ExecuteOutputCan(object obj) { return true; }
    }
}
