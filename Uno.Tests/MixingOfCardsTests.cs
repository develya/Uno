using Uno.Methods;
using Uno.Models;

namespace Uno.Tests;

public class MixingOfCardsTests
{
    [Fact]
    public void Shuffle_ShouldReturnList()
    {
        var cards = new List<Card>
        {
            new()
        };
            var mix = new MixingOfCards(cards);
            var shuffled = mix.Shuffle();
            Assert.NotNull(shuffled);
    }
}