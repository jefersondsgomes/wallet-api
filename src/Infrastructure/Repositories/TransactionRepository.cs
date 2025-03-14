using Core.Entities;
using Core.Repositories.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class TransactionRepository(ApplicationContext context) : RepositoryBase<Transaction>(context), ITransactionRepository
{

}
