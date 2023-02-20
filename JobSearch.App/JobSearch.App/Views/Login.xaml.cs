using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JobSearch.Domain.Models;
using AppJobSearch.API.Services;
using Newtonsoft.Json;
using JobSearch.App.Models;
using Rg.Plugins.Popup.Extensions;
using JobSearch.App.Utility.Load;

//C:\Dev\AppJobSearch\WebApplication1\AppJobSearch.API.csproj

namespace JobSearch.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private UserService _service;
        public Login()
        {
            InitializeComponent();

            _service = new UserService();
        }

        private void GoRegister(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }

        private async void GoStart(object sender, EventArgs e)
        {
            string email = Email.Text;
            string password = Password.Text;

            await Navigation.PushPopupAsync(new Loading());
            ResponseService<User> responseService = await _service.GetUser(email, password);
            if (responseService.IsSuccess)
            {
                App.Current.Properties.Add("User", JsonConvert.SerializeObject(responseService.Data));
                await App.Current.SavePropertiesAsync();
                App.Current.MainPage = new NavigationPage(new Start());
            }
            else
            {
                if (responseService.StatusCode == 404)
                {
                    await DisplayAlert("Erro", "Nenhum usuário encontrado!", "OK");
                }
                else
                {
                    await DisplayAlert("Erro", "Oops! Ocorreu um erro inesperado, tente novamente mais tarde.", "OK");
                }
                

            }
            await Navigation.PopAllPopupAsync();


        }

    }
}