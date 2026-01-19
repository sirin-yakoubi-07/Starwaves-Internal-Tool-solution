using System;
using Spectre.Console;

namespace StarwavesInternalTool.App.Pages
{
    internal static class ImportInvoicePage
    {
        public static void Show()
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold green]Import Invoice XML[/]\n");
            AnsiConsole.MarkupLine("Import Invoice XML screen.");
            //Console.ReadKey(true);
        }
    }
}