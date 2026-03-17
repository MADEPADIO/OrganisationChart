using Caliburn.Micro;
using MVVMCaliBurnMicro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMCaliBurnMicro.ViewModels
{
    internal class ShellViewModel   :   Conductor<object>
    {
		private string FirstName = "MADE";
		private string LastName = "PADIO";

        public ShellViewModel()
        {
            People.Add(new Person { firstName = "MADE", lastName = "PADIO" });
            People.Add(new Person { firstName = "Emmanuel", lastName = "Womoemi" });
			People.Add(new Person { firstName = "Nonso", lastName = "Okafor"});
            People.Add(new Person { firstName = "Nnaemeka", lastName = "Okwara" });
        }
        public string firstName
		{
			get { return FirstName; }
			set 
			{
				FirstName = value; 
				NotifyOfPropertyChange(() => FirstName); // Notifies property change in any occurence of FirstName where its value is changed
				NotifyOfPropertyChange(()=> fullName);
			}
		}

		public string lastName
		{
			get { return LastName; }
			set 
			{ 
				LastName = value;
				NotifyOfPropertyChange(() => LastName);
				NotifyOfPropertyChange(()=> fullName);
			}
		}

		public string fullName
		{
			get { return $"{firstName}{lastName}"; }
		}

		private BindableCollection<Person> People = new BindableCollection<Person>();

		public BindableCollection<Person> people
		{
			get { return People; }
			set { People = value; }
		}

		private Person SelectedPerson;

		public Person selectedPerson
		{
			get { return SelectedPerson; }
			set
			{ 
				SelectedPerson = value; 
				NotifyOfPropertyChange(() => SelectedPerson);
			
			}
		}

		// used to clear texts; and if else can be used or a return key can be used.
		public bool CanClearText(string firstname, string lastname) => !String.IsNullOrWhiteSpace(firstname) || !String.IsNullOrWhiteSpace(lastname);
		//{
		//return !String.IsNullOrWhiteSpace(firstname) && !String.IsNullOrWhiteSpace(lastname);
		//}
		public void ClearText(string firstname, string lastname)
		{
			firstName = "";
			lastName = "";
		}

		public void LoadPageOne()
		{
			ActivateItemAsync(new FirstChildViewModel());
		}

		public void LoadPageTwo()
		{
			ActivateItemAsync(new SecondChildViewModel());
		}
	}
}
