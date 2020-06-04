using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Lists.Views
{
    public partial class ToDoPage : ContentPage
    {
        public ToDoPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.ToDoDatabase.GetNotesAsync();
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ToDoEntryPage
            {
                BindingContext = new Lists.Models.Item()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ToDoEntryPage
                {
                    BindingContext = e.SelectedItem as Lists.Models.Item
                });
            }
        }
    }
}
