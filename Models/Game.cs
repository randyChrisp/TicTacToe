using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class Game
    {
        public Player X { get; set; }
        public Player O { get; set; }
        public string CurrentPlayer { get; set; }

        public bool IsGameOver = false;
    }
}
