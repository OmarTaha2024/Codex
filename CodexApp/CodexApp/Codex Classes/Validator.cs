using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodexApp.Codex_Classes
{
   public static class Validator
    {
        public static bool IsRequired(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                MessageBox.Show($"{fieldName} is required.");
                return false;
            }
            return true;
        }

        public static bool IsNumeric(string value, string fieldName)
        {
            if (!int.TryParse(value, out _))
            {
                MessageBox.Show($"{fieldName} must be a valid number.");
                return false;
            }
            return true;
        }

        public static bool IsDecimal(string value, string fieldName)
        {
            if (!decimal.TryParse(value, out _))
            {
                MessageBox.Show($"{fieldName} must be a valid decimal number.");
                return false;
            }
            return true;
        }

        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Please enter a valid email address.");
                return false;
            }
            return true;
        }

        public static bool IsDateRangeValid(DateTime startDate, DateTime endDate)
        {
            if (startDate >= endDate)
            {
                MessageBox.Show("Start date must be earlier than the end date.");
                return false;
            }
            return true;
        }

        public static bool IsComboBoxSelected(ComboBox comboBox, string fieldName)
        {
            if (comboBox.SelectedValue == null || string.IsNullOrWhiteSpace(comboBox.SelectedValue.ToString()))
            {
                MessageBox.Show($"Please select a value for {fieldName}.");
                return false;
            }
            return true;
        }
    }
}
