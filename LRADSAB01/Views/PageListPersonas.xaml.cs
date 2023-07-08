using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LRADSAB01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListPersonas : ContentPage
    {
        public PageListPersonas()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try 
            {
                listapersonas.ItemsSource = await App.Database.GetAllPersonas();
            }
            catch(Exception ex) 
            {
                ex.ToString();
            }

        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var page = new Views.PagePersonas();
            Navigation.PushAsync(page);
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            var page = new Views.PageMap();
            Navigation.PushAsync(page);
        }
    }
}