using Uno.Models;

namespace Uno.Methods;

public class CardGenerator
{
    public List<Card> GenerateCards()
    {
        var cards = new List<Card>();

        foreach (Color color in Enum.GetValues<Color>())
        {
            cards.AddRange();CreateSimpleCards(cards, color);
            cards.AddRange(CreateSpecialCards(color));
        }
        cards.AddRange(CreateChangedColorCards());
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

    private List<Card> CreateSpecialCards(Color color)
    {
        var cards = new List<Card>();
        cards.Add(new Card { Color = color, SpecialType = SpecialCard.Reverse });
        cards.Add(new Card { Color = color, SpecialType = SpecialCard.SkipTurn });
        return cards;
    }

    private List<Card> CreateChangedColorCards()
    {
        var cards = new List<Card>();
        for (int i = 0; i < 4; i++)
        {
            cards.Add(new Card { SpecialType = SpecialCard.ChangeColor, });
            cards.Add(new Card { SpecialType = SpecialCard.ChangeColorPlusFour, });
            cards.Add(new Card { SpecialType = SpecialCard.PlusTwo, });
        }
        return cards;
    }
}
