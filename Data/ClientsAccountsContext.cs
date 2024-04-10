using Microsoft.EntityFrameworkCore;
using FinancialAccounting.Models;
namespace FinancialAccounting.Data
{
    public class ClientsAccountsContext : DbContext
    {
        public DbSet<ClientsAccModel> ClientsAccounts { get; set; }
        public ClientsAccountsContext(DbContextOptions<ClientsAccountsContext> options) : base(options)
        {
        }
    }
}
