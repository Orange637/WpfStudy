namespace WpfStudy.Resources.Controls
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;

    using AdornedControl;

    public class BusyIndicator2 : ContentControl
    {
        public static readonly DependencyProperty AdornerdContentProperty = DependencyProperty.Register(
            "AdornedContent",
            typeof(FrameworkElement),
            typeof(BusyIndicator2),
            new PropertyMetadata(null, OnAdornedContentPropertyChangedCallback));

        public static readonly DependencyProperty IsBusyProperty = DependencyProperty.Register(
            "IsBusy", typeof(bool), typeof(BusyIndicator2), new PropertyMetadata(false, OnIsBusyPropertyChangedCallback));

        private ContentAdorner adorner;

        public FrameworkElement AdornedContent
        {
            get
            {
                return (FrameworkElement)this.GetValue(AdornerdContentProperty);
            }

            set
            {
                this.SetValue(AdornerdContentProperty, value);
            }
        }

        public bool IsBusy
        {
            get
            {
                return (bool)this.GetValue(IsBusyProperty);
            }

            set
            {
                this.SetValue(IsBusyProperty, value);
            }
        }

        private static void OnAdornedContentPropertyChangedCallback(
            DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
        }

        private static void OnIsBusyPropertyChangedCallback(
            DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            var self = (BusyIndicator2)sender;
            var busy = (bool)args.NewValue;

            if (busy)
            {
                self.ShowAdorner();
            }
            else
            {
                self.HideAdorner();
            }
        }

        private void HideAdorner()
        {
            if (this.adorner == null)
            {
                return;
            }

            var adornerLayer = AdornerLayer.GetAdornerLayer(this);
            if (adornerLayer != null)
            {
                adornerLayer.Remove(this.adorner);
                this.adorner.DisconnectChild();
                this.adorner = null;
            }
        }

        private void ShowAdorner()
        {
            var parent = this.Parent as Panel;

            this.adorner = new ContentAdorner(parent, this.AdornedContent);

            // this.adorner = new FrameworkElementAdorner(parent, new LoadingAnimation());
            var adornerLayer = AdornerLayer.GetAdornerLayer(this);
            if (adornerLayer != null)
            {
                adornerLayer.Add(this.adorner);
            }
        }
    }
}
