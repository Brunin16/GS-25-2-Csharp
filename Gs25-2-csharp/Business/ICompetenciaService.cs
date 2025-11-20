using Models;

namespace Business
{
    public interface ICompetenciaService
    {
        Task<Competencia> CreateAsync(Competencia competencia);
        Task<Competencia> GetByIdAsync(Guid id);
        Task<IEnumerable<Competencia>> GetAllAsync();
        Task<Competencia> UpdateAsync(Guid id, Competencia competenciaAtualizada);
        Task<bool> DeleteAsync(Guid id);
    }
}
