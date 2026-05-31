using System.Runtime.InteropServices.JavaScript;

namespace Uno.Models;

public class DeckOfCards
{
    private List<Card> _cards { get; set; }

    public DeckOfCards(List<Card> cards)
    {
         _cards = cards;
    }

    public Card? ReturnOneCard() => _cards.FirstOrDefault();

    public List<Card> ReturnSevenCards()
    {
        var cards = new List<Card>();

        for (int i = 0; i < 7; i++)
        {
            cards.Add(_cards[i]);

        }
        return cards;
    }
}