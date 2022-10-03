using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Models;
using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Windows.Controls;
using Scripts;
using System.Windows;

namespace WPFUI.Services
{
    internal static class InputService
    {
        internal static string ProcessRadioButton(RadioButton radioButton)
        {
            if (radioButton.IsChecked == true)
                return radioButton.Content.ToString();
            else
                switch (radioButton.Content)
                {
                    case "1":
                        return "0";
                    default:
                        return "1";
                }
        }

        internal static string ProcessExcelValue(string value)
        {
            value = Regex.Replace(value, @"[ ]{2,}", " "); // Replaces white spaces that contain 2 or more characters with an empty character
            value = value.Trim()
                         .Replace(" ", "_")
                         .Replace(".", "")
                         .Replace("(", "")
                         .Replace(")", "")
                         .Replace("&", "AND")
                         .ToUpper();
            return value;
        }
    }
}
