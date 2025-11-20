using Models;

namespace Business
{
    public interface ITrilhaCompetenciaService
    {
        Task<TrilhaCompetencia> AddCompetenciaAsync(Guid trilhaId, Guid competenciaId);
        Task<IEnumerable<Competencia>> GetCompetenciasByTrilhaAsync(Guid trilhaId);
        Task<bool> RemoveCompetenciaAsync(Guid trilhaId, Guid competenciaId);
    }
}
