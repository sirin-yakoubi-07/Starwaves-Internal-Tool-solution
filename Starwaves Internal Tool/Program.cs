using Spectre.Console;

namespace StarWaves.ConsoleApp;

class Program
{
    static void Main()
    {
        ShowWelcomeScreen();
    }

    static void ShowWelcomeScreen()
    {
        AnsiConsole.Clear();

        // 1️ App title;
        AnsiConsole.Write(
        Align.Center(
        new Markup("[bold dodgerblue1]STARWAVES[/]")
    )
);


        // 2️ One-line description
        AnsiConsole.Write(
        Align.Center(
        new Markup("[deepskyblue1]Events & Congresses Management Console[/]")
    )
);

        // 3️ Styled welcome container
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
            Border = BoxBorder.Rounded,
            BorderStyle = new Style(Color.MediumPurple1),
            Padding = new Padding(2, 1),
            Header = new PanelHeader(
                "[bold dodgerblue1]StarWaves Console[/]",
                Justify.Center
            )

        };
        

        // Render in correct order
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine();
        AnsiConsole.Write(welcomePanel);

        // Footer
        AnsiConsole.MarkupLine(
            "\n[grey]Press any key to continue...[/]"
        );
        Console.ReadKey(true);
    }
}
