using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LRADSAB01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePersonas : ContentPage
    {
        
        // Variable que guardara la foto 
        Plugin.Media.Abstractions.MediaFile photo = null;

        public PagePersonas()
        {
            InitializeComponent();
        }


        public byte[] GetImageToBytes() 
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] bytes = memory.ToArray();

                    return bytes;
                }
            }

            return null;
        }


        private async void btnproceso_Clicked(object sender, EventArgs e)
        {
            var person = new Models.Personas
            {
                Nombres = Nombres.Text,
                Apellidos = Apellidos.Text,
                FechaNac = FechaNac.Date,
                telefono = Telefono.Text,
                foto = GetImageToBytes()
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

        private async void btnfoto_Clicked(object sender, EventArgs e)
        {
            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions 
            {
                Directory = "APP",Name = "foto.jpg", SaveToAlbum= true
            });

            if (photo != null)
            {
                foto.Source = ImageSource.FromStream(()=> { return photo.GetStream(); });
            }
        }
    }
}