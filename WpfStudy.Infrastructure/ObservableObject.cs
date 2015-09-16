// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObservableObject.cs" company="mm-software">
//   mm-software
// </copyright>
// <summary>
//   The observable object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfStudy.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq.Expressions;

    /// <summary>
    /// The observable object.
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler == null)
            {
                return;
            }

            var memberExpression = propertyName.Body as MemberExpression;
            if (memberExpression != null)
            {
                handler(this, new PropertyChangedEventArgs(memberExpression.Member.Name));
            }
        }

        protected virtual void SetProperty<T>(ref T field, T value, Expression<Func<T>> propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return;
            }

            field = value;
            
            this.OnPropertyChanged(propertyName);
        }

        /*protected virtual void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                return;
            }

            field = value;
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this,new PropertyChangedEventArgs(propertyName));
            }
        }*/
    }
}