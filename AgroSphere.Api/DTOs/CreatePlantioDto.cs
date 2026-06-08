namespace AgroSphere.Api.DTOs;

public class CreatePlantioDto
{
    public string NomeCultura { get; set; } = string.Empty;

    public DateTime DataPlantio { get; set; }

    public double AreaCultivada { get; set; }

    public int FazendaId { get; set; }
}