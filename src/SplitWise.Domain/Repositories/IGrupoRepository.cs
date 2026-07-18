using SplitWise.Domain.Entities;

namespace SplitWise.Domain.Repositories;

public interface IGrupoRepository
{
     Task AdicionarAsync(Grupo grupo, CancellationToken cancellationToken = default);
     Task<Grupo?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default); 
}