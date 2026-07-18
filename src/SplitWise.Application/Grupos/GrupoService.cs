using SplitWise.Domain.Entities;
using SplitWise.Domain.Repositories;

namespace SplitWise.Application.Grupos;

public class GrupoService
{
    private readonly IGrupoRepository _grupoRepository;

    public GrupoService(IGrupoRepository grupoRepository)
    {
        this._grupoRepository = grupoRepository;
    }

    public async Task<Guid> CriarGrupoAsync(CriarGrupoRequest request, CancellationToken cancellationToken = default)
    {
       Grupo grupo = new Grupo(request.Nome);
       await _grupoRepository.AdicionarAsync(grupo, cancellationToken);
       return grupo.Id;
    }

    public async Task<Grupo?> ObterGrupoAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _grupoRepository.ObterPorIdAsync(id, cancellationToken);
    }
}