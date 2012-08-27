using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;

namespace IDevign.M3.Candy
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public virtual void OnLoad()
        {
            Debug.WriteLine(string.Format("Loaded {0}", this.GetType().Name));
        }

        public virtual void OnClose()
        {
            Debug.WriteLine(string.Format("Unloaded {0}", this.GetType().Name));
        }

        #region NotifyPropertyChanged Implementation 

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(Expression<Func<object>> expression)
        {
            var name = expression.Body.ToString();
            OnPropertyChanged(name);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}