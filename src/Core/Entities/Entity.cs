namespace Core.Entities;

public abstract class Entity
{
    public int Id { get; set; }
    public DateTime Created { get; } = DateTime.UtcNow;
}
