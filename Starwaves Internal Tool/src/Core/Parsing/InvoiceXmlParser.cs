using System;
using System.Linq;
using System.Xml.Linq;
using Spectre.Console;

namespace StarwavesInternalTool.Core.Parsing
{
    public static class InvoiceParser
    {
        /// <summary>
        /// Parses an invoice XML file safely.
        /// </summary>
        /// <param name="xmlPath">Path to the XML file</param>
        public static void Parse(string xmlPath)
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold yellow]Parsing invoice XML...[/]");

            if (!System.IO.File.Exists(xmlPath))
            {
                AnsiConsole.MarkupLine($"[red]Error:[/] File not found: [yellow]{xmlPath}[/]");
                ReturnToMenu();
                return;
            }

            try
            {
                XDocument document = XDocument.Load(xmlPath);

                // Check root element
                XElement facture = document.Element("Facture");
                if (facture == null)
                {
                    AnsiConsole.MarkupLine("[red]Error:[/] This XML is not a valid invoice.");
                    AnsiConsole.MarkupLine($"Root element found: [yellow]{document.Root?.Name ?? "None"}[/]");
                    ReturnToMenu();
                    return;
                }

                // Informations générales
                XElement info = facture.Element("InformationsGenerales");
                if (info == null)
                    throw new Exception("<InformationsGenerales> element is missing.");

                string numero = info.Element("NumeroFacture")?.Value ?? "N/A";
                string date = info.Element("DateFacture")?.Value ?? "N/A";
                string typeFacture = info.Element("TypeFacture")?.Value ?? "N/A";
                string devise = info.Element("Devise")?.Value ?? "N/A";

                // Vendeur
                XElement vendeur = facture.Element("Vendeur")
                    ?? throw new Exception("<Vendeur> element is missing.");

                string vendeurNom = vendeur.Element("RaisonSociale")?.Value ?? "N/A";
                string vendeurAdresse = vendeur.Element("Adresse")?.Value ?? "N/A";
                string vendeurMF = vendeur.Element("MatriculeFiscal")?.Value ?? "N/A";

                // Client
                XElement client = facture.Element("Client")
                    ?? throw new Exception("<Client> element is missing.");

                string clientNom = client.Element("RaisonSociale")?.Value ?? "N/A";
                string clientAdresse = client.Element("Adresse")?.Value ?? "N/A";

                // Lignes
                var lignes = facture.Element("Lignes")?.Elements("Ligne")
                    ?? throw new Exception("<Lignes> element is missing.");

                // Totaux
                XElement totaux = facture.Element("Totaux")
                    ?? throw new Exception("<Totaux> element is missing.");

                string totalHT = totaux.Element("TotalHT")?.Value ?? "0";
                string totalTVA = totaux.Element("TotalTVA")?.Value ?? "0";
                string totalTTC = totaux.Element("TotalTTC")?.Value ?? "0";

                // =========================
                // DISPLAY FULL DETAILS
                // =========================
                AnsiConsole.Clear();
                AnsiConsole.MarkupLine("[bold green]✔ Invoice XML parsed successfully[/]\n");

                AnsiConsole.MarkupLine("[bold]Informations générales[/]");
                AnsiConsole.MarkupLine($"Numéro       : [yellow]{numero}[/]");
                AnsiConsole.MarkupLine($"Date         : [yellow]{date}[/]");
                AnsiConsole.MarkupLine($"Type         : [yellow]{typeFacture}[/]");
                AnsiConsole.MarkupLine($"Devise       : [yellow]{devise}[/]\n");

                AnsiConsole.MarkupLine("[bold]Vendeur[/]");
                AnsiConsole.MarkupLine($"Nom          : [yellow]{vendeurNom}[/]");
                AnsiConsole.MarkupLine($"Adresse      : [yellow]{vendeurAdresse}[/]");
                AnsiConsole.MarkupLine($"Matricule MF : [yellow]{vendeurMF}[/]\n");

                AnsiConsole.MarkupLine("[bold]Client[/]");
                AnsiConsole.MarkupLine($"Nom          : [yellow]{clientNom}[/]");
                AnsiConsole.MarkupLine($"Adresse      : [yellow]{clientAdresse}[/]\n");

                AnsiConsole.MarkupLine("[bold]Lignes[/]");
                int index = 1;
                foreach (var ligne in lignes)
                {
                    string designation = ligne.Element("Designation")?.Value ?? "N/A";
                    string quantite = ligne.Element("Quantite")?.Value ?? "0";
                    string prix = ligne.Element("PrixUnitaire")?.Value ?? "0";
                    string tva = ligne.Element("TauxTVA")?.Value ?? "0";

                    AnsiConsole.MarkupLine($"{index}. {designation} | Qté: {quantite} | PU: {prix} | TVA: {tva}%");
                    index++;
                }

                AnsiConsole.MarkupLine("\n[bold]Totaux[/]");
                AnsiConsole.MarkupLine($"Total HT  : [yellow]{totalHT}[/]");
                AnsiConsole.MarkupLine($"Total TVA : [yellow]{totalTVA}[/]");
                AnsiConsole.MarkupLine($"Total TTC : [yellow]{totalTTC}[/]");

                // Summary table
                var summaryTable = new Table()
                    .RoundedBorder()
                    .AddColumn("[bold]Field[/]")
                    .AddColumn("[bold]Value[/]");

                summaryTable.AddRow("Invoice kind", typeFacture);
                summaryTable.AddRow("Invoice ID", numero);
                summaryTable.AddRow("Issue date", date);
                summaryTable.AddRow("Counterparty name", clientNom);

                AnsiConsole.MarkupLine("\n[bold dodgerblue1]Invoice Summary[/]");
                AnsiConsole.Write(summaryTable);

                ReturnToMenu();
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Invoice XML parsing failed:[/] {ex.Message}");
                ReturnToMenu();
            }
        }

        private static void ReturnToMenu()
        {
            AnsiConsole.MarkupLine("\n[grey]Press any key to return to the menu...[/]");
            Console.ReadKey(true);
        }
    }
}
