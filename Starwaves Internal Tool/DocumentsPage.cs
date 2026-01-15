using System;
using Spectre.Console;

namespace Starwaves_Internal_Tool
{
    internal static class DocumentsPage
    {
        public static void Show()
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold cyan]Documents[/]\n");
            AnsiConsole.MarkupLine("Documents placeholder screen.");

            AnsiConsole.MarkupLine("\n[grey]Press any key to return to main menu...[/]");
            Console.ReadKey(true);
        }
    }
}