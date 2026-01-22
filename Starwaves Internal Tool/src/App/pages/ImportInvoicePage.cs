using System;
using StarwavesInternalTool.Core.Enums;

namespace StarwavesInternalTool.App.pages
{
    public static class ImportInvoicePage
    {
        public static void Show()
        {
            Console.Clear();
            Console.WriteLine("Import Invoice");
            Console.WriteLine();

            InvoiceKind invoiceKind = AskForInvoiceKind();

            Console.WriteLine();
            Console.WriteLine($"Selected invoice kind: {invoiceKind}");

            // NEXT STEP will use invoiceKind
            Console.WriteLine("Continue to XML selection...");
        }

        private static InvoiceKind AskForInvoiceKind()
        {
            while (true)
            {
                Console.WriteLine("Choose invoice kind:");
                Console.WriteLine("1 - Sales");
                Console.WriteLine("2 - Purchase");
                Console.Write("Your choice: ");

                string? input = Console.ReadLine();

                if (input == "1")
                    return InvoiceKind.Sales;

                if (input == "2")
                    return InvoiceKind.Purchase;

                Console.WriteLine("Invalid choice. Please select 1 or 2.");
                Console.WriteLine();
            }
        }
    }
}
