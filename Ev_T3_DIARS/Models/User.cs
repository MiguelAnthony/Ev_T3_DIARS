using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ev_T3_DIARS.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Contrasenia { get; set; }
    }
}
