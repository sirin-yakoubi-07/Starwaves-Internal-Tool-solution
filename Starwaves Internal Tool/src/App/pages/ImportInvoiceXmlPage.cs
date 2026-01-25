using System;
using System.IO;
using Spectre.Console;
using StarwavesInternalTool.Core.Parsing;

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

                AnsiConsole.MarkupLine("\n[green]✔ XML file validated successfully[/]");

                try
                {
                    InvoiceParser.Parse(path);
                    AnsiConsole.MarkupLine("[green]✔ XML file parsed successfully[/]");
                    return path; // ✅ RETURN VALUE
                }
                catch (Exception ex)
                {
                    ShowError($"Parsing failed: {ex.Message}");
                }
            }
        }

        private static void ShowError(string message)
        {
            AnsiConsole.MarkupLine($"\n[red]✖ {message}[/]\n");
        }
    }
}
