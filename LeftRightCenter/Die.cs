using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA_320
{
    internal class Die
    {
        private const int MAX_NUMBER = 6;
        private Random _random;
        private int _lastValue;
        public int LastValue { get; set; }

        public void Roll()
        {
            LastValue = _random.Next(1, MAX_NUMBER);
        }
        public Die()
        {
            _random = new Random();
        }

    }
}

