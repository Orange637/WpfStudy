using System.Windows.Controls;

namespace WpfStudy.Resources.Validations
{
    public class MyIntValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false,"Can't be null!");
            }

            int age;

            if (!int.TryParse(value.ToString(), out age))
            {
                return new ValidationResult(false, "Must be a number!");
            }

            if (age > 18)
                return ValidationResult.ValidResult;
            return new ValidationResult(false, "年龄必须大于18");
        }
    }
}