using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp15
{
    public class obtenerRutaBD
    {
        public static String devolverRuta(String nombreBaseDatos)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, nombreBaseDatos);
        }
    }
}
