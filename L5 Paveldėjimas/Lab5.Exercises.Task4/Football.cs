using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Football : Player
    {
        /// <summary>
        /// Yellow cards issued to player
        /// </summary>
        public int YellowCards { get; set; }

        public Football(string teamName, string name, string surname, DateTime birthDate, int plays, int score, int yellowCards) :base(teamName, name, surname, birthDate, plays, score)
        {
            this.YellowCards = yellowCards;
        }

        public override string ToString()
        {
            return String.Format("| {0,-20} | {1, -15} | {2,10} | {3, -12} | {4, -25} | {5, -22} | Surinktų geltonų kortelių skaičius:{6}", TeamName, Name, Surname, BirthDate.ToString("yyyy-MM-dd"), Plays, Score, YellowCards);
        }
    }
}
