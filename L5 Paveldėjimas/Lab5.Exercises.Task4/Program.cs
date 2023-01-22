using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string PlayerData = "Zaidejai.csv";
            const string TeamsData = "Komandos.csv";

            List<Player> players = InOutUtils.ReadPlayers(PlayerData);
            List<Team> teams = InOutUtils.ReadTeams(TeamsData);

            Sports allSports = new Sports(players, teams);


            InOutUtils.WritePlayers("Visi zaidejai", players);

            Console.WriteLine("Pasirinkite miesta: ");
            string cityToFind = Console.ReadLine();

            List<Player> filteredPlayers = allSports.GetPlayersInCity(cityToFind);
            InOutUtils.WritePlayers(String.Format("Visi zaidejai zaidziantys mieste: {0}", cityToFind), filteredPlayers);


            Console.ReadKey();
        }
    }
}
