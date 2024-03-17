using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Budget.Models;
using Budget.Services.Interfaces;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace Budget.Pages
{
    public partial class Incomes
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }


        protected IEnumerable<Budget.Models.Income> incomes;

        protected RadzenDataGrid<Budget.Models.Income> grid0;

        protected string search = "";

        [Inject]
        protected SecurityService Security { get; set; }
        [Inject]
        public IIncomeService IncomeService { get; set; }

        protected async Task Search(ChangeEventArgs args)
        {
            search = $"{args.Value}";

            await grid0.GoToPage(0);

            // TODO: Populate incomes
        }

        protected async Task<IEnumerable<Income>> GetIncomes()
        {
            var incomes = await IncomeService.GetAllIncomes();
            return incomes;
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddIncome>("Add Income", null);
            await grid0.Reload();
        }

        protected async Task EditRow(Budget.Models.Income args)
        {
            await DialogService.OpenAsync<EditIncome>("Edit Income", new Dictionary<string, object> { {"Id", args.Id} });
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, Budget.Models.Income income)
        {
            // TODO: Delete income
        }

        protected async System.Threading.Tasks.Task DataGrid0LoadData(Radzen.LoadDataArgs args)
        {
            incomes = await GetIncomes();
            return;
        }
    }
}