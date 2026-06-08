using AgroSphere.Api.Data;
using AgroSphere.Api.DTOs;
using AgroSphere.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgroSphere.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FazendasController : ControllerBase
{
    private readonly AppDbContext _context;

    public FazendasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FazendaDto>>> Get()
    {
        var fazendas = await _context.Fazendas
            .Select(f => new FazendaDto
            {
                Id = f.Id,
                Nome = f.Nome,
                Localizacao = f.Localizacao
            })
            .ToListAsync();

        return Ok(fazendas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FazendaDto>> GetById(int id)
    {
        var fazenda = await _context.Fazendas.FindAsync(id);

        if (fazenda == null)
            return NotFound();

        return Ok(new FazendaDto
        {
            Id = fazenda.Id,
            Nome = fazenda.Nome,
            Localizacao = fazenda.Localizacao
        });
    }

    [HttpPost]
    public async Task<ActionResult> Post(CreateFazendaDto dto)
    {
        var fazenda = new Fazenda
        {
            Nome = dto.Nome,
            Localizacao = dto.Localizacao
        };

        _context.Fazendas.Add(fazenda);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetById),
            new { id = fazenda.Id },
            fazenda);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(
        int id,
        CreateFazendaDto dto)
    {
        var fazenda = await _context.Fazendas.FindAsync(id);

        if (fazenda == null)
            return NotFound();

        fazenda.Nome = dto.Nome;
        fazenda.Localizacao = dto.Localizacao;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var fazenda = await _context.Fazendas.FindAsync(id);

        if (fazenda == null)
            return NotFound();

        _context.Fazendas.Remove(fazenda);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}