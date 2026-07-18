using Microsoft.AspNetCore.Mvc;
using SplitWise.Application.Grupos;

namespace SplitWise.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GruposController : ControllerBase
{
    private readonly GrupoService _grupoService;

    public GruposController(GrupoService grupoService)
    {
        this._grupoService = grupoService;
    }

    [HttpPost]
    public async Task<IActionResult> CriarGrupo(CriarGrupoRequest request, CancellationToken cancellationToken)
    {
        var id = await _grupoService.CriarGrupoAsync(request, cancellationToken);
        return CreatedAtAction(nameof(ObterGrupoPorId), new { id }, new { id });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ObterGrupoPorId(Guid id, CancellationToken cancellationToken)
    {
        var grupo = await _grupoService.ObterGrupoAsync(id, cancellationToken);
        if (grupo == null)
            return NotFound();
        return Ok(grupo);
    }
}