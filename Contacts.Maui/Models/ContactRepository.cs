using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Maui.Models
{
    public class ContactRepository
    {
		public static List<Contact> _contacts = new List<Contact>
		{
			new Contact {ContactId=1, Name = "John Doe", Email = "john@gmail.com" },
			new Contact {ContactId=2,  Name = "Jane Doe", Email = "janedow@gmail.com" },
			new Contact {ContactId=3,  Name = "John Smith", Email = "johnsmimt@gmail.com" },
		};

		public static List<Contact> GetContacts() => _contacts;
		
		public static Contact GetContactById(int contactId)
		{
			return _contacts.FirstOrDefault(c => c.ContactId == contactId);
		}
	}
}
