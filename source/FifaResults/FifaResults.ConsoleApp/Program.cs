using System;
using System.IO;
using System.Linq;
using System.Text;
using FifaResults.Logic;

namespace FifaResults.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fifa 2019 Results");

            Controller ctrl = new Controller();
            ctrl.LoadClubs();
            ctrl.LoadPlayersForClubs();

            Console.WriteLine($"Es wurden {ctrl.Clubs.Count()} Clubs geladen.");

            WriteContentToFile("top10clubs.md", ctrl.GetTop10ClubsAsMarkdown());
            WriteContentToFile("last10clubs.md", ctrl.GetLast10ClubsAsMarkdown());
            WriteContentToFile("players.md", ctrl.GetPlayersUnder100KValueByNationAndValueAsMarkdown());

            Console.WriteLine();
            Console.WriteLine("Beliebige Taste zum Beenden drücken.");
        }

        private static void WriteContentToFile(string fileName, string content)
        {
            string fullName = Path.Combine(
                Utils.GetFullFolderNameInApplicationTree("output"), 
                fileName);

            File.WriteAllText(
                fullName,
                content,
                Encoding.UTF8);

            Console.WriteLine($">> Die Datei '{fullName}' wurde aktualisiert!");
        }
    }
}
