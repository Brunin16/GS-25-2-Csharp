using Business;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> GetByIdAsync(Guid id)
        {
            return await _context.Usuarios
                .Include(u => u.Matriculas)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> UpdateAsync(Guid id, Usuario usuarioAtualizado)
        {
            var usuario = await GetByIdAsync(id);
            if (usuario == null) return null;

            usuario.Nome = usuarioAtualizado.Nome;
            usuario.Email = usuarioAtualizado.Email;
            usuario.AreaAtuacao = usuarioAtualizado.AreaAtuacao;
            usuario.NivelCarreira = usuarioAtualizado.NivelCarreira;

            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var usuario = await GetByIdAsync(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
