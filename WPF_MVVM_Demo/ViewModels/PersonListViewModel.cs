using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_MVVM_Demo.Models;

namespace WPF_MVVM_Demo.ViewModels
{
    public class PersonListViewModel : BindableBase
    {
        private List<Person> _people;

        private string _newPersonFirstName = string.Empty;
        public string NewPersonFirstName
        {
            get { return _newPersonFirstName; }
            set { _newPersonFirstName = value; RaisePropertyChanged(nameof(NewPersonFirstName)); RaisePropertyChanged(nameof(CanAddPerson)); }
        }

        private string _newPersonLastName = string.Empty;
        public string NewPersonLastName
        {
            get { return _newPersonLastName; }
            set { _newPersonLastName = value; RaisePropertyChanged(nameof(NewPersonLastName)); RaisePropertyChanged(nameof(CanAddPerson)); }
        }

        public bool CanAddPerson
        {
            get { return NewPersonFirstName.Length > 0 & NewPersonLastName.Length > 0; }
        }

        public ICommand AddNewPersonCommand { get; }

        public ReadOnlyCollection<PersonViewModel> People
        {
            get
            {
                List<PersonViewModel> temp = new List<PersonViewModel>();
                foreach (Person person in _people)
                {
                    temp.Add(new PersonViewModel(person));
                }
                return new ReadOnlyCollection<PersonViewModel>(temp);
            }
        }

        public PersonListViewModel(List<Person> people)
        {
            _people = people;
            AddNewPersonCommand = new DelegateCommand(AddPerson).ObservesCanExecute(() => CanAddPerson);
        }

        private void AddPerson()
        {
            _people.Add(new Person(NewPersonFirstName, NewPersonLastName));
            RaisePropertyChanged(nameof(People));
            NewPersonFirstName = string.Empty;
            NewPersonLastName = string.Empty;
        }
    }
}
