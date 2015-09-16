using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfStudy.Bindings
{
    /// <summary>
    /// Interaction logic for BindingLoseEfficacy.xaml
    /// </summary>
    public partial class BindingLoseEfficacy : INotifyPropertyChanged
    {
        private int _staticInt;

        private string _showString;

        private CustomObject _showObject1;

        private CustomObject _showObject2;

        private CustomObject _showObject3;

        private NestedObject _nestedObject1;

        public NestedObject NestedObject1
        {
            get { return _nestedObject1; }
            set { _nestedObject1 = value;this.OnPropertyChanged("NestedObject1"); }
        }

        private NestedObject _nestedObject2;

        public NestedObject NestedObject2
        {
            get { return _nestedObject2; }
            set { _nestedObject2 = value;this.OnPropertyChanged("NestedObject2"); }
        }

        private NestedObject _nestedObject3;

        public NestedObject NestedObject3
        {
            get { return _nestedObject3; }
            set { _nestedObject3 = value;this.OnPropertyChanged("NestedObject3"); }
        }

        public CustomObject InnerObject3
        {
            get
            {
                return _nestedObject3.InnerObject;
            }

            set
            {
                _nestedObject3.InnerObject = value;
                this.OnPropertyChanged("InnerObject3");
            }
        }


        public BindingLoseEfficacy()
        {
            InitializeComponent();

            this.NestedObject1 = new NestedObject();
            this.NestedObject2 = new NestedObject();
            this.NestedObject3 = new NestedObject();
        }

        public string ShowString
        {
            get
            {
                return _showString;
            }
            set
            {
                _showString = value;
                this.OnPropertyChanged("ShowString");
            }
        }

        public CustomObject ShowObject1
        {
            get
            {
                return this._showObject1;
            }

            set
            {
                this._showObject1 = value;
                this.OnPropertyChanged("ShowObject1");
            }
        }

        public CustomObject ShowObject2
        {
            get
            {
                return this._showObject2;
            }

            set
            {
                this._showObject2 = value;
                this.OnPropertyChanged("ShowObject2");
            }
        }

        public CustomObject ShowObject3
        {
            get
            {
                return this._showObject3;
            }

            set
            {
                this._showObject3 = value;
                this.OnPropertyChanged("ShowObject3");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void ChangeShowString(object sender, RoutedEventArgs e)
        {
            this.ShowString = "Change This to another Object";
        }

        private void ChangeShowObject1(object sender, RoutedEventArgs e)
        {
            this.ShowObject1 = new CustomObject()
                {
                    CustomObjectInt = _staticInt++,
                    CustomObjectString = "double b" + _staticInt
                };
        }

        private void ChangeShowObject1ToNull(object sender, RoutedEventArgs e)
        {
            this.ShowObject1 = null;
        }

        private void ChangeShowObject2ToNull(object sender, RoutedEventArgs e)
        {
            this.ShowObject2 = null;
        }

        private void ChangeShowObject3ToNull(object sender, RoutedEventArgs e)
        {
            this.ShowObject3= null;
        }

        private void ChangeShowObject2(object sender, RoutedEventArgs e)
        {
            this.ShowObject2 = new CustomObject()
            {
                CustomObjectInt = _staticInt++,
                CustomObjectString = "triple b" + _staticInt
            };
        }

        private void ChangeShowObject3(object sender, RoutedEventArgs e)
        {

            this.ShowObject3 = new CustomObject()
            {
                CustomObjectInt = _staticInt++,
                CustomObjectString = "triple b" + _staticInt
            };
        }

        private void ChangeNestedObject1(object sender, RoutedEventArgs e)
        {
            if (this.NestedObject1 != null)
            {
                this.NestedObject1.InnerObject = new CustomObject()
                {
                    CustomObjectInt = _staticInt++,
                    CustomObjectString = "triple b" + _staticInt
                };
            }
        }

        private void ChangeNestedObject1ToNull(object sender, RoutedEventArgs e)
        {
            if (this.NestedObject1 != null)
            {
                this.NestedObject1.InnerObject = null;
            }
        }

        private void ChangeNestedObject2(object sender, RoutedEventArgs e)
        {
            if (this.NestedObject2 != null)
            {
                this.NestedObject2.InnerObject = new CustomObject()
                {
                    CustomObjectInt = _staticInt++,
                    CustomObjectString = "triple b" + _staticInt
                };

                this.NestedObject2.OnPropertyChanged("InnerObject");
            }
        }

        private void ChangeNestedObject2ToNull(object sender, RoutedEventArgs e)
        {
            if (this.NestedObject2 != null)
            {
                this.NestedObject2.InnerObject = null;
            }
        }
        private void ChangeNestedObject3(object sender, RoutedEventArgs e)
        {
            if (this.NestedObject3 != null)
            {
                this.InnerObject3 = new CustomObject()
                {
                    CustomObjectInt = _staticInt++,
                    CustomObjectString = "triple b" + _staticInt
                };
            }
        }

        private void ChangeNestedObject3ToNull(object sender, RoutedEventArgs e)
        {
            if (this.NestedObject3 != null)
            {
                this.InnerObject3 = null;
            }
        }
    }

    public class CustomObject : INotifyPropertyChanged
    {
        private string _customObjectString;

        private int _customObjectInt;

        public CustomObject()
        {
        }

        public string CustomObjectString
        {
            get
            {
                return _customObjectString;
            }
            set
            {
                _customObjectString = value;
                this.OnPropertyChanged("CustomObjectString");
            }
        }

        public int CustomObjectInt
        {
            get { return _customObjectInt; }
            set { _customObjectInt = value; this.OnPropertyChanged("CustomObjectInt");}
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override string ToString()
        {
            return string.Format("CustomObject - int:{0},string:{1}", this._customObjectInt, this._customObjectString);
        }
    }

    public class NestedObject : INotifyPropertyChanged
    {
        private CustomObject _innerObject;

        /// <summary>
        /// The key point is Forget to Notify this Object when it changes.
        /// </summary>
        public CustomObject InnerObject
        {
            get { return _innerObject; }
            set { _innerObject = value; /*this.OnPropertyChanged("InnerObject");*/}
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
