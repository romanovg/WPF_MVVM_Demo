using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPF_MVVM_Demo.Models;
using WPF_MVVM_Demo.ViewModels;

namespace WPF_MVVM_Demo.Test
{
    [TestClass]
    public class PersonViewModelTest
    {
        [TestMethod]
        public void TestFullName()
        {
            string firstName = "TestFistName";
            string lastName = "TestFistName";

            string expectedFullName = string.Concat(lastName, ", ", firstName);

            Person person = new Person(firstName, lastName);
            PersonViewModel personViewModel = new PersonViewModel(person);

            Assert.IsTrue(personViewModel.FullName.Equals(expectedFullName), "FullName mismatch");
        }
    }
}
