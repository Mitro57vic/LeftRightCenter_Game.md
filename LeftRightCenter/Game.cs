using System;
using System.Collections.Generic;

namespace OBA_320
{
    internal class Game
    {
        private Player _currentPlayer;
        private List<Player> _playerList = new List<Player>();
        private CLI _cli = new CLI();
        private DiceCup _dicecup;

        public Game()
        {
            _playerList = _cli.RetrievePlayerData();
            SetStartPlayer();
            play();
        }

        public void play()
        {
            do
            {
                ProcessDiceRoll(_currentPlayer.DiceRoll(_dicecup));
                _currentPlayer = PlayerToTheRight();

                if (MoreThanOnePlayerHasChips() == true)
                {
                    _cli.PrintStatus(_playerList);
                }
                else
                {
                    _cli.PrintWinner(_playerList);
                    break;
                }
            } while (true);
        }

        public void ProcessDiceRoll(List<int> diceValues)
        {
            foreach (var value in diceValues)
            {
                if (value == 4)
                {
                    PassChipToTheLeft();
                }
                else if (value == 5)
                {
                    PassChipToTheRight();
                }
                else if (value == 6)
                {
                    PlaceChipInPot();
                }
                else
                {
                    // Chip wird behalten (nichts passiert)
                }
            }
        }

        public void SetStartPlayer()
        {
            Random auswahl = new Random();
            int wähle = auswahl.Next(_playerList.Count);
            _currentPlayer = _playerList[wähle];
        }


        public Player PlayerToTheRight()
        {
            int index = _playerList.IndexOf(_currentPlayer) + 1;

            if (index >= _playerList.Count)
            {
                index = 0;
            }

            return _playerList[index];
        }



        public Player PlayerToTheLeft()
        {
            int index = _playerList.IndexOf(_currentPlayer) - 1;

            if (index < 0)
            {
                index = _playerList.Count - 1;
            }

            return _playerList[index];
        }


        public bool MoreThanOnePlayerHasChips()
        {
            int gespeicherteSpieler = _playerList.Count;

            foreach (var spieler in _playerList)
            {
                if (!spieler.HasChipsLeft)
                {
                    gespeicherteSpieler--;
                }
            }

            return gespeicherteSpieler > 1;
        }

        public void PassChipToTheLeft()
        {
            _currentPlayer.PassOnChip();
            PlayerToTheLeft().ReceiveChip();
        }

        public void PassChipToTheRight()
        {
            _currentPlayer.PassOnChip();
            PlayerToTheRight().ReceiveChip();
        }

        public void PlaceChipInPot()
        {
            _currentPlayer.PassOnChip();
        }
    }
}
