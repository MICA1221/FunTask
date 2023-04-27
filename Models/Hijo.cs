using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FunTask.Models
{
        public class Hijo
        {
            [Key]
            public int HijoId { get; set; }

            public int UsuarioId { get; set; }

            public Usuario Usuario { get; set; }

            public string ImagenPerfil { get; set; }

            public ICollection<Actividad> Actividades { get; set; }
        }
}

