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
            new(),
            new(),
            new(),
            new()
        };
            var original = cards.Count;
            var mix = new MixingOfCards(cards);
            var shuffled = mix.Shuffle();
            Assert.NotNull(shuffled);
            Assert.Equal(original , shuffled.Count);
    }
}