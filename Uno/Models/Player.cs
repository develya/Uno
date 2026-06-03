namespace Uno.Models;

public class Player
{
    public string Name { get; set; }
    public List<Card> Cards { get; set; }

    public void TakeCard(Card card)
    {
        Cards.Add(card);
    }

    public void TakeCards(List<Card> cards)
    {
        Cards.AddRange(cards);
    }

    public Card? PutCard(Card card)
    {
        if (!Cards.Contains(card))
            return null;
        Cards.Remove(card);

        return card;
    }


}