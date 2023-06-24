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
    public partial class PageResultado : ContentPage
    {
        public PageResultado()
        {
            InitializeComponent();
        }

        public PageResultado(String resultado)
        {
            InitializeComponent();

        }
    }
}