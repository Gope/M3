using System.Windows;
using System.Windows.Input;
using IDevign.M3.Candy;

namespace IDevign.M3.AppControls
{
    public class CoolControlViewModel : ViewModelBase
    {
        public string CoolValue
        {
            get { return "How to use Controls and MVVM is just in the making."; }
        }

        public ICommand DoSomethingCommand
        {
            get
            {
                return new DelegateCommand((obj) => { });
            }
        }
    }
}