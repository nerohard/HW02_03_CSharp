using System.Windows;
using HW02_03.Managers;
using HW02_03.Models;

namespace HW02_03
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow mainWindow = new MainWindow();
            Person person = new Person();
            NavigationModel navigationModel = new NavigationModel(mainWindow, person);
            NavigationManager.Instance.Initialize(navigationModel);
            mainWindow.Show();
            navigationModel.Navigate(IOHandlers.Input);
        }
    }
}
