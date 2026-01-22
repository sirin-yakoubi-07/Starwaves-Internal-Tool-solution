using Spectre.Console;
using StarwavesInternalTool.Core.Enums;

namespace StarwavesInternalTool.App.Pages
{
    public static class ImportInvoicePage
    {
        public static InvoiceKind ChooseInvoiceKind()
        {
            return AnsiConsole.Prompt(
                new SelectionPrompt<InvoiceKind>()
                    .Title("Select invoice kind:")
                    .AddChoices(
                        InvoiceKind.Sales,
                        InvoiceKind.Purchase
                    )
            );
        }
    }
}
