using Listado.Model;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Listado
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TareaPage : ContentPage
    {
        public TareaPage()
        {
            InitializeComponent();
        }
        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (Tarea)BindingContext;
            await App.Database.SaveAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (Tarea)BindingContext;
            await App.Database.DeleteAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}