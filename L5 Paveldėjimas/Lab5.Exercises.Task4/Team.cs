using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Team
    {
        /// <summary>
        /// Name of the team
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// City that the team is based in
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Main coach of the team
        /// </summary>
        public string Coach { get; set; }
        /// <summary>
        /// Ammount of times the team has played
        /// </summary>
        public int Plays { get; set; }
        /// <summary>
        /// Total Score from all games
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// Ammount of players the team has
        /// </summary>
        public int PlayersAmmount { get; set; }

        public Team(string name, string city, string coach, int plays)
        {
            this.Name = name;
            this.City = city;
            this.Coach = coach;
            this.Plays = plays;
            this.Score = 0;
            this.PlayersAmmount = 0;
        }
    }
}
