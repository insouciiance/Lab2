using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string directoryName = Console.ReadLine();
            string[][] inputLines = await CSVReader.ReadAllDirectoryAsync(directoryName);

            Team[] teams = TeamParser.Parse(inputLines);
            Array.Sort(teams);

            using CSVWriter writer = new CSVWriter("results.csv");
            foreach (Team team in teams)
            {
                await writer.WriteLineAsync(team.Name, team.Rating);
            }
        }
    }
}
