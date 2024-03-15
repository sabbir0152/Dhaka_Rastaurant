namespace CodeCampRestora.Domain.Entities.Common;

public class BaseEntity<TKey>
{
    public TKey Id { get; set; } = default!;
}