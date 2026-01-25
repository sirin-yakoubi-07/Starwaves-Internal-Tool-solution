using System;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using Spectre.Console;

namespace StarwavesInternalTool.Core.Parsing
{
    public static class InvoiceParser
    {
        public static void Parse(string xmlPath)
        {
            try
            {
                XDocument document = XDocument.Load(xmlPath);

                XElement facture = document.Element("Facture")
                    ?? throw new Exception("Root element <Facture> not found.");

                // =========================
                // Informations générales
                // =========================
                XElement info = facture.Element("InformationsGenerales")
                    ?? throw new Exception("<InformationsGenerales> not found.");

                string numero = info.Element("NumeroFacture")?.Value ?? "N/A";
                string date = info.Element("DateFacture")?.Value ?? "N/A";
                string type = info.Element("TypeFacture")?.Value ?? "N/A";
                string devise = info.Element("Devise")?.Value ?? "N/A";

                // =========================
                // Vendeur
                // =========================
                XElement vendeur = facture.Element("Vendeur")
                    ?? throw new Exception("<Vendeur> not found.");

                string vendeurNom = vendeur.Element("RaisonSociale")?.Value ?? "N/A";
                string vendeurAdresse = vendeur.Element("Adresse")?.Value ?? "N/A";
                string vendeurMF = vendeur.Element("MatriculeFiscal")?.Value ?? "N/A";

                // =========================
                // Client
                // =========================
                XElement client = facture.Element("Client")
                    ?? throw new Exception("<Client> not found.");

                string clientNom = client.Element("RaisonSociale")?.Value ?? "N/A";
                string clientAdresse = client.Element("Adresse")?.Value ?? "N/A";

                // =========================
                // Lignes
                // =========================
                var lignes = facture
                    .Element("Lignes")?
                    .Elements("Ligne")
                    ?? throw new Exception("<Lignes> not found.");

                // =========================
                // Totaux
                // =========================
                XElement totaux = facture.Element("Totaux")
                    ?? throw new Exception("<Totaux> not found.");

                string totalHT = totaux.Element("TotalHT")?.Value ?? "0";
                string totalTVA = totaux.Element("TotalTVA")?.Value ?? "0";
                string totalTTC = totaux.Element("TotalTTC")?.Value ?? "0";

                // =========================
                // DISPLAY RESULT
                // =========================
                AnsiConsole.Clear();
                AnsiConsole.MarkupLine("[bold green]✔ Facture XML parsed successfully[/]\n");

                AnsiConsole.MarkupLine("[bold]Informations générales[/]");
                AnsiConsole.MarkupLine($"Numéro       : [yellow]{numero}[/]");
                AnsiConsole.MarkupLine($"Date         : [yellow]{date}[/]");
                AnsiConsole.MarkupLine($"Type         : [yellow]{type}[/]");
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

                    AnsiConsole.MarkupLine(
                        $"{index}. {designation} | Qté: {quantite} | PU: {prix} | TVA: {tva}%"
                    );
                    index++;
                }

                AnsiConsole.MarkupLine("\n[bold]Totaux[/]");
                AnsiConsole.MarkupLine($"Total HT  : [yellow]{totalHT}[/]");
                AnsiConsole.MarkupLine($"Total TVA : [yellow]{totalTVA}[/]");
                AnsiConsole.MarkupLine($"Total TTC : [yellow]{totalTTC}[/]");

                AnsiConsole.MarkupLine(
                    "\n[grey]Press any key to continue...[/]"
                );
                Console.ReadKey(true);
            }
            catch (Exception ex)
            {
                throw new Exception($"Invoice XML parsing failed: {ex.Message}");
            }
        }
    }
}

