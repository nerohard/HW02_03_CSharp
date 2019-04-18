using System;
using System.Windows;
using System.Windows.Input;
using HW02_03.Models;
using HW02_03.Tools;

namespace HW02_03.ViewModels
{
    class InputViewModel : ObservableItem
    {

        private DateTime _selectedDate = DateTime.Now;
        private String _selectedFirstName = String.Empty;
        private String _selectedLastName = String.Empty;
        private String _selectedEmail = String.Empty;

        private readonly InputModel InputModel;
        private ICommand _submitCommand;

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set { ChangeAndNotify(ref _selectedDate, value, () => SelectedDate); }
        }

        public string SelectedFirstName
        {
            get { return _selectedFirstName; }
            set { ChangeAndNotify(ref _selectedFirstName, value, () => SelectedFirstName); }
        }

        public string SelectedLastName
        {
            get { return _selectedLastName; }
            set { ChangeAndNotify(ref _selectedLastName, value, () => SelectedLastName); }
        }

        public string SelectedEmail
        {
            get { return _selectedEmail; }
            set { ChangeAndNotify(ref _selectedEmail, value, () => SelectedEmail); }
        }

        public InputViewModel(Person person)
        {
            InputModel = new InputModel(person, this);
        }

        public void ShowInvalidInputMessage(Exception exception)
        {
            MessageBox.Show(exception.Message);
        }

        public ICommand SubmitCommand
        {
            get
            {
                if (_submitCommand == null) _submitCommand = new RelayCommand<object>(ExecuteInput, ExecuteInputCan);
                return _submitCommand;
            }
            set { ChangeAndNotify(ref _submitCommand, value, () => SubmitCommand); }
        }

        private void ExecuteInput(object obj)
        {
            InputModel.ValidateInput(SelectedFirstName, SelectedLastName, SelectedEmail, SelectedDate);
        }

        private bool ExecuteInputCan(object obj)
        {
            return (!string.IsNullOrWhiteSpace(_selectedFirstName) && !string.IsNullOrWhiteSpace(_selectedLastName) && !string.IsNullOrWhiteSpace(_selectedEmail));
        }

    }
}
