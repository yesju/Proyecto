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
    public partial class SelectUsuario : ContentPage
    {
        SQLiteConnection database;
        public SelectUsuario(object selectedItem)
        {
            var dato = selectedItem as _13090337;
            BindingContext = dato;
            InitializeComponent();
            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("Final.db");
            database = new SQLiteConnection(db);

            string[] uno = { "Administrador", "Usuario" };
            Picker_rol.ItemsSource = uno;
            Picker_rol.SelectedItem = dato.Rol;
        }

        private void Button_Actualizar_Clicked(object sender, EventArgs e)
        {
            var datos = new _13090337
            {

                Id = Entry_id.Text,
                Usuario = Entry_Usuario.Text,
                Contraseña= Entry_Contraseña.Text,
                Rol = Convert.ToString(Picker_rol.SelectedItem)


            };
            database.Update(datos);
            Navigation.PushAsync(new DataPage());

        }

        private void Button_Eliminar_Clicked(object sender, EventArgs e)
        {
            var datos = new _13090337
            {

                Id = Entry_id.Text
                


            };
            database.Delete(datos);
            Navigation.PushAsync(new DataPage());

        }
    }
}