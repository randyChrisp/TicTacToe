using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class Game
    {
        public Game()
        {
            string[] rows = new string[] { "topRow", "midRow", "bottomRow" };
            string[] columns = new string[] { "leftCol", "midCol", "rightCol" };

            squares = new List<Square>();

            foreach (string row in rows)
            {
                foreach (string col in columns)
                {
                    Square square = new Square { SquareId = row + col };
                    squares.Add(square);
                }
            }
        }

        public List<Square> squares { get; set; }

        //public List<Square> GetSquares() => squares;

        public bool HaveWinner { get; set; }

        public string Winner { get; set; }

        public bool IsTieGame { get; set; }

        public void DetermineWinner()
        {
            HaveWinner = false;
            Winner = null;

            if (WinnerMethod(0,1,2))
            {
                HaveWinner = true;
            }
            else if (WinnerMethod(3,4,5))
            {
                HaveWinner = true;
            }
            else if (WinnerMethod(6,7,8))
            {
                HaveWinner = true;
            }
            else if (WinnerMethod(0,3,6))
            {
                HaveWinner = true;
            }
            else if (WinnerMethod(1,4,7))
            {
                HaveWinner = true;
            }
            else if (WinnerMethod(2,5,8))
            {
                HaveWinner = true;
            }
            else if (WinnerMethod(0,4,8))
            {
                HaveWinner = true;
            }
            else if (WinnerMethod(2,4,6))
            {
                HaveWinner = true;
            } else
            {
                HaveWinner = false;
            }

            IsTieGame = true;

            foreach (Square square in squares)
            {
                if(square.IsEmpty)
                {
                    IsTieGame = false;
                    return;
                }
            }

        }

        private bool WinnerMethod(int xo1, int xo2, int xo3)
        {
            if(squares[xo1].PlayerTurn == squares[xo2].PlayerTurn && squares[xo1].PlayerTurn == squares[xo3].PlayerTurn)
            {
                Winner = squares[xo1].PlayerTurn;
                return true;
            }

            Winner = null;
            return false;
        }

    }
}
