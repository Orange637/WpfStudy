namespace WpfStudy.Resources.Validations
{
    using System.Globalization;
    using System.Windows.Controls;

    public class MinAgeValidation : ValidationRule
    {
        public int MinAge { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                int age;

                if (int.TryParse(value.ToString(), out age))
                {
                    if (age < this.MinAge)
                    {
                        return new ValidationResult(false, "Age must large than " + this.MinAge.ToString(CultureInfo.InvariantCulture));
                    }
                }
                else
                {
                    return new ValidationResult(false, "Age must be a number!");
                }
            }
            else
            {
                return new ValidationResult(false, "Age must not be null!");
            }

            return new ValidationResult(true, null);
        }
    }
}
