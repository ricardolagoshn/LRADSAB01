using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LRADSAB01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCreateAlumn : ContentPage
    {
        // Variable que guardara la foto 
        Plugin.Media.Abstractions.MediaFile photo = null;


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

        public String GetImageToBase64()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] bytes = memory.ToArray();

                    String StrBase64 = Convert.ToBase64String(bytes);

                    return StrBase64;
                }
            }

            return null;
        }

        public PageCreateAlumn()
        {
            InitializeComponent();
        }

        private async void btnfoto_Clicked(object sender, EventArgs e)
        {
            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "APP",
                Name = "foto.jpg",
                SaveToAlbum = true
            });

            if (photo != null)
            {
                foto.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }
        }

        private async void btnproceso_Clicked(object sender, EventArgs e)
        {
            var alumn = new Models.Alumnos
            {
                nombres = Nombres.Text,
                apellidos = Apellidos.Text,
                direccion = Direccion.Text,
                edad        = Edad.Text,
                telefono = Convert.ToInt32(Telefono.Text),
                foto = GetImageToBase64()
            };

            if (await Controllers.AlumnosController.CreateAlumn(alumn) != null)
            {
                await DisplayAlert("Aviso", "Alumno ingresado con exito", "OK");
            }
            else
            {
                await DisplayAlert("Aviso", "No se pudo ingresar", "OK");
            }
        }
    }
}