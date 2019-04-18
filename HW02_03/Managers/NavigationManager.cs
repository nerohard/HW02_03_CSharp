using HW02_03.Models;

namespace HW02_03.Managers
{
    class NavigationManager
    {
        private static NavigationManager _instance;
        private static object _locker = new object();
        private NavigationModel _navigationModel;

        public static NavigationManager Instance
        {
            get
            {
                if (_instance == null)
                {   
                    lock (_locker) { _instance = new NavigationManager(); }
                }
                return _instance;
            }
        }

        public void Initialize(NavigationModel navigationModel) { _navigationModel = navigationModel; }

        public void Navigate(IOHandlers handler) { _navigationModel?.Navigate(handler); }

        public void LoadOutput(Person person) { _navigationModel?.LoadOutput(person); }
    }
}
