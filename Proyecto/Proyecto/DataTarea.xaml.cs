using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.Collections.ObjectModel;

namespace Proyecto
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataTarea : ContentPage
    {
        public ObservableCollection<Tareas> Items { get; set; }
        SQLiteConnection database;
        public DataTarea()
        {
            InitializeComponent();
            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("Final.db");
            database = new SQLiteConnection(db);
            database.CreateTable<Tareas>();
            Items = new ObservableCollection<Tareas>(database.Table<Tareas>());
            BindingContext = this;
        }

        private void Boton_Insertar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InsertTarea());
        }
        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            await Navigation.PushAsync(new SelectTarea(e.SelectedItem as Tareas));
        }
    }
}