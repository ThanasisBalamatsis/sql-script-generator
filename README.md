# sql-script-generator

##A tailored WPF tool for Qualco that reads an Excel file (Open XML SDK) provided by the user and generates a SQL script based on the given values.
The solution consists of two class libraries, Models and Scripts, and the WPF project.
In the WPF project the UI is constructed as well as the services that provide methods for event handling, user input processing and script generation.
The Models project encompasses the FormViewModel class where the user input values are mapped to the corresponding properties. An instance of FormViewModel is given to all Script classes' constructors when the script generation is invoked.
