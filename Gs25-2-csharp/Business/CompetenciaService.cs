using Business;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Service
{
    public class CompetenciaService : ICompetenciaService
    {
        private readonly ApplicationDbContext _context;

        public CompetenciaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Competencia> CreateAsync(Competencia competencia)
        {
            _context.Competencias.Add(competencia);
            await _context.SaveChangesAsync();
            return competencia;
        }

        public async Task<Competencia> GetByIdAsync(Guid id)
        {
            return await _context.Competencias
                .Include(c => c.TrilhaCompetencias)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Competencia>> GetAllAsync()
        {
            return await _context.Competencias.ToListAsync();
        }

        public async Task<Competencia> UpdateAsync(Guid id, Competencia competenciaAtualizada)
        {
            var competencia = await GetByIdAsync(id);
            if (competencia == null) return null;

            competencia.Nome = competenciaAtualizada.Nome;
            competencia.Categoria = competenciaAtualizada.Categoria;
            competencia.Descricao = competenciaAtualizada.Descricao;

            await _context.SaveChangesAsync();
            return competencia;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var competencia = await GetByIdAsync(id);
            if (competencia == null) return false;

            _context.Competencias.Remove(competencia);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
