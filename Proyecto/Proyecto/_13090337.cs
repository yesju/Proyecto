using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Proyecto
{
    
    public   class _13090337
    {
        string id;
        string usuario;
        string contraseña;
        string rol;
       

        [PrimaryKey, Unique, MaxLength(8)]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [ MaxLength(20)]
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        [ MaxLength(30)]
        public string Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }

        [ MaxLength(40)]
        public string Rol
        {
            get { return rol; }
            set { rol = value; }
        }
  
    }
}
