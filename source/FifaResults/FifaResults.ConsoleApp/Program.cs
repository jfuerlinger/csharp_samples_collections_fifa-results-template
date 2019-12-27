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

            throw new NotImplementedException();
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
