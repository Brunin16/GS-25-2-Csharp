using Business;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Service
{
    public class TrilhaService : ITrilhaService
    {
        private readonly ApplicationDbContext _context;

        public TrilhaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Trilha> CreateAsync(Trilha trilha)
        {
            _context.Trilhas.Add(trilha);
            await _context.SaveChangesAsync();
            return trilha;
        }

        public async Task<Trilha> GetByIdAsync(Guid id)
        {
            return await _context.Trilhas
                .Include(t => t.TrilhaCompetencias)
                .Include(t => t.Matriculas)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Trilha>> GetAllAsync()
        {
            return await _context.Trilhas.ToListAsync();
        }

        public async Task<Trilha> UpdateAsync(Guid id, Trilha trilhaAtualizada)
        {
            var trilha = await GetByIdAsync(id);
            if (trilha == null) return null;

            trilha.Nome = trilhaAtualizada.Nome;
            trilha.Descricao = trilhaAtualizada.Descricao;
            trilha.Nivel = trilhaAtualizada.Nivel;
            trilha.CargaHoraria = trilhaAtualizada.CargaHoraria;
            trilha.FocoPrincipal = trilhaAtualizada.FocoPrincipal;

            await _context.SaveChangesAsync();
            return trilha;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var trilha = await GetByIdAsync(id);
            if (trilha == null) return false;

            _context.Trilhas.Remove(trilha);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
