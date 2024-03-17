using Budget.Models;
using Budget.Services.DbContext;
using Budget.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Budget.Services.Implementation;

public class IncomeService : IIncomeService
{
    private readonly BudgetDbContext _dbContext;

    public IncomeService(BudgetDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    /// <summary>
    /// Get All Incomes
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Income>?> GetAllIncomes()
    {
        var incomes = await _dbContext.Incomes.ToListAsync();
        return incomes;
    }
    /// <summary>
    /// Gets Income By Id
    /// </summary>
    /// <param name="id">The Identifier For The Income</param>
    /// <returns></returns>

    public async Task<Income?> GetIncomeById(Guid? id)
    {
        if (id == null)
        {
            return null;
        }
        var allIncomes = await GetAllIncomes();
        if (allIncomes != null && allIncomes.Any())
        {
            var income = allIncomes.FirstOrDefault(x => x.Id == id);
            return income;
        }

        return null;

    }

    public async Task<Income?> UpdateIncome(Income? income)
    {
        if (income == null)
        {
            return null;
        }
        var existingIncome = await GetIncomeById(income.Id);
        if (existingIncome == null)
        {
            return null;
        }
        _dbContext.Incomes.Update(income);
        await _dbContext.SaveChangesAsync();
        return income;
    }

    public async Task DeleteIncome(Guid? id)
    {
        if (id == null)
        {
            return;
        }
        var income =  await GetIncomeById(id);
        if (income == null)
        {
            return;
        }
        _dbContext.Remove(income);
        await _dbContext.SaveChangesAsync();
        return;
    }

    public async Task AddIncome(Income income)
    {
        _dbContext.Incomes.Add(income);
        await _dbContext.SaveChangesAsync();
    }
}