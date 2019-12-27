using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using FifaResults.Entities;

namespace FifaResults.Logic
{
    public class Controller
    {
        #region Constants

        private const string FileName = "data.csv";
        private const char SplitSeparator = ';';

        #endregion

        #region Fields

        private List<Club> _clubs;
        private List<Player> _players;
        private IDictionary<string, Club> _clubsCache;
        private string[] _lines;

        #endregion

        #region Propertise

        public IEnumerable<Club> Clubs => _clubs;
        public IEnumerable<Player> Players => _players;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialisiert den Controller:
        ///  - Liest die Datei (siehe Hilfsmethode) in die interne "_lines"-Struktur
        ///  - Instanziert den "_clubsCache"
        /// </summary>
        public Controller()
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// Lade alle Clubs ohne die Player!
        ///
        /// Die Clubs sind in der List "_clubs" sortiert nach dem Name aufsteigend zu sortieren!
        /// </summary>
        public void LoadClubs()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lädt die Player zu den zuvor geladenen Clubs.
        /// </summary>
        public void LoadPlayersForClubs()
        {
            throw new NotImplementedException();
        }

        public string GetTop10ClubsAsMarkdown()
        {
            throw new NotImplementedException();
        }

        public string GetLast10ClubsAsMarkdown()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Liefert alle Fifa Player mit einem Wert unter € 100.000 sortiert nach der Nationalität (aufsteigend)
        /// und dem Value (absteigend).
        /// </summary>
        /// <returns></returns>
        public string GetPlayersUnder100KValueByNationAndValueAsMarkdown()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Liefert den Markdown Header für die "Player"-Ausgabe.
        /// </summary>
        private string GeneratePlayerMarkdownHeader()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("|Name|Age|Wage|Value|Nationality|Club|");
            sb.AppendLine("|----|--:|---:|----:|:---------:|:---|");

            return sb.ToString();
        }

        /// <summary>
        /// Liefert den Markdown Header für die "Club"-Ausgabe.
        /// </summary>
        private string GenerateClubMarkdownHeader()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("|Name|Players|AverageAge|AverageWage|OverallValue|");
            sb.AppendLine("|----|------:|---------:|----------:|-----------:|");

            return sb.ToString();
        }

        /// <summary>
        /// Dies Hilfsmethode liest die Zeilen aus der Input-Datei
        /// in den internen Cache "_lines" ein.
        /// </summary>
        private void ReadLinesFromFile()
        {
            _lines = File.ReadAllLines(
                Utils.GetFullNameInApplicationTree(FileName),
                Encoding.UTF8);
        }

        /// <summary>
        /// Wandelt eine Währung als Zeichenkette in einen Integer um.
        /// </summary>
        public static int ParseCurrency(string currencyString)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Wandelt ein Gewicht als Zeichenkette in einen Double (metrisch) um.
        /// Das Ergebnis wird auf 2 Nachkommastellen gerundet!
        /// Die notwendige Formel finden Sie in den Hinweisen.
        /// </summary>
        public static double ParseWeightToMetric(string weightString)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Wandelt eine Körpergröße als Zeichenkette in einen Double (metrisch) um.
        /// Das Ergebnis wird auf 2 Nachkommastellen gerundet!
        /// Die notwendige Formel finden Sie in den Hinweisen.
        /// </summary>
        public static double ParseHeightToMetric(string heightString)
        {
            throw new NotImplementedException();
        }
    }

}
