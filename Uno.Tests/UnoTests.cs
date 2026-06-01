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
}