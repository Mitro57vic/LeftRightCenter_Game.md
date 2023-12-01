using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA_320
{
    internal class CLI
    {
        public List<Player> RetrievePlayerData()
        {

            List<Player> Playerlist = new List<Player>();
            do
            {
                Console.WriteLine("Geben Sie einen Namen ein.");
                string name = Console.ReadLine();
                Playerlist.Add(new Player(name));

            } while (DecisionMorePlayers());



            return Playerlist;
        }


        public bool DecisionMorePlayers()
        {

            Console.WriteLine("Möchten Sie noch einen Speieler hinzufügen?");
            Console.WriteLine("Ja oder Nein");

            bool again;
            string NewPlayer = Console.ReadLine();

            if (NewPlayer.ToLower() == "ja")
            {
                again = true;
                return again;
            }

            else if (NewPlayer.ToLower() == "nein")
            {
                again = false;
                return again;
            }

            else
            {
                again = false;
                return again;
            }


        }
        public void PrintStatus(List<Player> players)
        {

            Console.WriteLine("### Punktestand: ###");

            foreach (var spiel in players)
            {
                Console.WriteLine(spiel.PrintNameAndChips());
            }

            Console.WriteLine("### Ende der Runde ###");

        }
        public void PrintWinner(List<Player> players)
        {
            Player winner = null;

            foreach (var spiel in players)
            {
                if (spiel.HasChipsLeft == true)
                {
                    winner = spiel;
                }
            }
            Console.WriteLine(" Der Gewinner ist " + winner.Name);
        }
    }
}
    
  
