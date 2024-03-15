namespace CodeCampRestora.Domain.Entities;

public class Image
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string Base64Url {get; set;} = default!;
    public int Size { get; set; } = default!;
    public bool IsDeleted { get; set; }
}