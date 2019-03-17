

namespace TesisBlaMig
{
    using System;
    using TesisBlaMig.Models;
    using System.Net.Http;
    using TesisBlaMig.View;
    using Xamarin.Forms;
    using Newtonsoft.Json;
    

    public partial class MainPage : ContentPage
    { 

        public MainPage()
        {


            InitializeComponent();

            enterButton.Clicked += EnterButton_Clicked;


            var tapOlvideContraseña = new TapGestureRecognizer();
            tapOlvideContraseña.Tapped += async (s, e) => {

                await Navigation.PushAsync(new RecuperarCuentaPage());

            };
            enterButton2.GestureRecognizers.Add(tapOlvideContraseña);
                 

            var tapNuevoUsuario = new TapGestureRecognizer();
                tapNuevoUsuario.Tapped+= async(s, e) => { 
               
                await Navigation.PushAsync(new NewUserPage());

            };
              enterNuevoUsuario.GestureRecognizers.Add(tapNuevoUsuario);
        }
          private async void EnterButton_Clicked(object sender, EventArgs e)
        {
            //validndo el usurio
            if (string.IsNullOrEmpty(UserEntry.Text))
            {
                await DisplayAlert("Error", "Debes de ingresar un usuario", "Aceptar");
                UserEntry.Focus();
                return;
            }
            //validando la clave
            if (string.IsNullOrEmpty(passwordEntry.Text))
            {
                await DisplayAlert("Error", "Debes de ingresar una clave", "Aceptar");
                passwordEntry.Focus();
                return;
            }
           
           waitActivityIndicator.IsRunning = true;//
          string result;
           try {
               enterButton.IsEnabled = false;
               HttpClient client = new HttpClient();//creando un cliente 
               client.BaseAddress = new Uri("");
                string url = string.Format("/Z-Marke/api/DeviceUserAPI/{0}/{1}", UserEntry.Text, passwordEntry.Text);
               var response = await client.GetAsync(url);//trer los datos
               result = response.Content.ReadAsStringAsync().Result;//el contenido cde la respuesta que devuelve un estring
               enterButton.IsEnabled = true;
            }catch (Exception ex)
           {
             await DisplayAlert("Error", "No hay conexion intente luego", "Aceptar");
             enterButton.IsEnabled = true; 
             waitActivityIndicator.IsRunning =false;
            return;
 
           }

        waitActivityIndicator.IsRunning = false;
          
           // preguntndo si el usuario no valido
           if (string.IsNullOrEmpty(result)||result=="null")
           {
               await DisplayAlert("Error", "Usuario o contraseña no valido", "Aceptar");
               passwordEntry.Text=string.Empty;//limpindo el password
               passwordEntry.Focus();
               return;
           }
          var deviceUser = JsonConvert.DeserializeObject<DeviceUser>(result);
            await Navigation.PushAsync(new ProdutsPage(deviceUser));

/**  **/ 
        }
    }
}
