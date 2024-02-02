using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp15.Repositorios
{
    public class AlumnoRepositorio
    {
        private string _ruta;

        private SQLiteConnection conexion;

        public AlumnoRepositorio(string ruta) { 
            _ruta= ruta;
            conexion = new SQLiteConnection(ruta);
            System.Diagnostics.Debug.WriteLine($"La ruta de la base de datos es: {_ruta}" );
        }

    }
}
