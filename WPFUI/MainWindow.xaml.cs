using Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPFUI.Services;

namespace WPFUI
{
    public sealed partial class MainWindow : Window
    {
        private FormViewModel _formViewModel; //ViewModel containing all the required properties to create the sql scripts
        public MainWindow()
        {
            InitializeComponent();
            _formViewModel = new FormViewModel();
        }

        private void submitButtonWithInstCode_Click(object sender, RoutedEventArgs e)
        {
            ScriptService.GenerateScriptWithInstCode(this, _formViewModel, true);
        }

        private void submitButtonWithoutInstCode_Click(object sender, RoutedEventArgs e)
        {
            ScriptService.GenerateScriptWithoutInstCode(this, _formViewModel, false);
        }
    }
}
