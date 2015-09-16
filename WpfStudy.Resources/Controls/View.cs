// --------------------------------------------------------------------------------------------------------------------
// <copyright file="View.cs" company="mm-software">
//   mm-software
// </copyright>
// <summary>
//   The i view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfStudy.Resources.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Windows;

    /// <summary>
    /// The i view.
    /// </summary>
    public class View : Window, INotifyPropertyChanged
    {
        public View()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(ref T field, T value, Expression<Func<T>> propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return;
            }

            field = value;
            
            this.NotifyPropretyChanged(propertyName);
        }

        protected void NotifyPropretyChanged<T>(Expression<Func<T>> propertyName)
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

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Owner.Show();
            // this.Close();
            // Application.Current.Shutdown();
        }
    }
}