using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobSearch.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterJob : ContentPage
    {
        public RegisterJob()
        {
            InitializeComponent();
        }

        private void Goback(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void Save(object sender, EventArgs e)
        {
            DisplayAlert("Salvo", "Vaga Salva", "OK");
            Navigation.PopAsync();
        }
    }
}