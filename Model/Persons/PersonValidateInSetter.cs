namespace WpfStudy.Model.Persons
{
    using System;

    using WpfStudy.Infrastructure;

    public class PersonValidateInSetter : ObservableObject
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty!");
                }

                if (value.Length < 4)
                {
                    throw new ArgumentException("Name must have more than 4 char!");
                }

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
                if (value < 18)
                {
                    throw new ArgumentException("You must be an adult!");
                }

                this.age = value;
                this.OnPropertyChanged(() => this.Age);
            }
        }
    }
}
