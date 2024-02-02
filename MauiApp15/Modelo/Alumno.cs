using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp15.Modelo
{
    public class Alumno
    {
        private String nombre { get; set; }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private String apellido { get; set; }
        public String Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        private String dni { get; set; }
        public String Dni
        {
            get { return dni; }
            set { dni = value; }
        }
        private int edad { get; set; }
        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public Alumno(string nombre, string apellido, string dni, int edad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.dni = dni;
        }
    }
}
