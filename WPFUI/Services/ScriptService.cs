using Models;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Scripts;
using System.IO;
using System.Windows;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Linq;

namespace WPFUI.Services
{
    internal static class ScriptService
    {
        internal static void GenerateScriptWithInstCode(MainWindow window, FormViewModel formViewModel)
        {
            formViewModel = RunStandardProcess(window, formViewModel, true);

            if (formViewModel != null)
            {
                string script = new CheckInstallationScript(formViewModel).Script + "\n\n"
                              + new ManDeployLovTypeScript(formViewModel).Script + "\n\n";

                script = GenerateScriptFromExcelFile(formViewModel, script);

                try
                {
                    File.WriteAllText(formViewModel.SqlExportFilePath, script);
                    MessageBox.Show("Script successfully generated!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid export filePath");
                }
            }
        }

        internal static void GenerateScriptWithoutInstCode(MainWindow window, FormViewModel formViewModel)
        {
            formViewModel = RunStandardProcess(window, formViewModel, false);

            if (formViewModel != null)
            {
                string script = new ManDeployLovTypeScript(formViewModel).Script + "\n\n";

                script = GenerateScriptFromExcelFile(formViewModel, script);

                try
                {
                    File.WriteAllText(formViewModel.SqlExportFilePath, script);
                    MessageBox.Show("Script successfully generated!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid export filePath");
                }
            }
        }

        // Runs the standard process that is common for both cases of script generation
        private static FormViewModel? RunStandardProcess(MainWindow window, FormViewModel formViewModel, bool isInstCodeRequired)
        {
            IEnumerable<TextBox> textBoxes = MappingService.FindControlsInWindow<TextBox>(window);
            IEnumerable<RadioButton> radioButtons = MappingService.FindControlsInWindow<RadioButton>(window);

            if (ValidationService.IsValidationProcessSuccessful(textBoxes, isInstCodeRequired))
            {
                formViewModel = MappingService.MapFormValuesToFormViewModelProperties(textBoxes, formViewModel, isInstCodeRequired);
                formViewModel = MappingService.MapFormValuesToFormViewModelProperties(radioButtons, formViewModel);
                return formViewModel;
            }
            return null;
        }

        // Reads the Excel file and appends a script for each value of the Excel file
        private static string GenerateScriptFromExcelFile(FormViewModel formViewModel, string script)
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

        private static FormViewModel AssignValuesToFormViewModelProperties(FormViewModel formViewModel, string value)
        {
            formViewModel.LovDesc = value;
            formViewModel.LovComments = value;
            formViewModel.LovLongDesc = value;
            formViewModel.LovInternalDesc = formViewModel.LovtDesc.ToUpper() + "_" + InputService.ProcessExcelValue(value);

            return formViewModel;
        }
    }
}