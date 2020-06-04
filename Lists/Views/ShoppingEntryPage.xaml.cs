using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Lists.Views
{
    public partial class ShoppingEntryPage : ContentPage
    {
        public ShoppingEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Lists.Models.Item)BindingContext;
            note.Date = DateTime.UtcNow;
            await App.ShoppingDatabase.SaveNoteAsync(note);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Lists.Models.Item)BindingContext;
            await App.ShoppingDatabase.DeleteNoteAsync(note);
            await Navigation.PopAsync();
        }
    }
}
