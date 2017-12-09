using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

 
namespace Proyecto
{
public class Tareas
    {
        string id_tareas;
        string nombre;
        string descripcion;
        string persona;
        string prioridad;
        DateTime fecha_entrega;
        string dependencia;
        string status;
        
        [PrimaryKey, Unique, MaxLength(8)]
        public string Id_tareas
        {
            get { return id_tareas; }
            set { id_tareas = value; }
        }

        [MaxLength(20)]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        [MaxLength(20)]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        [MaxLength(20)]
        public string Persona
        {
            get { return persona; }
            set { persona = value; }
        }

        [MaxLength(20)]
        public string Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }
        [MaxLength(20)]
        public DateTime Fecha_entrega
        {
            get { return fecha_entrega; }
            set { fecha_entrega = value; }
        }

        [MaxLength(20)]
        public string Dependencia
        {
            get { return dependencia; }
            set { dependencia = value; }
        }

        [MaxLength(20)]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

    }
}
