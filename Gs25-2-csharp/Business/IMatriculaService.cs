using Models;

namespace Business
{
    public interface IMatriculaService
    {
        Task<Matricula> CreateAsync(Matricula matricula);
        Task<Matricula> GetByIdAsync(Guid id);
        Task<IEnumerable<Matricula>> GetAllAsync();
        Task<IEnumerable<Matricula>> GetByUsuarioAsync(Guid usuarioId);
        Task<IEnumerable<Matricula>> GetByTrilhaAsync(Guid trilhaId);
        Task<Matricula> UpdateStatusAsync(Guid id, string novoStatus);
        Task<bool> DeleteAsync(Guid id);
    }
}
