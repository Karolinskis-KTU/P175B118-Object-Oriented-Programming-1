using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace ConsoleApp1
{
    class InOutUtils
    {
        /// <summary>
        /// Reads players data from <paramref name="fileName"/>
        /// </summary>
        /// <param name="fileName">File to read from</param>
        /// <returns>Returns players data got from file</returns>
        public static List<Player> ReadPlayers(string fileName)
        {
            List<Player> players = new List<Player>();
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');

                string teamName = parts[0];
                string name = parts[1];
                string surname = parts[2];
                DateTime birthDate = DateTime.Parse(parts[3]);
                int plays = int.Parse(parts[4]);
                int score = int.Parse(parts[5]);

                switch (parts.Length)
                {
                    case 7:
                        int yellowCards = int.Parse(parts[6]);
                        Football footballPlayer = new Football(teamName, name, surname, birthDate, plays, score, yellowCards);
                        players.Add(footballPlayer);
                        break;
                    case 8:
                        int rebounds = int.Parse(parts[6]);
                        int assists = int.Parse(parts[7]);
                        Basketball basketballPlayer = new Basketball(teamName, name, surname, birthDate, plays, score, rebounds, assists);
                        players.Add(basketballPlayer);
                        break;
                    default:
                        break;
                }
            }
            return players;
        }
        /// <summary>
        /// Reads teams data from <paramref name="fileName"/>
        /// </summary>
        /// <param name="fileName">File to read from</param>
        /// <returns>Returns teams data got from file</returns>
        public static List<Team> ReadTeams(string fileName)
        {
            List<Team> teams = new List<Team>();

            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');

                string name = parts[0];
                string city = parts[1];
                string coach = parts[2];
                int plays = int.Parse(parts[3]);

                Team team = new Team(name, city, coach, plays);
                teams.Add(team);
            }
            return teams;
        }
        /// <summary>
        /// Writes player data to console window
        /// </summary>
        /// <param name="header">Header for naming the table</param>
        /// <param name="players">Players to write</param>
        public static void WritePlayers(string header, List<Player> players)
        {
            string dashes = new string('-', 123);
            Console.WriteLine(dashes);
            Console.WriteLine("| {0,-119} |", header);
            Console.WriteLine(dashes);
            Console.WriteLine("| {0,-20} | {1,-15} | {2,-10} | {3,-12} | {4,-25} | {5,-22} | {6}", "Komandos pavadinimas", "Pavardė", "Vardas", "Gimimo data", "Žaistų rungtynių skaičius", "Imestų taškų skaičius", "Papildomi duomenys");
            Console.WriteLine(dashes);
            foreach (Player player in players)
            {
                Console.WriteLine(player.ToString());
            }
            Console.WriteLine(dashes);
        }
    }
}
