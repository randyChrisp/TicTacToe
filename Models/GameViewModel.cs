using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class GameViewModel
    {
        public List<Square>Squares { get; set; }
        public Square WhoseTurn { get; set; }
        public bool IsGameOver { get; set; }
    }
}
