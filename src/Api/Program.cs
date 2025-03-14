
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<ApplicationContext>(options =>
        {
            var connectionString = Environment.GetEnvironmentVariable("PostgreSqlConnectionString");
            var logger = LoggerFactory.Create(l => l.AddConsole());

            options
                .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), options =>
                {
                    options.EnableRetryOnFailure(
                        3,
                        TimeSpan.FromSeconds(5),
                        default);

                    options.MigrationsHistoryTable("ef_migrations_hostory");
                })
                .UseLoggerFactory(logger)
                // Exibe todos os valores dos parâmetros no console, isso deve ser utilizado apenas para desenvolvimento
                .EnableSensitiveDataLogging();
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
