using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ev_T3_DIARS.Models
{
    public class Detalle_Rutina
    {
        public int Id { get; set; }
        public int Id_Rutina_Us { get; set; }
        public int Id_Ejercicios { get; set; }
        public int Tiempo { get; set; }
        public Ejercicios Ejercicio { get; set; }
    }
}
