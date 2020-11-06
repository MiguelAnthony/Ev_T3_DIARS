using Ev_T3_DIARS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ev_T3_DIARS.Patrones
{
    public interface Int_Rutina
    {
        public List<Detalle_Rutina> Rutina(int idRutina, int ejercicios);
    }
}
