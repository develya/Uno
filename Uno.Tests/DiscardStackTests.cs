using Uno.Models;

namespace Uno.Tests;

public class DiscardStackTests
{
    [Fact]

    public void DiscardStack_ShouldAddCard()
    {
        var cards = new List<Card>();
        var stack = new DiscardStack(cards);
        var card = new Card();
        stack.AddCard(card);
        var result = stack.GetTopCard();
        Assert.Equal(card, result);
    }

    [Fact]
    public void DiscardStack_ShouldReturnTopCard()
    {
        var firstCard = new Card { NumberOfCard = 1 };
        var secondCard = new Card { NumberOfCard = 2 };
        var cards = new List<Card> { firstCard, secondCard };
        var stack = new DiscardStack(cards);
        var result = stack.GetTopCard();
        Assert.Equal(secondCard, result);
    }

    [Fact]
    public void DiscardStack_ShouldReturnNull_WhenEmpty()
    {
        var stack = new DiscardStack(new List<Card>());
        var result = stack.GetTopCard();
        Assert.Null(result);
    }
}