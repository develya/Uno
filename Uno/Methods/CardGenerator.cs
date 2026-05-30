using Uno.Models;

namespace Uno.Methods;

public class CardGenerator
{
    public List<Card> GenerateCards()
    {
        var cards = new List<Card>();

        foreach (Color color in Enum.GetValues<Color>())
        {
            CreateSimpleCards(cards, color);
        }

        return cards;
    }

    private void CreateSimpleCards(List<Card> cards, Color color)
    {
        for (int i = 0; i <= 9; i++)
        {
            var card = new Card();

            card.Color = color;
            card.NumberOfCard = i;
            cards.Add(card);
        }
    }
}