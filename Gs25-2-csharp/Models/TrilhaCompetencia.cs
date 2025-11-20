using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TrilhaCompetencia
    {
        public Guid TrilhaId { get; set; }
        public Trilha Trilha { get; set; }

        public Guid CompetenciaId { get; set; }
        public Competencia Competencia { get; set; }
    }
}
