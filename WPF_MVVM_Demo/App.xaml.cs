using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_MVVM_Demo.Models;
using WPF_MVVM_Demo.ViewModels;

namespace WPF_MVVM_Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private List<Person> _people = new List<Person>() { new Person("John", "Doe") };

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            window.Content = new PersonListViewModel(_people);
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            foreach (Person person in _people)
            {
                Debug.WriteLine($"{person.LastName}, {person.FirstName}");
            }
        }
    }
}
