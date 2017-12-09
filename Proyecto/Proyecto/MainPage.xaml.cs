using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;

namespace Proyecto
{
    public partial class MainPage : ContentPage
    {
        SQLiteConnection database;

        public MainPage()
        {
            InitializeComponent();
            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("Final.db");
            database = new SQLiteConnection(db);
            database.CreateTable<_13090337>();
        }

        private void login_Clicked(object sender, EventArgs e)
        { 
            
            var login = database.Query<_13090337>("select* from _13090337 where Usuario =?", Usuario.Text);
           
            if (login.Count == 0)
            {
            }
            else 
            {
                DisplayAlert("Conexion Exitoso", "Bienvenido" + Usuario.Text, "Aceptar");
                Navigation.PushAsync(new Principal());

            }
            if (login.Count == 0)
            {
                DisplayAlert("Usuario y/o Contraseña incorrecta", "", "OK");
            }



        }
        
    }
}
