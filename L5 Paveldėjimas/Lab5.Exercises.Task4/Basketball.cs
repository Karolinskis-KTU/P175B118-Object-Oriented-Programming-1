using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Basketball : Player
    {
        /// <summary>
        /// Successful rebounds by player
        /// </summary>
        public int Rebounds { get; set; }
        /// <summary>
        /// Sucessful pass that resuled in a getting points
        /// </summary>
        public int Assists { get; set; }

        public Basketball(string teamName, string name, string surname, DateTime birthDate, int plays, int score, int rebounds, int assists) :base(teamName, name, surname, birthDate, plays, score)
        {
            this.Rebounds = rebounds;
            this.Assists = assists;
        }

        public override string ToString()
        {
            return String.Format("| {0,-20} | {1, -15} | {2,10} | {3, -12} | {4, -25} | {5, -22} | Atkovotų kamuolių skaičius:{6} Rezultatyvių perdavimų skaičius:{7} ", TeamName, Name, Surname, BirthDate.ToString("yyyy-MM-dd"), Plays, Score, Rebounds, Assists);
        }
    }
}
