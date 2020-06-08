using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Lists.Views
{
    public partial class ShoppingPage : ContentPage
    {
        public ShoppingPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.ShoppingDatabase.GetNotesAsync();
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShoppingEntryPage
            {
                BindingContext = new Lists.Models.Item()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ShoppingEntryPage
                {
                    BindingContext = e.SelectedItem as Lists.Models.Item
                });
            }
        }

        //async void OnCheckBoxCheckedChanged(object sender, SelectedItemChangedEventArgs e)
        //{
        //    if (e.SelectedItem != null)
        //    {
        //        //var note = e.SelectedItem as Lists.Models.Item;
        //        //await Navigation.PushAsync(new ShoppingEntryPage
        //        //{
        //        //    BindingContext = new Lists.Models.Item()
        //        //});
        //        await Navigation.PushAsync(new ShoppingEntryPage
        //        {
        //            BindingContext = e.SelectedItem as Lists.Models.Item
        //        });
        //        //await App.ShoppingDatabase.DeleteNoteAsync((Lists.Models.Item)BindingContext);
        //    }
        //}
    }
}