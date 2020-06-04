using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Lists.Views
{
    public partial class GoalsEntryPage : ContentPage
    {
        public GoalsEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Lists.Models.Item)BindingContext;
            note.Date = DateTime.UtcNow;
            await App.GoalsDatabase.SaveNoteAsync(note);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Lists.Models.Item)BindingContext;
            await App.GoalsDatabase.DeleteNoteAsync(note);
            await Navigation.PopAsync();
        }
    }
}
