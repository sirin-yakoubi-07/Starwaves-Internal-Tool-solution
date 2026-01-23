using Spectre.Console;
using StarwavesInternalTool.Core.Enums;

namespace StarwavesInternalTool.App.pages
{
    public static class ImportInvoicePage
    {
        public static void Show()
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold dodgerblue1]Import Invoice[/]\n");

            InvoiceKind invoiceKind = AskForInvoiceKind();

            // ➜ Go to XML selection page
            string xmlPath = ImportInvoiceXmlPage.Show();

            // Temporary confirmation
            AnsiConsole.MarkupLine(
                $"\nInvoice Kind: [green]{invoiceKind}[/]"
            );
            AnsiConsole.MarkupLine(
                $"XML Path: [green]{xmlPath}[/]"
            );

            AnsiConsole.MarkupLine(
                "\n[grey]Next steps will be implemented here...[/]"
            );
        }

        private static InvoiceKind AskForInvoiceKind()
        {
            return AnsiConsole.Prompt(
                new SelectionPrompt<InvoiceKind>()
                    .Title("Choose invoice kind:")
                    .AddChoices(
                        InvoiceKind.Sales,
                        InvoiceKind.Purchase
                    )
            );
        }
    }
}


