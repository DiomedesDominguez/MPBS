using Listado.Model;
using System;
using Xamarin.Forms;

namespace Listado
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetAllAsync<Tarea>();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TareaPage
            {
                BindingContext = new Tarea()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TareaPage
                {
                    BindingContext = e.SelectedItem as Tarea
                });
            }
        }
    }
}
