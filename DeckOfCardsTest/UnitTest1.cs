using DeckOfCardsMVCApp.Models;

namespace DeckOfCardsTest;

public class Tests
{
    public Deck deck = Deck.GetInstance;

    [Test]
    public void Test_DeckInstanceCount_Return52()
    {
        var cardsCount = deck.CardsCountInDeck();
        Assert.That(cardsCount, Is.EqualTo(52));
    }

    [Test]
    public void Test_Shuffle_Gets_Different_Deck()
    {
        var isDifferent = false;

        Deck newDeckInstance = Deck.GetInstance;

        newDeckInstance.Shuffle();

        for (var i = 0; i < deck.CardsCountInDeck(); i++)
        {
            if (deck.Cards()[i].GetSuit() != newDeckInstance.Cards()[i].GetSuit() ||
                deck.Cards()[i].GetRank() != newDeckInstance.Cards()[i].GetRank())
            {
                //At least one true statement shows that deck is shuffled
                isDifferent = true;
                break;
            }
        }

        //If this test passes, then newDeck is different than previous deck
        Assert.That(isDifferent, Is.True);
    }
}