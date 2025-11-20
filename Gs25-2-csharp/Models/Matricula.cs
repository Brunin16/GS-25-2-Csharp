using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Matricula
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Required]
        public Guid TrilhaId { get; set; }
        public Trilha Trilha { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }

        public DateTime DataInscricao { get; set; } = DateTime.UtcNow;
    }
}
