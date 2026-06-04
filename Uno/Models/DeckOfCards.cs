
namespace Uno.Models;

public class DeckOfCards
{
    private Stack<Card> _cards { get; set; }

    public DeckOfCards(List<Card> cards)
    {
        _cards = new Stack<Card>(cards);
    }

    public Card? ReturnOneCard()
    {
        if (_cards.Count == 0)
            return null;

        return _cards.Pop();
    }

    public List<Card> ReturnSevenCards()
    {
        var cards = new List<Card>();

        for (int i = 0; i < 7; i++)
        {
            if (_cards.Count == 0)
            {
                break;
            }
            cards.Add(_cards.Pop());

        }
        return cards;
    }
}