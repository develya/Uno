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
}