using System.Windows;
using System.Windows.Input;
using IDevign.M3.Candy;

namespace IDevign.M3.AppControls
{
    public class CoolControlViewModel : ViewModelBase
    {
        public string CoolValue
        {
            get { return "This value is so cool!"; }
        }

        public ICommand ReactToSomethingCommand
        {
            get
            {
                return new DelegateCommand((obj) => { });
            }
        }

        //public static readonly RoutedEvent TapEvent = EventManager.RegisterRoutedEvent("MouseEnter", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CoolControl));

        //// Provide CLR accessors for the event 
        //public event RoutedEventHandler Tap
        //{
        //    add { AddHandler(TapEvent, value); }
        //    remove { RemoveHandler(TapEvent, value); }
        //}
    }
}