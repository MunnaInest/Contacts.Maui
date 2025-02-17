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
			var contact = _contacts.FirstOrDefault(c => c.ContactId == contactId);
			if (contact != null)
			{
				return new Contact
				{
					ContactId = contact.ContactId,
					Name = contact.Name,
					Email = contact.Email,
					Phone = contact.Phone,
					Address = contact.Address,
				};
			}
			return null;
		}

		public static void UpdateContact(int contactId, Contact contact)
		{
			if (contactId != contactId) return;

			var contactToUpdate = _contacts.FirstOrDefault(c => c.ContactId == contactId);
			if (contactToUpdate != null)
			{
				//AutoMapper
				contactToUpdate.Address = contact.Address;
				contactToUpdate.Email = contact.Email;
				contactToUpdate.Name = contact.Name;
				contactToUpdate.Phone = contact.Phone;
			}
		}

		public static void AddContact(Contact contact)
		{
			contact.ContactId = _contacts.Max(c => c.ContactId) + 1;
			_contacts.Add(contact);
		}

		public static void DeleteContact(int contactId)
		{
			var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);
			if (contact != null)
			{
				_contacts.Remove(contact);
			}
		}

		public static List<Contact> SearchContacts(string filter)
		{
			var contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.StartsWith(filter, StringComparison.OrdinalIgnoreCase))?.ToList();

			if (contacts == null || contacts.Count <= 0)
			{
				contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.StartsWith(filter, StringComparison.OrdinalIgnoreCase))?.ToList();
			}
			else
			{
				return contacts;
			}

			if (contacts == null || contacts.Count <= 0)
			{
				contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone.StartsWith(filter, StringComparison.OrdinalIgnoreCase))?.ToList();
			}
			else
			{
				return contacts;
			}

			if (contacts == null || contacts.Count <= 0)
			{
				contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Address) && x.Address.StartsWith(filter, StringComparison.OrdinalIgnoreCase))?.ToList();
			}
			else
			{
				return contacts;
			}

			return contacts.ToList();
		}
	}
}
