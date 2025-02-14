using Contacts.Maui.Models;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

[QueryProperty("ContactId", "Id")]
public partial class EditContactPage : ContentPage
{
	private Contact contact;
	public EditContactPage()
	{
		InitializeComponent();

	}

	private void btnCancel_Clicked(object sender, EventArgs e)
	{
		//Shell.Current.GoToAsync("..");
		Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
	}

	public string ContactId { 
		set
		{
			contact = ContactRepository.GetContactById(int.Parse(value));
			lblName.Text = contact.Name;
		}
	}
}