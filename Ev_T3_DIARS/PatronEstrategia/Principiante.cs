using Ev_T3_DIARS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ev_T3_DIARS.Patrones
{
    public class Principiante : Int_Rutina
    {
        public List<Detalle_Rutina> Rutina(int idRutina, int ejercicios)
        {
            Random random = new Random();
            List<Detalle_Rutina> detalles = new List<Detalle_Rutina>();
            for (int i = 0; i < 5; i++)
            {
                var detalle = new Detalle_Rutina();
                var ejercicio = random.Next(1, ejercicios);

                detalle.Id_Ejercicios = ejercicio;
                detalle.Id_Rutina_Us = idRutina;
                detalle.Tiempo = random.Next(60, 120);

                detalles.Add(detalle);

            }
            return detalles;
        }
    }
}
