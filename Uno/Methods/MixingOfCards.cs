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
        Random random = new();

        for (int i = _cards.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);

            var temp = _cards[i];

            _cards[i] = _cards[j];

            _cards[j] = temp;
        }

        return _cards;
    }
}