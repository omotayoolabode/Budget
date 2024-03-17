using Budget.Models;

namespace Budget.Services.Interfaces;

public interface IIncomeService
{
    public Task<IEnumerable<Income>?> GetAllIncomes();
    public Task<Income?> GetIncomeById(Guid? id);
    public Task<Income?> UpdateIncome(Income? income);
    public Task DeleteIncome(Guid? id);
    Task AddIncome(Income income);
    IEnumerable<Income> SearchIncomes(string search, IEnumerable<Income> incomes);
}