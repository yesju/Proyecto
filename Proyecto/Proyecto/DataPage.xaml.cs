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
    public partial class DataPage : ContentPage
    {
        public ObservableCollection<_13090337> Items { get; set; } 
        SQLiteConnection database;

        public DataPage()
        {
            InitializeComponent();
            string db;
           db = DependencyService.Get<ISQLite>().GetLocalFilePath("Final.db");
           database = new SQLiteConnection(db);
           database.CreateTable<_13090337>();
           Items = new ObservableCollection<_13090337>(database.Table<_13090337>());
           BindingContext = this;
           


        }
       

        private void Boton_Insertar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InsertUsuario());
        }
        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
       {
            if (e.SelectedItem == null) 
                 return; 
             await Navigation.PushAsync(new SelectUsuario(e.SelectedItem as _13090337)); 
        }

       

       
    }
}