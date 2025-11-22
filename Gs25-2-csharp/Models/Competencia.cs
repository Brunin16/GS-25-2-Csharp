using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class Competencia
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(120)]
        public string Nome { get; set; }

        [MaxLength(100)]
        public string Categoria { get; set; }

        [MaxLength(255)]
        public string Descricao { get; set; }
        [JsonIgnore]
        public ICollection<TrilhaCompetencia>? TrilhaCompetencias { get; set; }
    }
}
