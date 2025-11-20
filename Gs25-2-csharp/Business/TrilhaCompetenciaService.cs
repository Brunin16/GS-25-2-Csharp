using Business;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Service
{
    public class TrilhaCompetenciaService : ITrilhaCompetenciaService
    {
        private readonly ApplicationDbContext _context;

        public TrilhaCompetenciaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TrilhaCompetencia> AddCompetenciaAsync(Guid trilhaId, Guid competenciaId)
        {
            var exists = await _context.TrilhaCompetencias
                .AnyAsync(tc => tc.TrilhaId == trilhaId && tc.CompetenciaId == competenciaId);

            if (exists) return null;

            var entity = new TrilhaCompetencia
            {
                TrilhaId = trilhaId,
                CompetenciaId = competenciaId
            };

            _context.TrilhaCompetencias.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Competencia>> GetCompetenciasByTrilhaAsync(Guid trilhaId)
        {
            return await _context.TrilhaCompetencias
                .Where(tc => tc.TrilhaId == trilhaId)
                .Select(tc => tc.Competencia)
                .ToListAsync();
        }

        public async Task<bool> RemoveCompetenciaAsync(Guid trilhaId, Guid competenciaId)
        {
            var entity = await _context.TrilhaCompetencias
                .FirstOrDefaultAsync(tc => tc.TrilhaId == trilhaId && tc.CompetenciaId == competenciaId);

            if (entity == null) return false;

            _context.TrilhaCompetencias.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
