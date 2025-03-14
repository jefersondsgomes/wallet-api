using Core.Entities;
using Core.Repositories.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class UserRepository(ApplicationContext context) : RepositoryBase<User>(context), IUserRepository
{

}
