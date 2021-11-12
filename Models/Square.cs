using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class Square
    {
        public string SquareId { get; set; }
        public string PlayerTurn { get; set; }

        public bool IsEmpty => string.IsNullOrEmpty(PlayerTurn);
        public bool IsRightSquare => SquareId.EndsWith("rightCol");
    }
}
