using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FunTask.Models
{   
        public class Usuario
        {
            [Key]
            public int UsuarioId { get; set; }

            [Required]
            public string NombreUsuario { get; set; }

            public ICollection<Hijo> Hijos { get; set; }
        }
    
}
