namespace WpfStudy.Model.Persons
{
    using System.ComponentModel;

    using WpfStudy.Infrastructure;

    public class PersonDerivedFromIDataErrorInfo : ObservableObject, IDataErrorInfo
    {
        private string name;

        private int age;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.OnPropertyChanged(() => this.Name);
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                this.age = value;
                this.OnPropertyChanged(() => this.Age);
            }
        }

        // never called by WPF
        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    case "Name":
                        if (string.IsNullOrWhiteSpace(this.Name))
                        {
                            return "Name cannot be empty!";
                        }

                        if (this.Name.Length < 4)
                        {
                            return "Name must have more than 4 char!";
                        }

                        break;
                    case "Age":
                        if (this.Age < 18)
                        {
                            return "You must be an adult!";
                        }

                        break;
                }

                return null;
            }
        }
    }
}
