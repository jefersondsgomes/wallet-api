namespace Core.Entities;

public class User(
    string? name,
    string email,
    string? userName,
    string? password) : Entity
{
    public string? Name { get; private set; } = name;
    public Email Email { get; private set; } = email;
    public string? UserName { get; private set; } = userName;
    public string? Password { get; private set; } = password;

    public Wallet? Wallet { get; private set; }
}
