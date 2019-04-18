using System.Windows.Controls;
using HW02_03.Models;
using HW02_03.ViewModels;

namespace HW02_03.Views
{
    /// <summary>
    /// Interaction logic for OutputView.xaml
    /// </summary>
    public partial class OutputView : UserControl
    {
        private Person _person;
        private OutputViewModel _outputViewModel;

        public OutputView() { InitializeComponent(); }

        public OutputView(Person person)
        {
            InitializeComponent();
            _outputViewModel = new OutputViewModel(person);
            DataContext = _outputViewModel;
        }

        public void EditInfo(Person person)
        {
            InitializeComponent();
            _outputViewModel.EditPersonInfo(person); //Editing information about persons is not working
            DataContext = _outputViewModel;
        }
    }
}
