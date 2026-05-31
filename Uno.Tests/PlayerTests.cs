using Uno.Models;

namespace Uno.Tests;

public class PlayerTests
{
    [Fact]
    public void Player_ShouldTakeOneCard()
    {
        var Player = new Player() { Cards = new List<Card>() };
        Player.TakeCard(new Card());
        Assert.Single(Player.Cards);
    }

    [Fact]
    public void Player_ShouldTakeManyCards()
    {
        var Player = new Player() { Cards = new List<Card>() };
        var cards = new List<Card>
        {
            new Card(),
            new Card(),
            new Card(),
            new Card(),
            new Card(),
            new Card(),
            new Card(),
        };
        Player.TakeCards(cards);
        Assert.Equal(7, Player.Cards.Count);
    }

    [Fact]
    public void Player_ShouldReturnNullIfNoCards()
    {
        var Player = new Player { Cards = new List<Card>() };
        var result = Player.PutCard(new Card());
        Assert.Null(result);
    }

    [Fact]
    public void Player_ShouldPutCard()
    {
        var card = new Card();
        var Player = new Player() { Cards = new List<Card> { card } };
        var result = Player.PutCard(card);
        Assert.NotNull(result);
        Assert.Empty(Player.Cards);
    }
}