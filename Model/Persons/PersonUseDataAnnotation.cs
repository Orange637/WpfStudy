namespace WpfStudy.Model.Persons
{
    using System.ComponentModel.DataAnnotations;

    using WpfStudy.Infrastructure;

    public class PersonUseDataAnnotation : ObservableObject
    {
        private int age;

        private string name;

        [Range(18, 120, ErrorMessage = "Age must be a positive integer")]
        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                this.ValidateProperty(value, "Age");
                this.SetProperty(ref this.age, value, () => this.Age);
            }
        }

        [Required(ErrorMessage = "A name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must have at least 3 characters")]
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.ValidateProperty(value, "Name");
                this.SetProperty(ref this.name, value, () => this.Name);
            }
        }

        protected void ValidateProperty<T>(T value, string propertyName)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = propertyName });
        }
    }
}
