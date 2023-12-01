using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA_320
{
    internal class DiceCup
    {
        private List<Die> _dice = new List<Die>();
        private const int NUM_DICE = 3;

        public DiceCup()
        {
            InitializeDice();
        }

        private void InitializeDice()
        {
            for (int i = 0; i < NUM_DICE; i++)
            {
                _dice.Add(new Die());
            }
        }

        public void Shake()
        {
            foreach (var die in _dice)
            {
                die.Roll();
            }
        }

        public List<int> GetValues()
        {
            List<int> values = new List<int>();

            foreach (var die in _dice)
            {
                values.Add(die.LastValue);
            }

            return values;
        }
    }
}
