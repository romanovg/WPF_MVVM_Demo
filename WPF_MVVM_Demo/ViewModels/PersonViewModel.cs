using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_Demo.Models;

namespace WPF_MVVM_Demo.ViewModels
{
    public class PersonViewModel
    {
        private Person _person;

        public string FullName
        {
            get { return string.Concat(_person.LastName, ", ", _person.FirstName); }
        }

        public PersonViewModel()
        {
            _person = new Person("John", "Doe");
        }
    }
}
