using System;
using System.Windows.Controls;
using HW02_03.Models;
using HW02_03.ViewModels;

namespace HW02_03.Views
{
    /// <summary>
    /// Interaction logic for InputView.xaml
    /// </summary>
    public partial class InputView : UserControl
    {
        private InputViewModel _inputViewModel;

        public InputView(Person person)
        {
            InitializeComponent();
            _inputViewModel = new InputViewModel(person);
            DataContext = _inputViewModel;
        }
    }
}
