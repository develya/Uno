using Uno.Methods;
using Uno.Models;

namespace Uno.Tests;

public class GameRulesTests
{
    [Fact]
    public void CanPlay_ShouldReturnTrue_WhenColorsAreTheSame()
    {
         var rules = new GameRules();

         var playedCard = new Card { Color = Color.Blue, NumberOfCard = 1 };
         var topCard = new Card { Color = Color.Blue, NumberOfCard = 2 };
         var result = rules.CanPlay(playedCard, topCard, null);
         Assert.True(result);
    }

    [Fact]
    public void CanPlay_ShouldReturnTrue_WhenNumbersAreTheSame()
    {
        var rules = new GameRules();
        var playedCard = new Card { Color = Color.Blue, NumberOfCard = 1 };
        var topCard = new Card { Color = Color.Red, NumberOfCard = 1 };
        var result = rules.CanPlay(playedCard, topCard, null);
        Assert.True(result);
    }

    [Fact]
    public void CanPlay_ShouldReturnFalse_WhenNothingIsTheSame()
    {
        var rules = new GameRules();
        var playedCard = new Card { Color = Color.Blue, NumberOfCard = 2 };
        var topCard = new Card { Color = Color.Red, NumberOfCard = 1 };
        var result = rules.CanPlay(playedCard, topCard, null);
        Assert.False(result);
    }
}