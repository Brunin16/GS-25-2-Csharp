using Models;

namespace Business
{
    public interface ITrilhaService
    {
        Task<Trilha> CreateAsync(Trilha trilha);
        Task<Trilha> GetByIdAsync(Guid id);
        Task<IEnumerable<Trilha>> GetAllAsync();
        Task<Trilha> UpdateAsync(Guid id, Trilha trilhaAtualizada);
        Task<bool> DeleteAsync(Guid id);
    }
}
