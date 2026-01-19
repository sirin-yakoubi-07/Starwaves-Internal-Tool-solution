using Spectre.Console;

namespace Starwaves_Internal_Tool;

internal class Menu
{
    public MenuOption ShowMenu()
    {
        var menu = new SelectionPrompt<MenuOption>()
            .Title("[bold dodgerblue1]Main Menu[/]")
            .PageSize(5)
            .HighlightStyle(new Style(Color.HotPink))
            .AddChoices(
                MenuOption.ImportInvoiceXml,
                MenuOption.Documents,
                MenuOption.Dashboards,
                MenuOption.Exit
            );

        return AnsiConsole.Prompt(menu);
    }
}

internal enum MenuOption
{
    ImportInvoiceXml,
    Documents,
    Dashboards,
    Exit
}

