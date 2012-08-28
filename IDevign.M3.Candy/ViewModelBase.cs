using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;

namespace IDevign.M3.Candy
{
    /// <summary>
    /// Base class for viewmodels implementing <see cref="INotifyPropertyChanged"/> and basic eventhandling.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region Handling of View events

        public virtual void OnLoad()
        {
            Debug.WriteLine(string.Format("Loaded {0}", this.GetType().Name));
        }

        public virtual void OnClose()
        {
            Debug.WriteLine(string.Format("Unloaded {0}", this.GetType().Name));
        }

        #endregion

        #region NotifyPropertyChanged Implementation 

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(Expression<Func<object>> expression)
        {
            OnPropertyChanged(GetPropertyName(expression));
        }
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private static string GetPropertyName<TProp>(Expression<Func<TProp>> propertySelector)
        {
            var memberExpr = propertySelector.Body as MemberExpression;

            if (memberExpr == null) throw new ArgumentException("must be a member accessor", "propertySelector");

            return memberExpr.Member.Name;
        }

        #endregion
    }
}