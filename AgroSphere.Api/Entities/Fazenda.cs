namespace AgroSphere.Api.Entities;

public class Fazenda
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Localizacao { get; set; } = string.Empty;

    public ICollection<Plantio> Plantios { get; set; }
        = new List<Plantio>();
}