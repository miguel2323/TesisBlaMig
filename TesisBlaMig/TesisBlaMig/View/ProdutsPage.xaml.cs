using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using TesisFarmcias.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using System.

namespace TesisFarmcias
{
    

    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class ProdutsPage : ContentPage
    {
       private List<Productos> productos;
       

        public ProdutsPage(DeviceUser deviceUser)
        {
            InitializeComponent();
            titlelabel.Text = String.Format("Bienvenido {0} {1}",
            deviceUser.FirstName, deviceUser.LastName);
           productsLisView.ItemTemplate = new DataTemplate(typeof(ProductsCell));//para personalizar la celdas

            this.LoadProducts();
        }

        private async void LoadProducts()
        {
            waitActivityIndicator.IsRunning = true;//
            string result;
            try
            {
                HttpClient client = new HttpClient();//creando un cliente 
                client.BaseAddress = new Uri("");
              string url = string.Format("/Z-Marke/api/ProductsAPI");
                var response = await client.GetAsync(url);//trer los datos
                result = response.Content.ReadAsStringAsync().Result;//el contenido cde la respuesta que devuelve un estring
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "No hay conexion intente luego", "Aceptar");
                waitActivityIndicator.IsRunning = false;
                return;
            }


            waitActivityIndicator.IsRunning = false;
            productos = JsonConvert.DeserializeObject<List<Productos>>(result);
         productsLisView.ItemsSource = productos;
    


        }
    }
}