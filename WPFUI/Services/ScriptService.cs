using Models;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Scripts;
using System.IO;
using System.Windows;

namespace WPFUI.Services
{
    public static class ScriptService
    {
        // Runs the standard process that is common for both cases of script generation
        public static FormViewModel? RunStandardProcess(MainWindow window, FormViewModel formViewModel)
        {
            IEnumerable<TextBox> textBoxes = MappingService.FindControlsInWindow<TextBox>(window);
            IEnumerable<RadioButton> radioButtons = MappingService.FindControlsInWindow<RadioButton>(window);

            if (ValidationService.IsValidationProcessSuccessful(textBoxes))
            {
                formViewModel = MappingService.MapFormValuesToFormViewModelProperties(textBoxes, formViewModel);
                formViewModel = MappingService.MapFormValuesToFormViewModelProperties(radioButtons, formViewModel);
                return formViewModel;
            }
            return null;
        }
        public static void AssembleScriptWithInstCode(MainWindow window, FormViewModel formViewModel)
        {
            formViewModel = RunStandardProcess(window, formViewModel);

            if (formViewModel != null)
            {
                string script = new CheckInstallationScript(formViewModel).Script + "\n\n"
                              + new ManDeployLovTypeScript(formViewModel).Script + "\n\n";

                script = InputService.GenerateScriptFromExcelFile(formViewModel, script);

                try
                {
                    File.WriteAllText(formViewModel.SqlExportFilePath, script);
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid export filePath");
                }
            }
        }

        public static void AssembleScriptWithoutInstCode(MainWindow window, FormViewModel formViewModel)
        {
            formViewModel = RunStandardProcess(window, formViewModel);

            if (formViewModel != null)
            {
                formViewModel.InstallationCode = ""; // Script should have empty Installation Code
                string script = new ManDeployLovTypeScript(formViewModel).Script + "\n\n";

                script = InputService.GenerateScriptFromExcelFile(formViewModel, script);

                try
                {
                    File.WriteAllText(formViewModel.SqlExportFilePath, script);
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid export filePath");
                }
            }
        }
    }
}
