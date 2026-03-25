Help and Support Guide
This document provides instructions on how to use the Lixys Browser Template and how to resolve common technical issues.

Getting Started
Download the repository as a ZIP file or clone it using Git.

Open the solution file (.sln) in Visual Studio 2022.

Ensure that the Microsoft Edge WebView2 Runtime is installed on your operating system.

If you see errors related to missing libraries, go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution and install the Microsoft.Web.WebView2 package.

Customizing the Start Page
The browser is configured to load a local file named index.html upon startup.
To change the interface of the start page:

Locate the index.html file in the project directory.

Edit the HTML, CSS, or JavaScript code within that file.

Save the changes and restart the application.

Common Issues and Solutions
XAML Parse Exception
This usually happens if the application cannot find the icon file.
Ensure that the icon file (e.g., Снимок.ico) is included in the project and its Build Action is set to Resource in the Properties window.

WebView2 Not Loading
If the browser area remains blank:

Check your internet connection.

Verify that the WebView2 Runtime is installed on your PC.

Ensure the project has been "Cleaned" and "Rebuilt" via the Build menu.

Window Dragging Not Working
If you cannot move the window by clicking the title bar, ensure that the System.Windows.Input namespace is correctly referenced in the MainWindow.xaml.cs file.

How to Contribute
If you want to improve this template:

Fork the repository.

Create a new branch for your feature.

Submit a Pull Request with a detailed description of your changes.

License and Copyright
This project is for educational and personal use. Users are responsible for ensuring that their final builds do not violate any third-party copyrights.
