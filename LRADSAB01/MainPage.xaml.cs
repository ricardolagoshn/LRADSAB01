using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LRADSAB01
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnproceso_Clicked(object sender, EventArgs e)
        {
            /*
            var resultado = Convert.ToDouble(numero1.Text) + Convert.ToDouble(numero2.Text);

            //await DisplayAlert("Aviso", "El resultado es " + resultado.ToString(), "OK");

            if (resultado > 0)
            {
                Views.PageResultado page = new Views.PageResultado(Convert.ToString(resultado));
                await Navigation.PushAsync(page);
            }
            else
                await DisplayAlert("Aviso", "No coloco datos", "OK");

            */

            var persona = new Models.Personas 
            {
                Id= 1,
                Nombres="Ricardo",
                Apellidos="Lagos",
                FechaNac= DateTime.Now,
                telefono = "99887766"
            };

            Views.PageResultado page = new Views.PageResultado();
            page.BindingContext = persona;
            await Navigation.PushAsync(page);


        }
    }
}
