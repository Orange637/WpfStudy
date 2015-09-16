namespace WpfStudy.Model.Persons
{
    using WpfStudy.Infrastructure;

    public class Person : ObservableObject
    {
        private string name;

        private int age;

        public int Age
        {
            get { return this.age; }
            set { this.SetProperty(ref this.age, value, () => this.Age); }
        }
        
        public string Name
        {
            get { return this.name; }
            set { this.SetProperty(ref this.name, value, () => this.Name); }
        }
        
    }
}
