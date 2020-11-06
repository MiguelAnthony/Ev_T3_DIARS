using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ev_T3_DIARS.Models;
using Ev_T3_DIARS.Patrones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Ev_T3_DIARS.Controllers
{
    [Authorize]
    public class EjercicioController : BaseController
    {
        private readonly T3Context context;
        private readonly IHostEnvironment hostEnv;
        private Int_Rutina tipoRutina;
       
        public EjercicioController(T3Context context, IHostEnvironment hostEnv) : base(context)
        {
            this.context = context;
            this.hostEnv = hostEnv;
        }

        [HttpGet]
        public ActionResult Index(int idRutina)
        {
            ViewBag.Ejercicios = context.Ejercicios.ToList();

            var rutina = context.DetalleRutinas.
                Where(o => o.Id_Rutina_Us == idRutina).
                Include(o => o.Ejercicio).
                ToList();

            return View(rutina);
        }

        [HttpGet]
        public ActionResult Rutina()
        {
            var rutinaUsuario = context.RutinaUsuarios.
                Where(o => o.IdUsuario == LoggedUser().Id).
                ToList();
            return View(rutinaUsuario);
        }

        [HttpGet]
        public ActionResult Registro_Rutina()
        {
            ViewBag.Tipo = new List<string> { "Principiante", "Intermedio", "Avanzado" };
            return View(new Rutina_Usuario());
        }
        [HttpPost]
        public ActionResult Registro_Rutina(Rutina_Usuario rutina)
        {
            rutina.IdUsuario = LoggedUser().Id;
            if (ModelState.IsValid)
            {
                context.RutinaUsuarios.Add(rutina);
                context.SaveChanges();

                int idRutina = rutina.Id;
                var ejercicios = context.Ejercicios.ToList();
                int ejercicio = ejercicios.Count();

                Console.WriteLine("numero elementos: "+ ejercicio);
                switch (rutina.Tipo)
                {
                    case "Principiante":
                        tipoRutina = new Principiante();
                        break;
                    case "Intermedio":
                        tipoRutina = new Intermedio();
                        break;
                    case "Avanzado":
                        tipoRutina = new Avanzado();
                        break;
                }

                var aplicar = tipoRutina.Rutina(idRutina, ejercicio);

                context.DetalleRutinas.AddRange(aplicar);
                context.SaveChanges();

                return RedirectToAction("Rutina");
            }
            else
            {
                ViewBag.Tipo = new List<string> { "Intermedio", "Principiante", "Avanzado" };
                return View(new Rutina_Usuario());
            }
        }
    }
}
