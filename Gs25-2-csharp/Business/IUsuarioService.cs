using Models;

namespace Business
{
    public interface IUsuarioService
    {
        Task<Usuario> CreateAsync(Usuario usuario);
        Task<Usuario> GetByIdAsync(Guid id);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> UpdateAsync(Guid id, Usuario usuarioAtualizado);
        Task<bool> DeleteAsync(Guid id);
    }
}
