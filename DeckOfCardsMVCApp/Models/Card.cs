using DeckOfCardsMVCApp.Enums;

namespace DeckOfCardsMVCApp.Models;

public class Card
{
    private Suits _suit;
    private Ranks _rank;

    public Card(Suits suit, Ranks rank)
    {
        _suit = suit;
        _rank = rank;
    }

    public Suits GetSuit()
    {
        return _suit;
    }

    public Ranks GetRank()
    {
        return _rank;
    }

    public override string ToString()
    {
        return _suit + " " + _rank;
    }
}