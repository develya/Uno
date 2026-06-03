using Uno.Models;

namespace Uno.Methods;

public class MixingOfCards
{
    private List<Card> _cards { get; set; }

    public MixingOfCards(List<Card> cards)
    {
        _cards = cards;
    }

    public List<Card> Shuffle()
    {
        var shuffled = _cards.OrderBy(x => Random.Shared.Next()).ToList();

        return shuffled;
    }
}