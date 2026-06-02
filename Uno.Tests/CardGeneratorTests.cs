using Uno.Methods;
using Uno.Models;

namespace Uno.Tests;

public class CardGeneratorTests
{
    [Fact]
    public void Generator_ShouldCreateCardsFrom0To9()
    {
        var generator = new CardGenerator();

        var cards = generator.GenerateCards();

        for (int i = 0; i <= 9; i++)
        {
            Assert.Contains(cards, x => x.NumberOfCard == i);
        }
    }

    [Fact]
    public void Generator_ShouldCreateReverseCards()
    {
        var generator = new CardGenerator();
        var cards = generator.GenerateCards();
        var reverseCards = cards.Count(x => x.SpecialType == SpecialCard.Reverse);
        Assert.Equal(4, reverseCards);
    }

    [Fact]
    public void Generator_ShouldCreateSkipCards()
    {
        var generator = new CardGenerator();
        var cards = generator.GenerateCards();
        var skipCards = cards.Count(x => x.SpecialType == SpecialCard.SkipTurn);
        Assert.Equal(4, skipCards);
    }

    [Fact]
    public void Generator_ShouldCreateChangeColorCards()
    {
        var generator = new CardGenerator();
        var cards = generator.GenerateCards();
        var changedColorCards = cards.Count(x => x.SpecialType == SpecialCard.ChangeColor);
        Assert.Equal(4, changedColorCards);
    }

    [Fact]
    public void Generator_ShouldCreatePlusFourCards()
    {
        var generator = new CardGenerator();
        var cards = generator.GenerateCards();
        var plusFour = cards.Count(x => x.SpecialType == SpecialCard.ChangeColorPlusFour);
        Assert.Equal(4, plusFour);
    }

    [Fact]
    public void Generator_ShouldCreateAllCards()
    {
        var generator = new CardGenerator();
        var cards = generator.GenerateCards();
        Assert.NotEmpty(cards);
    }
}