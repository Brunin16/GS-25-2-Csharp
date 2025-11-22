using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class Matricula
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UsuarioId { get; set; }
        [JsonIgnore]
        public Usuario? Usuario { get; set; }

        public Guid TrilhaId { get; set; }
        [JsonIgnore]
        public Trilha? Trilha { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }

        public DateTime DataInscricao { get; set; } = DateTime.UtcNow;
    }
}
