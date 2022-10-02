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
    public static class InputService
    {
        // Reads the Excel file and appends a script for each value of the Excel file
        public static string GenerateScriptFromExcelFile(FormViewModel formViewModel, string script)
        {
            try
            {
                using (SpreadsheetDocument spreadsheetDocument =
                       SpreadsheetDocument.Open(formViewModel.ExcelFilePath, false))
                {
                    WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                    WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                    SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                    string value;

                    foreach (Row row in sheetData.Elements<Row>())
                    {
                        Cell cell = row.Elements<Cell>().First();
                        int stringId = Convert.ToInt32(cell.InnerText);
                        value = workbookPart.SharedStringTablePart
                                            .SharedStringTable
                                            .Elements<SharedStringItem>()
                                            .ElementAt(stringId).InnerText;

                        formViewModel = AssignValuesToFormViewModelProperties(formViewModel, value);
                        script += new VariablesDeclarationScript(formViewModel).Script + "\n\n"
                                + new ManDeployLstOfValScript(formViewModel).Script + "\n\n";
                    }
                }

                script += new SelectScript(formViewModel).Script;
                return script;
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Excel filePath");
            }

            return script;
        }

        public static string ProcessRadioButton(RadioButton radioButton)
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

        private static string Process(string value)
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

        private static FormViewModel AssignValuesToFormViewModelProperties(FormViewModel formViewModel, string value)
        {
            formViewModel.LovDesc = value;
            formViewModel.LovComments = value;
            formViewModel.LovLongDesc = value;
            formViewModel.LovInternalDesc = formViewModel.LovtDesc.ToUpper() + "_" + Process(value);

            return formViewModel;
        }
    }
}
