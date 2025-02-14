using Contacts.Maui.Models;

namespace Contacts.Maui.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

	private void contactCtrl_OnSave(object sender, EventArgs e)
	{
		ContactRepository.AddContact(new Models.Contact
		{
			Address = contactCtrl.Address,
			Email = contactCtrl.Email,
			Name = contactCtrl.Name,
			Phone = contactCtrl.Phone
		});
		Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
	}

	private void contactCtrl_OnCancel(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
	}

	private void contactCtrl_OnError(object sender, string e)
	{
		DisplayAlert("Error", e, "OK");
	}
}