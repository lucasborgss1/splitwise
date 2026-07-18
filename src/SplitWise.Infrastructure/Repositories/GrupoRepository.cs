using Microsoft.EntityFrameworkCore;
using SplitWise.Domain.Entities;
using SplitWise.Domain.Repositories;
using SplitWise.Infrastructure.Data;

namespace SplitWise.Infrastructure.Repositories;

public class GrupoRepository : IGrupoRepository
{
    private readonly AppDbContext _context;

    public GrupoRepository(AppDbContext context)
    {
        this._context = context;
    }

    public async Task AdicionarAsync(Grupo grupo, CancellationToken cancellationToken = default)
    {
        await _context.Grupos.AddAsync(grupo, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Grupo?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Grupos.FirstOrDefaultAsync(grupo => grupo.Id == id, cancellationToken);
    }
}