using DeckOfCardsMVCApp.Enums;

namespace DeckOfCardsMVCApp.Models;

public sealed class Deck
{
    private const int CountOfCards = 52;
    private Card[] _cards;
    private int _currentCardIndex;
    private readonly Random _randomNumberGen;
    
    private static Deck instance = null;
    public static Deck GetInstance
    {
        get
        {
            if (instance == null)
                instance = new Deck();
            return instance;
        }
    }
    
    private Deck()
    {
        _cards = new Card[CountOfCards];
        _randomNumberGen = new Random();
        SetupGame();
    }

    public Card[] Cards()
    {
        return _cards;
    }

    public string? DealOneCard()
    {
        return _currentCardIndex == 52 ? null : _cards[_currentCardIndex++].ToString();
    }

    public void Shuffle()
    {
        for (var i = 0; i < CardsCountInDeck(); i++)
        {
            var randomIndex = _randomNumberGen.Next(0, CardsCountInDeck());

            (_cards[i], _cards[randomIndex]) = (_cards[randomIndex], _cards[i]);
        }
    }

    public void Restart()
    {
        SetupGame();
    }

    private void SetupGame()
    {
        _currentCardIndex = 0;
        var index = 0;
        for (var i = 0; i < Enum.GetNames(typeof(Suits)).Length; i++)
        {
            for (var j = 0; j < Enum.GetNames(typeof(Ranks)).Length; j++)
            {
                _cards[index++] = new Card((Suits)i, (Ranks)j);
            }
        }

        Shuffle();
    }

    public int CardsCountInDeck()
    {
        return CountOfCards - _currentCardIndex;
    }
}