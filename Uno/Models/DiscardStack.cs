namespace Uno.Models;

public class DiscardStack
{
    private List<Card> _cards { get; set; }

    public DiscardStack(List<Card> cards)
    {
        _cards = cards;
    }

    public void AddCard(Card card)
    {
        _cards.Add(card);
    }

    public Card? GetTopCard()
    {
        return _cards.LastOrDefault();
    }

}