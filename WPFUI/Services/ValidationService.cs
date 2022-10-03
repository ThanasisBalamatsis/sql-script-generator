using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using WPFUI.Constants;

namespace WPFUI.Services
{
    internal static class ValidationService
    {
        internal static bool IsValidationProcessSuccessful(IEnumerable<TextBox> textBoxes)
        {
            string errorsMessage = "";

            foreach (TextBox textBox in textBoxes)
            {
                if (ValidationLists.pathsToCheck.Contains(textBox.Name))
                {
                    errorsMessage = CheckPaths(textBox, errorsMessage);
                }
                else if (ValidationLists.intOrBlankFields.Contains(textBox.Name))
                {
                    errorsMessage = CheckIfIntegerOrBlank(textBox, errorsMessage);
                }
                else if (ValidationLists.nonNullableNonEmptyStringFields.Contains(textBox.Name))
                {
                    errorsMessage = CheckIfNonNullableNonEmptyString(textBox, errorsMessage);
                }
                else if (ValidationLists.nullableIntFields.Contains(textBox.Name))
                {
                    errorsMessage = CheckIfNullableInt(textBox, errorsMessage);
                }
                else if (ValidationLists.nullableNonEmptyStringFields.Contains(textBox.Name))
                {
                    errorsMessage = CheckIfNullableNonEmptyString(textBox, errorsMessage);
                }
                else if (ValidationLists.oneZeroOrNullFields.Contains(textBox.Name))
                {
                    errorsMessage = CheckIfOneZeroOrNull(textBox, errorsMessage);
                }
            }

            if (errorsMessage == "")
                return true;
            else
            {
                MessageBox.Show(errorsMessage);
                return false;
            }
        }

        private static string CheckPaths(TextBox textBox, string errorsMessage)
        {
            switch (textBox.Name)
            {
                case "ExcelFilePath":
                    try
                    {
                        // Try to open the Excel file at the given filePath
                        SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(textBox.Text, false);

                    }
                    catch (Exception)
                    {
                        errorsMessage += $"\n{textBox.Name} path is not valid";
                    }
                    break;

                case "SqlExportFilePath":

                    if (!CheckIfFileTypeIsSql(textBox.Text))
                        errorsMessage += $"\n{textBox.Name} should end with .sql";

                    try
                    {
                        File.WriteAllText(textBox.Text, ""); // Try to create a .sql file to the given path
                        File.Delete(textBox.Text); // Delete the file if it is successfully written
                    }
                    catch (Exception)
                    {
                        errorsMessage += $"\n{textBox.Name} path is not valid";
                    }
                    break;
            }
            return errorsMessage;
        }

        private static bool CheckIfFileTypeIsSql(string path)
        {
            try
            {
                if (path.Substring(path.Length - 4, 4) == ".sql")
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static string CheckIfIntegerOrBlank(TextBox textBox, string errorsMessage)
        {
            if (String.IsNullOrWhiteSpace(textBox.Text))
                return errorsMessage;

            try
            {
                Convert.ToInt32(textBox.Text);
                return errorsMessage;
            }
            catch (Exception)
            {
                errorsMessage += $"\n{textBox.Name} value should be a number or blank space";
                return errorsMessage;
            }
        }

        private static string CheckIfNonNullableNonEmptyString(TextBox textBox, string errorsMessage)
        {
            if (String.IsNullOrWhiteSpace(textBox.Text))
                errorsMessage += $"\n{textBox.Name} should not be empty";

            if (textBox.Text == "null" || textBox.Text == "NULL" || textBox.Text.Trim().ToUpper() == "NULL")
                errorsMessage += $"\n{textBox.Name} should not be null";

            return errorsMessage;
        }

        private static string CheckIfNullableInt(TextBox textBox, string errorsMessage)
        {
            if (textBox.Text == "null" || textBox.Text == "NULL")
                return errorsMessage;

            try
            {
                Convert.ToInt32(textBox.Text);
                return errorsMessage;
            }
            catch (Exception)
            {
                errorsMessage += $"\n{textBox.Name} value is not a number or null";
                return errorsMessage;
            }
        }

        private static string CheckIfNullableNonEmptyString(TextBox textBox, string errorsMessage)
        {
            if (textBox.Text == "null" || textBox.Text == "NULL")
                return errorsMessage;

            if (String.IsNullOrWhiteSpace(textBox.Text))
                errorsMessage += $"\n{textBox.Name} should not be empty";

            return errorsMessage;
        }

        private static string CheckIfOneZeroOrNull(TextBox textBox, string errorsMessage)
        {
            if (textBox.Text == "1" || textBox.Text == "0" || textBox.Text == "null" || textBox.Text == "NULL")
                return errorsMessage;

            errorsMessage += $"\n{textBox.Name} should be 1, 0 or null";
            return errorsMessage;
        }
    }
}
