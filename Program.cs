using Microsoft.EntityFrameworkCore;
using FinancialAccounting.Data;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialAccounting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<ApiContext>
                (opt => opt.UseInMemoryDatabase("RigistrationDB"));
            //builder.Services.AddDbContext<ApiContext>
            //    (options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            var connectionString = "здесь строка подключения к вашей базе данных MSSQL Server";

            builder.Services.AddDbContext<ApiContext>(options =>
                options.UseSqlServer(connectionString));


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
