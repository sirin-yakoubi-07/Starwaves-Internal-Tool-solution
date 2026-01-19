using Spectre.Console;

namespace Starwaves_Internal_Tool;

class Program
{
    static void Main()
    {
        while (true)
        {
            AnsiConsole.Clear();

            ShowWelcomeScreen();

            // Show menu directly under the welcome screen
            var menu = new Menu();
            var result = menu.ShowMenu();

            // Exit → return to welcome screen
            if (result == MenuOption.Exit)
                continue;

            // Placeholder for future pages
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine(
                $"[bold dodgerblue1]{result}[/]\n"
            );
            AnsiConsole.MarkupLine("[grey]Feature coming soon...[/]");
            AnsiConsole.MarkupLine("\n[grey]Press any key to return[/]");
            Console.ReadKey(true);
        }
    }

    static void ShowWelcomeScreen()
    {
        // Title
        AnsiConsole.Write(
            Align.Center(
                new Markup("[bold dodgerblue1]STARWAVES[/]")
            )
        );

        AnsiConsole.WriteLine();

        // Description
        AnsiConsole.Write(
            Align.Center(
                new Markup("[deepskyblue1]Events & Congresses Management Console[/]")
            )
        );

        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine();

        // Welcome panel
        var welcomePanel = new Panel(
            Align.Center(
                new Markup(
                    "[bold mediumpurple3]Welcome![/]\n\n" +
                    "[white]Plan, organize, and manage[/] " +
                    "[hotpink]events[/], [orange1]congresses[/],\n" +
                    "[white]and attendee experiences with ease.[/]"
                ),
                VerticalAlignment.Middle
            )
        )
        {
            Width = 70,
            Border = BoxBorder.Rounded,
            BorderStyle = new Style(Color.MediumPurple1),
            Padding = new Padding(2, 1),
            Header = new PanelHeader(
                "[bold dodgerblue1]StarWaves Console[/]",
                Justify.Center
            )
        };

        AnsiConsole.Write(Align.Center(welcomePanel));
        AnsiConsole.WriteLine();
    }
}
