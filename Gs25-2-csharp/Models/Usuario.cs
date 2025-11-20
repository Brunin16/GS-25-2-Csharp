using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(100)]
        public string AreaAtuacao { get; set; }

        [MaxLength(50)]
        public string NivelCarreira { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        public ICollection<Matricula> Matriculas { get; set; }
    }
}
