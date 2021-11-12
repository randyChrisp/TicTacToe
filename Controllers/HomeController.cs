using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            Game board = new Game();
            List<Square> squares = board.squares;

            foreach (Square square in squares)
            {
                square.PlayerTurn = TempData[square.SquareId]?.ToString();
            }

            board.DetermineWinner();

            GameViewModel model = new GameViewModel
            {
                Squares = squares,
                WhoseTurn = new Square { PlayerTurn = TempData["thisTurn"]?.ToString()?? "X"},
                IsGameOver = board.HaveWinner || board.IsTieGame
            };

            if (model.IsGameOver)
            {
                TempData["thisTurn"] = "X";
                TempData["message"] = board.HaveWinner ? board.Winner + " wins!" : "It's a tie!";
            }
            else
            {
                TempData.Keep();
            }

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Index(GameViewModel gameView)
        {
            TempData[gameView.WhoseTurn.SquareId] = gameView.WhoseTurn.PlayerTurn;
            TempData["thisTurn"] = gameView.WhoseTurn.PlayerTurn == "X" ? "O" : "X";

            return RedirectToAction("Index");
        }
    }
}
