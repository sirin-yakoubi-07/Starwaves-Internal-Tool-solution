using System;
using Spectre.Console;

namespace StarwavesInternalTool_App_Pages
{
    internal static class DashboardsPage
    {
        public static void Show()
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold magenta]Dashboards[/]\n");
            AnsiConsole.MarkupLine("Dashboards placeholder screen.");

            AnsiConsole.MarkupLine("\n[grey]Press any key to return to main menu...[/]");
            Console.ReadKey(true);
        }
    }
}
