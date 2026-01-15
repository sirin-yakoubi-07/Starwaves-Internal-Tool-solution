using System;
using Spectre.Console;

namespace Starwaves_Internal_Tool
{
    internal class Menu
    {
        public void ShowMenu()
        {
            while (true)
            {
                AnsiConsole.Clear();
                AnsiConsole.MarkupLine("[bold dodgerblue1]Main Menu[/]\n");

                AnsiConsole.MarkupLine("1. Import Invoice XML");
                AnsiConsole.MarkupLine("2. Documents");
                AnsiConsole.MarkupLine("3. Dashboards");
                AnsiConsole.MarkupLine("4. Exit");

                AnsiConsole.MarkupLine("\n[grey]Choose an option (1–4):[/]");

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        ImportInvoicePage.Show();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        DocumentsPage.Show();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        DashboardsPage.Show();
                        break;

                    case ConsoleKey.D4:
                        return; // Exit application

                    default:
                        AnsiConsole.MarkupLine("\n[red]Invalid choice. Press any key...[/]");
                        Console.ReadKey(true);
                        break;
                }
            }
        }
    }
}
