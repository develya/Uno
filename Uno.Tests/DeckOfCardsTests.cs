using Uno.Models;

namespace Uno.Tests;

public class DeckOfCardsTests
{
    [Fact]
    public void Deck_ShouldReturnNull_When_ListIsEmpty()
    {
        var deck = new DeckOfCards(new List<Card>());
        var card = deck.ReturnOneCard();
        Assert.Null(card);
    }

    [Fact]
    public void Deck_ShouldReturnCard_When_ListIsNotEmpty()
    {
        var deck = new DeckOfCards([new Card()]);
        var card = deck.ReturnOneCard();
        Assert.NotNull(card);
    }

    [Fact]

    public void Deck_ShouldReturnSevenCards()
    {
        var cards = new List<Card>();

        for (int i = 0; i < 10; i++)
        {
             cards.Add(new Card());
        }
        var desk = new DeckOfCards(cards);
        var result  = desk.ReturnSevenCards();
        Assert.Equal(7, result.Count);
    }
}