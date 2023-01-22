using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Sports
    {
        private List<Player> players;
        private List<Team> teams;

        public Sports()
        {
            this.players = new List<Player>();
            this.teams = new List<Team>();
        }

        public Sports(List<Player> players, List<Team> teams) : this()
        {
            foreach (Player player in players)
            {
                this.players.Add(player);
            }

            foreach (Team team in teams)
            {
                this.teams.Add(team);
            }
        }

        public int CountPlayers()
        {
            return this.players.Count;
        }
        public int CountTeams()
        {
            return this.teams.Count;
        }
        /// <summary>
        /// Finds Teams that are in <paramref name="city"/>
        /// </summary>
        /// <param name="city">City to find by</param>
        /// <returns>Returns a list of teams that are in <paramref name="city"/></returns>
        private List<Team> GetTeamsInCity(string city)
        {
            List<Team> filtered = new List<Team>();

            foreach (Team team in teams)
            {
                if (team.City == city)
                {
                    filtered.Add(team);
                }
            }
            return filtered;
        }

        /// <summary>
        /// Finds players that are in <paramref name="city"/>
        /// </summary>
        /// <param name="city">City to find by</param>
        /// <returns>Returns a list of players that are in <paramref name="city"/></returns>
        public List<Player> GetPlayersInCity(string city)
        {
            List<Team> teams = UpdateTeamData(GetTeamsInCity(city));
            List<Player> players = GetPlayersByCriteria(teams);

            return players;
        }

        /// <summary>
        /// Updates team list with ammount of players in team and total score
        /// </summary>
        /// <param name="teams"></param>
        /// <returns></returns>
        private List<Team> UpdateTeamData(List<Team> teams)
        {
            foreach (Player player in players)
            {
                foreach (Team team in teams)
                {
                    if (team.Name == player.TeamName)
                    {
                        team.PlayersAmmount++;
                        team.Score += player.Score;
                    }
                }
            }
            return teams;
        }

        /// <summary>
        /// Gets list of players by their team and score
        /// </summary>
        /// <param name="teams">List of all teams to compare to</param>
        /// <returns>Returns a list of players that meet the criteria</returns>
        private List<Player> GetPlayersByCriteria(List<Team> teams)
        {
            List<Player> filtered = new List<Player>();

            foreach (Player player in players)
            {
                foreach (Team team in teams)
                {
                    decimal averageScore = team.Score / team.PlayersAmmount;
                    if (team.Name == player.TeamName && player.Score >= averageScore && player.Plays == team.Plays)
                    {
                        filtered.Add(player);
                    }
                }
            }
            return filtered;
        }
    }
}
