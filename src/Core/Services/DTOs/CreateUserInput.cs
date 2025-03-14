namespace Core.Services.DTOs;

public record CreateUserInput
{
    public string? Name { get; init; }
    public string? Email { get; init; }
    public string? UserName { get; init; }
    public string? Password { get; init; }
}
