using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class Trilha
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(120)]
        public string Nome { get; set; }

        [MaxLength(255)]
        public string Descricao { get; set; }

        [MaxLength(50)]
        public string Nivel { get; set; }

        public int CargaHoraria { get; set; }

        [MaxLength(100)]
        public string FocoPrincipal { get; set; }
        [JsonIgnore]
        public ICollection<TrilhaCompetencia>? TrilhaCompetencias { get; set; }
        [JsonIgnore]
        public ICollection<Matricula>? Matriculas { get; set; }
    }
}
