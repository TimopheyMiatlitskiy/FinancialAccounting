using Microsoft.EntityFrameworkCore;
using FinancialAccounting.Data;
using Microsoft.Extensions.DependencyInjection;
using FinancialAccounting.Controllers;

namespace FinancialAccounting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApiContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDbContext<ClientsAccountsContext>(options =>
                options.UseSqlServer(connectionString));

            //builder.Services.AddRazorPages();
            //builder.Services.AddDbContext<ApiContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
            //    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
