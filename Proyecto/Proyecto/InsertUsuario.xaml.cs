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
    public partial class InsertUsuario : ContentPage
    {
        SQLiteConnection database;
        public InsertUsuario()
        {
           
            InitializeComponent();
            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("Final.db");
            database = new SQLiteConnection(db);

            string[] uno = { "Administrador", "Usuario" };
            Picker_rol.ItemsSource = uno;
           

        }

        private void Boton_Insertar_Clicked(object sender, EventArgs e)
        {
            var datos = new _13090337
            {
                Id = Entry_id.Text,
                Usuario = Entry_Usuario.Text,
                Contraseña= Entry_Contraseña.Text,
                Rol = Convert.ToString(Picker_rol.SelectedItem)



            };
            database.Insert(datos);
          Navigation.PushAsync(new DataPage());


        }

       
    }
}