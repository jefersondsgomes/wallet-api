using Core.Entities;
using Core.Repositories.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class WalletRepository(ApplicationContext context) : RepositoryBase<Wallet>(context), IWalletRepository
{

}
