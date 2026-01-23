using System.IO;
using Spectre.Console;

namespace StarwavesInternalTool.App.pages
{
    public static class ImportInvoiceXmlPage
    {
        public static string Show()
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold dodgerblue1]Import Invoice – XML File[/]\n");

            while (true)
            {
                string path = AnsiConsole.Ask<string>(
                    "Enter the [green]XML file path[/]:"
                ).Trim();

                if (string.IsNullOrWhiteSpace(path))
                {
                    ShowError("Path cannot be empty.");
                    continue;
                }

                if (!File.Exists(path))
                {
                    ShowError("File does not exist.");
                    continue;
                }

                if (Path.GetExtension(path).ToLower() != ".xml")
                {
                    ShowError("File must have a .xml extension.");
                    continue;
                }

                // Valid path
                AnsiConsole.MarkupLine(
                    "\n[green]✔ XML file validated successfully[/]"
                );

                return path;
            }
        }

        private static void ShowError(string message)
        {
            AnsiConsole.MarkupLine(
                $"\n[red]✖ {message}[/]\n"
            );
        }
    }
}
