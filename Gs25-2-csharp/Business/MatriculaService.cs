using Business;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Service
{
    public class MatriculaService : IMatriculaService
    {
        private readonly ApplicationDbContext _context;

        public MatriculaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Matricula> CreateAsync(Matricula matricula)
        {
            _context.Matriculas.Add(matricula);
            await _context.SaveChangesAsync();
            return matricula;
        }

        public async Task<Matricula> GetByIdAsync(Guid id)
        {
            return await _context.Matriculas
                .Include(m => m.Usuario)
                .Include(m => m.Trilha)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Matricula>> GetAllAsync()
        {
            return await _context.Matriculas.ToListAsync();
        }

        public async Task<IEnumerable<Matricula>> GetByUsuarioAsync(Guid usuarioId)
        {
            return await _context.Matriculas
                .Where(m => m.UsuarioId == usuarioId)
                .Include(m => m.Trilha)
                .ToListAsync();
        }

        public async Task<IEnumerable<Matricula>> GetByTrilhaAsync(Guid trilhaId)
        {
            return await _context.Matriculas
                .Where(m => m.TrilhaId == trilhaId)
                .Include(m => m.Usuario)
                .ToListAsync();
        }

        public async Task<Matricula> UpdateStatusAsync(Guid id, string novoStatus)
        {
            var matricula = await GetByIdAsync(id);
            if (matricula == null) return null;

            matricula.Status = novoStatus;
            await _context.SaveChangesAsync();
            return matricula;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var matricula = await GetByIdAsync(id);
            if (matricula == null) return false;

            _context.Matriculas.Remove(matricula);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
