using System;
using HW02_03.Views;

namespace HW02_03.Models
{

    public enum IOHandlers
    {
        Input,
        Output
    }

    class NavigationModel
    {
        private MainWindow _mainWindow;
        private InputView _inputView;
        private OutputView _outputView;


        public NavigationModel(MainWindow mainWindow, Person person)
        {
            _mainWindow = mainWindow;
            _inputView = new InputView(person);
            _outputView = new OutputView(person);
        }

        public void Navigate(IOHandlers handler)
        {
            switch (handler)
            {
                case IOHandlers.Input:
                    _mainWindow.ContentControl.Content = _inputView;
                    break;
                case IOHandlers.Output:
                    _mainWindow.ContentControl.Content = _outputView;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(handler), handler, null);
            }
        }

        public void LoadOutput(Person person)
        {
            _outputView.EditInfo(person);
        }
    }
}
