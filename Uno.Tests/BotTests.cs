using Uno.Models;

namespace Uno.Tests;

public class BotTests
{
    [Fact]
    public void Bot_ShouldPlayCard_WhenCardMatches()
    {
        var card = new Card { Color = Color.Red, NumberOfCard = 1, };
        var player = new Player { Cards = new List<Card> { card } };
        var bot = new Bot(player);
        var deck = new DeckOfCards(new List<Card>());
        var topCard = new Card { Color = Color.Red, NumberOfCard = 5 };
        var result = bot.ChooseCard(topCard, deck);
        Assert.Equal(card, result);
        Assert.Empty(player.Cards);
    }

    [Fact]
    public void Bot_ShouldReturnNull_WhenNoCardsCanBePlayed()
    {
        var player = new Player { Cards = new List<Card>() };
        var bot = new Bot(player);
        var deck = new DeckOfCards(
            new List<Card> { new Card { Color = Color.Green, NumberOfCard = 9 }, }
        );
        var topCard = new Card { Color = Color.Red, NumberOfCard = 5 };
        var result = bot.ChooseCard(topCard, deck);
        Assert.Null(result);
        Assert.Single(player.Cards);
    }
}