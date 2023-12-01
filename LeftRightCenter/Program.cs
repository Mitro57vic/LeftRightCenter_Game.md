using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA_320
{
    internal class Program
    {
        static void Main(string[] args)

        {
            Game game = new Game();
            game.play();
            Console.WriteLine("Drücke Enter, um das Programm zu beenden.");
            Console.ReadLine();
        }
    }
}
        

   