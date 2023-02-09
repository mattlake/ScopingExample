using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DbContext.Context;

public static class DataContextExtensions
{
    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, string relativePath = "..")
    {
        string databasePath = Path.Combine(relativePath, "Database.db");

        services.AddDbContext<DataContext>(options =>
            options.UseSqlite($"Data source={databasePath}")
        );

        return services;
    }
}