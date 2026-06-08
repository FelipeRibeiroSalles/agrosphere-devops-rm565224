using AgroSphere.Api.Data;
using AgroSphere.Api.DTOs;
using AgroSphere.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgroSphere.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlantiosController : ControllerBase
{
    private readonly AppDbContext _context;

    public PlantiosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlantioDto>>> Get()
    {
        var plantios = await _context.Plantios
            .Select(p => new PlantioDto
            {
                Id = p.Id,
                NomeCultura = p.NomeCultura,
                DataPlantio = p.DataPlantio,
                AreaCultivada = p.AreaCultivada,
                FazendaId = p.FazendaId
            })
            .ToListAsync();

        return Ok(plantios);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlantioDto>> GetById(int id)
    {
        var plantio = await _context.Plantios.FindAsync(id);

        if (plantio == null)
            return NotFound();

        return Ok(new PlantioDto
        {
            Id = plantio.Id,
            NomeCultura = plantio.NomeCultura,
            DataPlantio = plantio.DataPlantio,
            AreaCultivada = plantio.AreaCultivada,
            FazendaId = plantio.FazendaId
        });
    }

    [HttpPost]
    public async Task<ActionResult> Post(CreatePlantioDto dto)
    {
        var plantio = new Plantio
        {
            NomeCultura = dto.NomeCultura,
            DataPlantio = dto.DataPlantio,
            AreaCultivada = dto.AreaCultivada,
            FazendaId = dto.FazendaId
        };

        _context.Plantios.Add(plantio);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetById),
            new { id = plantio.Id },
            plantio);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(
        int id,
        CreatePlantioDto dto)
    {
        var plantio = await _context.Plantios.FindAsync(id);

        if (plantio == null)
            return NotFound();

        plantio.NomeCultura = dto.NomeCultura;
        plantio.DataPlantio = dto.DataPlantio;
        plantio.AreaCultivada = dto.AreaCultivada;
        plantio.FazendaId = dto.FazendaId;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var plantio = await _context.Plantios.FindAsync(id);

        if (plantio == null)
            return NotFound();

        _context.Plantios.Remove(plantio);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}