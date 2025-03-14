using Core.Entities;
using Core.Services.DTOs;

namespace Core.Services.Interfaces;

public interface IUserService
{
    Task<User> CreateAsync(CreateUserInput input, CancellationToken cancellationToken);
    Task<User> GetByIdAsync(int id, CancellationToken cancellationToken);
}
