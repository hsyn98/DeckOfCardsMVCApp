using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DeckOfCardsMVCApp.Models;

namespace DeckOfCardsMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly Deck _deck;

        public HomeController()
        {
            _deck = Deck.GetInstance;
        }

        public IActionResult Index()
        {
            return View();
        }

        public Task<JsonResult> DealOneCard()
        {
            var card = _deck.DealOneCard();
            var cardCount = _deck.CardsCountInDeck();

            return Task.FromResult(Json(new {card, cardCount}));
        }
        
        public Task<JsonResult> Shuffle()
        {
            _deck.Shuffle();
            
            return Task.FromResult(Json("Ok"));
        }
        
        public Task<JsonResult> Restart()
        {
            _deck.Restart();
            
            return Task.FromResult(Json("Ok"));
        }
    }
}