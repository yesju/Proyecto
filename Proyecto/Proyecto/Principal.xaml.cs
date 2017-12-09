using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace Proyecto
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal : ContentPage
    {
        public Principal()
        {
            InitializeComponent();
        }
        private void Boton_Insertar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InsertUsuario());
        }

        private void Boton_Tareas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InsertTarea());

        }

        private void Boton_AsigTareas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DataTarea());

            DisplayAlert("Tareas Incompleta", "", "OK");


        }

        private void Boton_Usuarios_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DataPage());
        }
    }
}