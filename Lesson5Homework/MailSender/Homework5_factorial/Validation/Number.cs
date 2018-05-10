using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Homework5_factorial.Validation
{
    class Number : System.Windows.Controls.ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!(value is int)) return new ValidationResult(false, "Введенное значение не число");

            //int num;

            //if (!(Int32.TryParse(value.ToString(), out num))) return ;
            return ValidationResult.ValidResult;
        }
    }
}
