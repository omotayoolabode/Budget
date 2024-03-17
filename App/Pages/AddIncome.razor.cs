using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Budget.Services.Interfaces;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace Budget.Pages;

public partial class AddIncome
{
    [Inject] protected IJSRuntime JSRuntime { get; set; }

    [Inject] protected NavigationManager NavigationManager { get; set; }

    [Inject] protected DialogService DialogService { get; set; }

    [Inject] protected TooltipService TooltipService { get; set; }

    [Inject] protected ContextMenuService ContextMenuService { get; set; }

    [Inject] protected NotificationService NotificationService { get; set; }
    [Inject] protected IIncomeService IncomeService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        income = new Models.Income();
    }

    protected bool errorVisible;
    protected Models.Income income;

    [Inject] protected SecurityService Security { get; set; }

    protected async Task FormSubmit()
    {
        income.Id = Guid.NewGuid();
        income.IncomeDate = DateTime.Now;
        try
        {
            await IncomeService.AddIncome(income);
            NotificationService.Notify(new NotificationMessage
            {
                Severity = NotificationSeverity.Success,
                Summary = $"{income.IncomeName} created successfully "
            });
            DialogService.Close();
        }
        catch (Exception)
        {
             NotificationService.Notify(new NotificationMessage
            {
                Severity = NotificationSeverity.Error,
                Summary = $"There was an error creating {income.IncomeName}, please try again "
            });

        }
    }

    protected async Task CancelButtonClick(MouseEventArgs args)
    {
        DialogService.Close(null);
    }
}