using System;
using Spectre.Console;

namespace Starwaves_Internal_Tool
{
    internal static class ImportInvoicePage
    {
        public static void Show()
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold green]Import Invoice XML[/]\n");
            AnsiConsole.MarkupLine("Import Invoice XML screen.");

            AnsiConsole.MarkupLine("\n[grey]Press any key to return to main menu...[/]");
            Console.ReadKey(true);
        }
    }
}