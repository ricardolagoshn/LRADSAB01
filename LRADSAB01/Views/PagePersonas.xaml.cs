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
    public partial class PagePersonas : ContentPage
    {
        public PagePersonas()
        {
            InitializeComponent();
        }

        private async void btnproceso_Clicked(object sender, EventArgs e)
        {
            var person = new Models.Personas
            {
                Nombres = Nombres.Text,
                Apellidos = Apellidos.Text,
                FechaNac = FechaNac.Date,
                telefono = Telefono.Text,
                foto = null
            };

            if (await App.Database.AddPersona(person) > 0)
            {
                await DisplayAlert("Aviso", "Persona ingresada con exito", "OK");
            }
            else 
            {
                await DisplayAlert("Aviso", "No se pudo ingresar", "OK");
            }

        }

        private void btnfoto_Clicked(object sender, EventArgs e)
        {

        }
    }
}