using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace MvcAssagnment1.Controllers
{
    public class GameController : Controller
    {
        private const string SessionKeyNumber = "_Number";
        private const string SessionKeyGuessCount = "_GuessCount";
        private const int MinNumber = 1;
        private const int MaxNumber = 100;

        [HttpGet]
        public IActionResult GuessingGame()
        {
            // Generate a new random number and reset the guess count
            HttpContext.Session.SetInt32(SessionKeyNumber, new Random().Next(MinNumber, MaxNumber + 1));
            HttpContext.Session.SetInt32(SessionKeyGuessCount, 0);
            ViewBag.Message = "Try to guess the number between 1 and 100!";
            return View();
        }

        [HttpPost]
        public IActionResult GuessingGame(int? guess)
        {
            if (!guess.HasValue)
            {
                ViewBag.Message = "Please enter a valid number.";
                return View();
            }

            int number = HttpContext.Session.GetInt32(SessionKeyNumber) ?? new Random().Next(MinNumber, MaxNumber + 1);
            int guessCount = HttpContext.Session.GetInt32(SessionKeyGuessCount) ?? 0;
            guessCount++;
            HttpContext.Session.SetInt32(SessionKeyGuessCount, guessCount);

            if (guess.Value == number)
            {
                ViewBag.Message = $"Congratulations! You've guessed the number {number} in {guessCount} attempts.";
                // Reset the game
                HttpContext.Session.SetInt32(SessionKeyNumber, new Random().Next(MinNumber, MaxNumber + 1));
                HttpContext.Session.SetInt32(SessionKeyGuessCount, 0);
            }
            else if (guess.Value < number)
            {
                ViewBag.Message = "Too low! Try again.";
            }
            else
            {
                ViewBag.Message = "Too high! Try again.";
            }

            ViewBag.GuessCount = guessCount;
            return View();
        }
    }
}
