using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace WPFUI.Services
{
    internal static class MappingService
    {
        // Finds recursively the Controls of a given type T (e.g. TextBox, RadioButton, Border) in a dependency object (e.g. window)
        internal static IEnumerable<T> FindControlsInWindow<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            if (dependencyObject == null)
                yield return (T)Enumerable.Empty<T>();

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
            {
                DependencyObject ithChild = VisualTreeHelper.GetChild(dependencyObject, i);

                if (ithChild == null)
                    continue;

                if (ithChild is T type)
                    yield return type;

                foreach (T childOfChild in FindControlsInWindow<T>(ithChild))
                    yield return childOfChild;
            }
        }

        // Maps the user input to the corresponding property of a FormViewModel instance
        internal static FormViewModel MapFormValuesToFormViewModelProperties(IEnumerable<TextBox> textBoxes, FormViewModel formViewModel)
        {
            foreach (TextBox textBox in textBoxes)
            {
                foreach (PropertyInfo property in formViewModel.GetType().GetProperties())
                {
                    if (property.Name == textBox.Name)
                    {
                        property.SetValue(formViewModel, textBox.Text);
                    }
                }
            }
            return formViewModel;
        }

        internal static FormViewModel MapFormValuesToFormViewModelProperties(IEnumerable<RadioButton> radioButtons, FormViewModel formViewModel)
        {
            foreach (RadioButton radioButton in radioButtons)
            {
                foreach (PropertyInfo property in formViewModel.GetType().GetProperties())
                {
                    if (property.Name == radioButton.Name)
                    {
                        string checkedValue = InputService.ProcessRadioButton(radioButton);
                        property.SetValue(formViewModel, checkedValue);
                    }
                }
            }
            return formViewModel;
        }
    }
}
