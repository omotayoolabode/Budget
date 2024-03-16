using Budget.Models;
using Microsoft.EntityFrameworkCore;

namespace Budget.Services.DbContext;

public class BudgetDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public BudgetDbContext(DbContextOptions<BudgetDbContext> options) : base(options)
    {
    }
    public DbSet<Income> Incomes { get; set; }
}