using Budget.Services.DbContext;
using Budget.Services.Implementation;
using Budget.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Budget.Services_Registration;

public static class ServiceRegistration
{
    
    public static IServiceCollection RegisterCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BudgetDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));
        services.AddTransient<IIncomeService, IncomeService>();
        return services;
    }
}