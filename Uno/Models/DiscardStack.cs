namespace Uno.Models;

public class DiscardStack
{
    private Stack<Card> _cards { get; set; }

    public DiscardStack(List<Card> cards)
    {
        _cards = new Stack<Card>(cards);
    }

    public void AddCard(Card card)
    {
        _cards.Push(card);
    }

    public Card? GetTopCard()
    {
        if (_cards.Count == 0)
            return null;
        return _cards.Peek();
    }

}