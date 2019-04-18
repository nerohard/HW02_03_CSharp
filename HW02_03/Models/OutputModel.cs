using HW02_03.Managers;

namespace HW02_03.Models
{
    class OutputModel
    {

        private Person _person;

        public OutputModel(Person person) { _person = person; }

        public void ToForm() { NavigationManager.Instance.Navigate(IOHandlers.Input); }
    }
}
