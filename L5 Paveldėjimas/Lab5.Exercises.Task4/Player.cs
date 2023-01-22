using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Player
    {
        /// <summary>
        /// Name of the team that the player is in
        /// </summary>
        public string TeamName { get; set; }
        /// <summary>
        /// Name of the player
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Surname of the player
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Player's birthdate
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Ammount of time the player has played
        /// </summary>
        public int Plays { get; set; }
        /// <summary>
        /// Total score that the player has got
        /// </summary>
        public int Score { get; set; }

        public Player(string teamName, string name, string surname, DateTime birthDate, int plays, int score)
        {
            this.TeamName = teamName;
            this.Name = name;
            this.Surname = surname;
            this.BirthDate = birthDate;
            this.Plays = plays;
            this.Score = score;
        }
    }
}
