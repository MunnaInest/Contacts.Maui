using Contacts.Maui.Models;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();

		List<Contact> contacts =ContactRepository.GetContacts();
		listContacts.ItemsSource = contacts.ToList();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		SearchBar.Text = string.Empty;
		LoadContacts();
	}

	private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		if (listContacts.SelectedItem != null)
		{
			await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).ContactId}");
		}
	}

	private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		listContacts.SelectedItem = null;
	}

	private void btnAdd_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync(nameof(AddContactPage));
	}

	private void MenuItem_Clicked(object sender, EventArgs e)
	{
		var menuItem = sender as MenuItem;
		var contact = menuItem.CommandParameter as Contact;
		ContactRepository.DeleteContact(contact.ContactId);
		LoadContacts();
	}

	private void LoadContacts()
	{
		var contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());
		listContacts.ItemsSource = contacts.ToList();
	}

	private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
	{
		var contacts = new ObservableCollection<Contact>(ContactRepository.SearchContacts(((SearchBar)sender).Text));
		listContacts.ItemsSource = contacts;
	}

}