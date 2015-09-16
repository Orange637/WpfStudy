namespace WpfStudy.Resources.Validations
{
    using System.Globalization;
    using System.Windows.Controls;

    public class StringNotEmptyValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return new ValidationResult(false, "Not Empty");
        }
    }
}
