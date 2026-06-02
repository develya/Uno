using Uno.Models;

namespace Uno.Tests;

public class UnoTests
{
    [Fact]
    public void StartGame_ShouldGivePlayersSevenCards()
    {
        var players = new List<Player>
        {
            new Player { Cards = new List<Card>() }, new Player { Cards = new List<Card>() }
        };
        var game = new Models.Uno { Players = players };
        game.StartGame();
        Assert.Equal(7, players[0].Cards.Count);
        Assert.Equal(7, players[1].Cards.Count);

    }

    [Fact]
    public void PlayTurn_ShouldPutCard_WhenMoveAllowed()
    {
        var card = new Card { Color = Color.Blue, NumberOfCard = 1 };
        var player = new Player { Cards = new List<Card> { card } };
        var game = new Models.Uno
        {
            Players = new List<Player> { player },
            DiscardStack = new DiscardStack(
                new List<Card> { new Card { Color = Color.Red, NumberOfCard = 1 } })
        };
        var result = game.PlayTurn(player, card);
            Assert.True(result);
            Assert.Empty(player.Cards);

    }

}