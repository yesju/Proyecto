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
    public partial class InsertTarea : ContentPage
    {
        SQLiteConnection database;
        public InsertTarea()
        {
           
            InitializeComponent();
            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("Final.db");
            database = new SQLiteConnection(db);
           

            string[] uno = { "Urge", "Normal" };
            Picker_prioridad.ItemsSource = uno;

            string[] dos = { "Tarea 1", "Tarea 2", "Tarea 3", "Tarea 4" };
            Picker_dependencia.ItemsSource = dos;

            string[] tres = { "Creada", "En Ejecucion", "Completada", "No Completada" };
            Picker_Status.ItemsSource = tres;

            var consulta = database.Query<_13090337>("select Usuario from Usuarios");
            string[] usuario = new string[consulta.Count()];
            int i = 0;
            foreach (var usuarios in consulta)
            {
                usuario[i] = usuarios.Usuario;
                i++;
            }

        }
         
       

        private void Boton_Insertar_Clicked(object sender, EventArgs e)
        {
            var datos = new Tareas
            {
                Id_tareas = Entry_idtareas.Text,
                Nombre = Entry_nombretareas.Text,
                Descripcion = Entry_descripcion.Text,
                Persona = Entry_persona.Text,
                Prioridad = Convert.ToString(Picker_prioridad.SelectedItem),
                Fecha_entrega= Picker_fechaentrega.Date,
                Dependencia = Convert.ToString(Picker_dependencia.SelectedItem),
                Status = Convert.ToString(Picker_Status.SelectedItem)


            };
            database.Insert(datos);
            Navigation.PushAsync(new DataTarea());
        }

        
       

        }
    }
