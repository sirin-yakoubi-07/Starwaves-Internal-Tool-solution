using Spectre.Console;
using StarwavesInternalTool.Core.Enums;
using StarwavesInternalTool.App.pages;

namespace StarwavesInternalTool.App.pages
{
    public static class ImportInvoicePage
    {
        public static void Show()
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold dodgerblue1]Import Invoice[/]\n");

            // Step 1: Ask for invoice kind
            InvoiceKind invoiceKind = AskForInvoiceKind();

            // Step 2: Ask for XML file and parse it
            string xmlPath = ImportInvoiceXmlPage.Show();

            // Step 3: Temporary confirmation (until next steps are implemented)
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



