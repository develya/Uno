using Uno.Methods;
using Uno.Models;

namespace Uno.Tests;

public class CardGeneratorTests
{
    [Fact]
    public void Generator_ShouldCreateCardsFrom0To9()
    {
        var generator = new CardGenerator(new List<Card>());

        var cards = generator.GenerateCards();

        for (int i = 0; i <= 9; i++)
        {
            Assert.Contains(cards, x => x.NumberOfCard == i);
        }
    }


}