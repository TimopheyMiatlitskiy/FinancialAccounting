using Microsoft.EntityFrameworkCore;
using FinancialAccounting.Models;
namespace FinancialAccounting.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<SiteRegistration> Registrations { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) :base(options)
        {

        }
    }
}
