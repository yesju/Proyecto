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
    public partial class SelectTarea : ContentPage
    {
        SQLiteConnection database;
        public SelectTarea(object selectedItem)
        {
            var dato = selectedItem as Tareas;
            BindingContext = dato;
            InitializeComponent();
            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("Final.db");
            database = new SQLiteConnection(db);

            string[] uno = { "Urge", "Normal" };
            Picker_prioridad.ItemsSource = uno;
            Picker_prioridad.SelectedItem = dato.Prioridad;

            string[] dos = { "Tarea 1", "Tarea 2", "Tarea 3", "Tarea 4" };
            Picker_dependencia.ItemsSource = dos;
            Picker_dependencia.SelectedItem = dato.Dependencia;

            string[] tres = { "Creada", "En Ejecucion", "Completada", "No Completada" };
            Picker_Status.ItemsSource = tres;
            Picker_Status.SelectedItem = dato.Status;
        }

        private void Button_Actualizar_Clicked(object sender, EventArgs e)
        {
              var datos = new Tareas
            {
                Id_tareas = Entry_idtareas.Text,
                Nombre = Entry_nombretareas.Text,
                Descripcion = Entry_descripcion.Text,
                Persona = Entry_persona.Text,
                Prioridad = Convert.ToString(Picker_prioridad.SelectedItem),
                Fecha_entrega = Picker_fechaentrega.Date,
                  Dependencia = Convert.ToString(Picker_dependencia.SelectedItem),
                  Status = Convert.ToString(Picker_Status.SelectedItem)


              };
            database.Update(datos);
            Navigation.PushAsync(new DataTarea());
        }

        private void Button_Eliminar_Clicked(object sender, EventArgs e)
        {
            var datos = new Tareas
            {
                Id_tareas = Entry_idtareas.Text
               

            };
            database.Delete(datos);
            Navigation.PushAsync(new DataTarea());

        }
    }
}